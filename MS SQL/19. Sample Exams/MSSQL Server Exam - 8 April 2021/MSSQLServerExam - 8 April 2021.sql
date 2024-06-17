--Databases MSSQL Server Retake Exam - 8 April 2021

--1
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY(1,1),
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(50) NOT NULL,
[Name] VARCHAR(50),
Birthdate DATETIME,
Age INT CHECK(AGE BETWEEN 14 AND 110),
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(25),
LastName VARCHAR(25),
Birthdate DATETIME,
Age INT CHECK(AGE BETWEEN 18 AND 110),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id)
)
CREATE TABLE [Status](
Id INT PRIMARY KEY IDENTITY(1,1),
[Label] VARCHAR(20) NOT NULL
)
CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY(1,1),
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
StatusId INT NOT NULL FOREIGN KEY REFERENCES [Status](Id),
OpenDate DATETIME NOT NULL,
CloseDate DATETIME,
[Description] VARCHAR(200) NOT NULL,
UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
EmployeeId INT  FOREIGN KEY REFERENCES Employees(Id)
)

--2
INSERT INTO Employees(FirstName,	LastName,	Birthdate,	DepartmentId)
VALUES ('Marlo','O''Malley',	'1958-9-21',	1),
('Niki','Stanaghan','1969-11-26',4),
('Ayrton','Senna',	'1960-03-21',	9),
('Ronnie','Peterson','1944-02-14',9),
('Giovanna','Amati','1959-07-20',5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,[Description],UserId,EmployeeId)
VALUES (1,1,'2017-04-13',NULL,'Stuck Road on Str.133',6,2),
(6,3,'2015-09-05','2015-12-06','Charity trail running',3,5),
(14,2,'2015-09-07',NULL,'Falling bricks on Str.58',5,2),
(4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)

--3
UPDATE Reports 
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--4
DELETE FROM Reports WHERE [StatusId] =4

--5
SELECT r.[Description],
FORMAT(r.OpenDate,'dd-MM-yyyy') AS OpenDate
FROM Reports AS r
WHERE r.EmployeeId IS NULL
ORDER BY r.OpenDate ASC,r.[Description] ASC

--6
SELECT r.[Description],
c.[Name] AS CategoryName
FROM Reports AS r
RIGHT JOIN Categories AS c ON r.CategoryId = c.Id
WHERE r.CategoryId is not null
ORDER BY r.[Description] ASC, c.[Name] ASC


--7
SELECT TOP(5)
c.[Name] AS CategoryName,
COUNT(r.Id) AS ReportsNumber
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC,CategoryName ASC


--8
SELECT u.Username,
c.[Name] AS CategoryName/*,
u.Birthdate,
r.OpenDate,
r.CloseDate*/
FROM Reports AS r
JOIN Users AS u ON r.UserId = u.Id
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE ( DATEPART(WEEK,u.Birthdate) = DATEPART(WEEK,r.OpenDate)
AND DATEPART(DAY,u.Birthdate) = DATEPART(DAY,r.OpenDate)
) /*OR(
  DATEPART(WEEK,u.Birthdate) = DATEPART(WEEK,r.CloseDate)
AND DATEPART(DAY,u.Birthdate) = DATEPART(DAY,r.CloseDate)
)*/
ORDER BY u.Username ASC, c.[Name] ASC


--9
SELECT 
CONCAT_WS(' ',e.FirstName,e.LastName) AS FullName,
COUNT(u.Id) AS UsersCount
FROM Reports AS r
RIGHT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
GROUP BY e.FirstName,e.LastName
ORDER BY UsersCount DESC, FullName ASC

--10
SELECT 
	IIF(e.FirstName IS NULL AND e.LastName IS NULL, 'None', e.FirstName + ' ' + e.LastName) AS Employee,
    IIF(d.Name IS NULL, 'None', d.Name) AS Department,
    ISNULL(c.[Name], 'None') AS Category,
    ISNULL(r.[Description], 'None') AS [Description],
    ISNULL(FORMAT(r.OpenDate, 'dd.MM.yyyy'), 'None') AS OpenDate,
    ISNULL(s.[Label], 'None') AS [Status],
    ISNULL(u.[Name], 'None') AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
LEFT JOIN Status AS s ON r.StatusId = s.Id
LEFT JOIN Users AS u on r.UserId = u.Id
ORDER BY
	e.FirstName DESC,
	e.LastName DESC, 
	Department,
	Category, 
	Description, 
	OpenDate, 
	Status, 
	User



--11
GO
CREATE OR ALTER FUNCTION udf_HoursToComplete (@StartDate DATETIME,
												@EndDate DATETIME)
RETURNS INT
AS
BEGIN
    DECLARE @TotalHours INT;

  
    IF @StartDate IS NULL OR @EndDate IS NULL
    BEGIN
        RETURN 0;
    END

    -- Calculate the total hours between the start date and end date
    SET @TotalHours = DATEDIFF(HOUR, @StartDate, @EndDate);

    RETURN @TotalHours;
END
GO
SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

--12
GO
CREATE OR ALTER PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT,
													@ReportId INT)
AS 
BEGIN
	 DECLARE @EmployeeDepartmentId INT = (
	 	 SELECT DepartmentId FROM Employees AS e
	 WHERE e.Id = @EmployeeId
	 )
     DECLARE @ReportDepartmentId INT=(
	 SELECT c.DepartmentId FROM Reports AS r
	 JOIN Categories AS c ON r.CategoryId = c.Id
	 WHERE r.Id = @ReportId
	 )
	 IF(@ReportDepartmentId = @EmployeeDepartmentId)
	 BEGIN
		 UPDATE Reports
        SET EmployeeId = @EmployeeId
        WHERE Id = @ReportId;
	 END
	 ELSE
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
END
GO
EXEC usp_AssignEmployeeToReport 17, 2
EXEC usp_AssignEmployeeToReport 30, 1




