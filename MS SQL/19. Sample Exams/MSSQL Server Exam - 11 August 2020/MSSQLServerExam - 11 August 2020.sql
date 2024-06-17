--Databases MSSQL Server Retake Exam - 11 August 2020

--1

CREATE TABLE Countries(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender CHAR(1) CHECK(Gender IN('M','F')),
Age INT,
PhoneNumber VARCHAR(10) CHECK(LEN(PhoneNumber) = 10),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Products(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(25) UNIQUE,
[Description] NVARCHAR(250),
Recipe NVARCHAR(MAX),
Price DECIMAL(18,4) CHECK(Price>=0)
)

CREATE TABLE Feedbacks(
Id INT PRIMARY KEY IDENTITY(1,1),
[Description] NVARCHAR(255),
Rate DECIMAL(18,2) CHECK(Rate BETWEEN 0 AND 10),
ProductId INT FOREIGN KEY REFERENCES Products(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(25) UNIQUE,
AddressText NVARCHAR(30),
Summary NVARCHAR(200),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(30),
[Description] NVARCHAR(200),
OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients(
ProductId INT NOT NULL,
IngredientId INT NOT NULL,
CONSTRAINT PK_ProductsIngredients PRIMARY KEY(ProductId,IngredientId),
CONSTRAINT FK_ProductId FOREIGN KEY(ProductId) REFERENCES Products(Id),
CONSTRAINT FK_IngredientId FOREIGN KEY(IngredientId) REFERENCES Ingredients(Id)
)

--2
INSERT INTO Distributors([Name],CountryId,AddressText,Summary)
VALUES 

('Deloitte & Touche',		2,	'6 Arch St #9757',	'Customizable neutral traveling'),
('Congress Title',			13,	'58 Hancock St',	'Customer loyalty'),
('Kitchen People',			1,	'3 E 31st St #77',	'Triple-buffered stable delivery'),
('General Color Co Inc',	21,	'6185 Bohn St #72',	'Focus group'),
('Beck Corporation',		23,	'21 E 64th Ave',	'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName,	LastName,	Age,	Gender,	PhoneNumber,   CountryId)
VALUES

		('Francoise',	'Rautenstrauch',	15,	'M'	,'0195698399',	5),
		('Kendra',	'Loud',	22,	'F',	'0063631526',	11),
		('Lourdes',	'Bauswell',	50	,'M', '0139037043',	8),
		('Hannah',	'Edmison',	18,	'F',	'0043343686',	1),
		('Tom',	'Loeza',	31,	'M',	'0144876096',	23),
		('Queenie',	'Kramarczyk',	30,	'F',	'0064215793',	29),
		('Hiu',	'Portaro',	25,	'M',	'0068277755',	16),
		('Josefa',	'Opitz',	43,	'F',	'0197887645',	17)


--3
UPDATE Ingredients
SET DistributorId =35
WHERE [Name] IN ('Bay Leaf', 'Paprika','Poppy')

UPDATE Ingredients 
SET OriginCountryId=14
WHERE OriginCountryId =8

--4
DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--5
SELECT [Name],	Price,	[Description] FROM Products
ORDER BY Price DESC,[Name] ASC


--6
SELECT 
f.ProductId,	
f.Rate,	
f.[Description],
c.Id,	
c.Age,	
c.Gender FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.Rate<5
ORDER BY f.ProductId DESC,f.Rate ASC

--7
SELECT 
CONCAT_WS(' ',c.FirstName,c.LastName) AS CustomerName,
c.PhoneNumber,
c.Gender
FROM Feedbacks AS f
RIGHT JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.CustomerId IS NULL
ORDER BY c.Id ASC



--8

SELECT 
c.FirstName,
c.Age,
c.PhoneNumber FROM Customers AS c
LEFT JOIN Countries AS co ON c.CountryId = co.Id
WHERE (c.Age >=21 AND c.FirstName LIKE '%an%') OR 
(

(SUBSTRING(c.PhoneNumber,LEN(c.PhoneNumber)-1,2) = '38') AND
(co.[Name] != 'Greece')

)
ORDER BY c.FirstName ASC,c.Age DESC

--9
SELECT 
d.[Name] AS DistributorName,
i.[Name] AS IngredientName,
p.[Name] AS ProductName,
AVG(f.Rate) AS AverageRate
FROM Ingredients AS i
 JOIN ProductsIngredients AS pin ON pin.IngredientId = i.Id
 JOIN Products AS p ON pin.ProductId = p.Id
 JOIN Distributors AS d ON i.DistributorId = d.Id
 JOIN Feedbacks AS f ON f.ProductId = p.Id
GROUP BY d.[Name],i.[Name],p.[Name]
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY DistributorName,
IngredientName, ProductName

--10
WITH DistributorIngredientCounts AS (
    SELECT
        c.[Name] AS CountryName,
        d.[Name] AS DistributorName,
        COUNT(i.Id) AS IngredientCount
    FROM
        Distributors d
         LEFT JOIN Ingredients i ON d.Id = i.DistributorId
		 LEFT JOIN Countries AS c ON d.CountryId = c.Id
    GROUP BY
        c.Name,
        d.Name
),
MaxIngredientCounts AS (
    SELECT
        CountryName,
        MAX(IngredientCount) AS MaxCount
    FROM
        DistributorIngredientCounts
    GROUP BY
        CountryName
)
SELECT
    d.CountryName,
    d.DistributorName
FROM
    DistributorIngredientCounts d
     JOIN MaxIngredientCounts m ON m.CountryName = d.CountryName AND d.IngredientCount = m.MaxCount
ORDER BY
    d.CountryName,
    d.DistributorName;


--11
GO
CREATE OR ALTER VIEW v_UserWithCountries 
AS
SELECT 
CONCAT_WS(' ',c.FirstName,c.LastName) AS CustomerName,
c.Age,
c.Gender,
co.[Name] AS CountryName from Customers AS c
JOIN Countries AS co ON c.CountryId = co.Id
GO
SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

 --12
CREATE OR ALTER TRIGGER trg_DeleteProductRelations
ON Products
INSTEAD OF DELETE
AS
BEGIN
 
    DELETE FROM Feedbacks
    WHERE ProductId IN (SELECT Id FROM DELETED);

    
    DELETE FROM ProductsIngredients
    WHERE ProductId IN (SELECT Id FROM DELETED);

  
    DELETE FROM Products
    WHERE Id IN (SELECT Id FROM DELETED);
END;
 
 DELETE FROM Products WHERE Id = 7