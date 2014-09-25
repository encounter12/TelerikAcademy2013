-- TASK 2
-- Get all departments and how many employees there are in each one.
-- Sort the result by the number of employees in descending order.

USE [Company20140908]
GO

SELECT Name, (
	SELECT COUNT(*)
	FROM Employees e
	JOIN Departments d
	ON e.DepartmentId = d.Id
) AS [Number Of Employees]
FROM Departments
ORDER BY [Number Of Employees] DESC
