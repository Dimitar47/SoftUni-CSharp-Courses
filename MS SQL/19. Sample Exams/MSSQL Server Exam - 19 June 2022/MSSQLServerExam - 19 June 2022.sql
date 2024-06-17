--Databases MSSQL Server Exam - 19 June 2022

--1
CREATE TABLE Owners(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
PhoneNumber  VARCHAR(15) NOT NULL,
[Address] VARCHAR(50)
)
CREATE TABLE AnimalTypes(
Id INT PRIMARY KEY IDENTITY(1,1),
AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
Id INT PRIMARY KEY IDENTITY(1,1),
AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)
CREATE TABLE Animals(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(30) NOT NULL,
BirthDate DATE NOT NULL,
OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages(
CageId INT NOT NULL,
AnimalId INT NOT NULL,
CONSTRAINT PK_AnimalCage PRIMARY KEY(CageId,AnimalId),
CONSTRAINT FK_Cage FOREIGN KEY(CageId) REFERENCES Cages(Id),
CONSTRAINT FK_Animal FOREIGN KEY(AnimalId) REFERENCES Animals(Id)
)

CREATE TABLE VolunteersDepartments(
Id INT PRIMARY KEY IDENTITY(1,1),
DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
[Address] VARCHAR(50),
AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

--2
INSERT INTO Volunteers([Name],PhoneNumber,[Address],AnimalId,DepartmentId)
VALUES 
	('Anita Kostova','0896365412','Sofia, 5 Rosa str.',15,1),
	('Dimitur Stoev','0877564223',null,42,4),
	('Kalina Evtimova','0896321112','Silistra, 21 Breza str.',9,7),
	('Stoyan Tomov','0898564100','Montana, 1 Bor str.',18,8),
	('Boryana Mileva','0888112233',null,31,5)

INSERT INTO Animals([Name],BirthDate,OwnerId,AnimalTypeId)
VALUES ('Giraffe','2018-09-21',21,1),
('Harpy Eagle','2015-04-17',15,3),
('Hamadryas Baboon','2017-11-02',null,1),
('Tuatara','2021-06-30',2,4)


--3
SELECT * FROM Owners WHERE [Name] = 'Kaloqn Stoqnov'
SELECT *FROM Animals
UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL

--4
DELETE FROM Volunteers WHERE DepartmentId = 2
DELETE FROM VolunteersDepartments WHERE [DepartmentName] = 'Education program assistant'

--5
SELECT v.[Name],
v.PhoneNumber,
v.[Address],
v.AnimalId,
v.DepartmentId 
FROM Volunteers AS v
ORDER BY v.[Name] ASC, v.AnimalId ASC, v.DepartmentId ASC

--6
SELECT a.[Name],
ay.AnimalType,
FORMAT(a.BirthDate,'dd.MM.yyyy') AS BirthDate
FROM Animals AS a
JOIN AnimalTypes AS ay ON a.AnimalTypeId = ay.Id
ORDER BY a.[Name] ASC

--7
SELECT TOP 5 o.[Name] AS [Owner],
COUNT(*) AS CountOfAnimals
FROM Animals AS a
JOIN Owners AS o ON  o.Id= a.OwnerId
GROUP BY o.[Name] 
ORDER BY CountOfAnimals DESC, [Owner]

--8
SELECT 
CONCAT_WS('-',o.[Name],a.[Name]) AS OwnersAnimals,
o.PhoneNumber,
c.Id AS CageId
FROM Animals AS a
JOIN AnimalTypes AS ay ON ay.Id = a.AnimalTypeId
JOIN Owners AS o ON o.Id = a.OwnerId
JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
JOIN Cages AS c ON ac.CageId = c.Id 
WHERE ay.Id = 1
ORDER BY o.[Name], a.[Name] DESC

--9
SELECT v.[Name],
v.PhoneNumber,
SUBSTRING(
v.[Address],
CHARINDEX(',',TRIM(v.[Address]))+2,
(LEN(v.[Address]) - CHARINDEX(',',v.[Address])+1)
) AS [Address]
FROM Volunteers AS v 
WHERE v.DepartmentId = 2 AND (LEFT(TRIM([Address]),5)) ='Sofia'
ORDER BY v.[Name] ASC

--10
SELECT a.[Name],
YEAR(a.BirthDate) AS BirthYear,
ay.AnimalType FROM Animals AS a
JOIN AnimalTypes AS ay ON ay.Id = a.AnimalTypeId
WHERE a.OwnerId IS NULL AND DATEDIFF(YEAR,a.BirthDate,'01/01/2022')<5 AND ay.AnimalType <> 'Birds'
ORDER BY a.[Name]

--11
GO
CREATE OR ALTER FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @volunteersCount INT=
	(SELECT COUNT(*) FROM Volunteers AS v
	JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
	WHERE vd.DepartmentName = @VolunteersDepartment
	)
	RETURN @volunteersCount
END
GO
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')


--12
GO
CREATE OR ALTER PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName varchar(100))
AS 
BEGIN


	SELECT @AnimalName AS [Name],
	CASE
		WHEN (a.OwnerId IS NULL) THEN 'For adoption' 
		ELSE o.[Name]
	END AS OwnersName 
	FROM Animals AS a
		LEFT JOIN Owners AS o ON o.Id = a.OwnerId
		WHERE a.[Name] = @AnimalName
	
END
GO
EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'


