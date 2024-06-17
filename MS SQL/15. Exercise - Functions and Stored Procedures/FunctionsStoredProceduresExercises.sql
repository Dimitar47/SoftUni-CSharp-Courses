--Functions and Stored Procedures Exercises
--1
Use SoftUni

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
    SELECT FirstName, LastName 
    FROM Employees
    WHERE Salary > 35000;
END;
exec  usp_GetEmployeesSalaryAbove35000;

--2

create procedure usp_GetEmployeesSalaryAboveNumber(@number Decimal(18,4))
as
begin
select FirstName,LastName from Employees
where Salary >=@number
end
exec usp_GetEmployeesSalaryAboveNumber 48100


--3
create procedure usp_GetTownsStartingWith (@name varchar(50))
as
begin
select [Name] from Towns
where [Name] like @name +'%'
end
exec usp_GetTownsStartingWith 'b'

--4
create procedure usp_GetEmployeesFromTown  (@name varchar(50))
as
begin
select FirstName as 'First Name', LastName as 'Last Name' from Employees e
Join Addresses a on e.AddressID = a.AddressID
Join Towns t on a.TownID = t.TownID
where t.[Name] = @name
end
exec usp_GetEmployeesFromTown 'Sofia'

select * from Employees where AddressID = 291 --Sofia's ID
select * from Addresses
select * from Towns 

--5
CREATE OR ALTER FUNCTION dbo.ufn_GetSalaryLevel(@salary DECIMAL(18, 4)) 
RETURNS VARCHAR(32)
AS
BEGIN
    DECLARE @level VARCHAR(32);

    IF (@salary < 30000)
        SET @level = 'Low';
    ELSE IF (@salary BETWEEN 30000 AND 50000) 
        SET @level = 'Average';
    ELSE
        SET @level = 'High';

    RETURN @level;	
END;

--6
CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel
    @salaryLevel VARCHAR(32)
AS
BEGIN
    -- Select the employees matching the given salary level
    SELECT 
        FirstName,
        LastName
    FROM 
        Employees
    WHERE 
        dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel;
END;
exec usp_EmployeesBySalaryLevel @salaryLevel = 'Low'

--7
CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50)) 
RETURNS BIT
AS
BEGIN
DECLARE @currentIndex int = 1;

WHILE(@currentIndex <= LEN(@word))
	BEGIN

	DECLARE @currentLetter varchar(1) = SUBSTRING(@word, @currentIndex, 1);

	IF(CHARINDEX(@currentLetter, @setOfLetters)) = 0
	BEGIN
	RETURN 0;
	END

	SET @currentIndex += 1;
	END

RETURN 1;
END

--8

CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS


DECLARE @empIDsToBeDeleted TABLE
(
Id int
)

INSERT INTO @empIDsToBeDeleted
SELECT e.EmployeeID
FROM Employees AS e
WHERE e.DepartmentID = @departmentId


ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL;

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Employees
WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Departments
WHERE DepartmentID = @departmentId 



SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.DepartmentID = @departmentId



EXEC usp_DeleteEmployeesFromDepartment @departmentId = 7; -- Specify the department ID here



Use Bank
--9
create procedure usp_GetHoldersFullName
as
select FirstName + ' ' + LastName as [Full Name] from AccountHolders

--10
CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan
    @thresholdBalance DECIMAL(18, 2)
AS
BEGIN
    -- Query to select people with total balance higher than the threshold
    SELECT 
        FirstName as [First Name],
        LastName as [Last Name]
    FROM 
        AccountHolders ah
     JOIN 
        Accounts a ON ah.Id = a.AccountHolderId
    GROUP BY 
        FirstName,LastName
    HAVING 
        SUM(a.Balance) > @thresholdBalance
    ORDER BY 
        FirstName,LastName;
END;

exec usp_GetHoldersWithBalanceHigherThan 100

--11
CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@sum Decimal(18,4),@interestRate float,@years int)
returns Decimal(18,4)
as
Begin
	DECLARE @FV DECIMAL(18,4)
	SET @FV = @sum * POWER((1.0+@interestRate),@years)
return @FV
End
select dbo.ufn_CalculateFutureValue(1000,0.10,5)

--12
CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount
(
    @AccountId INT,
    @InterestRate FLOAT
)
AS
BEGIN
   
	-- Get account information including account holder's name
    SELECT 
		@AccountId as [Account Id],
        ah.FirstName as [First Name],
        ah.LastName as [Last Name],
        a.Balance as [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) as [Balance in 5 years]
    FROM 
        Accounts a
    INNER JOIN 
        AccountHolders ah ON a.AccountHolderId = ah.Id
    WHERE 
        a.Id = @AccountId;
    
END

exec usp_CalculateFutureValueForAccount 1,0.1


--13
CREATE FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(255))
RETURNS TABLE
AS
RETURN
(
    WITH RankedUsers AS (
        SELECT
            ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNum,
            Cash
        FROM UsersGames ug
		LEFT JOIN Games g ON ug.GameId = g.Id
		LEFT JOIN Users u ON ug.UserId = u.Id
        WHERE g.[Name] = @GameName
    )
    SELECT SUM(Cash) AS SumCash
    FROM RankedUsers
    WHERE RowNum % 2 = 1
);

-- Execute the function over the given game name
SELECT * FROM ufn_CashInUsersGames('Love in a mist');

