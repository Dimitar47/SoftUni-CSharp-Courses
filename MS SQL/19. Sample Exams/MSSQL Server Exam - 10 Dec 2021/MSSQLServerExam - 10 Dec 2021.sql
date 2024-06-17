--Databases MSSQL Server Retake Exam - 10 Dec 2021

--1

CREATE TABLE Passengers(
Id INT PRIMARY KEY IDENTITY(1,1),
FullName VARCHAR(100) UNIQUE NOT NULL,
Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(30) UNIQUE NOT NULL,
LastName VARCHAR(30) UNIQUE NOT NULL,
Age TINYINT NOT NULL CHECK (Age BETWEEN 21 AND 62),
Rating FLOAT CHECK(Rating BETWEEN 0.0 AND 10.00)
)

CREATE TABLE AircraftTypes(
Id INT PRIMARY KEY IDENTITY(1,1),
TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft(
Id INT PRIMARY KEY IDENTITY(1,1),
Manufacturer VARCHAR(25) NOT NULL,
Model VARCHAR(30) NOT NULL,
[Year] INT NOT NULL,
FlightHours INT,
Condition CHAR(1) NOT NULL,
TypeId INT NOT NULL FOREIGN KEY REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft(
AircraftId INT NOT NULL,
PilotId INT NOT NULL,
CONSTRAINT PK_PilotsAircraft PRIMARY KEY(AircraftId,PilotId),
CONSTRAINT FK_AircraftId FOREIGN KEY (AircraftId)  REFERENCES Aircraft(Id),
CONSTRAINT FK_PilotId FOREIGN KEY(PilotId) REFERENCES Pilots(Id)
)

CREATE TABLE Airports(
Id INT PRIMARY KEY IDENTITY(1,1),
AirportName VARCHAR(70) UNIQUE NOT NULL,
Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations(
Id INT PRIMARY KEY IDENTITY(1,1),
AirportId INT NOT NULL FOREIGN KEY REFERENCES Airports(Id),
[Start] DATETIME NOT NULL,
AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
TicketPrice DECIMAL(18,2) NOT NULL  DEFAULT (15)
)

--2
INSERT INTO Passengers(FullName, Email)
SELECT CONCAT_WS(' ',p.FirstName,p.LastName) ,
CONCAT(p.FirstName,p.LastName,'@gmail.com')
FROM Pilots AS p
WHERE p.Id BETWEEN 5  AND 15;

--3
UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C','B') AND (FlightHours IS NULL OR FlightHours<=100) AND [Year]>=2013


--4
DELETE FROM Passengers WHERE LEN(FullName)<=10


--5
SELECT Manufacturer,
Model,	
FlightHours,
Condition 
FROM Aircraft 
ORDER BY FlightHours DESC

--6
SELECT 
pil.FirstName, pil.LastName,
a.Manufacturer, a.Model, a.FlightHours
FROM Pilots AS pil
JOIN PilotsAircraft AS pa ON pa.PilotId = pil.Id
JOIN Aircraft AS a ON pa.AircraftId = a.Id
WHERE a.Id IS NOT NULL and a.FlightHours<304
ORDER BY a.FlightHours DESC,pil.FirstName ASC

--7
SELECT  TOP 20
fd.Id AS DestinationId,
fd.[Start],
p.FullName,
 ai.AirportName,
 fd.TicketPrice 
 FROM FlightDestinations AS fd
 JOIN Passengers AS p ON fd.PassengerId = p.Id
 JOIN Airports AS ai ON fd.AirportId = ai.Id
 WHERE DAY([Start]) %2=0
 ORDER BY fd.TicketPrice DESC, ai.AirportName ASC
 
 --8
 SELECT ai.Id AS AircraftId,
ai.Manufacturer,
ai.FlightHours,
COUNT(fd.Id) AS FlightDestinationsCount,
ROUND(AVG(fd.TicketPrice),2) AS AvgPrice
 FROM FlightDestinations AS fd
 JOIN Aircraft AS ai ON fd.AircraftId = ai.Id
 GROUP BY ai.Id,ai.Manufacturer,ai.FlightHours
 HAVING COUNT(fd.Id)>=2
 ORDER BY FlightDestinationsCount DESC, AircraftId ASC


 --9
 SELECT 
 p.FullName,
 COUNT(*) AS CountOfAircraft,	
 SUM(fd.TicketPrice) AS TotalPayed
 FROM Passengers AS p
 JOIN FlightDestinations AS fd ON fd.PassengerId = p.Id
 JOIN Aircraft AS ai ON fd.AircraftId = ai.Id
 GROUP BY p.FullName
 HAVING COUNT(ai.Id) >1 AND SUBSTRING(p.FullName,2,1)='a'
 ORDER BY p.FullName
 

 --10
SELECT ap.AirportName,
fd.[Start] AS DayTime,
fd.TicketPrice,
p.FullName,
ac.Manufacturer,
ac.Model
FROM FlightDestinations AS fd
JOIN Airports AS ap ON fd.AirportId = ap.Id
JOIN Passengers AS p ON fd.PassengerId = p.Id
JOIN Aircraft AS ac ON fd.AircraftId = ac.Id
WHERE (DATEPART(HOUR,fd.[Start]) BETWEEN 6 AND 20) AND fd.TicketPrice>2500
ORDER BY ac.Model ASC

--11
GO
CREATE OR ALTER FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(100))
RETURNS INT
AS
BEGIN 
	DECLARE @countFlightsDestinations INT=
	(
	SELECT COUNT(*) FROM FlightDestinations AS fd
	JOIN Passengers AS p ON fd.PassengerId = p.Id
	WHERE p.Email = @email
	)
	RETURN @countFlightsDestinations
	
END
GO
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')


--12
GO
CREATE OR ALTER PROCEDURE usp_SearchByAirportName (@airportName VARCHAR(70))
AS
BEGIN 
SELECT ap.AirportName,
p.FullName,
CASE
	WHEN fd.TicketPrice<=400 THEN 'Low'
	WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
	WHEN fd.TicketPrice >=1501 THEN 'High'
END AS LevelOfTickerPrice,
ac.Manufacturer,
ac.Condition,
[at].TypeName
FROM FlightDestinations AS fd
JOIN Airports AS ap ON fd.AirportId = ap.Id
JOIN Passengers AS p ON fd.PassengerId = p.Id
JOIN Aircraft AS ac ON fd.AircraftId = ac.Id
JOIN AircraftTypes AS [at] ON ac.TypeId = [at].Id  
WHERE ap.AirportName = @airportName
ORDER BY ac.Manufacturer, p.FullName
END
GO
EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'