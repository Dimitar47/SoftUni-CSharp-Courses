--Databases MSSQL Server Exam - 21 Jun 2020


--1
CREATE TABLE Cities
(
    Id int PRIMARY KEY IDENTITY,
    Name NVARCHAR(20) NOT NULL,
    CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(30) NOT NULL,
    CityId INT NOT NULL REFERENCES Cities(Id),
    EmployeeCount INT NOT NULL,
    BaseRate DECIMAL(8, 2)
)

CREATE TABLE Rooms
(
    Id INT PRIMARY KEY IDENTITY,
    Price DECIMAL(8, 2) NOT NULL,
    Type NVARCHAR(20) NOT NULL,
    Beds INT NOT NULL,
    HotelId INT NOT NULL REFERENCES Hotels(Id)
)

CREATE TABLE Trips
(
    Id INT PRIMARY KEY IDENTITY,
    RoomId INT NOT NULL REFERENCES Rooms(Id),
    BookDate DATE NOT NULL,
    ArrivalDate DATE NOT NULL,
    ReturnDate DATE NOT NULL,
    CancelDate DATE,
    CHECK (BookDate < ArrivalDate),
    CHECK (ArrivalDate < ReturnDate)    
)

CREATE TABLE Accounts
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(20),
    LastName NVARCHAR(50) NOT NULL,
    CityId INT NOT NULL REFERENCES Cities(Id),
    BirthDate Date NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips
(
    AccountId INT NOT NULL REFERENCES Accounts(Id),
    TripId INT NOT NULL REFERENCES Trips(Id),
    Luggage INT NOT NULL CHECK (Luggage >= 0)
    PRIMARY KEY (AccountId, TripId)
)

--2
INSERT INTO Accounts(FirstName,	MiddleName,	LastName,	CityId,	BirthDate,	Email)
VALUES ('John',	'Smith',	'Smith',	34,	'1975-07-21',	'j_smith@gmail.com'),
		('Gosho',	NULL,	'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
		('Ivan',	'Petrovich',	'Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
		('Friedrich',	'Wilhelm',	'Nietzsche',	2,	'1844-10-15',	'f_nietzsche@softuni.bg')


INSERT INTO Trips(RoomId,	BookDate,	ArrivalDate,	ReturnDate,	CancelDate)
VALUES  (101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
		(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
		(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
		(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
		(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

--3
UPDATE Rooms
SET Price = Price + Price * 0.14
WHERE HotelId IN(5,7,9)

--4
DELETE FROM AccountsTrips
WHERE AccountId = 47 


--5
SELECT FirstName,	LastName,
FORMAT(BirthDate,'MM-dd-yyyy') AS BirthDate,	
c.[Name] AS Hometown,
Email FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
WHERE SUBSTRING(Email,1,1) = 'e'
ORDER BY Hometown

--6
SELECT
c.[Name] AS City,
COUNT(h.Id) AS Hotels
FROM Cities AS c
JOIN Hotels AS h ON h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY Hotels DESC, c.[Name]

--7
SELECT 
a.Id,
CONCAT_WS(' ',a.FirstName,a.LastName) AS FullName,
MAX(DATEDIFF(DAY,ArrivalDate,ReturnDate)) AS LongestTrip,
MIN(DATEDIFF(DAY,ArrivalDate,ReturnDate)) AS ShortestTrip
FROM Accounts AS a
JOIN AccountsTrips AS ac ON ac.AccountId = a.Id
JOIN Trips AS t ON ac.TripId = t.Id
WHERE t.CancelDate is null AND a.MiddleName is null
GROUP BY a.Id,a.FirstName,a.LastName
ORDER BY LongestTrip DESC,ShortestTrip ASC


--8
SELECT TOP 10 c.Id,
c.[Name] AS City,
c.CountryCode AS Country,
COUNT(*) AS Accounts
FROM Cities AS c
JOIN Accounts AS a ON a.CityId = c.Id
GROUP BY c.Id,c.[Name],c.CountryCode
ORDER BY Accounts DESC

--9
SELECT
    a.Id,
    a.Email,
    c.[Name] AS City,
    COUNT(t.Id) AS Trips
FROM
    Accounts a
     JOIN Cities c ON a.CityId = c.Id
	 JOIN AccountsTrips  ap ON ap.AccountId = a.Id
     JOIN Trips t ON ap.TripId = t.Id
     JOIN Rooms r ON t.RoomId = r.Id
     JOIN Hotels h ON r.HotelId = h.Id AND h.CityId = c.Id  
GROUP BY
    a.Id,
   a.Email,
    c.[Name]
HAVING
    COUNT(t.Id) > 0 
ORDER BY
    COUNT(t.Id) DESC, 
    a.Id;   

GO


--10
WITH AccountHomeTown AS(
SELECT a.Id,
a.FirstName,
a.MiddleName,
a.LastName,
c.[Name] FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
),
HotelCity AS(
SELECT h.Id,
h.CityId,
c.[Name] FROM Hotels AS h
JOIN Cities AS c ON h.CityId = c.Id
)
SELECT 
t.Id,
CONCAT_WS(' ',ah.FirstName,ah.MiddleName,ah.LastName) AS [Full Name],
ah.[Name] AS [From] ,
hc.[Name] AS [To],
CASE 
 WHEN t.CancelDate IS NULL THEN	CONVERT(VARCHAR,DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) + ' days'
 ELSE 'Canceled'
END AS Duration
FROM AccountHomeTown AS ah
	 JOIN AccountsTrips  ap ON ap.AccountId = ah.Id
     JOIN Trips t ON ap.TripId = t.Id
	 JOIN Rooms AS r ON t.RoomId = r.Id
	 JOIN HotelCity AS hc ON hc.Id  = r.HotelId
ORDER BY [Full Name], t.Id

--11
GO
CREATE OR ALTER FUNCTION udf_GetAvailableRoom (@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @Result NVARCHAR(255);

    WITH AvailableRooms AS (
        SELECT
            r.Id AS RoomId,
            r.[Type] AS RoomType,
            r.Beds,
            (h.BaseRate + r.Price) * @People AS TotalPrice
        FROM
            Rooms r
            JOIN Hotels h ON r.HotelId = h.Id
        WHERE
            r.HotelId = @HotelId
            AND r.Beds >= @People
            AND NOT EXISTS (
                SELECT 1
                FROM Trips t
                WHERE t.RoomId = r.Id
                AND t.CancelDate IS NULL
                AND @Date BETWEEN t.ArrivalDate AND t.ReturnDate
            )
    )
    SELECT TOP 1
        @Result = 'Room ' + CAST(RoomId AS NVARCHAR(10)) + ': ' + RoomType +
                  ' (' + CAST(Beds AS NVARCHAR(10)) + ' beds) - $' + CAST(TotalPrice AS NVARCHAR(20))
    FROM
        AvailableRooms
    ORDER BY
        TotalPrice DESC

    IF @Result IS NULL
    BEGIN
        SET @Result = 'No rooms available'
    END

    RETURN @Result
END
GO
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2) --BASE RATE = 13.90
														--HotelId = 112
														--RoomId 211 
														--RoomPrice = 87.50
														--Beds = 5
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
SELECT dbo.udf_GetAvailableRoom(6, '2012-11-01', 2)						

--12
GO
CREATE OR ALTER PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN

DECLARE @tripHotelId INT = 
(SELECT TOP 1 h.Id FROM Rooms AS r
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Trips AS t ON t.RoomId = r.Id
WHERE t.Id = @TripId)

DECLARE @targetRoomHotelId INT = 
(SELECT TOP(1) h.Id FROM Hotels AS h
JOIN Rooms AS r ON r.HotelId = h.Id
WHERE r.Id = @TargetRoomId)

If(@tripHotelId != @targetRoomHotelId)
THROW 50001,'Target room is in another hotel!',1
DECLARE @tripAccountsBeds INT = 
		(SELECT COUNT(*) FROM Accounts AS a 
		JOIN AccountsTrips AS ap ON ap.TripId = a.Id
		JOIN Trips AS t ON ap.TripId = t.Id
		WHERE t.Id = @TripId)

DECLARE @targetRoomBeds INT = 
(SELECT r.Beds FROM Rooms AS r
WHERE r.Id = @TargetRoomId)

IF(@tripAccountsBeds >@targetRoomBeds)
THROW 50002,'Not enough beds in target room!',1	

UPDATE Trips
SET RoomId = @TargetRoomId
WHERE Id=@TripId
END
GO
EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8

