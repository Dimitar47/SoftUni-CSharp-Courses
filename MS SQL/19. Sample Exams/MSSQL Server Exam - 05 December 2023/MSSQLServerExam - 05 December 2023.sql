--Databases MSSQL Server Retake Exam - 05 December 2023
--1
CREATE TABLE Passengers(
Id int PRIMARY KEY Identity(1,1),
[Name] nvarchar(80) NOT NULL
)
CREATE TABLE Towns(
Id int PRIMARY KEY Identity(1,1),
[Name] varchar(30) NOT NULL
)
CREATE  TABLE RailwayStations(
Id INT PRIMARY KEY Identity(1,1),
[Name] varchar(50) NOT NULL,
TownId int NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)
CREATE TABLE Trains(
Id int PRIMARY KEY IDENTITY(1,1),
HourOfDeparture varchar(5) NOT NULL,
HourOfArrival varchar(5) NOT NULL,
DepartureTownId int NOT NULL FOREIGN KEY REFERENCES Towns(Id),
ArrivalTownId int NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE TrainsRailwayStations(
TrainId INT NOT NULL,
RailwayStationId INT NOT NULL,
CONSTRAINT PK_TrainRailwayStation PRIMARY KEY(TrainId,RailwayStationId),
CONSTRAINT FK_Train FOREIGN KEY(TrainId) REFERENCES Trains(Id),
CONSTRAINT FK_RailWayStation FOREIGN KEY(RailWayStationId) REFERENCES RailwayStations(Id)
)

CREATE TABLE MaintenanceRecords(
Id int PRIMARY KEY Identity(1,1),
DateOfMaintenance date NOT NULL,
Details varchar(2000) NOT NULL,
TrainId int NOT NULL FOREIGN KEY REFERENCES Trains(Id)
)
CREATE TABLE Tickets(
Id int PRIMARY KEY IDENTITY(1,1),
Price DECIMAL(18,2) NOT NULL,
DateOfDeparture DATE NOT NULL,
DateOfArrival DATE NOT NULL,
TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id),
PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
)
--2
INSERT INTO Trains(HourOfDeparture,HourOfArrival,DepartureTownId,ArrivalTownId)
VALUES ('07:00','19:00',1,3),
('08:30','20:30',5,6),
('09:00','21:00',4,8),
('06:45','03:55',27,7),
('10:15','12:15',15,5)

INSERT INTO TrainsRailwayStations(TrainId,RailwayStationId)
VALUES (36,	1),
(36,4),
(36,31),
(36, 57),
(36, 7),
(37, 13),
(37, 54),

(37	,60),
(37, 16),
(38, 10),
(38, 50),
(38	,52),
(38	,22),
(39	,68),

(39	,3),
(39,	31),
(39	,19),
(40	,41),
(40	,7),
(40	,52),
(40	,13)

INSERT INTO Tickets(Price,DateOfDeparture,DateOfArrival,TrainId,PassengerId)
VALUES (90.00,	'2023-12-01',	'2023-12-01',	36	,1),
(115.00,	'2023-08-02',	'2023-08-02',	37,	2),
(160.00,	'2023-08-03',	'2023-08-03',	38,	3),
(255.00	,'2023-09-01',	'2023-09-02',	39	,21),
(95.00	,'2023-09-02',	'2023-09-03',	40	,22)

--3
UPDATE Tickets
SET DateOfArrival = DATEADD(WEEK,1,DateOfArrival), DateOfDeparture =DATEADD(WEEK,1,DateOfDeparture)
WHERE DateOfDeparture >'2023-10-31'

--4
DELETE FROM TrainsRailwayStations WHERE TrainId IN (SELECT tr.Id FROM Trains AS tr
JOIN Towns AS [to] ON [to].Id = tr.DepartureTownId
WHERE [to].[Name] = 'Berlin')
DELETE FROM MaintenanceRecords  WHERE TrainId IN (SELECT tr.Id FROM Trains AS tr
JOIN Towns AS [to] ON [to].Id = tr.DepartureTownId
WHERE [to].[Name] = 'Berlin')
DELETE FROM Tickets  WHERE TrainId IN (SELECT tr.Id FROM Trains AS tr
JOIN Towns AS [to] ON [to].Id = tr.DepartureTownId
WHERE [to].[Name] = 'Berlin')
DELETE FROM Trains
WHERE Id IN (SELECT tr.Id FROM Trains AS tr
JOIN Towns AS [to] ON [to].Id = tr.DepartureTownId
WHERE [to].[Name] = 'Berlin')


--5
SELECT t.DateOfDeparture AS DateOfDeparture, t.Price AS TicketPrice FROM Tickets AS t
ORDER BY t.Price ASC,t.DateOfDeparture DESC

--6
SELECT p.[Name] AS PassengerName,
t.Price AS TicketPrice,
t.DateOfDeparture AS DateOfDeparture,
t.TrainId AS TrainID
FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
ORDER BY t.[Price] DESC, PassengerName ASC

--7
SELECT t.[Name] AS Town,
rs.[Name] AS RailwayStation
FROM RailwayStations AS rs
LEFT JOIN TrainsRailwayStations AS trs ON trs.RailwayStationId = rs.Id
LEFT JOIN Trains AS tr ON tr.Id = trs.TrainId
LEFT JOIN Towns AS t ON t.Id = rs.TownId
WHERE tr.ArrivalTownId is NULL and tr.DepartureTownId is NULL
ORDER BY t.[Name] ASC, rs.[Name] ASC


--8

SELECT TOP(3)
tr.Id AS TrainId,
tr.HourOfDeparture AS HourOfDeparture,
tick.Price AS TicketPrice,
t.[Name] AS Destination
FROM Trains AS tr
JOIN Towns AS t ON t.Id = tr.ArrivalTownId
JOIN Tickets AS tick ON tick.TrainId = tr.Id
WHERE tick.Price>50 AND tr.HourOfDeparture LIKE '08:%'
ORDER BY tick.Price ASC

--9

SELECT t.[Name] AS TownName,
Count(*) AS PassengersCount FROM Passengers AS p
JOIN Tickets AS tick ON tick.PassengerId = p.Id
JOIN Trains AS tr ON tr.Id = tick.TrainId
JOIN Towns AS t ON t.Id = tr.ArrivalTownId
WHERE tick.Price > 76.99
GROUP BY t.[Name]
ORDER BY TownName


--10
SELECT tr.Id AS TrainID,
t.[Name] AS DepartureTown,
mr.Details AS Details
FROM MaintenanceRecords AS mr
 JOIN Trains AS tr ON mr.TrainId = tr.Id
 JOIN Towns AS t ON t.Id = tr.DepartureTownId
WHERE Details LIKE '%inspection%' 
ORDER BY TrainID

--11
CREATE OR ALTER FUNCTION udf_TownsWithTrains(@name VARCHAR(255))
RETURNS INT
AS
BEGIN
DECLARE @townId int = (SELECT t.Id FROM Towns AS t
where t.[Name] = @name)
DECLARE @trainsCount int=(
SELECT COUNT(*) FROM Trains AS tr
JOIN Towns AS t On t.Id = tr.ArrivalTownId OR t.Id = tr.DepartureTownId
WHERE t.[Name] = @name)
RETURN @trainsCount
END

SELECT dbo.udf_TownsWithTrains('Paris')

--12
CREATE OR ALTER PROCEDURE usp_SearchByTown(@townName VARCHAR(255)) 
AS
SELECT p.[Name] AS 	PassengerName,
tick.DateOfDeparture AS DateOfDeparture,
tr.HourOfDeparture AS HourOfDeparture
FROM Towns AS t
JOIN Trains AS tr ON tr.ArrivalTownId = t.Id
JOIN Tickets AS tick ON tick.TrainId = tr.Id 
JOIN Passengers AS p ON tick.PassengerId = p.Id
WHERE t.[Name] = @townName
ORDER BY DateOfDeparture DESC, PassengerName ASC

EXEC usp_SearchByTown 'Berlin'