--Built-in Functions: Exercises

--1

SELECT FirstName, LastName 
FROM Employees
WHERE FirstName LIKE 'Sa%'

--2
SELECT FirstName, LastName 
FROM Employees
WHERE LastName LIKE '%ei%'

--3
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3,10)
AND DATEPART(Year,HireDate) BETWEEN 1995 AND 2005

--4
SELECT FirstName,LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--5
SELECT [Name]
FROM Towns
WHERE LEN([Name]) IN (5,6)
ORDER BY [Name] ASC

--6
SELECT *
FROM Towns
WHERE LEFT([Name],1) IN ('M','K','B','E')
ORDER BY [Name] ASC

--7
SELECT *
FROM Towns
WHERE LEFT([Name],1) NOT IN ('R','B','D')
ORDER BY [Name] ASC

--8
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
(SELECT FirstName,LastName
FROM Employees
WHERE YEAR(Hiredate)>2000
)
GO

--9
SELECT Firstname, LastName
FROM Employees
WHERE LEN(LastName) = 5

--10
SELECT 
	EmployeeID, 
	FirstName,
	LastName,
	Salary,
	DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM 
	Employees
WHERE
	Salary BETWEEN 10000 AND 50000
ORDER BY  
	Salary DESC


--11
WITH RankedEmployees AS (
    SELECT 
        EmployeeID,
        FirstName,
        LastName,
        Salary,
        DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
    FROM 
        Employees
    WHERE 
        Salary BETWEEN 10000 AND 50000
)
SELECT 
    EmployeeID,
    FirstName,
    LastName,
    Salary,
    [Rank]
FROM 
    RankedEmployees
WHERE 
    [Rank] = 2
ORDER BY 
    Salary DESC;

--12
USE [Geography]
SELECT CountryName AS 'Country Name',IsoCode AS 'Iso Code'
FROM Countries
WHERE  LEN(CountryName) - LEN(REPLACE(LOWER(CountryName), 'a', '')) >= 3
ORDER BY IsoCode

--13
SELECT PeakName, RiverName,SUBSTRING(LOWER(PeakName),1,LEN(PeakName)-1) + LOWER(Rivername) as Mix
FROM Peaks
JOIN Rivers ON RIGHT(PeakName,1) = LEFT(RiverName,1)
ORDER BY Mix

--14
USE Diablo
SELECT TOP(50) [Name],FORMAT([Start], 'yyyy-MM-dd') as [Start]
FROM Games
WHERE YEAR([Start]) IN (2011,2012)
ORDER BY [Start],[Name]

--15
SELECT Username, SUBSTRING(
							Email,
							CHARINDEX('@', Email)+1,
							LEN(Email) - CHARINDEX('@', Email)+1) 
							AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

--16
SELECT Username, IpAddress as [IP Address]
FROM Users
WHERE IpAddress LIKE ('___.1%.%.___')
ORDER BY  Username

--17
SELECT 
    [Name],
    CASE
        WHEN DATEPART(Hour,[Start]) >= 0 AND DATEPART(Hour,[Start]) < 12 THEN 'Morning'
        WHEN DATEPART(Hour,[Start]) >= 12 AND DATEPART(Hour,[Start]) < 18 THEN 'Afternoon'
        WHEN DATEPART(Hour,[Start]) >= 18 AND DATEPART(Hour,[Start]) < 24 THEN 'Evening'
    END AS [Part of the Day],
    CASE
        WHEN Duration IS NULL THEN 'Extra Long'
        WHEN Duration <= 3 THEN 'Extra Short'
        WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
        WHEN Duration > 6 THEN 'Long'
    END AS Duration
FROM 
    Games
ORDER BY 
    [Name] ASC,
    Duration ASC,
    [Part of the Day] ASC;

--18
USE Orders
SELECT ProductName, OrderDate,
DATEADD(DAY,3,OrderDate) AS [Pay Due],
DATEADD(Month,1,OrderDate) AS [Deliver Due]
FROM Orders

--19
CREATE DATABASE People
USE People
CREATE TABLE People (
    Id INT PRIMARY KEY,
    [Name] VARCHAR(50),
    Birthdate DATETIME
);

INSERT INTO People (Id, [Name], Birthdate) VALUES
(1, 'Victor', '2000-12-07 00:00:00.000'),
(2, 'Steven', '1992-09-10 00:00:00.000'),
(3, 'Stephen', '1910-09-19 00:00:00.000'),
(4, 'John', '2010-01-06 00:00:00.000');


SELECT
    [Name],
    DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
    DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
    DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
    DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM
    People;

