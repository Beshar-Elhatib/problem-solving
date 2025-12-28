	DECLARE @Counter INT = 1;

	--This loop prints numbers from 1 to 5.
	WHILE @Counter <= 5
	BEGIN
		PRINT 'Count: ' + CAST(@Counter AS VARCHAR);
		SET @Counter = @Counter + 1;
	END

	Print '';
	Print 'Revered Counter';

	--This loop prints numbers from 5 to 1.
	set @Counter= 5;

	WHILE @Counter > 0
	BEGIN
		PRINT 'Count: ' + CAST(@Counter AS VARCHAR);
		SET @Counter = @Counter - 1;
	END


	
--This loop iterates over each employee in the Employees table.
print ' ' 

DECLARE @EmployeeID INT;
DECLARE @Name varchar(50);
DECLARE @MaxID INT;

-- Initialize the starting point
SELECT @EmployeeID = MIN(EmployeeID) FROM Employees;

-- Find the maximum EmployeeID
SELECT @MaxID = MAX(EmployeeID) FROM Employees;

-- Loop through employees
WHILE @EmployeeID IS NOT NULL AND @EmployeeID <= @MaxID
BEGIN
    -- Perform an operation, e.g., print employee's name
    SELECT @Name=Name FROM Employees WHERE EmployeeID = @EmployeeID;
	PRINT @Name;

    -- Get the next EmployeeID
    SELECT @EmployeeID = MIN(EmployeeID) FROM Employees WHERE EmployeeID > @EmployeeID;

END
