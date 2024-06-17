--Databases MSSQL Server Exam - 28 Jun 2020

--1


USE ColonialJourney
CREATE TABLE Planets(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
PlanetId INT NOT NULL FOREIGN KEY REFERENCES Planets(Id)
)

CREATE TABLE Spaceships(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
Manufacturer VARCHAR(30) NOT NULL,
LightSpeedRate INT DEFAULT 0
)
CREATE TABLE Colonists(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
Ucn VARCHAR(10) NOT NULL UNIQUE,
BirthDate DATE NOT NULL
)

CREATE TABLE Journeys(
Id INT PRIMARY KEY IDENTITY(1,1),
JourneyStart DATETIME NOT NULL,
JourneyEnd DATETIME NOT NULL,
Purpose VARCHAR(11) CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
DestinationSpaceportId INT NOT NULL FOREIGN KEY REFERENCES Spaceports(Id),
SpaceshipId INT NOT NULL FOREIGN KEY REFERENCES Spaceships(Id)
)

CREATE TABLE TravelCards(
Id INT PRIMARY KEY IDENTITY(1,1),
CardNumber VARCHAR(10) NOT NULL UNIQUE,
JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
ColonistId INT NOT NULL FOREIGN KEY REFERENCES Colonists(Id),
JourneyId INT NOT NULL FOREIGN KEY REFERENCES Journeys(Id)
)


--2
INSERT INTO Planets([Name])
VALUES ('Mars'),('Earth'),('Jupiter'),('Saturn')

INSERT INTO Spaceships([Name],	Manufacturer,	LightSpeedRate)
VALUES ('Golf',	'VW',	3),
		('WakaWaka',	'Wakanda',	4),
		('Falcon9',	'SpaceX',	1),
		('Bed',	'Vidolov',	6)


--3
UPDATE Spaceships
SET LightSpeedRate+=1
WHERE Id BETWEEN 8 AND 12


--4
DELETE FROM TravelCards WHERE JourneyId IN (1,2,3)
DELETE FROM Journeys WHERE Id IN (1,2,3)


--5
SELECT Id,
FORMAT(JourneyStart,'dd/MM/yyyy') AS JourneyStart,
FORMAT(JourneyEnd,'dd/MM/yyyy') AS JourneyEnd
FROM Journeys 
WHERE Purpose = 'Military'
ORDER BY JourneyStart ASC

--6
SELECT c.Id,
CONCAT_WS(' ',c.FirstName,c.LastName) AS full_name
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY  c.Id ASC


--7
SELECT COUNT(*) AS [count] FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
JOIN Journeys AS j ON tc.JourneyId = j.Id
WHERE j.Purpose = 'Technical'


--8
SELECT ss.[Name],ss.Manufacturer FROM Spaceships AS ss
JOIN Journeys AS j On j.SpaceshipId = ss.Id
JOIN TravelCards AS tc ON tc.JourneyId = j.Id
JOIN Colonists AS c ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot' AND (
(YEAR('01/01/2019') - YEAR(c.BirthDate))<30 )
ORDER BY ss.[Name] ASC

--9
SELECT p.[Name] AS PlanetName,
COUNT(j.Id) AS JourneysCount
FROM Planets AS p
JOIN Spaceports AS sp ON sp.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
GROUP BY p.[Name]
ORDER BY JourneysCount DESC,PlanetName ASC


--10

/*
tc.JobDuringJourney,
CONCAT_WS(' ',c.FirstName,c.LastName) AS FullName
*/
WITH JobRanks AS (
SELECT 
tc.JobDuringJourney,
CONCAT_WS(' ',c.FirstName,c.LastName) AS FullName,
DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate) AS JobRank
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
JOIN Journeys AS j On tc.JourneyId = j.Id
)
SELECT * FROM JobRanks WHERE JobRank = 2


--11
GO
CREATE OR ALTER FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30)) 
RETURNS INT
AS
BEGIN
DECLARE @colonistsCount INT = (
SELECT COUNT(*) FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
JOIN Journeys AS j ON tc.JourneyId = j.Id
JOIN Spaceports AS sp ON j.DestinationSpaceportId = sp.Id
JOIN Planets AS p ON sp.PlanetId = p.Id
WHERE p.[Name] = @PlanetName
)
RETURN @colonistsCount
END
GO

SELECT dbo.udf_GetColonistsCount('Otroyphus')


--12
GO
CREATE OR ALTER PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN

DECLARE @isExistingJourneyId INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId)

IF(@isExistingJourneyId IS NULL)
BEGIN;
	THROW 50001, 'The journey does not exist!', 1
END;

DECLARE @samePurpose VARCHAR(11) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)

IF (@samePurpose = @NewPurpose)
BEGIN;
	THROW 50002, 'You cannot change the purpose!',1;
END;

UPDATE Journeys 
SET Purpose = @NewPurpose
WHERE Id = @JourneyId


END
GO

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
SELECT * FROM Journeys WHERE Id = 4 --FROM EDUCATIONAL TO TECHNICAL
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'












