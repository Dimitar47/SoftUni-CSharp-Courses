--Subqueries and Joins Exercises

--1
USE SoftUni
SELECT TOP(5) EmployeeID, JobTitle, e.AddressID, AddressText
FROM Employees AS e
JOIN Addresses a ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC

--2
SELECT TOP(50) e.FirstName, e.LastName, t.[Name], a.AddressText
FROM Employees AS e
JOIN Addresses a ON e.AddressID = a.AddressID 
JOIN Towns t ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName

--3
SELECT TOP(50) e.EmployeeID, e.FirstName, e.LastName, d.[Name]
FROM Employees AS e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] LIKE 'Sales'
ORDER BY e.EmployeeID ASC

--4
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
FROM Employees AS e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary15000
ORDER BY e.DepartmentID ASC

--5
SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID ASC

--6
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
FROM Employees AS e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate  '1.1.1999' AND d.[Name] IN ('Sales','Finance')
ORDER BY e.HireDate ASC

--7
SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name]
FROM Employees AS e
JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE ep.ProjectID IS NOT NULL AND p.StartDateCONVERT(VARCHAR, '08132002', 103)
ORDER BY e.EmployeeID ASC

--8
SELECT TOP(5) e.EmployeeID, e.FirstName,
CASE WHEN p.StartDate '2005' THEN p.[Name] 
	ELSE NULL
END AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24 

--9
SELECT e.EmployeeID, e.FirstName, e.ManagerID,
(
SELECT m.FirstName
FROM Employees AS m
WHERE m.EmployeeID = e.ManagerID
)
FROM Employees AS e
WHERE e.ManagerID IN (3,7) 
ORDER BY e.EmployeeID

--10
SELECT 
	TOP(50)
    EmployeeID,
    FirstName + ' ' + LastName AS EmployeeName,
    (SELECT FirstName + ' ' + LastName FROM Employees WHERE Employees.EmployeeID = e.ManagerID) AS ManagerName,
	(SELECT d.[Name] FROM Departments AS d WHERE e.DepartmentID = d.DepartmentID) AS DepartmentName
FROM 
    Employees AS e
ORDER BY 
    EmployeeID ASC;

--11
SELECT MIN(DepartmentAverages.AvgSalary) AS MinAverageSalary
FROM 
(
    SELECT e.DepartmentID, 
    AVG(e.Salary) AS AvgSalary
    FROM Employees AS e
    GROUP BY e.DepartmentID
) AS DepartmentAverages;



--12
USE [Geography]
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
JOIN Mountains m ON m.Id = mc.MountainId
JOIN Peaks p ON p.MountainId = m.Id
WHERE c.CountryName = 'Bulgaria' and p.Elevation 2835
ORDER BY p.Elevation DESC

--13
SELECT 
    c.CountryCode, 
    COUNT(mc.MountainID) AS MountainRanges
FROM 
    Countries c
JOIN 
    MountainsCountries mc ON c.CountryCode = mc.CountryCode
JOIN 
    Mountains m ON mc.MountainID = m.Id
WHERE 
    c.CountryCode IN ('US', 'RU', 'BG')
GROUP BY 
    c.CountryCode;

--14
SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries c
LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF' AND (r.Id IS NULL OR r.Id IS NOT NULL)
ORDER BY c.CountryName ASC

--15
WITH CurrencyUsage AS (
    SELECT 
        ContinentCode, 
        CurrencyCode, 
        COUNT() AS UsageCount
    FROM 
        Countries
    GROUP BY 
        ContinentCode, 
        CurrencyCode
),
FilteredCurrencyUsage AS (
    SELECT 
        ContinentCode, 
        CurrencyCode, 
        UsageCount
    FROM 
        CurrencyUsage
    WHERE 
        UsageCount  1
),
MostUsedCurrency AS (
    SELECT 
        ContinentCode, 
        CurrencyCode, 
        UsageCount,
        RANK() OVER (PARTITION BY ContinentCode ORDER BY UsageCount DESC) AS rk
    FROM 
        FilteredCurrencyUsage
)
SELECT 
    ContinentCode, 
    CurrencyCode, 
    UsageCount AS CurrencyUsage
FROM 
    MostUsedCurrency
WHERE 
    rk = 1
ORDER BY 
    ContinentCode;



--16
SELECT COUNT() AS [Count]
FROM Countries c
LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains m ON mc.MountainId = m.Id	
WHERE mc.MountainId IS NULL



--17
WITH CountryHighestPeaks AS (
    SELECT
        mc.CountryCode,
        MAX(p.Elevation) AS HighestElevation
    FROM
        MountainsCountries mc
    JOIN Mountains m ON mc.MountainID = m.Id
    JOIN Peaks p ON m.Id = p.MountainID
    GROUP BY
        mc.CountryCode
),
CountryLongestRivers AS (
    SELECT
        cr.CountryCode,
        MAX(r.[Length]) AS LongestRiverLength
    FROM
        CountriesRivers cr
    JOIN Rivers r ON cr.RiverID = r.Id
    GROUP BY
        cr.CountryCode
)
SELECT
TOP(5)
    c.CountryName,
    COALESCE(chp.HighestElevation, 'NULL') AS HighestElevation,
    COALESCE(clr.LongestRiverLength, 'NULL') AS LongestRiverLength
FROM
    Countries c
LEFT JOIN
    CountryHighestPeaks chp ON c.CountryCode = chp.CountryCode
LEFT JOIN
    CountryLongestRivers clr ON c.CountryCode = clr.CountryCode
ORDER BY
    chp.HighestElevation DESC ,
    clr.LongestRiverLength DESC,
    c.CountryName


--18
WITH RankedPeaks AS (
    SELECT
        c.CountryName,
        m.MountainRange,
        p.PeakName,
        p.Elevation,
        ROW_NUMBER() OVER (PARTITION BY c.CountryCode ORDER BY p.Elevation DESC) as [Rank]
    FROM
        Countries c
    LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
    LEFT JOIN Mountains m ON mc.MountainID = m.Id
    LEFT JOIN Peaks p ON m.Id = p.MountainID
)

SELECT TOP(5)
    COALESCE(rp.CountryName, c.CountryName) AS Country,
	COALESCE(rp.PeakName, '(no highest peak)') AS [Highest Peak Name],
    COALESCE(rp.Elevation, 0) AS [Highest Peak Elevation],
	COALESCE(rp.MountainRange, '(no mountain)') AS [Mountain]
FROM
    Countries c
LEFT JOIN
    RankedPeaks rp ON c.CountryName = rp.CountryName
WHERE
    rp.Rank = 1 OR rp.PeakName IS NULL
ORDER BY
    c.CountryName,
    PeakName;
