CREATE DATABASE AcademicRecordsDB;
GO

USE AcademicRecordsDB;
GO

CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL
);

CREATE TABLE Exams (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Grades (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Value DECIMAL(3,2) NOT NULL CHECK (Value >= 2.00 AND Value <= 6.00),
    ExamId INT NOT NULL,
    StudentId INT NOT NULL,
    CONSTRAINT FK_Grades_Exams FOREIGN KEY (ExamId) REFERENCES Exams(Id),
    CONSTRAINT FK_Grades_Students FOREIGN KEY (StudentId) REFERENCES Students(Id)
);

INSERT INTO Students (FullName) VALUES 
('John Doe'),
('Jane Smith'),
('Alice Johnson'),
('Michael Brown'),
('Emily Davis'),
('David Wilson'),
('Sophia Martinez'),
('Daniel Anderson'),
('Emma Thomas'),
('Christopher Taylor');

INSERT INTO Exams (Name) VALUES 
('Mathematics'),
('Science'),
('History'),
('Computer Science'),
('Physics'),
('Chemistry'),
('Biology'),
('Literature'),
('Philosophy'),
('Psychology');

INSERT INTO Grades (Value, ExamId, StudentId) VALUES 
(4.55, 1, 1),
(5.60, 2, 1),
(3.75, 3, 1),
(5.10, 4, 1),
(5.95, 5, 2),
(4.80, 6, 2),
(3.25, 7, 2),
(4.50, 8, 3),
(5.00, 9, 3),
(5.85, 10, 3),
(4.20, 1, 4),
(5.35, 2, 4),
(3.50, 3, 4),
(5.00, 4, 4),
(5.90, 5, 5),
(4.70, 6, 5),
(2.80, 7, 5),
(4.45, 8, 6),
(5.25, 9, 6),
(5.95, 10, 6),
(4.00, 1, 7),
(5.10, 2, 7),
(3.65, 3, 7),
(5.00, 4, 8),
(5.75, 5, 8),
(5.20, 6, 8),
(4.60, 7, 9),
(5.95, 8, 9),
(6.00, 9, 9),
(4.30, 10, 10),
(5.15, 1, 10),
(3.75, 2, 10);