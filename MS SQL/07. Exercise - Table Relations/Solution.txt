
----Table Relations: Exercises
CREATE DATABASE [TableRelations]

USE [TableRelations]

--1
CREATE TABLE Passports(
	PassportID INT,
	PassportNumber VARCHAR(50),
	CONSTRAINT PK_Passport PRIMARY KEY(PassportID)
)

CREATE TABLE Persons(
  PersonID INT,
  FirstName VARCHAR(50),
  Salary DECIMAL,
  PassportID INT,
  CONSTRAINT PK_PersonID PRIMARY KEY (PersonID),
  CONSTRAINT FK_PersonPassport FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)
  )

  INSERT INTO Passports(PassportID, PassportNumber)
  VALUES(101,'N34FG21B'),
  (102,'K65LO4R7'),
  (103,'ZE657QP2')

  INSERT INTO Persons(PersonID,FirstName,Salary,PassportID)
  VALUES (1,'Roberto', 43300.00,102),
  (2,'Tom',56100.00,103),
  (3,'Yana',60200.00,101)
  

  --2
CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY,
[Name] VARCHAR(50),
EstablishedOn DATE
);
CREATE TABLE Models(
ModelID INT PRIMARY KEY,
[Name] VARCHAR(50),
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
);
INSERT INTO Manufacturers(ManufacturerID,[Name],EstablishedOn)
VALUES (1,'BMW','07/03/1916'),
(2,'Tesla','01/01/2003'),
(3,'Lada','01/05/1966')

INSERT INTO Models(ModelID,[Name],ManufacturerID)
VALUES (101,'X1',1),
(102,'i6',1),
(103,'Model S',2),
(104,'Model X',2),
(105,'Model 3',2),
(106,'Nova',3)

--3
CREATE TABLE Students(
StudentID INT PRIMARY KEY,
[Name] varchar(50)
)
CREATE TABLE Exams(
ExamID INT PRIMARY KEY,
[Name] VARCHAR(50)
)
CREATE TABLE StudentsExams(
StudentID INT,
ExamID INT,
CONSTRAINT PK_StudentExam PRIMARY KEY (StudentID,ExamID),
CONSTRAINT FK_StudentID FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_ExamID FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)
INSERT INTO Students(StudentID,[Name])
VALUES (1,'Mila'),
(2,'Toni'),
(3,'Ron')

INSERT INTO Exams(ExamID,[Name])
VALUES (101,'SpringMVC'),
(102,'Neo4j'),
(103,'Oracle 11g')

INSERT INTO StudentsExams(StudentID,ExamID)
VALUES (1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

--4
CREATE TABLE Teachers(
TeacherID INT  PRIMARY KEY,
[Name] VARCHAR(50),
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
);
INSERT INTO Teachers(TeacherID,[Name],ManagerID)
VALUES (101,'John',NULL),
(102,'Maya',106),
(103,'Silvia',106),
(104,'Ted',105),
(105,'Mark',101),
(106,'Greta',101)

SELECT * FROM teachers


--5
CREATE TABLE Cities(
CityID INT PRIMARY KEY,
[Name] VARCHAR(50)
);
CREATE TABLE Customers(
CustomerID INT PRIMARY KEY,
[Name] VARCHAR(50),
Birthday DATE,
CityID INT FOREIGN KEY REFERENCES Cities(CityID)
);

CREATE TABLE Orders(
OrderID INT PRIMARY KEY ,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
);

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY,
[Name] VARCHAR(50)
);
CREATE TABLE Items(
ItemID INT PRIMARY KEY,
[Name] VARCHAR(50),
ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
);
CREATE TABLE OrderItems(
OrderID INT,
ItemID INT,
CONSTRAINT PK_OrderItem PRIMARY KEY(OrderID,ItemID),
CONSTRAINT FK_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
CONSTRAINT FK_ItemID FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
);

--6
CREATE TABLE Majors(
MajorID INT PRIMARY KEY,
[Name] VARCHAR(50)
);
CREATE TABLE  Subjects(
SubjectID INT PRIMARY KEY,
SubjectName VARCHAR(50)
)
CREATE TABLE  Students(
StudentID INT PRIMARY KEY,
StudentNumber VARCHAR(50),
StudentName VARCHAR(50),
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
);
CREATE TABLE  Agenda(
StudentID INT,
SubjectID INT,
CONSTRAINT PK_Agenda PRIMARY KEY (StudentID,SubjectID),
CONSTRAINT FK_StudentAgenda FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_SubjectAgenda FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);
CREATE TABLE  Payments(
PaymentID INT PRIMARY KEY ,
PaymentDate DATE,
PaymentAmount DECIMAL,
StudentID INT,
CONSTRAINT FK_StudentPayment FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
);


--9
USE [Geography]

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks As p ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC