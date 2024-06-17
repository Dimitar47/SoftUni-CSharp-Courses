--MS SQL Regular Exam - 16 June 2024
--1


CREATE TABLE Contacts(
Id INT PRIMARY KEY IDENTITY,
Email NVARCHAR(100),
PhoneNumber NVARCHAR(20),
PostAddress NVARCHAR(200),
Website NVARCHAR(50)
)
CREATE TABLE Libraries(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
ContactId INT NOT NULL FOREIGN KEY REFERENCES Contacts(Id)
)
CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Authors(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(100) NOT NULL,
ContactId INT NOT NULL FOREIGN KEY REFERENCES Contacts(Id)
)
CREATE TABLE Books(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(100) NOT NULL,
YearPublished INT NOT NULL,
ISBN NVARCHAR(13) UNIQUE NOT NULL,
AuthorId INT NOT NULL FOREIGN KEY REFERENCES Authors(Id),
GenreId INT NOT NULL FOREIGN KEY REFERENCES Genres(Id)
)


CREATE TABLE LibrariesBooks(
LibraryId INT NOT NULL,
BookId INT NOT NULL,
CONSTRAINT PK_LibrariesBooks PRIMARY KEY(LibraryId,BookId),
CONSTRAINT FK_LibraryId FOREIGN KEY(LibraryId) REFERENCES Libraries(Id),
CONSTRAINT FK_BookId FOREIGN KEY(BookId) REFERENCES Books(Id)
)

--2

INSERT INTO Contacts(Email,	PhoneNumber,	PostAddress,	Website)
VALUES (	NULL,	NULL,	NULL,	NULL),
	   (	NULL,	NULL,	NULL,	NULL),
	   ('stephen.king@example.com',	'+4445556666',	'15 Fiction Ave, Bangor, ME',	'www.stephenking.com'),
	   (	'suzanne.collins@example.com',	'+7778889999',	'10 Mockingbird Ln, NY, NY',	'www.suzannecollins.com')
INSERT INTO Authors(	[Name],	ContactId)
VALUES(	'George Orwell'	,21),
	   ('Aldous Huxley',	22),
	   ('Stephen King',	23),
	   (	'Suzanne Collins',	24)


INSERT INTO Books(Title,	YearPublished,	ISBN,	AuthorId,	GenreId)
VALUES
		('1984',	1949,	'9780451524935',	16,	2),
		('Animal Farm',	1945,	'9780451526342',		16,	2),
		('Brave New World',	1932,	'9780060850524',	17,	2),
		('The Doors of Perception',	1954,	'9780060850531',	17,	2),
		('The Shining',	1977,	'9780307743657',	18,	9),
		('It',	1986,	'9781501142970',	18,	9),
		('The Hunger Games',	2008,	'9780439023481',	19,	7),
		('Catching Fire',	2009,	'9780439023498',	19,	7),
		('Mockingjay',	2010,	'9780439023511',	19,	7)


INSERT INTO LibrariesBooks(LibraryId,	BookId)
VALUES  (1,	36),
		(1,	37),
		(2,	38),
		(2,	39),
		(3,	40),
		(3,	41),
		(4,	42),
		(4,	43),
		(5,	44)

--3


UPDATE Contacts
SET Website = 'www.' + LOWER(REPLACE(a.[Name], ' ', '')) + '.com'
FROM Contacts c
JOIN Authors a ON c.Id = a.ContactId
WHERE c.Website IS NULL;

--4

BEGIN TRANSACTION
DELETE FROM LibrariesBooks
WHERE BookId IN (SELECT Id FROM Books WHERE AuthorId = 1)
DELETE FROM Books
WHERE AuthorId = 1
DELETE FROM Authors  
WHERE Id = 1
ROLLBACK TRANSACTION

--5
SELECT b.Title AS  [Book Title], b.ISBN, b.YearPublished AS [YearReleased]
FROM Books as b
ORDER BY YearReleased DESC, [Book Title] ASC

--6
SELECT b.Id,b.Title,b.ISBN,g.[Name] AS Genre FROM Books AS b
JOIN Genres AS g ON b.GenreId = g.Id
WHERE g.[Name] IN ('Biography','Historical Fiction')
ORDER BY Genre ASC, b.Title ASC

--7
SELECT l.[Name] AS [Library],
c.Email
FROM Libraries AS l
JOIN Contacts AS c ON l.ContactId = c.Id
WHERE l.Id NOT IN (
    SELECT DISTINCT lb.LibraryId
    FROM LibrariesBooks AS lb
    JOIN Books AS b ON lb.BookId = b.Id
    JOIN Genres AS g ON b.GenreId = g.Id
    WHERE g.[Name] = 'Mystery'
)
ORDER BY l.[Name] ASC;


--8
SELECT TOP 3 b.Title,b.YearPublished AS [Year], g.[Name] AS Genre
FROM Books AS b
JOIN Genres AS g ON b.GenreId = g.Id
where (b.YearPublished>2000 AND b.[Title] LIKE '%a%') OR 
	  (b.YearPublished<1950 AND g.[Name] LIKE '%Fantasy%') 
ORDER BY b.Title ASC,YearPublished DESC


--9
SELECT a.[Name] AS Author,
c.Email,
c.PostAddress AS [Address] FROM Authors AS a
JOIN Contacts AS c ON a.ContactId = c.Id
WHERE c.PostAddress LIKE '%UK%'
ORDER BY Author  ASC


--10
SELECT a.[Name] AS Author,
b.Title,
l.[Name] AS [Library],
c.PostAddress AS [Library Address]
FROM Books AS b
JOIN Genres AS g ON b.GenreId = g.Id
JOIN Authors AS a ON b.AuthorId = a.Id
JOIN LibrariesBooks AS lb ON lb.BookId = b.Id
JOIN Libraries AS l ON lb.LibraryId = l.Id
JOIN Contacts AS c ON l.ContactId = c.Id
WHERE g.[Name] = 'Fiction' AND c.PostAddress LIKE '%Denver%'
ORDER BY b.Title ASC

--11
GO
CREATE OR ALTER FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @totalCountOfBooks INT= (
	SELECT COUNT(*) FROM Books AS b
	JOIN Authors AS a ON b.AuthorId = a.Id
	JOIN LibrariesBooks AS lb ON lb.BookId = b.Id
	JOIN Libraries AS l ON lb.LibraryId = l.Id
	WHERE a.[Name] = @name
	);
	return @totalCountOfBooks
END
GO

SELECT dbo.udf_AuthorsWithBooks('J.K. Rowling')

--12
GO
CREATE OR ALTER PROCEDURE usp_SearchByGenre(@genreName NVARCHAR(30))
AS
BEGIN
SELECT b.Title, b.YearPublished AS [Year],
b.ISBN, a.[Name] AS Author, g.[Name] AS Genre
FROM Books AS b
JOIN Genres AS g ON b.GenreId = g.Id
JOIN Authors AS a ON b.AuthorId = a.Id
WHERE g.[Name] = @genreName
ORDER BY b.Title ASC
END
GO
EXEC usp_SearchByGenre 'Fantasy'
