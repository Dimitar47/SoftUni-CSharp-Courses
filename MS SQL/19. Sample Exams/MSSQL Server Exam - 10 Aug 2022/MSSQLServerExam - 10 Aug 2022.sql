--Databases MSSQL Server Retake Exam - 10 Aug 2022
--1
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Locations(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
Municipality VARCHAR(50),
Province VARCHAR(50)
)
CREATE TABLE Sites(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(100) NOT NULL,
LocationId INT NOT NULL FOREIGN KEY REFERENCES Locations(Id),
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
Establishment VARCHAR(15)
)

CREATE TABLE Tourists(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
Age INT NOT NULL CHECK (AGE>=0 AND AGE<=120),
PhoneNumber VARCHAR(20) NOT NULL,
Nationality VARCHAR(30) NOT NULL,
Reward VARCHAR(20)
)
CREATE TABLE SitesTourists(
TouristId INT NOT NULL,
SiteId INT NOT NULL,
CONSTRAINT PK_SiteTourist PRIMARY KEY(TouristId,SiteId),
CONSTRAINT FK_SiteTouristId FOREIGN KEY(TouristId) REFERENCES Tourists(Id),
CONSTRAINT FK_SiteId FOREIGN KEY(SiteId) REFERENCES Sites(Id)
)
CREATE TABLE BonusPrizes(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL
)
CREATE TABLE TouristsBonusPrizes(
TouristId INT NOT NULL,
BonusPrizeId INT NOT NULL,
CONSTRAINT PK_TouristBonusPrize PRIMARY KEY(TouristId,BonusPrizeId),
CONSTRAINT FK_TouristBonusPrizeId FOREIGN KEY(TouristId) REFERENCES Tourists(Id),
CONSTRAINT FK_BonusPrizeId FOREIGN KEY(BonusPrizeId) REFERENCES BonusPrizes(Id)
)

--2
INSERT INTO Tourists([Name],Age,PhoneNumber,Nationality,Reward)
VALUES ('Borislava Kazakova',52,'+359896354244','Bulgaria',NULL),
('Peter Bosh',48,'+447911844141','UK',NULL),
('Martin Smith',29,'+353863818592','Ireland','Bronze badge'),
('Svilen Dobrev',49,'+359986584786','Bulgaria','Silver badge'),
('Kremena Popova',38,'+359893298604','Bulgaria',NULL)


INSERT INTO Sites([Name],	LocationId,	CategoryId,	Establishment)
	VALUES ('Ustra fortress',90,7,'X'),
	('Karlanovo Pyramids',65,7,NULL),
	('The Tomb of Tsar Sevt',63,8,'V BC'),
	('Sinite Kamani Natural Park',17,1,NULL),
	('St. Petka of Bulgaria – Rupite',92,6,'1994')


--3
UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL

--4
DELETE FROM TouristsBonusPrizes WHERE BonusPrizeId = 5
DELETE  FROM BonusPrizes WHERE [Name] = 'Sleeping bag'

--5
SELECT [Name],
Age,	
PhoneNumber,
Nationality 
FROM Tourists 
ORDER BY Nationality ASC, Age DESC, [Name]

--6
SELECT s.[Name] AS [Site],
l.[Name] AS [Location],
s.Establishment,
c.[Name] AS Category
FROM Sites AS s
JOIN Locations AS l ON s.LocationId = l.Id
JOIN Categories AS c ON s.CategoryId = c.Id
ORDER BY Category DESC, [Location] ASC, [Site] ASC

--7
SELECT l.Province,
l.Municipality,
l.[Name] AS [Location],
COUNT(*) AS CountOfSites
FROM Sites AS s
JOIN Locations AS l ON s.LocationId = l.Id
WHERE l.Province = 'Sofia'
GROUP BY l.Province,l.Municipality, l.[Name]
ORDER BY CountOfSites DESC, [Location] ASC

--8
SELECT s.[Name] AS [Site],
l.[Name] AS [Location],
l.Municipality,
l.Province,
s.Establishment
FROM Sites AS s
JOIN Locations AS l ON s.LocationId = l.Id
WHERE SUBSTRING(l.[Name],1,1) NOT IN ('B','M','D') AND s.Establishment LIKE '%BC'
ORDER BY [Site] ASC

--9
SELECT t.[Name],
t.Age,
t.PhoneNumber,
t.Nationality,
CASE 
	WHEN tbp.BonusPrizeId IS NULL THEN '(no bonus prize)' ELSE (SELECT bp.[Name] WHERE bp.Id = tbp.BonusPrizeId)

END AS Reward
FROM Tourists AS t
 LEFT JOIN TouristsBonusPrizes AS tbp ON tbp.TouristId = t.Id
LEFT JOIN BonusPrizes AS bp ON tbp.BonusPrizeId = bp.Id
 ORDER BY t.[Name] ASC

 --10
SELECT 
 SUBSTRING(t.[Name],CHARINDEX(' ',t.[Name]),LEN(t.[Name]) - CHARINDEX(' ',t.[Name])+1) AS [LastName],
t.Nationality,
t.Age,
t.PhoneNumber
FROM Tourists AS t
 LEFT JOIN SitesTourists AS st ON st.TouristId = t.Id
 LEFT  JOIN Sites AS s ON st.SiteId = s.Id
 LEFT JOIN Categories AS c ON s.CategoryId = c.Id
 WHERE c.[Name] = 'History and archaeology' AND st.SiteId is NOT NULL
 GROUP BY t.[Name],t.Nationality,t.Age,t.PhoneNumber
 ORDER BY [LastName] ASC

 --11
 CREATE OR ALTER FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(255))
 RETURNS INT
 AS
 BEGIN 
 DECLARE @TouristCount int=(
 SELECT COUNT(*) FROM Tourists AS t
 JOIN SitesTourists AS st ON st.TouristId = t.Id
 JOIN Sites AS s ON st.SiteId = s.Id
 WHERE s.[Name] = @Site
 )
 RETURN @TouristCount
 END
 SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')
 SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')
 SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River')

 --12
CREATE OR ALTER PROCEDURE usp_AnnualRewardLottery(@TouristName VARCHAR(255))
AS
BEGIN 
SELECT 
t.[Name],
CASE 
 WHEN COUNT(*)>=25 AND COUNT(*)<50 THEN 'Bronze badge'
 WHEN COUNT(*) >=50 AND COUNT(*)<100 THEN 'Silver badge'
 WHEN COUNT(*) >=100 THEN 'Gold badge'
END AS Reward
FROM Tourists AS t
JOIN SitesTourists AS st ON st.TouristId = t.Id
JOIN Sites AS s ON st.SiteId = s.Id
WHERE t.[Name] = @TouristName
GROUP BY t.[Name]
END 
EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'
EXEC usp_AnnualRewardLottery 'Teodor Petrov'
EXEC usp_AnnualRewardLottery 'Zac Walsh'
EXEC usp_AnnualRewardLottery 'Brus Brown'