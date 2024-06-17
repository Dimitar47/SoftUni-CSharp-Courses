--Databases MSSQL Server Exam - 13 February 2021



--1
USE Bitbucket
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY(1,1),
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(30) NOT NULL,
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
RepositoryId INT NOT NULL,
ContributorId INT NOT NULL,
CONSTRAINT PK_RepositoriesContributors PRIMARY KEY(RepositoryId,ContributorId),
CONSTRAINT FK_RepositoryId FOREIGN KEY(RepositoryId) REFERENCES Repositories(Id),
CONSTRAINT FK_ContributorId FOREIGN KEY(ContributorId) REFERENCES Users(Id)
)

CREATE TABLE Issues(
Id INT PRIMARY KEY IDENTITY(1,1),
Title VARCHAR(255) NOT NULL,
IssueStatus CHAR(6) NOT NULL,
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Commits(
Id INT PRIMARY KEY IDENTITY(1,1),
[Message] VARCHAR(255) NOT NULL,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Files(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL(18,2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
)


--2
INSERT INTO Files([Name],Size,ParentId,CommitId)
VALUES  ('Trade.idk',	2598.0,	1,	1),
		('menu.net',	9238.31,	2,	2),
		('Administrate.soshy',	1246.93,	3,	3),
		('Controller.php'	,7353.15,	4,	4),
		('Find.java',	9957.86,	5,	5),
		('Controller.json',	14034.87,	3,	6),
		('Operate.xix',	7662.92	,7,	7)

INSERT INTO Issues(Title,	IssueStatus,	RepositoryId,	AssigneeId)
VALUES	('Critical Problem with HomeController.cs file',	'open',	1,	4),
		('Typo fix in Judge.html',	'open',	4,	3),
		('Implement documentation for UsersService.cs',	'closed',	8,	2),
		('Unreachable code in Index.cs',	'open',	9,	8)

--3
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--4
DELETE FROM Issues WHERE RepositoryId =3
DELETE FROM RepositoriesContributors WHERE RepositoryId = 3
DELETE FROM Files WHERE CommitId IN (SELECT Id FROM Commits WHERE RepositoryId=3)
DELETE FROM Commits WHERE RepositoryId = 3
DELETE FROM Repositories 
WHERE Id =3


--5
SELECT c.Id,c.[Message],c.RepositoryId,	c.ContributorId FROM Commits AS c 
ORDER by c.Id ASC,
c.[Message] ASC,
c.RepositoryId ASC,
c.ContributorId ASC

--6
SELECT f.Id,f.[Name],f.Size FROM Files AS f
WHERE f.Size >1000 AND f.[Name] LIKE '%html%'
ORDER BY f.Size DESC,
f.Id ASC,
f.[Name] ASC

--7
SELECT i.Id,
(u.Username + ' : ' + i.Title) AS IssueAssignee
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC,IssueAssignee ASC

--8

SELECT  o.Id,
o.[Name],
CONVERT(Varchar(50),o.Size) + 'KB' AS Size
FROM Files AS f
RIGHT JOIN Files AS O ON O.Id = f.ParentId
WHERE f.Id is null
ORDER BY o.Id ASC,
o.[Name] ASC,Size DESC

--9
SELECT TOP 5 r.Id,
r.[Name],
COUNT(*) AS Commits
FROM Repositories AS r
 JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
 JOIN Commits AS c ON c.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY Commits DESC,
r.Id ASC,
r.[Name] ASC

--10
SELECT 
u.Username,
AVG(f.Size) AS Size
FROM Users AS u
JOIN Commits AS c ON  c.ContributorId = u.Id
JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY Size DESC, u.Username ASC


--11
GO
CREATE OR ALTER FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS 
BEGIN 
	DECLARE @commitCountForUser INT =
	(
	SELECT COUNT(*) FROM Users AS u
	JOIN Commits AS c ON c.ContributorId = u.Id
	WHERE u.Username = @username
	);

	RETURN @commitCountForUser
END
GO
SELECT dbo.udf_AllUserCommits('UnderSinduxrein')


--12
GO
CREATE OR ALTER PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(100))
AS
BEGIN
SELECT f.Id,
f.[Name],
CONVERT(VARCHAR(50),f.Size) + 'KB' AS Size

FROM Files AS f
WHERE f.[Name] LIKE CONCAT('%',@fileExtension)
ORDER BY
	f.Id ASC,
	f.[Name] ASC,
	Size DESC
END 
GO
EXEC usp_SearchForFiles 'txt'
