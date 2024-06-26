--Triggers and Transactions Exercises
Use Bank

--1



create table Logs (
LogId int Primary Key Identity(1,1),
AccountId int Foreign Key References Accounts(Id),
OldSum decimal(18,2) NOT NULL,
NewSum decimal(18,2) NOT NULL
)

go
CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON Accounts FOR UPDATE 
AS
Insert into Logs(AccountId,OldSum, NewSum)
SELECT i.Id, d.Balance, i.Balance
 FROM inserted AS i
 JOIN deleted AS d ON i.Id = d.Id
 WHERE i.Balance != d.Balance
 go
Update Accounts
Set Balance = Balance + 10
Where Id = 1


--2
Create Table NotificationEmails(
Id int Primary Key Identity(1,1),
Recipient int Foreign Key References Accounts(Id),
[Subject] varchar(255) NOT NULL,
Body text NOT NULL
)




Create or alter TRIGGER tr_AddToEmailsOnLogUpdate
ON Logs After Insert 
AS
Insert into NotificationEmails(Recipient,[Subject],Body)
Select i.AccountId,
'Balance change for account: ' + CAST(i.AccountId as nvarchar),
'On ' + Cast(GETDATE()as nvarchar)+' your balance was changed from '+ 
Cast(i.OldSum as nvarchar)+' to ' +CAST(i.NewSum as nvarchar)+'.'
 FROM inserted AS i

 select * from NotificationEmails

 --3
CREATE OR ALTER PROCEDURE usp_DepositMoney(@AccountId INT, @moneyAmount Decimal(18,4))
AS
	BEGIN TRANSACTION
		IF (@moneyAmount < 0) THROW 50001, 'Invalid amount', 1
		UPDATE Accounts
		SET Balance = Balance + @moneyAmount
		WHERE Accounts.Id = @AccountId
		BEGIN
			COMMIT
		END

--4
CREATE OR ALTER PROCEDURE usp_WithdrawMoney(@AccountId int,@MoneyAmount Decimal(18,4))
AS
	BEGIN TRANSACTION
		IF @moneyAmount < 0 THROW 50001, 'Invalid amount', 1
		UPDATE Accounts
		SET Balance = Balance - @MoneyAmount
		WHERE Id = @AccountId
		BEGIN 
			COMMIT
		END

EXEC usp_WithdrawMoney @AccountId = 5, @MoneyAmount = 25


--5
CREATE OR ALTER PROCEDURE usp_TransferMoney(@SenderId int, @ReceiverId int, @Amount Decimal(18,4))
AS
BEGIN TRANSACTION
BEGIN TRY
		IF @Amount < 0 THROW 50001, 'Invalid amount', 1
		UPDATE Accounts
		SET Balance = Balance - @Amount
		WHERE Id = @SenderId
		
		UPDATE Accounts
		SET Balance = Balance + @Amount
		WHERE Id = @ReceiverId
END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
COMMIT TRANSACTION	

EXEC  usp_TransferMoney @SenderId = 5,@ReceiverId = 1,@Amount = 5000
GO

--6
Use Diablo
go
CREATE TRIGGER tr_UserGameItems_LevelRestriction ON UserGameItems
INSTEAD OF UPDATE
AS
     BEGIN
         IF(
           (
               SELECT Level
               FROM UsersGames
               WHERE Id =
               (
                   SELECT UserGameId
                   FROM inserted
               )
           ) <
           (
               SELECT MinLevel
               FROM Items
               WHERE Id =
               (
                   SELECT ItemId
                   FROM inserted
               )
           ))
             BEGIN
                 RAISERROR('Your current level is not enough', 16, 1);
         END;

/* Assign the new item when the exception isn't thrown */
         INSERT INTO UserGameItems
         VALUES
         (
         (
             SELECT ItemId
             FROM inserted
         ),
         (
             SELECT UserGameId
             FROM inserted
         )
         );
     END;
	 
/* Add bonus cash */
UPDATE ug
  SET
      ug.Cash+=50000
FROM UsersGames AS ug
     JOIN Users AS u ON u.Id = ug.UserId
     JOIN Games AS g ON g.Id = ug.GameId
WHERE u.FirstName IN('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
AND g.Name = 'Bali';


--7
-- Declaring initial variables

DECLARE @userGameId INT = 
(
  SELECT ug.[Id]
  FROM [UsersGames] AS [ug] 
  JOIN [Users] AS [u] ON ug.[UserId] = u.[Id]
  JOIN [Games] AS [g] ON ug.[GameId] = g.[Id]
  WHERE u.[Username] = 'Stamat' AND g.[Name] = 'Safflower'
)
DECLARE @itemsCost DECIMAL(18, 4)

-- Buying items within 11-12 level range:

DECLARE @minLevel INT = 11
DECLARE @maxLevel INT = 12
DECLARE @playerCash DECIMAL(18, 4) = 
(
	SELECT [Cash]
    FROM [UsersGames]
    WHERE [Id] = @userGameId
)

SET @itemsCost = 
(
	SELECT SUM(Price)
    FROM [Items]
    WHERE [MinLevel] BETWEEN @minLevel AND @maxLevel
)

IF (@playerCash >= @itemsCost)
BEGIN
	BEGIN TRANSACTION
    UPDATE [UsersGames]
    SET [Cash] -= @itemsCost
    WHERE [Id] = @userGameId
      
    INSERT INTO [UserGameItems] (ItemId, UserGameId)
    (
		SELECT
			[Id],
			@userGameId
		FROM [Items]
		WHERE [MinLevel] BETWEEN @minLevel AND @maxLevel
	)
	COMMIT     
END

-- Buying items within 19-21 level range:

SET @minLevel = 19
SET @maxLevel = 21
SET @playerCash = 
(
	SELECT [Cash]
    FROM [UsersGames]
    WHERE [Id] = @userGameId
)

SET @itemsCost = 
(
	SELECT SUM(Price)
    FROM [Items]
    WHERE [MinLevel] BETWEEN @minLevel AND @maxLevel
)

IF (@playerCash >= @itemsCost)
BEGIN
	BEGIN TRANSACTION
    UPDATE [UsersGames]
    SET [Cash] -= @itemsCost
    WHERE [Id] = @userGameId
      
    INSERT INTO [UserGameItems] (ItemId, UserGameId)
    (
		SELECT
			[Id],
			@userGameId
		FROM [Items]
		WHERE [MinLevel] BETWEEN @minLevel AND @maxLevel
	)
	COMMIT     
END

-- Selecting result table:

SELECT i.[Name] AS [Item Name]
FROM [UserGameItems] AS [ugi]
JOIN [Items] AS [i] ON i.[Id] = ugi.[ItemId]
JOIN [UsersGames] AS [ug] ON ug.[Id] = ugi.[UserGameId]
JOIN [Games] AS [g] ON g.[Id] = ug.[GameId]
WHERE g.[Name] = 'Safflower'
ORDER BY [Item Name]



--8
GO
Use SoftUni
GO
CREATE PROCEDURE usp_AssignProject(@employeeId int,@projectId int)
AS
BEGIN TRANSACTION
Declare @projectsCount int =
(
Select Count(@projectId) from EmployeesProjects
where EmployeeID = @employeeId
)
if @projectsCount >=3
BEGIN
		RAISERROR('The employee has too many projects!', 16, 1)
		ROLLBACK		
END

INSERT INTO [EmployeesProjects] VALUES
		(@employeeId, @projectID)
COMMIT TRANSACTION


--9
CREATE TABLE Deleted_Employees(
EmployeeId int PRIMARY KEY IDENTITY(1,1),
FirstName varchar(50),
LastName varchar(50),
MiddleName varchar(50),
JobTitle varchar(50),
DepartmentId int FOREIGN KEY References Departments(DepartmentID),
Salary decimal(18,4)
)

CREATE  TRIGGER tr_InsertToDelEmployeesOnEmployeesDelete
ON Employees AFTER DELETE
AS
BEGIN
Insert INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
Select d.FirstName, d.LastName, d.MiddleName, d.JobTitle, d.DepartmentId, d.Salary
from deleted as d
END



ALTER TABLE EmployeesProjects
DROP CONSTRAINT FK_EmployeesProjects_Employees;
ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Employees
FOREIGN KEY (EmployeeID)
REFERENCES Employees(EmployeeID)
ON DELETE CASCADE;

delete from Employees
where JobTitle = 'Design Engineer'
