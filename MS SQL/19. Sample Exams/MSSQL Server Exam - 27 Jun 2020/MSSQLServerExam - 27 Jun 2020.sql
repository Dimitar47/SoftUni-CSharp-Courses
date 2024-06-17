--Databases MSSQL Server Exam - 27 Jun 2020

--1
CREATE TABLE Clients(
ClientId INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Phone CHAR(12) NOT NULL CHECK(LEN(Phone)=12)
)




CREATE TABLE Mechanics(
MechanicId INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models(
ModelId INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) UNIQUE NOT NULL
)
CREATE TABLE Jobs(
JobId INT PRIMARY KEY IDENTITY(1,1),
ModelId INT NOT NULL FOREIGN KEY REFERENCES Models(ModelId),
[Status] CHAR(11) NOT NULL DEFAULT 'PENDING' CHECK([Status] IN('Pending', 'In Progress' ,'Finished')),
ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientId),
MechanicId INT  FOREIGN KEY REFERENCES Mechanics(MechanicId),
IssueDate DATE NOT NULL,
FinishDate DATE
)

CREATE TABLE Orders(
OrderId INT PRIMARY KEY IDENTITY(1,1),
JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
IssueDate DATE,
Delivered bit NOT NULL DEFAULT 0
)
CREATE TABLE Vendors(
VendorId INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) UNIQUE NOT NULL


)
CREATE TABLE Parts(
PartId INT PRIMARY KEY IDENTITY(1,1),
SerialNumber VARCHAR(50) UNIQUE NOT NULL,
[Description] VARCHAR(255),
Price DECIMAL(6,2)NOT NULL CHECK(Price>0),
VendorId INT NOT NULL FOREIGN KEY REFERENCES Vendors(VendorId),
StockQty INT NOT NULL DEFAULT 0 CHECK(StockQty >=0)
)


CREATE TABLE OrderParts(
OrderId INT NOT NULL,
PartId INT NOT NULL ,
Quantity INT NOT NULL DEFAULT 1 CHECK(Quantity>0),
CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId,PartId) ,
CONSTRAINT FK_OrderPartsOrderId FOREIGN KEY(OrderId) REFERENCES Orders(OrderId),
CONSTRAINT FK_OrderPartsPartId FOREIGN KEY(PartId) REFERENCES Parts(PartId)
)

CREATE TABLE PartsNeeded(
JobId INT NOT NULL,
PartId INT NOT NULL ,
Quantity INT NOT NULL DEFAULT 1 CHECK(Quantity>0),
CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId,PartId),
CONSTRAINT FK_PartsNeededJobId FOREIGN KEY(JobId) REFERENCES Jobs(JobId),
CONSTRAINT FK_PartsNeededPartId FOREIGN KEY(PartId) REFERENCES Parts(PartId)
)

--2

INSERT INTO Clients(FirstName,	LastName,	Phone)
VALUES 
('Teri','Ennaco','570-889-5187'),
('Merlyn','Lawler','201-588-7810'),
('Georgene','Montezuma','925-615-5185'),
('Jettie','Mconnell','908-802-3564'),
('Lemuel','Latzke','631-748-6479'),
('Melodie','Knipp','805-690-1682'),
('Candida','Corbley','908-275-8357')

INSERT INTO Parts(SerialNumber,	[Description],	Price,	VendorId)
VALUES  ('WP8182119',	'Door Boot Seal',	117.86,	2),
		('W10780048',	'Suspension Rod',	42.81,	1),
		('W10841140',	'Silicone Adhesive', 	6.77,	4),
		('WPY055980',	'High Temperature Adhesive',	13.94,	3)

--3
UPDATE Jobs
SET MechanicId =3, [Status] = 'In Progress'
WHERE [Status] = 'Pending'


--4
DELETE FROM OrderParts WHERE OrderId =19
DELETE FROM Orders WHERE OrderId = 19

--5
SELECT 
CONCAT_WS(' ',FirstName,LastName) AS Mechanic,
j.[Status],
j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

--6
SELECT 
CONCAT_WS(' ',c.FirstName,c.LastName) AS Client,
DATEDIFF(DAY,j.IssueDate,'04-24-2017') AS [Days going],
j.[Status]
FROM Clients AS c
JOIN Jobs AS j ON j.ClientId = c.ClientId
WHERE j.[Status] <> 'Finished'
ORDER BY [Days going] DESC,c.ClientId ASC

--7
SELECT 
CONCAT_WS(' ',m.FirstName,m.LastName) AS Mechanic,
AVG(DATEDIFF(DAY,j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId ASC

--8
SELECT 
CONCAT_WS(' ',m.FirstName,m.LastName) AS Available
FROM Mechanics AS m
LEFT JOIN
	Jobs AS j ON j.MechanicId = m.MechanicId AND j.[Status]!='Finished'
WHERE j.MechanicId IS NULL
ORDER BY m.MechanicId ASC

--9
-- Select detailed information to debug the data integrity and relationships
SELECT 
    j.JobId, 
    ISNULL(SUM(p.Price * op.Quantity), 0) as Total
FROM Jobs AS j
LEFT JOIN Orders o on j.JobId = o.JobId
LEFT join OrderParts op on o.OrderId = op.OrderId
LEFT join Parts p on op.PartId = p.PartId
WHERE J.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId


--10
SELECT 
    p.PartId,
    p.[Description],
    pn.Quantity AS Required,
    ISNULL(p.StockQty, 0) AS [In Stock],
    ISNULL(o.Ordered, 0) AS Ordered
FROM 
    Parts p
JOIN 
    PartsNeeded pn ON p.PartId = pn.PartId
JOIN 
    Jobs j ON pn.JobId = j.JobId
LEFT JOIN (
    SELECT 
        PartId,
        SUM(Quantity) AS Ordered
    FROM 
        Orders o
    JOIN 
        PartsNeeded pn ON o.JobId = pn.JobId AND o.Delivered = 0
    GROUP BY 
        PartId
) o ON p.PartId = o.PartId
WHERE 
    j.[Status] != 'Finished'
    AND (ISNULL(p.StockQty, 0) + ISNULL(o.Ordered, 0)) < pn.Quantity
ORDER BY 
    p.PartId ASC;

--11
SELECT * FROM Jobs WHERE JobId = 1
GO
CREATE OR ALTER PROCEDURE usp_PlaceOrder(@jobId INT,@partSerialNumber VARCHAR(50),@Quantity INT)
AS
BEGIN
		IF(@jobId IN (SELECT JobId FROM Jobs WHERE [Status] ='Finished')) THROW 50011 ,
																	'This job is not active!',1
		IF( @Quantity<=0) THROW 50012,'Part quantity must be more than zero!',1
		IF(@jobId NOT IN(SELECT JobId FROM Jobs)) THROW 50013,'Job not found!',1
		IF(@partSerialNumber NOT IN (SELECT SerialNumber FROM Parts)) THROW 50014,'Part not found!',1
		
		DECLARE @partId INT = (Select top(1) PartId from Parts where SerialNumber = @partSerialNumber)
		DECLARE @orderIdForJob int= (SELECT top(1) OrderId FROM Orders WHERE JobId = @jobId)

		DECLARE @issueDate Date = (SELECT IssueDate FROM Orders  where OrderId = @orderIdForJob and JobId =
											@jobId)
		DECLARE @partIdInOrderParts INT = (SELECT PartId from OrderParts where OrderId = @orderIdForJob
												and PartId = @partId)
		IF((@issueDate is NULL) AND (@orderIdForJob != 0 ))
		BEGIN
			IF(@partIdInOrderParts !=0) 
			BEGIN
			UPDATE OrderParts
				SET Quantity+=@Quantity
				WHERE OrderId = @orderIdForJob and PartId = @partId
			Return
			END
			
			ELSE
			BEGIN
				INSERT INTO OrderParts(OrderId,PartId,Quantity)
				VALUES (@orderIdForJob,@partId,@Quantity)
				RETURN
			END
				
		END
		
			INSERT INTO Orders(JobId,IssueDate,Delivered)
			VALUES (@jobId,NULL,0)
			SET @orderIdForJob = (SELECT TOP(1) OrderId FROM Orders ORDER BY OrderId DESC)
            INSERT INTO OrderParts VALUES (@orderIdForJob, @partId, @Quantity)
	
			
END
GO


DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH


--12
GO
CREATE OR ALTER FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(18,2)
AS
BEGIN
	DECLARE @totalCost DECIMAL(18,2)=
	(
	SELECT 
	CASE
	WHEN COUNT(o.OrderId)>0 THEN SUM(p.[Price])
	ELSE 0
	END 
	FROM Parts AS p
	LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
	LEFT JOIN Orders AS o ON op.OrderId = o.OrderId 
	LEFT JOIN Jobs AS j ON o.JobId = j.JobId
	WHERE j.JobId = @jobId
	)
	

	
	RETURN @totalCost
END
GO

SELECT dbo.udf_GetCost(1)
SELECT dbo.udf_GetCost(3)