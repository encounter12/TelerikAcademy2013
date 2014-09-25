----------------------------------------------------------------------------------------------------------
-- Task 01.                                                                                             --
-- Create a database with two tables:                                                                   --
-- Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).               --
-- Insert few records for testing. Write a stored procedure that selects the full names of all persons. --
----------------------------------------------------------------------------------------------------------

CREATE DATABASE People
GO
USE People
GO

CREATE TABLE Persons
(
  Id INT IDENTITY PRIMARY KEY,
  FirstName NVARCHAR(32) NOT NULL,
  LastName NVARCHAR(32) NOT NULL,
  SSN CHAR(9) NOT NULL
)

CREATE TABLE Accounts
(
  Id INT IDENTITY PRIMARY KEY,
  PersonId INT NOT NULL FOREIGN KEY REFERENCES Persons(Id),
  Balance MONEY NOT NULL
)

INSERT Persons VALUES('John','Smith','012345678')
INSERT Persons VALUES('Mary','Sue','012345678')
INSERT Persons VALUES('Jane','Doe','012345678')

INSERT Accounts VALUES(1, 1000)
INSERT Accounts VALUES(1, -1000)
INSERT Accounts VALUES(2, 320)
INSERT Accounts VALUES(3, 0)
INSERT Accounts VALUES(3, 1200)
GO

---------------------------------------------------------------------------------------------
-- Task 02.                                                                                --                                                             
-- Create a stored procedure that accepts a number as a parameter                          --
-- and returns all persons who have more money in their accounts than the supplied number. --
---------------------------------------------------------------------------------------------

CREATE PROC usp_FindBalanceOver(@minimumBalance MONEY)
AS
  SELECT *
  FROM Persons JOIN Accounts ON Persons.Id = PersonId
  WHERE Balance > @minimumBalance
GO

EXEC usp_FindBalanceOver 0
EXEC usp_FindBalanceOver 600
EXEC usp_FindBalanceOver 1320
GO

----------------------------------------------------------------------------------------------------
-- Task 03.                                                                                       --
-- Create a function that accepts as parameters - sum, yearly interest rate and number of months. --
-- It should calculate and return the new sum.                                                    --
-- Write a SELECT to test whether the function works as expected.                                 --
----------------------------------------------------------------------------------------------------

CREATE FUNCTION dbo.udf_FinalSum(@initialSum MONEY, @yearlyInterestRate FLOAT, @months INT)
    RETURNS MONEY
AS
BEGIN
    DECLARE @monthlyInterestRate FLOAT
    SET @monthlyInterestRate = POWER(1 + @yearlyInterestRate, 1/12.0) - 1
    RETURN @initialSum*POWER(1+@monthlyInterestRate, @months)
END
GO

SELECT *, dbo.udf_FinalSum(initialSum, yearlyInterestRate, months)
FROM (
    VALUES (100, 0.10, 12),
           (100, 0.20, 12),
           (100, 0.20, 18),
           (100, 0.20, 24)
           ) AS Arguments(initialSum, yearlyInterestRate, months)
GO

--------------------------------------------------------------------------------
-- Task 04.                                                                   --
-- Create a stored procedure that uses the function from the previous example --
-- to give an interest to a person's account for one month.                   --
-- It should take the AccountId and the interest rate as parameters.          --
--------------------------------------------------------------------------------

CREATE PROC usp_CreditAccountInterest(@AccountId INT, @yearlyInterestRate MONEY)
AS
    UPDATE Accounts
    SET Balance = dbo.udf_FinalSum(Balance, @yearlyInterestRate, 1)
    WHERE Id = @AccountId
GO

--------------------------------------------------------------------------------------------------------
-- Task 05.                                                                                           --
-- Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney (AccountId, money) --
-- that operate in transactions.                                                                      --
--------------------------------------------------------------------------------------------------------

CREATE PROC usp_WithdrawMoney(@AccountId INT, @amount MONEY)
AS
    BEGIN TRAN
        UPDATE Accounts
        SET Balance = Balance - @amount
        WHERE Id = @AccountId
    COMMIT
GO

CREATE PROC usp_DepositMoney(@AccountId INT, @amount MONEY)
AS
    BEGIN TRAN
        UPDATE Accounts
        SET Balance = Balance + @amount
        WHERE Id = @AccountId
    COMMIT
GO

-------------------------------------------------------------------------------------
-- Task 06.                                                                        --
-- Create another table - Logs(LogID, AccountID, OldSum, NewSum).                  --
-- Add a trigger to the Accounts table that enters a new entry into the Logs table --
-- every time the sum on an account changes.                                       --
-------------------------------------------------------------------------------------

CREATE TABLE Logs
(
    Id INT IDENTITY PRIMARY KEY,
    AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
    OldSum MONEY NOT NULL,
    NewSum MONEY NOT NULL
)
GO

CREATE TRIGGER tr_LogBalanceChange ON Accounts FOR UPDATE
AS
    INSERT INTO dbo.Logs 
    SELECT inserted.Id, deleted.Balance, inserted.Balance
    FROM deleted JOIN inserted ON deleted.Id = inserted.Id
GO

UPDATE Accounts SET Balance = Balance * 2
GO

-----------------------------------------------------------------------------------------------------
-- Task 07.                                                                                        --
-- Define a function in the database TelerikAcademy that returns all Employee's names              --
-- (first or middle or last name) and all town's names that are comprised of given set of letters. --
-- Example 'oistmiahf' will return 'Sofia', 'Smith', ... but not 'Rob' and 'Guy'.                  --
-----------------------------------------------------------------------------------------------------

USE TelerikAcademy
GO

CREATE FUNCTION CheckIfHasLetters (@word nvarchar(20), @letters nvarchar(20))
	RETURNS BIT
AS
BEGIN
	DECLARE @lettersLen int = LEN(@letters),
	@matches int = 0,
	@currentChar nvarchar(1)

	WHILE(@lettersLen > 0)
	BEGIN
		SET @currentChar = SUBSTRING(@letters, @lettersLen, 1)
		IF(CHARINDEX(@currentChar, @word, 0) > 0)
			BEGIN
				SET @matches += 1
				SET @lettersLen -= 1
			END
		ELSE
		SET @lettersLen -= 1
	END

	IF(@matches >= LEN(@word) OR @matches >= LEN(@letters))
	RETURN 1

	RETURN 0
END

GO

CREATE FUNCTION NamesAndTowns(@letters nvarchar(20))
RETURNS @ResultTable TABLE
(
	Name varchar(50) NOT NULL
)
AS
BEGIN
	INSERT INTO @ResultTable
	SELECT LastName FROM Employees

	INSERT INTO @ResultTable
	SELECT FirstName FROM Employees

	INSERT INTO @ResultTable
	SELECT towns.Name FROM Towns towns

	DELETE FROM @ResultTable
	WHERE dbo.CheckIfHasLetters(Name, @letters) = 0

	RETURN
END

GO

SELECT * FROM dbo.NamesAndTowns('oistmiahf')

---------------------------------------------------------------------------------------------
-- Task 08.                                                                                --
-- Using database cursor write a T-SQL script that scans all employees and their addresses --
-- and prints all pairs of employees that live in the same town.                           --
---------------------------------------------------------------------------------------------

DECLARE employeesPairsCursor CURSOR READ_ONLY FOR
SELECT e.FirstName, e.LastName, t.Name,
	e1.FirstName, e1.LastName
FROM Employees AS e 
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
INNER JOIN Towns AS t ON a.TownID = t.TownID
INNER JOIN Addresses AS a1 ON t.TownID = a1.TownID
INNER JOIN Employees AS e1 ON a1.AddressID = e1.AddressID
WHERE e.EmployeeID != e1.EmployeeID
ORDER BY t.Name ASC, e.FirstName ASC, e.LastName ASC

OPEN employeesPairsCursor
DECLARE @firstName1 NVARCHAR(32)
DECLARE @lastName1 NVARCHAR(32)
DECLARE @town NVARCHAR(32)
DECLARE @firstName2 NVARCHAR(32)
DECLARE @lastName2 NVARCHAR(32)
FETCH NEXT FROM employeesPairsCursor
INTO @firstName1, @lastName1, @town, @firstName2, @lastName2

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT @firstName1 + ' ' + @lastName1 +
          '     ' + @town + '      ' + @firstName2 + ' ' + @lastName2

    FETCH NEXT FROM employeesPairsCursor
    INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
END

CLOSE employeesPairsCursor
DEALLOCATE employeesPairsCursor
GO

----------------------------------------------------------------------------------------------
-- Task 09.                                                                                 --
-- * Write a T-SQL script that shows for each town a list of all employees that live in it. --
-- Sample output:                                                                           --
-- Sofia -> Svetlin Nakov, Martin Kulov, George Denchev                                     --
-- Ottawa -> Jose Saraiva                                                                   --
----------------------------------------------------------------------------------------------

CREATE TABLE #Temp
(
    ID INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(64) NOT NULL,
    TownName NVARCHAR(32) NOT NULL
)

INSERT INTO #Temp
SELECT e.FirstName + ' ' + e.LastName as FullName, t.Name as TownName
FROM Employees AS e
INNER JOIN Addresses AS a ON a.AddressID = e.AddressID
INNER JOIN Towns AS t ON t.TownID = a.TownID
GROUP BY t.TownID, t.Name, e.EmployeeId, e.FirstName, e.LastName

DECLARE @name NVARCHAR(64)
DECLARE @town NVARCHAR(32)

DECLARE townsCursor CURSOR READ_ONLY FOR
SELECT DISTINCT TownName
FROM #Temp

OPEN townsCursor
FETCH NEXT FROM townsCursor
INTO @town

-- nested loops with separate cursors
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT @town

    DECLARE fullNamesCursor CURSOR READ_ONLY FOR
    SELECT tmp.FullName
    FROM #Temp AS tmp
    WHERE TownName = @town
    
    OPEN fullNamesCursor

    FETCH NEXT FROM fullNamesCursor
    INTO @name

    WHILE @@FETCH_STATUS = 0
    BEGIN
        PRINT '   ' + @name
        FETCH NEXT FROM fullNamesCursor INTO @name
    END

    CLOSE fullNamesCursor
    DEALLOCATE fullNamesCursor

    FETCH NEXT FROM townsCursor INTO @town
END

CLOSE townsCursor
DEALLOCATE townsCursor

DROP TABLE #TEMP

GO

------------------------------------------------------------------------------------------
-- Task 10.                                                                             --
-- Define a .NET aggregate function StrConcat that takes as input a sequence of strings -- 
-- and return a single string that consists of the input strings separated by ','.      --
-- For example the following SQL statement should return a single string:               --
-- SELECT StrConcat(FirstName + ' ' + LastName)                                         --
-- FROM Employees                                                                       --
------------------------------------------------------------------------------------------

sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

--Change path to dll
CREATE ASSEMBLY SqlConcatenate
FROM 'D:\Dropbox\Pav\Telerik Academy 2013\Databases\6. Transact-SQL\Homework\SqlConcatenate.dll'  
WITH PERMISSION_SET = SAFE
GO

CREATE AGGREGATE StrConcat(@input nvarchar(100))
RETURNS nvarchar(max)
EXTERNAL NAME SqlConcatenate.Concat;
GO

SELECT dbo.STRCONCAT(FirstName + ' ' + LastName) FROM Employees
