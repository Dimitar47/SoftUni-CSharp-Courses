--IndicesDataAggregationExercises
use Gringotts
--1
select count(*) as [Count] from WizzardDeposits
--2
select max(MagicWandSize) as [LongestMagicWand] from WizzardDeposits 
--3
select DepositGroup, max(MagicWandSize) as [LongestMagicWand] from WizzardDeposits 
group by DepositGroup

--4 
WITH AvgWandSizes AS (
    SELECT DepositGroup, AVG(MagicWandSize) AS AvgWandSize
    FROM WizzardDeposits
    GROUP BY DepositGroup
)
SELECT top(2) DepositGroup
FROM AvgWandSizes
ORDER BY AvgWandSize ASC

--5
select DepositGroup,Sum(DepositAmount) as [TotalSum] from WizzardDeposits
group by DepositGroup

--6
select DepositGroup,Sum(DepositAmount) as [TotalSum] from WizzardDeposits
where MagicWandCreator = 'Ollivander family'
group by DepositGroup

--7
select DepositGroup,Sum(DepositAmount) as [TotalSum] from WizzardDeposits
where MagicWandCreator = 'Ollivander family'
group by DepositGroup
having Sum(DepositAmount) < 150000
order by [TotalSum] Desc

--8
select DepositGroup, MagicWandCreator,
Min(DepositCharge) as [MinDepositCharge]
from WizzardDeposits
group by DepositGroup, MagicWandCreator
order by MagicWandCreator ASC, DepositGroup ASC

--9
SELECT 
    AgeGroup,
    COUNT(*) AS WizardCount
FROM (
    SELECT 
        CASE 
            WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
            WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
            WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
            WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
            WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
            WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
            WHEN Age >= 61 THEN '[61+]'
        END AS AgeGroup
    FROM WizzardDeposits
) AS AgeGroups
GROUP BY AgeGroup
ORDER BY AgeGroup;


--10
SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE Id IN (
    SELECT DISTINCT Id
    FROM WizzardDeposits
    WHERE DepositGroup = 'Troll Chest'
)
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter;

--11
select DepositGroup ,IsDepositExpired,AVG(DepositInterest) as [AverageInterest] from WizzardDeposits
where DepositStartDate >'01/01/1985'
group by DepositGroup, IsDepositExpired
order by DepositGroup desc, IsDepositExpired asc


--12
SELECT 
    SUM( Host.DepositAmount-Guest.DepositAmount) AS TotalDifference
FROM 
    WizzardDeposits AS Host
JOIN 
    WizzardDeposits AS Guest
ON 
    Host.Id = Guest.Id - 1



use SoftUni

--13
select DepartmentID, Sum(Salary) as [TotalSalary]
from Employees
group by DepartmentID
Order by DepartmentID



--14
select DepartmentID, MIN(Salary) as [MinimumSalary]
from Employees
where DepartmentID in (2,5,7) and HireDate>'01/01/2000'
group by DepartmentID

--15
select *  
into New_Table
from Employees
where Salary >30000

delete from New_Table
where ManagerID = 42

Update New_Table
Set Salary = Salary + 5000
where DepartmentID = 1

select DepartmentID,avg(salary)as AverageSalary  from New_Table
group by DepartmentID


--16
select DepartmentID, max(Salary) as [MaxSalary] from Employees
group by DepartmentID
having max(Salary) not between 30000 and 70000

--17
select count(Salary) as [Count]  from Employees
where ManagerID is null

--18

WITH CTE AS
(
SELECT  DepartmentID, SALARY,
DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY SALARY DESC ) RANK_SALARY
FROM Employees
)
 
SELECT DISTINCT (DepartmentID), SALARY AS ThirdHighestSalary
FROM CTE
WHERE RANK_SALARY = 3;

--19
WITH DepartmentAvgSalary AS (
    SELECT 
        DepartmentID,
        AVG(Salary) AS AvgSalary
    FROM 
        Employees
    GROUP BY 
        DepartmentID
)
select top(10) FirstName,LastName,e.DepartmentID
from Employees e
JOIN DepartmentAvgSalary d on d.DepartmentID = e.DepartmentID
where Salary > AvgSalary
order by DepartmentID

