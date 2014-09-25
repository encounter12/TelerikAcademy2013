-- README: Open the current script (sql file) with Microsoft SQL Server Management Studio: File - Open - File (Ctrl + O). 
-- In order to run specific query just highlight it and click on Execute (press F5).

-- Tasks:

-- 01. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.

USE TelerikAcademy
SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- 02. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

USE TelerikAcademy
DECLARE @lowestSalary int
SET @lowestSalary = (SELECT MIN(Salary) FROM Employees)
SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e
WHERE Salary > @lowestSalary AND Salary <= 1.1 * @lowestSalary

-- 03. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. 
-- Use a nested SELECT statement.

USE TelerikAcademy
SELECT CONCAT(e.FirstName, ' ' , e.MiddleName, ' ', e.LastName) AS FullName, 
	e.Salary, d.Name AS DepartmentName
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- 04. Write a SQL query to find the average salary in the department #1.

USE TelerikAcademy
SELECT AVG(Salary) AS AverageSalary
FROM Employees e
WHERE e.DepartmentID = 1

-- 05. Write a SQL query to find the average salary  in the "Sales" department.

USE TelerikAcademy
SELECT d.Name AS DepartmentName, AVG(Salary) AS AverageSalary
FROM Employees e
    INNER JOIN Departments d
        ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

-- 06. Write a SQL query to find the number of employees in the "Sales" department.

USE TelerikAcademy
SELECT d.Name, COUNT(e.EmployeeID) AS EmployeesNumber
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

-- 07. Write a SQL query to find the number of all employees that have manager.

USE TelerikAcademy
SELECT COUNT(e.EmployeeID) AS EmployeesWithManagerCount
FROM Employees e
WHERE e.ManagerID IS NOT NULL

-- 08. Write a SQL query to find the number of all employees that have no manager.

USE TelerikAcademy
SELECT COUNT(e.EmployeeID) AS EmployeesWithoutManagerCount
FROM Employees e
WHERE e.ManagerID IS NULL

-- 09. Write a SQL query to find all departments and the average salary for each of them.

USE TelerikAcademy
SELECT d.Name, AVG(e.Salary) AS AverageSalary
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

-- 10. Write a SQL query to find the count of all employees in each department and for each town.

USE TelerikAcademy
SELECT d.Name AS DepartmentName, t.Name AS Town, COUNT(e.EmployeeID) AS EmployeesCount
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID
	INNER JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.TownID, t.Name, d.DepartmentID, d.Name


-- 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.

USE TelerikAcademy
SELECT m.FirstName, m.LastName, COUNT(e.ManagerID) AS EmployeesCount
FROM Employees e
	INNER JOIN Employees m
		ON e.ManagerID = m.EmployeeID
GROUP BY m.EmployeeID, m.FirstName, m.LastName
HAVING (COUNT(e.ManagerID) = 5)
ORDER BY m.FirstName, m.LastName


-- 12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

-- Option 01: 
USE TelerikAcademy
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, 
	COALESCE(m.FirstName + m.LastName, '(no manager)') AS ManagerName
FROM Employees e
	LEFT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

-- Option 02:
USE TelerikAcademy
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, 
	ISNULL(m.FirstName + m.LastName, '(no manager)') AS ManagerName
FROM Employees e
	LEFT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID


-- 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.

USE TelerikAcademy
SELECT e.FirstName, e.MiddleName, e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5

-- 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". 
-- Search in  Google to find how to format dates in SQL Server.

-- Option 01:
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff') AS CurrentDateTime

-- Option 02:
DECLARE @currentDate DATETIME
SET @currentDate = GETDATE()
SELECT CONVERT(VARCHAR(10), @currentDate, 104) + ' ' + CONVERT(VARCHAR(12), @currentDate, 114) AS CurrentDateTime


-- 15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. 
-- Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. 
-- Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
-- Define a check constraint to ensure the password is at least 5 characters long.

USE TelerikAcademy
CREATE TABLE Users (
	UserID int IDENTITY,
	UserName nvarchar(50) NOT NULL UNIQUE,
	Password nvarchar(50) CHECK(LEN(Password) >= 5),
	FullName nvarchar(50) NOT NULL,
	LastLoginTime DATETIME,
	CONSTRAINT PK_Users PRIMARY KEY(UserID)
);

--16.Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. 
--Test if the view works correctly.

USE TelerikAcademy
INSERT INTO Users 
	([Username], [Password], [FullName], [LastLoginTime])
VALUES
	('pechenkata', 'mypass', 'Àdriana Nikolova', GETDATE()),
	('grafa', 'mechetopass', 'Vladimir Ampov', GETDATE()),
	('Shamara', 'password', 'Mihail Mihailov', DATEADD(DAY, -10, GETDATE())),
	('Penjata', 'parolata', 'Penko Tenchev', DATEADD(DAY, -3, GETDATE()))
;

CREATE VIEW [UsersLoggedInToday] AS
SELECT u.*
FROM Users AS u
WHERE CONVERT (DATE, u.LastLoginTime) = CONVERT (DATE, GETDATE());

SELECT ut.*
FROM UsersLoggedInToday AS ut


-- 17. Write a SQL statement to create a table Groups.
-- Groups should have unique name (use unique constraint).
-- Define primary key and identity column.                

CREATE TABLE Groups
(
	GroupId INT IDENTITY PRIMARY KEY,
	Name VARCHAR(16) UNIQUE NOT NULL
);


                                                                                     
-- 18. Write a SQL statement to add a column GroupID to the table Users.                            
-- Fill some data in this new column and as well in the Groups table.                           
-- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables. 


ALTER TABLE Users
ADD GroupId INT FOREIGN KEY REFERENCES Groups(GroupId);

INSERT INTO Groups VALUES ('Admins');
INSERT INTO Groups VALUES ('Moderators');
INSERT INTO Groups VALUES ('Users');

UPDATE Users SET GroupId = 1;

INSERT INTO Users VALUES ('user123', 'pass123', 'John', GETDATE(), 2);
INSERT INTO Users VALUES ('user1234', 'pass1234', 'Jane', GETDATE(), 2);
INSERT INTO Users VALUES ('user1235', 'pass1235', 'Bill', GETDATE(), 3);
INSERT INTO Users VALUES ('user1236', 'pass1236', 'Tosho', GETDATE(), 3);

                                                                      
-- 19. Write SQL statements to insert several records in the Users and Groups tables. 
-- See above

                                                                         
-- 20. Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Groups SET Name = UPPER(Name);
UPDATE Users SET FullName = REVERSE(FullName) WHERE Username LIKE '%5%';

                                                                          
-- 21. Write SQL statements to delete some of the records from the Users and Groups tables. 

DELETE FROM Users WHERE UserId = 1;
DELETE FROM Groups WHERE GroupId = 3;


                                                                                               
-- 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
-- Combine the first and last names as a full name.                                                       
-- For username use the first letter of the first name + the last name (in lowercase).                   
-- Use the same for the password, and NULL for last login time.                                           


-- add EmployeeId to the user name and password to satisfy the Username uniqueness constraint
INSERT INTO Users (UserName, Password, FullName)
SELECT CONCAT(LOWER(LEFT(FirstName, 1) + LastName), EmployeeID) AS UserName,
	   CONCAT(LOWER(LEFT(FirstName, 1) + LastName), EmployeeID) AS Password,
       FirstName + ' ' + LastName AS FullName
FROM Employees;

                                                      
-- 23. Write a SQL statement that changes the password to NULL          
-- for all users that have not been in the system since 10.03.2010. 


INSERT INTO Users (Username, Password, FullName, LastLoginTime)
VALUES ('olduser1', 'olduserpass', 'Very old user', CONVERT(DATE, '09.03.2010', 104));

UPDATE Users SET Password = NULL
WHERE LastLoginTime < CONVERT(DATE, '10.03.2010', 104);


                                                                       
-- 24. Write a SQL statement that deletes all users without passwords (NULL password). 

DELETE FROM Users
WHERE Password IS NULL;
                                               
-- 25. Write a SQL query to display the average employee salary by department and job title.


SELECT d.Name AS DepartmentName, e.JobTitle, AVG(e.Salary) As AverageSalary
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID, d.Name, e.JobTitle
ORDER BY d.Name ASC, AverageSalary ASC;


-- 26. Write a SQL query to display the minimal employee salary by department and job title
-- along with the name of some of the employees that take it.
                        

SELECT d.Name AS DepartmentName, e.JobTitle, MIN(e.Salary) as MinSalary, MIN(e.FirstName + ' ' + e.LastName) AS EmployeeName
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID, d.Name, e.JobTitle
ORDER BY d.Name ASC, MinSalary ASC;

                                                             
-- 27. Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 t.Name, COUNT(e.EmployeeId) AS EmployeesCount
FROM Towns AS t
INNER JOIN Addresses AS a ON t.TownID = a.TownID
INNER JOIN Employees AS e ON a.AddressID = e.AddressID
GROUP BY t.TownID, t.Name
ORDER BY EmployeesCount DESC;

-- IF we want to select ALL towns with maximal number of employees, the query becomes more complicated
SELECT t.Name, COUNT(e.EmployeeId) AS EmployeesCount
FROM Towns AS t
INNER JOIN Addresses AS a ON t.TownID = a.TownID
INNER JOIN Employees AS e ON a.AddressID = e.AddressID
GROUP BY t.TownID, t.Name
HAVING COUNT(e.EmployeeId) = (
	SELECT TOP 1 COUNT(e1.EmployeeId) AS MaxEmployeesCount
	FROM Towns AS t1
	INNER JOIN Addresses AS a1 ON t1.TownID = a1.TownID
	INNER JOIN Employees AS e1 ON a1.AddressID = e1.AddressID
	GROUP BY t1.TownID
	ORDER BY MaxEmployeesCount DESC
)
ORDER BY t.Name ASC;


                                                      
-- 28. Write a SQL query to display the number of managers from each town.

SELECT t.Name, COUNT(e.EmployeeId) AS ManagersCount
FROM Towns AS t
INNER JOIN Addresses AS a ON t.TownID = a.TownID
INNER JOIN Employees AS e ON a.AddressID = e.AddressID
WHERE e.ManagerID IS NULL
GROUP BY t.TownID, t.Name
ORDER BY ManagersCount DESC;


                                                                                                 
-- 29. Write a SQL to create table WorkHours to store work reports for each employee                          
-- (employee id, date, task, hours, comments).                                                              
-- Don't forget to define identity, primary key and appropriate foreign key.                                
-- Issue few SQL statements to insert, update and delete of some data in the table.                         
-- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.                   
-- For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE [dbo].[WorkHours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Task] [nvarchar](80) NOT NULL,
	[Hours] [float] NOT NULL,
	[Comments] [nvarchar] (300) NOT NULL,
	CONSTRAINT [PK_WorkHours] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
	ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[WorkHours] 
WITH CHECK ADD CONSTRAINT [FK_WorkHours_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeID]);

GO

ALTER TABLE [dbo].[WorkHours] CHECK CONSTRAINT [FK_WorkHours_Employees];

GO
----------------------------------------------------------------------------------------------------
INSERT INTO WorkHours
VALUES (5, '12-05-2012', 'Added new product', 2.30, 'The new product will be developed');
INSERT INTO WorkHours
VALUES (12, '10-25-2011', 'Found a new bug', 2.30, 'Found a bug in an existing project');
INSERT INTO WorkHours
VALUES (181, '7-7-2012', 'Fixed a fe bugs', 2.30, 'Fixed some bugs before the release');

UPDATE WorkHours
SET EmployeeId = 141
WHERE Id = 3;

UPDATE WorkHours
SET EmployeeId = 13
WHERE EmployeeId = 10;

DELETE FROM WorkHours
WHERE EmployeeId = 5;

DELETE FROM WorkHours
WHERE Date = '10-24-2011';

--------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[WorkHoursLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OldEmployeeId] [int],
	[OldDate] [date],
	[OldTask] [nvarchar](80),
	[OldHours] [float],
	[OldComments] [nvarchar] (300),
	[NewEmployeeId] [int],
	[NewDate] [date],
	[NewTask] [nvarchar](80),
	[NewHours] [float],
	[NewComments] [nvarchar] (300),
	[Command] [nvarchar] (30),
	CONSTRAINT [PK_WorkHoursLogs] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
	ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

----------------------------------------------------------------------------------------------------

GO

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TRIGGER [dbo].[WorkHoursInsert] ON [dbo].[WorkHours]
AFTER INSERT
AS
DECLARE @newEmployeeId int, @newDate date, @newTask nvarchar (80),
		@newHours float, @newComment nvarchar (max)
SELECT @newEmployeeId = i.EmployeeId, @newDate = i.Date,
	   @newTask = i.Task, @newHours = i.Hours, @newComment = i.Comments
FROM [dbo].[WorkHours] AS p 
INNER JOIN inserted i ON p.Id = i.Id
INSERT INTO WorkHoursLogs (NewEmployeeId, NewDate, NewTask,
			NewHours, NewComments, Command)
VALUES (@newEmployeeId, @newDate, @newTask, @newHours, @newComment, 'Insert');

GO

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TRIGGER [dbo].[WorkHoursUpdate] ON [dbo].[WorkHours]
AFTER UPDATE
AS
DECLARE @newEmployeeId int, @newDate date, @newTask nvarchar (80),
		@newHours float, @newComment nvarchar (300),
		@oldEmployeeId int, @oldDate date, @oldTask nvarchar (80),
		@oldHours float, @oldComment nvarchar (300)
SELECT @oldEmployeeId = i.EmployeeId, @oldDate = i.Date,
	   @oldTask = i.Task, @oldHours = i.Hours, @oldComment = i.Comments
FROM [dbo].[WorkHours] AS p 
INNER JOIN deleted i ON p.Id = i.Id
SELECT @newEmployeeId = i.EmployeeId, @newDate = i.Date,
	   @newTask = i.Task, @newHours = i.Hours, @newComment = i.Comments
FROM [dbo].[WorkHours] AS p 
INNER JOIN inserted i ON p.Id = i.Id
INSERT INTO WorkHoursLogs (OldEmployeeId, OldDate, OldTask,
			OldHours, OldComments, NewEmployeeId, NewDate, NewTask,
			NewHours, NewComments, Command)
VALUES (@oldEmployeeId, @oldDate, @oldTask, @oldHours, @oldComment,
		@newEmployeeId, @newDate, @newTask, @newHours, @newComment, 'Update');

GO

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TRIGGER [dbo].[WorkHoursDelete] ON [dbo].[WorkHours]
AFTER DELETE
AS
DECLARE @oldEmployeeId int, @oldDate date, @oldTask nvarchar (80),
		@oldHours float, @oldComment nvarchar (300)
SELECT @oldEmployeeId = i.EmployeeId, @oldDate = i.Date,
	   @oldTask = i.Task, @oldHours = i.Hours, @oldComment = i.Comments
FROM deleted i
INSERT INTO WorkHoursLogs (OldEmployeeId, OldDate, OldTask,
			OldHours, OldComments, Command)
VALUES (@oldEmployeeId, @oldDate, @oldTask, @oldHours, @oldComment, 'Delete');