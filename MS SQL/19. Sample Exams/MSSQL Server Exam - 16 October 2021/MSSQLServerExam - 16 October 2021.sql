--Databases MSSQL Server Exam - 16 October 2021

--1

CREATE TABLE Sizes(
Id INT PRIMARY KEY IDENTITY(1,1),
[Length] INT NOT NULL CHECK([Length] BETWEEN 10 AND 25),
RingRange DECIMAL(18,2) NOT NULL CHECK(RingRange BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes(
Id INT PRIMARY KEY IDENTITY(1,1),
TasteType VARCHAR(20) NOT NULL,
TasteStrength VARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands(
Id INT PRIMARY KEY IDENTITY(1,1),
BrandName VARCHAR(30) UNIQUE NOT NULL,
BrandDescription VARCHAR (MAX)
)

CREATE TABLE Cigars(
Id INT PRIMARY KEY IDENTITY(1,1),
CigarName VARCHAR(80) NOT NULL,
BrandId INT NOT NULL FOREIGN KEY REFERENCES Brands(Id),
TastId INT NOT NULL FOREIGN KEY REFERENCES Tastes(Id),
SizeId INT NOT NULL FOREIGN KEY REFERENCES Sizes(Id),
PriceForSingleCigar DECIMAL(18,4) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL

)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY(1,1),
Town VARCHAR(30) NOT NULL,
Country NVARCHAR(30) NOT NULL,
Streat NVARCHAR(100) NOT NULL,
ZIP VARCHAR(20) NOT NULL
)


CREATE TABLE Clients(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(50) NOT NULL,
AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id)
)
CREATE TABLE ClientsCigars(
ClientId INT NOT NULL,
CigarId INT NOT NULL,
CONSTRAINT PK_ClientsCigars PRIMARY KEY(ClientId,CigarId),
CONSTRAINT FK_ClientId FOREIGN KEY (ClientId) REFERENCES Clients(Id),
CONSTRAINT FK_CigarId FOREIGN KEY(CigarId) REFERENCES Cigars(Id)
)

--2
INSERT INTO Cigars(CigarName,	BrandId,	TastId,	SizeId,	PriceForSingleCigar,	ImageURL)
VALUES ('COHIBA ROBUSTO',9,1,5,15.50,'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I',9,1,10,410.00,'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE',14,5,11,7.50,'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN',14,4,15,32.00,'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',2,3,8,85.21,'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town,	Country,Streat,ZIP)
VALUES ('Sofia','Bulgaria','18 Bul. Vasil levski','1000'),
('Athens','Greece','4342 McDonald Avenue','10435'),
('Zagreb','Croatia','4333 Lauren Drive','10000')


--3
UPDATE Cigars
SET PriceForSingleCigar= PriceForSingleCigar + PriceForSingleCigar * 0.2
WHERE TastId =1 
UPDATE Brands 
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--4
DELETE FROM Clients
WHERE AddressId IN (SELECT Id FROM Addresses WHERE LEFT(Country,1) = 'C')
DELETE FROM Addresses
WHERE LEFT(Country,1) = 'C'


--5
SELECT c.CigarName,c.PriceForSingleCigar,
c.ImageURL FROM Cigars AS c
ORDER BY c.PriceForSingleCigar ASC,c.CigarName DESC

--6
SELECT c.Id,c.CigarName,c.PriceForSingleCigar,t.TasteType,t.TasteStrength FROM Cigars AS c
JOIN Tastes AS t ON c.TastId = t.Id
WHERE c.TastId IN (2,3)
ORDER BY c.PriceForSingleCigar DESC


--7
SELECT cl.Id,
CONCAT_WS(' ',cl.FirstName,cl.LastName) AS ClientName,
cl.Email
FROM Clients AS cl
LEFT JOIN ClientsCigars AS cc ON cc.ClientId = cl.Id
LEFT JOIN Cigars AS ci ON cc.CigarId = ci.Id
WHERE cc.CigarId IS NULL
ORDER BY ClientName ASC

--8

SELECT TOP 5 
ci.CigarName,
ci.PriceForSingleCigar,
ci.ImageURL 
FROM Cigars AS ci
  JOIN Sizes AS s ON ci.SizeId = s.Id
WHERE s.[Length]>12 and (ci.CigarName LIKE '%ci%' or ci.PriceForSingleCigar>50) and s.RingRange>2.55
ORDER BY ci.CigarName ASC, ci.PriceForSingleCigar DESC

--9
SELECT 
CONCAT_WS(' ',cl.FirstName,cl.LastName) AS FullName,
a.Country,
a.ZIP,
CONCAT('$',CONVERT(varchar,max(ci.PriceForSingleCigar))) AS [CigarPrice]
FROM Clients AS cl
 JOIN Addresses AS a ON cl.AddressId = a.Id
 JOIN ClientsCigars AS cc ON cc.ClientId = cl.Id
 JOIN Cigars AS ci ON cc.CigarId = ci.Id
WHERE ISNUMERIC(ZIP) =1  
 group by cl.FirstName,cl.LastName,a.Country,a.ZIP
ORDER BY FullName ASC

/*
cl.LastName,
AVG(s.[Length]) AS CiagrLength,
CEILING(s.RingRange) AS CiagrRingRange
*/
--10
SELECT 
cl.LastName,
AVG(s.[Length]) AS CiagrLength,
CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM Clients AS cl
  JOIN ClientsCigars AS cc ON cc.ClientId = cl.Id
  JOIN Cigars AS ci ON cc.CigarId = ci.Id
 JOIN Sizes AS s ON ci.SizeId = s.Id
WHERE cc.CigarId is not null
GROUP BY  cl.LastName
ORDER BY CiagrLength DESC


--11
GO
CREATE OR ALTER FUNCTION udf_ClientWithCigars(@name VARCHAR(100))
RETURNS INT
AS
BEGIN
	
	DECLARE @cigarCount int = 
	(Select COUNT(*) from Cigars AS ci
	JOIN ClientsCigars AS cc ON cc.CigarId = ci.Id
	JOIN Clients AS cl ON cc.ClientId = cl.Id
	WHERE cl.FirstName = @name
	)
	return @cigarCount
END
GO
SELECT dbo.udf_ClientWithCigars('Betty')


--12
GO
CREATE OR ALTER PROCEDURE usp_SearchByTaste(@taste VARCHAR(100))
AS
BEGIN
SELECT ci.CigarName,
CONCAT('$',CONVERT(varchar,ci.PriceForSingleCigar)) AS Price,
t.TasteType,
b.BrandName,
CONCAT_WS(' ',CONVERT(varchar,s.[Length]),'cm') AS CigarLength,
CONCAT_WS(' ',CONVERT(varchar,s.RingRange),'cm') AS CigarRingRange
FROM Tastes AS t
JOIN Cigars as ci ON ci.TastId = t.Id
JOIN Brands AS b ON ci.BrandId = b.Id
JOIN Sizes AS s ON ci.SizeId = s.Id
WHERE t.TasteType = @taste
ORDER BY CigarLength ASC,CigarRingRange DESC
END
GO
EXEC usp_SearchByTaste 'Woody'