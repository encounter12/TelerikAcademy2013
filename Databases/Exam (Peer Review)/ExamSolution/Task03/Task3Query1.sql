-- TASK 1
-- Get the full name (first name + “ “ + last name)  of every employee and
-- their salary, for each employee with salary between $100 000 and $150 000,
-- inclusive. Sort the results by salary in ascending order.

USE [Company20140908]
GO

SELECT FirstName + ' ' + LastName AS [EmployeeName], AnnualSalary
FROM Employees
WHERE AnnualSalary >= 100000 AND AnnualSalary <= 150000
ORDER BY AnnualSalary
