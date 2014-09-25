USE [ToysStore]
GO

-- Get all toys' name, price and color from category "boys"

SELECT t.Name, t.Price, t.Color
FROM Toys as t
INNER JOIN ToysCategories AS tc ON t.Id = tc.ToyId
INNER JOIN Categories as C ON tc.CategoryId = c.Id
WHERE c.Name = 'boys'
ORDER BY t.Name ASC