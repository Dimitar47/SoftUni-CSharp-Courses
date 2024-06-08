-- Exercises: Database Introduction

--1
CREATE DATABASE Minions

--2
USE Minions

CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

--3
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)


--4
INSERT INTO Towns(Id,[Name])
VALUES (1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna');

INSERT INTO Minions(Id,[Name],Age,TownId)
VALUES (1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2);


--5
TRUNCATE TABLE Minions

--6
DROP TABLE Minions
DROP TABLE Towns

--7
CREATE TABLE People(
Id INT IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR(200) Not Null,
Picture VARBINARY(MAX),
Height DECIMAL(5,2),
[Weight] DECIMAL(5,2),
Gender CHAR(1) Not Null,
BirthDate DATE Not Null,
Biography NVARCHAR(max)
);

INSERT INTO People([Name], Picture, Height, [Weight], Gender, BirthDate, Biography)
				VALUES ('Dimitar',NULL,1.75,62.5,'m','2001-10-18', NULL),
				('Cvetelina',NULL,1.60,40.55,'f','2012-02-13', NULL),
				('Bojidar',NULL,1.70,75.55,'m','2008-03-19', NULL),
				('Veselin',NULL,1.80,60.35,'m','2003-01-29', NULL),
				('Kristiqn',NULL,1.30,25.35,'m','2019-05-30', NULL)


--8
CREATE TABLE Users(
Id INT IDENTITY(1,1) PRIMARY KEY,
Username VARCHAR(30) UNIQUE NOT NULL ,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(max),
LastLoginTime DATETIME,
IsDeleted BIT
);

INSERT INTO Users(Username,[Password],ProfilePicture,LastLoginTime, IsDeleted)
VALUES ('user1', 'password1', NULL, '2024-05-10 08:00:00', 0),
('user2', 'password2', NULL, '2024-05-11 09:00:00', 0),
('user3', 'password3', NULL, '2024-05-12 10:00:00', 0),
('user4', 'password4', NULL, '2024-05-13 11:00:00', 0),
('user5', 'password5', NULL, '2024-05-14 12:00:00', 0);

--9
ALTER TABLE Users
	DROP CONSTRAINT PK_Users

ALTER TABLE Users
	ADD CONSTRAINT PK_Users 
	PRIMARY KEY (Id, Username)

--10
ALTER TABLE Users
ADD CONSTRAINT Check_PasswordLength
	CHECK (LEN([Password]) >= 5)

--11
ALTER TABLE Users
ADD CONSTRAINT Default_LastLoginTime
DEFAULT GETDATE() FOR [LastLoginTime]

--12
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users
Primary KEY(Id)

ALTER TABLE [Users]
ADD CONSTRAINT CHK_Usernames CHECK (LEN(Username) >= 3)


--13
CREATE TABLE Directors(
Id INT IDENTITY(1,1),
DirectorName NVARCHAR(255) NOT NULL,
Notes nvarchar(255),
CONSTRAINT PK_DirectorId PRIMARY KEY(Id) 
);

CREATE TABLE Genres(
Id INT IDENTITY(1,1),
GenreName NVARCHAR(255) NOT NULL,
Notes NVARCHAR(255),
CONSTRAINT PK_GenreId PRIMARY KEY(Id)
);

CREATE TABLE Categories(
Id INT IDENTITY(1,1),
CategoryName NVARCHAR(255) NOT NULL,
Notes NVARCHAR(255),
CONSTRAINT PK_CategoryId PRIMARY KEY(Id)
);

CREATE TABLE Movies(
Id INT IDENTITY(1,1),
Title NVARCHAR(255) NOT NULL,
DirectorId INT,
CopyrightYear INT,
[Length] INT,
GenreId INT,
CategoryId INT,
Rating INT,
Notes NVARCHAR(255),
CONSTRAINT PK_MovieId PRIMARY KEY(Id),
CONSTRAINT FK_MovieDirector FOREIGN KEY(DirectorId) REFERENCES Directors(Id),
CONSTRAINT FK_MovieGenre FOREIGN KEY(GenreId) REFERENCES Genres(Id),
CONSTRAINT FK_MovieCategory FOREIGN KEY(CategoryId) REFERENCES Categories(Id)
);

INSERT INTO Directors(DirectorName,Notes)
VALUES ('Pesho', NULL),
('Sasho',NULL),
('Tosho', NULL),
('Gosho',NULL),
('Sho', NULL);

INSERT INTO Genres(GenreName,Notes)
VALUES ('Horror', NULL),
('Action',NULL),
('Comedy', NULL),
('Science-fiction',NULL),
('Anime', NULL);

INSERT INTO Categories(CategoryName,Notes)
VALUES ('Category1', NULL),
('Category2',NULL),
('Category3', NULL),
('Category4',NULL),
('Category5', NULL);

INSERT INTO Movies(Title,DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Rating,Notes)
			VALUES ('Title1',1,2010,25,1,1,4,NULL),
				   ('Title2',2,2011,24,2,2,3,NULL),
				   ('Title3',3,2012,23,3,3,2,NULL),
				   ('Title4',4,2013,22,4,4,1,NULL), 
				   ('Title5',5,2014,21,5,5,2, NULL);

--14
CREATE TABLE Categories(
Id INT IDENTITY(1,1),
CategoryName NVARCHAR(255) NOT NULL,
DailyRate INT,
WeeklyRate INT,
MonthlyRate INT,
WeekendRate INT,
CONSTRAINT PK_Category PRIMARY KEY(Id)
);
CREATE TABLE Cars(
Id INT IDENTITY(1,1),
PlateNumber NVARCHAR(255) NOT NULL,
Manufacturer NVARCHAR(255) NOT NULL,
Model NVARCHAR(255),
CarYear INT,
CategoryId INT NOT NULL,
Doors INT,
Picture VARBINARY(MAX),
Condition NVARCHAR(255),
Available BIT
CONSTRAINT PK_Car PRIMARY KEY(Id),
CONSTRAINT FK_CarCategory FOREIGN KEY(CategoryId) REFERENCES Categories(Id)
);

CREATE TABLE Employees(
Id INT IDENTITY(1,1),
FirstName NVARCHAR(255),
LastName NVARCHAR(255),
Title NVARCHAR(255),
Notes NVARCHAR(255),
CONSTRAINT PK_Employee PRIMARY KEY(Id),
);

CREATE TABLE Customers(
Id INT IDENTITY(1,1),
DriverLicenceNumber NVARCHAR(255),
FullName NVARCHAR(255),
[Address] NVARCHAR(255),
City NVARCHAR(255),
ZIPCode INT,
Notes NVARCHAR(255),
CONSTRAINT PK_Customer PRIMARY KEY(Id)
);

CREATE TABLE RentalOrders (
Id INT IDENTITY(1,1), 
EmployeeId INT,
CustomerId INT, 
CarId INT, 
TankLevel DECIMAL, 
KilometrageStart DECIMAL,
KilometrageEnd DECIMAL, 
TotalKilometrage DECIMAL,
StartDate DATE,
EndDate DATE,
TotalDays INT,
RateApplied DECIMAL,
TaxRate decimal,
OrderStatus bit,
Notes nvarchar(255),
CONSTRAINT PK_RentalOrder PRIMARY KEY(Id),
CONSTRAINT FK_RentalOrderEmployee FOREIGN KEY(EmployeeId) REFERENCES Employees(Id),
CONSTRAINT FK_RentalOrderCustomer FOREIGN KEY(CustomerId) REFERENCES Customers(Id),
CONSTRAINT FK_RentalOrderCar FOREIGN KEY(CarId) REFERENCES Cars(Id)
);

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES('Category1',Null,Null,Null,Null),
('Category2',Null,Null,Null,Null),
('Category3',Null,Null,Null,Null);

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES ('PlateNumber1','Manufacturer1',Null,Null,1,Null,Null,Null,Null),
('PlateNumber2','Manufacturer2',Null,Null,2,Null,Null,Null,Null),
('PlateNumber3','Manufacturer3',Null,Null,3,Null,Null,Null,Null);


INSERT INTO Employees ( FirstName, LastName, Title, Notes)
VALUES (Null,Null,Null,Null),
(Null,Null,Null,Null),
(Null,Null,Null,Null);


INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES (Null,Null,Null,Null,Null,Null),
(Null,Null,Null,Null,Null,Null),
(Null,Null,Null,Null,Null,Null);

INSERT INTO RentalOrders(EmployeeId, CustomerId,CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage,
						StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES(1,1,1,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null),
(2,2,2,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null),
(3,3,3,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null);

--15
CREATE TABLE Employees (
Id INT IDENTITY(1,1),
FirstName NVARCHAR(255),
LastName NVARCHAR(255),
Title NVARCHAR(255),
Notes NVARCHAR(255),
CONSTRAINT PK_Employee PRIMARY KEY(Id)
);



CREATE TABLE Customers (
AccountNumber NVARCHAR(255),
FirstName NVARCHAR(255),
LastName NVARCHAR(255),
PhoneNumber NVARCHAR(255),
EmergencyName NVARCHAR(255),
EmergencyNumber NVARCHAR(255),
Notes NVARCHAR(255),
CONSTRAINT PK_Customer PRIMARY KEY(AccountNumber)
);

CREATE TABLE RoomStatus (
RoomStatus NVARCHAR(255),
Notes NVARCHAR(255),
CONSTRAINT PK_RoomStatus PRIMARY KEY(RoomStatus)
);
CREATE TABLE RoomTypes (
RoomType NVARCHAR(255), 
Notes NVARCHAR(255),
CONSTRAINT PK_RoomType PRIMARY KEY(RoomType)
);
CREATE TABLE BedTypes (
BedType NVARCHAR(255), 
Notes NVARCHAR(255),
CONSTRAINT PK_BedType PRIMARY KEY(BedType)
);

CREATE TABLE  Rooms (
RoomNumber INT,
RoomType NVARCHAR(255),
BedType NVARCHAR(255),
Rate DECIMAL,
RoomStatus NVARCHAR(255),
Notes NVARCHAR(255),
CONSTRAINT PK_Room PRIMARY KEY(RoomNumber),
CONSTRAINT FK_RoomType FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
CONSTRAINT FK_BedType FOREIGN KEY(BedType) REFERENCES BedTypes(BedType),
CONSTRAINT FK_RoomStatus FOREIGN KEY(RoomStatus) REFERENCES RoomStatus(RoomStatus)
);
CREATE TABLE  Payments 
(Id INT IDENTITY(1,1),
EmployeeId INT,
PaymentDate DATE,
AccountNumber NVARCHAR(255),
FirstDateOccupied DATE, 
LastDateOccupied DATE,
TotalDays INT,
AmountCharged DECIMAL,
TaxRate DECIMAL,
TaxAmount DECIMAL,
PaymentTotal DECIMAL,
Notes NVARCHAR(255),
CONSTRAINT PK_Payment PRIMARY KEY (Id),
CONSTRAINT  FK_PaymentEmployee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
CONSTRAINT FK_PaymentAccountNumber FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber)
);
CREATE TABLE   Occupancies (
Id INT IDENTITY(1,1),
EmployeeId INT,
DateOccupied DATE,
AccountNumber NVARCHAR(255),
RoomNumber INT,
RateApplied DECIMAL,
PhoneCharge DECIMAL,
Notes NVARCHAR(255),
CONSTRAINT PK_Occupancy PRIMARY KEY (Id),
CONSTRAINT FK_OccupancyEmployee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
CONSTRAINT FK_OccupancyCustomer FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
CONSTRAINT FK_OccupancyRoomNumber FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber)
);


INSERT INTO  Employees (FirstName, LastName, Title, Notes)
VALUES (Null,Null,Null,Null),
(Null,Null,Null,Null),
(Null,Null,Null,Null);

INSERT INTO  Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES ('AccountNumber1',Null,Null,Null,Null,Null,Null),
('AccountNumber2',Null,Null,Null,Null,Null,Null),
('AccountNumber3',Null,Null,Null,Null,Null,Null);

INSERT INTO  RoomStatus (RoomStatus, Notes)
VALUES ('RoomStatus1',Null),
('RoomStatus2',Null),
('RoomStatus3',Null);

INSERT INTO  RoomTypes (RoomType, Notes)
VALUES ('RoomType1',Null),
('RoomType2',Null),
('RoomType3',Null);

INSERT INTO BedTypes (BedType, Notes)
VALUES ('BedType1',Null),
('BedType2',Null),
('BedType3',Null);

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES (100,'RoomType1','BedType1',Null,'RoomStatus1',Null),
(101,'RoomType2','BedType2',Null,'RoomStatus2',Null),
(102,'RoomType3','BedType3',Null,'RoomStatus3',Null);

INSERT INTO Payments ( EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays,
					AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES (1,Null,'AccountNumber1',Null,Null,Null,Null,Null,Null,Null,Null),
(2,Null,'AccountNumber2',Null,Null,Null,Null,Null,Null,Null,Null),
(3,Null,'AccountNumber3',Null,Null,Null,Null,Null,Null,Null,Null);

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES (1,Null,'AccountNumber1',100,Null,Null,Null),
(2,Null,'AccountNumber2',101,Null,Null,Null),
(3,Null,'AccountNumber3',102,Null,Null,Null);

--16
-- Create the database
CREATE DATABASE SoftUni;

-- Use the SoftUni database
USE SoftUni;


CREATE TABLE Towns (
    Id INT IDENTITY PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL
);


CREATE TABLE Addresses (
    Id INT IDENTITY PRIMARY KEY,
    AddressText VARCHAR(255) NOT NULL,
    TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
);

-- Create the Departments table
CREATE TABLE Departments (
    Id INT IDENTITY PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL
);

-- Create the Employees table
CREATE TABLE Employees (
    Id INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR(100) NOT NULL,
    MiddleName VARCHAR(100),
    LastName VARCHAR(100) NOT NULL,
    JobTitle VARCHAR(100) NOT NULL,
    DepartmentId INT NOT NULL,
    HireDate DATE NOT NULL,
    Salary DECIMAL(15, 2) NOT NULL,
    AddressId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);


--17
USE [master];
GO

-- Command to backup the 'SoftUni' database
BACKUP DATABASE [SoftUni]
TO DISK = 'D:\Users\admin\Desktop\C# DB_SoftUni\MS SQL - May 2024\3. Exercise - Databases Introduction\softuni-backup.bac'
WITH INIT, NAME = 'SoftUni Full Backup', NOSKIP, NOFORMAT;


-- Set the database to single user mode to drop it
ALTER DATABASE [SoftUni] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

-- Command to drop the 'SoftUni' database
DROP DATABASE [SoftUni];

-- Command to restore the 'SoftUni' database from a backup file
RESTORE DATABASE [SoftUni]
FROM DISK = 'D:\Users\admin\Desktop\C# DB_SoftUni\MS SQL - May 2024\3. Exercise - Databases Introduction\softuni-backup.bac'
WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10;

--18

USE SoftUni;


INSERT INTO Towns ([Name])
VALUES 
    ('Sofia'),
    ('Plovdiv'),
    ('Varna'),
    ('Burgas');


INSERT INTO Departments ([Name])
VALUES 
    ('Engineering'),
    ('Sales'),
    ('Marketing'),
    ('Software Development'),
    ('Quality Assurance');


INSERT INTO Addresses (AddressText, TownId)
VALUES 
    ('Address 1', 1), 
    ('Address 2', 2),
    ('Address 3', 3),
    ('Address 4', 4),
    ('Address 5', 1);


INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES 
    ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 
        (SELECT Id FROM Departments WHERE [Name] = 'Software Development'), 
        '2013-02-01', 3500.00, 
        (SELECT Id FROM Addresses WHERE AddressText = 'Address 1')),

    ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 
        (SELECT Id FROM Departments WHERE Name = 'Engineering'), 
        '2004-03-02', 4000.00, 
        (SELECT Id FROM Addresses WHERE AddressText = 'Address 2')),

    ('Maria', 'Petrova', 'Ivanova', 'Intern', 
        (SELECT Id FROM Departments WHERE Name = 'Quality Assurance'), 
        '2016-08-28', 525.25, 
        (SELECT Id FROM Addresses WHERE AddressText = 'Address 3')),

    ('Georgi', 'Teziev', 'Ivanov', 'CEO', 
        (SELECT Id FROM Departments WHERE Name = 'Sales'), 
        '2007-12-09', 3000.00, 
        (SELECT Id FROM Addresses WHERE AddressText = 'Address 4')),

    ('Peter', 'Pan', 'Pan', 'Intern', 
        (SELECT Id FROM Departments WHERE Name = 'Marketing'), 
        '2016-08-28', 599.88, 
        (SELECT Id FROM Addresses WHERE AddressText = 'Address 5'));


--19
SELECT * FROM Towns	
SELECT * FROM Departments
SELECT * FROM Employees

--20
SELECT * FROM Towns ORDER BY [Name];
SELECT * FROM Departments ORDER BY [Name];
SELECT * FROM Employees ORDER BY Salary DESC;

--21
SELECT [Name] FROM Towns ORDER BY [Name];
SELECT [Name] FROM Departments ORDER BY [Name];
SELECT FirstName,LastName,JobTitle,Salary FROM Employees ORDER BY Salary DESC;

--22
UPDATE Employees
SET Salary = Salary + 0.1 * Salary;
SELECT Salary FROM Employees;

--23
UPDATE Payments
SET TaxRate = TaxRate - 0.03 * TaxRate;
SELECT TaxRate from Payments;

--24
DELETE  FROM Occupancies;