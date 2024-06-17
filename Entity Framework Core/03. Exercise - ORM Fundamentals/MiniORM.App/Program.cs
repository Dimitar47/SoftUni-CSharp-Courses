using MiniORM.App.Data;
using MiniORM.App.Data.Entities;

namespace MiniORM.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Import this SQL script into SSMS:
            CREATE DATABASE MiniORM
            GO
            USE MiniORM
            GO
            CREATE TABLE Projects
            (
	            Id INT IDENTITY PRIMARY KEY,
	            Name VARCHAR(50) NOT NULL
            )

            CREATE TABLE Departments
            (
	            Id INT IDENTITY PRIMARY KEY,
	            Name VARCHAR(50) NOT NULL
            )

            CREATE TABLE Employees
            (
	            Id INT IDENTITY PRIMARY KEY,
	            FirstName VARCHAR(50) NOT NULL,
	            MiddleName VARCHAR(50),
	            LastName VARCHAR(50) NOT NULL,
	            IsEmployed BIT NOT NULL,
	            DepartmentId INT
	            CONSTRAINT FK_Employees_Departments FOREIGN KEY
	            REFERENCES Departments(Id)
            )
            CREATE TABLE EmployeesProjects
            (
	            ProjectId INT NOT NULL
	            CONSTRAINT FK_Employees_Projects REFERENCES Projects(Id),
	            EmployeeId INT NOT NULL
	            CONSTRAINT FK_Employees_Employee REFERENCES Employees(Id),
	            CONSTRAINT PK_Projects_Employees
	            PRIMARY KEY (ProjectId, EmployeeId)
            )
            GO
            INSERT INTO MiniORM.dbo.Departments (Name) VALUES ('Research');
            INSERT INTO MiniORM.dbo.Employees (FirstName, MiddleName, LastName, IsEmployed, DepartmentId) VALUES
            ('Sophia', NULL, 'Ivy', 1, 1),
            ('Peter', 'Isaacs', 'Porter', 0, 1),
            ('Ian', 'Phillips', 'Taylor', 1, 1),
            ('George', NULL, 'Wilson', 1, 1);
            INSERT INTO MiniORM.dbo.Projects (Name) 
            VALUES ('C# Project'), ('Java Project');
            INSERT INTO MiniORM.dbo.EmployeesProjects (ProjectId, EmployeeId) VALUES
            (1, 1),
            (1, 3),
            (2, 2),
            (2, 3)

             */

            string connectionString = "Server=DESKTOP-H4T3O5Q;Database=MiniORM;Integrated Security=true;" +
                "TrustServerCertificate=true;";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";
           // employee.MiddleName = "Test";
            context.SaveChanges();
        }
    }
}
