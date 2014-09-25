-- TASK 3
-- Get each employee’s full name (first name + “ “ + last name),
-- project’s name, department’s name, starting and ending date for
-- each employee in project. Additionally get the number of all
-- reports, which time of reporting is between the start and end
-- date. Sort the results first by the employee id, then by the 
-- project id. (This query is slow, be patient!)

USE [Company20140908]
GO

SELECT e.FirstName + ' ' + e.LastName AS [Employee's Full Name],
	p.Name, ep.StartingDate, ep.EndingDate, d.Name
FROM Employees e
	JOIN EmployeesProjects ep
		ON ep.EmployeeId = e.Id
	JOIN Projects p
		ON p.Id = ep.ProjectId
	JOIN Departments d
		ON e.DepartmentId = d.Id
ORDER BY e.Id, p.Id
