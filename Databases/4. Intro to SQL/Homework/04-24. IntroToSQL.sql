--README: Open the current script (sql file) with Microsoft SQL Server Management Studio: File - Open - File (Ctrl + O). 
--In order to run specific query just highlight it and click on Execute (press F5).

--Tasks:

--04. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

SELECT * 
FROM [TelerikAcademy].[dbo].[Departments]

--05. Write a SQL query to find all department names.

SELECT Name 
FROM [TelerikAcademy].[dbo].[Departments]

--06. Write a SQL query to find the salary of each employee.

SELECT FirstName, MiddleName, LastName, Salary 
FROM [TelerikAcademy].[dbo].[Employees]

--07. Write a SQL to find the full name of each employee.

SELECT REPLACE(CONCAT(emp.FirstName, ' ', emp.MiddleName, ' ', emp.LastName),'  ', ' ') AS FullName
FROM [TelerikAcademy].[dbo].[Employees] AS emp

--08. Write a SQL query to find the email addresses of each employee (by his first and last name). 
--Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".

SELECT CONCAT(emp.FirstName, '.', emp.LastName, '@telerik.com') AS [Full Email Addresses]
FROM [TelerikAcademy].[dbo].[Employees] AS emp

--09. Write a SQL query to find all different employee salaries.

SELECT DISTINCT REPLACE(CONCAT(emp.FirstName, ' ', emp.MiddleName, ' ', emp.LastName),'  ', ' ') AS FullName, emp.Salary
FROM [TelerikAcademy].[dbo].[Employees] AS emp


--10. Write a SQL query to find all information about the employees whose job title is "Sales Representative".

SELECT emp.*, dept.Name AS DepartmentName
FROM [TelerikAcademy].[dbo].[Employees] AS emp
	INNER JOIN Departments dept
		ON emp.DepartmentID = dept.DepartmentID
WHERE emp.JobTitle = 'Sales Representative'

--11. Write a SQL query to find the names of all employees whose first name starts with "SA".

SELECT FirstName, LastName
FROM [TelerikAcademy].[dbo].[Employees]
WHERE FirstName LIKE 'SA%'

--12. Write a SQL query to find the names of all employees whose last name contains "ei".

USE TelerikAcademy
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--13. Write a SQL query to find the salary of all employees whose salary is in the range [20000 ... 30000].

USE TelerikAcademy
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

USE TelerikAcademy
SELECT FirstName, LastName, Salary
FROM Employees AS emp
WHERE emp.Salary IN (25000, 14000, 12500, 23600)
ORDER BY emp.Salary

--15. Write a SQL query to find all employees that do not have manager.

USE TelerikAcademy
SELECT FirstName, LastName, ManagerID
FROM Employees AS emp
WHERE emp.ManagerID IS NULL

--16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

USE TelerikAcademy
SELECT FirstName, LastName, Salary
FROM Employees AS emp
WHERE emp.Salary > 50000
ORDER BY emp.Salary

--17. Write a SQL query to find the top 5 best paid employees.

USE TelerikAcademy
SELECT TOP 5 FirstName, LastName, Salary
FROM Employees AS emp
ORDER BY emp.Salary DESC

--18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.

USE TelerikAcademy
SELECT emp.FirstName, emp.LastName, addr.AddressText
FROM Employees emp
	INNER JOIN Addresses addr
		ON emp.AddressID = addr.AddressID

--19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).

USE TelerikAcademy
SELECT emp.FirstName, emp.LastName, addr.AddressText
FROM Employees emp, Addresses addr
WHERE emp.AddressID = addr.AddressID

--20. Write a SQL query to find all employees along with their manager.

USE TelerikAcademy
SELECT CONCAT(emp.FirstName, ' ', emp.LastName) AS EmployeeName, CONCAT(mgr.FirstName, ' ', mgr.LastName) AS ManagerName
FROM Employees emp, Employees mgr
WHERE emp.ManagerID = mgr.EmployeeID

--21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.

USE TelerikAcademy
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, a.AddressText AS Address, CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName
FROM Employees e
	INNER JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID


--22. Write a SQL query to find all departments and all town names as a single list. Use UNION.

USE TelerikAcademy
SELECT Name AS DepartmentsTowns
FROM Departments
UNION
SELECT Name AS DepartmentsTowns
FROM Towns

--23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 
--Use right outer join. Rewrite the query to use left outer join.

USE TelerikAcademy
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName
FROM Employees e 
	LEFT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

USE TelerikAcademy
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName
FROM Employees m 
	RIGHT OUTER JOIN Employees e
		ON e.ManagerID = m.EmployeeID

--24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.

USE TelerikAcademy
SELECT e.FirstName, e.LastName, d.Name, e.HireDate
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE (YEAR(e.HireDate) BETWEEN 1995 AND 2005) 
	AND (d.Name IN ('Sales', 'Finance'))