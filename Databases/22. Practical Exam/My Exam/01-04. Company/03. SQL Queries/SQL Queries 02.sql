USE Company
GO
SELECT d.Name AS DepartmentName, COUNT(e.Id) AS EmployeesCount
FROM Departments d
	INNER JOIN Employees e ON d.Id = e.DepartmentId
GROUP BY d.Name
GO