--Databases MSSQL Server Regular Exam - 15 Oct 2023
--1
CREATE TABLE Countries(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) NOT NULL

)
CREATE TABLE Destinations(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Rooms (
Id int Primary KEY Identity(1,1),
[Type] varchar(40) NOT NULL,
[Price] Decimal(18,2) NOT NULL,
BedCount INT NOT NULL  
	CHECK(BedCount>0 AND BedCount<=10)
)
CREATE TABLE Hotels(
Id int PRIMARY KEY Identity(1,1),
[Name] varchar(50) NOT NULL,
DestinationId int NOT NULL FOREIGN KEY REFERENCES Destinations(Id)
)

CREATE Table Tourists(
Id int Primary KEY Identity(1,1),
[Name] nvarchar(80) NOT NULL,
PhoneNumber varchar(20) NOT NULL,
Email varchar(80),
CountryId int NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)
CREATE TABLE Bookings(
Id int PRIMARY KEY IDENTITY(1,1),
ArrivalDate Datetime2 NOT NULL,
DepartureDate Datetime2 NOT NULL,
AdultsCount int NOT NULL CHECK (AdultsCount BETWEEN 1 AND 10),
ChildrenCount int NOT NULL CHECK ( ChildrenCount BETWEEN 0 AND 9),
TouristId int  NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
HotelId int NOT NULL FOREIGN KEY REFERENCES Hotels(Id),
RoomId int NOT NULL FOREIGN KEY REFERENCES Rooms(Id)
)
CREATE TABLE HotelsRooms(
HotelId int NOT NULL,
RoomId int NOT NULL,
Constraint PK_HotelRoom PRIMARY KEY(HotelId,RoomId),
Constraint FK_HotelId FOREIGN KEY(HotelId) References Hotels(Id),
Constraint FK_RoomId FOREIGN KEY(RoomId) REFERENCES Rooms(Id)
)

--2
INSERT INTO Tourists([Name],PhoneNumber,Email,CountryId)
VALUES('John Rivers',	'653-551-1555',	'john.rivers@example.com',	6),
('Adeline Aglaé','122-654-8726',	'adeline.aglae@example.com',	2),
('Sergio Ramirez',	'233-465-2876',	's.ramirez@example.com',	3),
('Johan Müller',	'322-876-9826',	'j.muller@example.com',	7),
('Eden Smith',	'551-874-2234',	'eden.smith@example.com',	6)

INSERT INTO Bookings(ArrivalDate,	DepartureDate,	AdultsCount,	ChildrenCount,	TouristId,	HotelId,	RoomId)
VALUES ('2024-03-01',	'2024-03-11',	1,	0,	21,	3,	5),
('2023-12-28',	'2024-01-06',	2,	1,	22,	13,	3),
('2023-11-15',	'2023-11-20',	1,	2,	23,	19,	7),
('2023-12-05',	'2023-12-09',	4,	0,	24,	6,	4),
('2024-05-01',	'2024-05-07',	6,	0,	25,	14,	6)

--3
UPDATE BOOKINGS
SET DepartureDate=DATEADD(DAY,1,DepartureDate)
WHERE MONTH(ArrivalDate) =12 AND YEAR(ArrivalDate) = 2023

UPDATE Tourists
SET Email =NULL
WHERE [Name] LIKE '%MA%'

--4
BEGIN TRANSACTION;


DELETE FROM Bookings
WHERE TouristId IN (SELECT Id FROM Tourists WHERE Name LIKE '%Smith%');


DELETE FROM Tourists
WHERE Name LIKE '%Smith%';

COMMIT TRANSACTION;

--5
Select FORMAT(b.ArrivalDate,'yyyy-MM-dd') AS ArrivalDate,b.AdultsCount,b.ChildrenCount from Bookings AS b
JOIN Rooms AS r ON r.Id = b.RoomId
order by r.Price DESC, b.ArrivalDate ASC

--6
SELECT h.Id,h.[Name] FROM Hotels AS h
JOIN Bookings AS b ON b.HotelId = h.Id
JOIN HotelsRooms AS hr ON hr.HotelId = h.Id
JOIN Rooms AS r ON r.Id = hr.RoomId
WHERE r.[Type] = 'VIP Apartment'
GROUP BY h.Id,h.[Name], r.[Type]
ORDER BY Count(b.Id) DESC


--7
--t.Id,t.[Name],t.PhoneNumber
SELECT t.Id,t.[Name],t.PhoneNumber FROM Tourists t
LEFT JOIN Bookings AS b ON b.TouristId = t.Id
LEFT JOIN Hotels AS h ON h.Id = b.HotelId
WHERE h.Id is NULL
ORDER BY t.[Name] ASC

--8
SELECT top(10) 
h.[Name], 
d.[Name] AS DestinationName,
c.[Name] AS CountryName
FROM Bookings AS b
JOIN Hotels AS h ON b.HotelId = h.Id
JOIN Destinations AS d ON h.DestinationId = d.Id
JOIN Countries AS c ON c.Id = d.CountryId
where b.HotelId %2=1 AND ArrivalDate <'2023-12-31'
ORDER BY CountryName, ArrivalDate


--9
SELECT h.[Name] AS HotelName,
r.Price AS RoomPrice
FROM Tourists AS t
JOIN  Bookings AS b ON b.TouristId = t.Id
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Rooms AS r ON b.RoomId = r.Id 
WHERE t.[Name] NOT LIKE '%ez'
ORDER by RoomPrice DESC
 
 --10
 SELECT h.Name AS HotelName,
 SUM(r.Price*DATEDIFF(DAY,b.ArrivalDate,b.DepartureDate)) as TotalRevenue
 FROM Bookings AS b
 JOIN Hotels AS h ON b.HotelId = h.Id
 JOIN Rooms AS r ON b.RoomId = r.Id
 GROUP BY h.[Name]
 ORDER BY TotalRevenue DESC

 --11

 CREATE OR ALTER FUNCTION udf_RoomsWithTourists(@name VARCHAR(255)) 
RETURNS INT
AS
BEGIN
    DECLARE @touristCount INT;
	Select @touristCount= SUM(ChildrenCount + AdultsCount)
    FROM Tourists AS t
	JOIN Bookings AS b ON b.TouristId = t.Id
	JOIN Rooms AS r ON b.RoomId = r.Id
    WHERE r.[Type] = @name;
    
    RETURN @touristCount;
END
Select  dbo.udf_RoomsWithTourists('Double Room')

--12
CREATE OR ALTER PROCEDURE usp_SearchByCountry(@country VARCHAR(255)) 
AS
BEGIN
SELECT t.[Name],
t.PhoneNumber,
t.Email,
COUNT(b.Id) AS CountOfBookings
FROM Tourists AS t
JOIN Bookings AS b ON b.TouristId = t.Id
WHERE t.CountryId IN (Select c.Id from Countries c where c.[Name] = @country)
GROUP BY t.[Name],t.PhoneNumber,t.Email
ORDER BY t.[Name] ASC, CountOfBookings DESC
END
exec usp_SearchByCountry 'Greece'