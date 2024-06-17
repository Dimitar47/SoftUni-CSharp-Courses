--Databases MSSQL Server Exam - 19 Feb 2023
--1

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL
)
CREATE TABLE Addresses (
Id INT PRIMARY KEY IDENTITY(1,1),
StreetName NVARCHAR(100) NOT NULL,	
StreetNumber INT NOT NULL,
Town VARCHAR(30) NOT NULL,
Country VARCHAR(50) NOT NULL,
ZIP INT NOT NULL
)
CREATE TABLE Publishers(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(30) UNIQUE NOT NULL,
AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id),
Website NVARCHAR(40),
Phone NVARCHAR(20) 
)
CREATE TABLE PlayersRanges(
Id INT PRIMARY KEY IDENTITY(1,1),
PlayersMin INT NOT NULL,
PlayersMax INT NOT NULL
)
CREATE TABLE Boardgames(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(30) NOT NULL,
YearPublished INT NOT NULL,
Rating DECIMAL(18,2) NOT NULL,
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
PublisherId INT NOT NULL FOREIGN KEY REFERENCES Publishers(Id),
PlayersRangeId INT NOT NULL FOREIGN KEY REFERENCES PlayersRanges(Id)
)

CREATE TABLE Creators(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(30) NOT NULL
)
CREATE TABLE CreatorsBoardgames(
CreatorId INT NOT NULL,
BoardgameId INT NOT NULL,
CONSTRAINT PK_CreatorBoard PRIMARY KEY(CreatorId,BoardgameId),
CONSTRAINT FK_CreatorId FOREIGN KEY(CreatorId) REFERENCES Creators(Id),
CONSTRAINT FK_BoardgameId FOREIGN KEY(BoardgameId) REFERENCES Boardgames(Id)
)

--2
INSERT INTO Boardgames([Name],YearPublished,Rating,CategoryId,PublisherId,PlayersRangeId)
VALUES ('Deep Blue',2019,5.67,1,15,7),
('Paris',2016,9.78,7,1,5),
('Catan: Starfarers',2021,9.87,7,13,6),
('Bleeding Kansas',2020,3.25,3,7,4),
('One Small Step',2019,5.75,5,9,2)

INSERT INTO Publishers([Name],AddressId,Website,Phone)
VALUES ('Agman Games',5,'www.agmangames.com','+16546135542'),
('Amethyst Games',7,'www.amethystgames.com','+15558889992'),
('BattleBooks',	13,'www.battlebooks.com','+12345678907')


--3
UPDATE PlayersRanges
SET PlayersMax +=1
WHERE PlayersMin =2 AND PlayersMax = 2
UPDATE Boardgames
SET [Name] +='V2'
WHERE YearPublished>=2020

--4
DELETE FROM CreatorsBoardgames WHERE BoardgameId IN (SELECT Id from Boardgames WHERE PublisherId IN (SELECT Id FROM Publishers WHERE AddressId IN (SELECT Id FROM Addresses WHERE Town LIKE 'L%')))
DELETE FROM Boardgames WHERE PublisherId IN (SELECT Id FROM Publishers WHERE AddressId IN (SELECT Id FROM Addresses WHERE Town LIKE 'L%'))
DELETE FROM Publishers WHERE AddressId IN (SELECT Id FROM Addresses WHERE Town LIKE 'L%')
DELETE FROM Addresses
WHERE Town LIKE 'L%'
SELECT * FROM CreatorsBoardgames

--5
SELECT bg.[Name],bg.Rating FROM Boardgames AS bg
ORDER BY bg.YearPublished ASC, bg.[Name] DESC

--6
SELECT b.Id,
b.[Name],
b.YearPublished,
c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON b.CategoryId = c.Id
WHERE c.[Name] IN ('Strategy Games','Wargames')
ORDER BY b.YearPublished DESC

--7
SELECT c.Id,
CONCAT_WS(' ',c.FirstName,c.LastName) AS CreatorName,
c.Email FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cbg ON cbg.CreatorId = c.Id
LEFT JOIN Boardgames AS bg ON  cbg.BoardgameId = bg.Id
WHERE cbg.BoardgameId is null
ORDER BY CreatorName ASC


--8
SELECT TOP(5) bg.[Name],
bg.Rating,
c.[Name] AS CategoryName
FROM Boardgames AS bg
JOIN Categories AS c ON c.Id = bg.CategoryId
WHERE (bg.Rating>7 and bg.[Name] LIKE '%a%') OR (bg.Rating>7.50 AND PlayersRangeId=4)
ORDER BY bg.[Name] ASC, bg.Rating DESC

--9
SELECT CONCAT_WS(' ',c.FirstName,c.LastName ) AS FullName,
c.Email,
MAX(bg.Rating) AS Rating
FROM Creators AS c
JOIN CreatorsBoardgames AS cbg ON cbg.CreatorId = c.Id
JOIN Boardgames AS bg ON cbg.BoardgameId = bg.Id 
WHERE c.Email LIKE '%.com'
GROUP BY c.FirstName,c.LastName,c.Email
ORDER BY FullName ASC

--10
SELECT c.LastName,
CEILING(AVG(bg.Rating)) AS AverageRating,
p.[Name] AS PublisherName
FROM Creators AS c
 JOIN CreatorsBoardgames AS cbg ON cbg.CreatorId = c.Id
 JOIN Boardgames AS bg ON cbg.BoardgameId = bg.Id
 JOIN Publishers AS p ON bg.PublisherId = p.Id
WHERE cbg.CreatorId IS NOT NULL AND p.[Name] = 'Stonemaier Games'
GROUP BY c.LastName,p.[Name]
ORDER BY  AVG(bg.Rating) DESC

--11
CREATE OR ALTER FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(255)) 
RETURNS INT
AS
BEGIN 
DECLARE @BgTotalCount INT=(
SELECT COUNT(*) FROM Creators AS c
JOIN CreatorsBoardgames AS cbg ON cbg.CreatorId = c.Id
JOIN Boardgames AS bg ON cbg.BoardgameId = bg.Id
WHERE c.FirstName = @name
)
RETURN @bgTotalCount
END

SELECT dbo.udf_CreatorWithBoardgames('Bruno')

--12
CREATE OR ALTER PROCEDURE usp_SearchByCategory(@category VARCHAR(255)) 
AS
BEGIN
SELECT bg.[Name],
bg.YearPublished,
bg.Rating,
c.[Name] AS CategoryName,
p.[Name] AS PublisherName,
CONCAT_WS(' ',CONVERT(VARCHAR,plr.PlayersMin),'people') AS MinPlayers,
CONCAT_WS(' ',CONVERT(VARCHAR,plr.PlayersMax),'people') AS MaxPlayers
FROM Boardgames AS bg
JOIN Categories AS c ON bg.CategoryId = c.Id
JOIN Publishers AS p ON bg.PublisherId = p.Id
JOIN PlayersRanges AS plr ON bg.PlayersRangeId = plr.Id
WHERE c.[Name] = @category
ORDER BY PublisherName ASC, bg.YearPublished DESC
END
EXEC usp_SearchByCategory 'Wargames'

