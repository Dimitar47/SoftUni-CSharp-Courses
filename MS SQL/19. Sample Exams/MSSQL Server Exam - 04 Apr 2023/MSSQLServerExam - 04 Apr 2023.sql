--Databases MSSQL Server Retake Exam - 04 Apr 2023
--1
CREATE TABLE Countries(
Id INT PRIMARY KEY Identity(1,1),
[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses (
Id INT PRIMARY KEY IDENTITY(1,1),
StreetName NVARCHAR(20) NOT NULL,
StreetNumber INT,
PostCode INT NOT NULL,
City VARCHAR(25) NOT NULL,
CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Vendors(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(25) NOT NULL,
NumberVAT NVARCHAR(15) NOT NULL,
AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id)
)

CREATE TABLE Clients(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(25) NOT NULL,
NumberVAT NVARCHAR(15) NOT NULL,
AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id)
)

CREATE TABLE  Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Products(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(35) NOT NULL,
Price DECIMAL(18,2) NOT NULL,
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
VendorId INT NOT NULL FOREIGN KEY  REFERENCES Vendors(Id)
)

CREATE TABLE Invoices(
Id INT PRIMARY KEY IDENTITY(1,1),
Number INT NOT NULL,
IssueDate DATETIME2 NOT NULL,
DueDate DATETIME2 NOT NULL,
Amount DECIMAL(18,2) NOT NULL,
Currency varchar(5) NOT NULL,
ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(Id)
)

CREATE TABLE ProductsClients(
ProductId INT NOT NULL,
ClientId INT NOT NULL,
CONSTRAINT PK_ProductClient PRIMARY KEY(ProductId,ClientId),
CONSTRAINT FK_ProductId FOREIGN KEY(ProductId) REFERENCES Products(Id),
CONSTRAINT FK_ClientId FOREIGN KEY(ClientId) REFERENCES Clients(Id)
)


--2
INSERT INTO Products([Name],	Price,	CategoryId,	VendorId)
VALUES
('SCANIA Oil Filter XD01',	78.69,	1,	1),
('MAN Air Filter XD01',	97.38,	1	,5),
('DAF Light Bulb 05FG87',	55.00,	2	,13),
('ADR Shoes 47-47.5',	49.85,	3,	5),
('Anti-slip pads S',	5.87,	5,	7)

INSERT INTO Invoices(Number,	IssueDate,	DueDate,	Amount,	Currency,	ClientId)
VALUES 
(1219992181,	'2023-03-01',	'2023-04-30',	180.96,	'BGN',	3),
(1729252340,	'2022-11-06',	'2023-01-04',	158.18,	'EUR',	13),
(1950101013,	'2023-02-17',	'2023-04-18',	615.15,	'USD',	19)

--3
UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE MONTH(IssueDate) = 11 AND YEAR(IssueDate) = 2022

UPDATE Clients 
SET AddressId =3
WHERE [Name] LIKE '%CO%'

--4
DELETE FROM ProductsClients
WHERE ClientId IN (SELECT Id FROM Clients  WHERE NumberVAT LIKE 'IT%')
DELETE FROM Invoices
WHERE ClientId IN (SELECT Id FROM Clients  WHERE NumberVAT LIKE 'IT%')
DELETE FROM Clients
WHERE NumberVAT LIKE 'IT%'

--5
SELECT Number,Currency FROM Invoices
ORDER BY Amount DESC, DueDate ASC

--6
SELECT p.Id,
p.[Name],
p.Price,
c.[Name] AS CategoryName
FROM Products AS p
JOIN Categories AS c ON p.CategoryId = c.Id
WHERE c.[Name] IN ('ADR','Others')
ORDER BY Price DESC

--7
SELECT c.Id,
c.[Name] AS Client,
(a.StreetName + ' ' + 
CONVERT(VARCHAR,a.StreetNumber) +',' +
' ' + a.City+',' + ' ' +
CONVERT(VARCHAR, a.PostCode)+','+ ' ' + (Select c.[Name] from Countries c WHERE CountryId = c.Id)) AS [Address]
FROM Clients AS c
LEFT JOIN ProductsClients AS pc ON pc.ClientId = c.Id
LEFT JOIN Products AS p ON pc.ProductId =p.Id
LEFT JOIN Addresses AS a ON a.Id = c.AddressId
WHERE pc.ProductId IS NULL
ORDER BY c.[Name] ASC

--8
SELECT TOP(7) i.Number,
i.Amount,
c.[Name] AS Client FROM Invoices AS i
JOIN Clients AS c ON i.ClientId = c.Id
WHERE (IssueDate < '2023-01-01' AND Currency = 'EUR') OR (Amount > 500 AND c.NumberVAT LIKE 'DE%')
ORDER BY i.Number ASC,i.Amount DESC

--9
SELECT c.[Name] AS Client,
MAX(p.Price) AS Price,
c.NumberVAT AS [VAT Number]
FROM Clients AS c
JOIN ProductsClients AS pc ON pc.ClientId = c.Id
JOIN Products AS p ON pc.ProductId = p.Id
WHERE c.[Name] NOT LIKE '%KG'
GROUP BY c.[Name],c.NumberVAT
ORDER BY Price DESC

--10
SELECT c.[Name] AS Client,
FLOOR(AVG(p.Price)) AS [Average Price]
FROM Clients AS c
JOIN ProductsClients AS pc ON pc.ClientId = c.Id
JOIN Products as p ON pc.ProductId = p.Id
JOIN Vendors AS v ON p.VendorId = v.Id
WHERE pc.ProductId IS NOT NULL AND v.NumberVAT LIKE '%FR%'
GROUP BY c.[Name]
ORDER BY [Average Price] ASC, Client DESC

--11
CREATE OR ALTER FUNCTION udf_ProductWithClients(@name VARCHAR(255)) 
RETURNS INT
AS
BEGIN
DECLARE @totalClientCount int=(
SELECT COUNT(*) FROM Clients AS c
JOIN ProductsClients AS pc ON pc.ClientId = c.Id
JOIN Products AS p ON pc.ProductId = p.Id
WHERE p.[Name] = @name)

return @totalClientCount
END

SELECT dbo.udf_ProductWithClients('DAF FILTER HU12103X')

--12
CREATE OR ALTER PROCEDURE usp_SearchByCountry(@country VARCHAR(255)) 
AS
BEGIN 
SELECT v.[Name] AS Vendor,
v.NumberVAT AS VAT,
CONCAT_WS(' ',a.StreetName,a.StreetNumber) AS [Street Info],
CONCAT_WS(' ',a.City,a.PostCode) AS [City Info]
FROM Vendors AS v
JOIN Addresses AS a ON v.AddressId = a.Id
JOIN Countries AS c ON a.CountryId = c.Id
WHERE c.[Name] = @country
ORDER BY v.[Name] ASC, c.[Name]
END

EXEC usp_SearchByCountry 'France'