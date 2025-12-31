
	use C21_DB1;

	 BEGIN TRY
        -- Intentional division by zero error
        SELECT 1 / 0;
    END TRY
    BEGIN CATCH
        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_SEVERITY() AS ErrorSeverity,
            ERROR_STATE() AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE() AS ErrorLine,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH

	




    declare @NewStockQty INT;

	set @NewStockQty=-5;


    -- Start a TRY block
    BEGIN TRY
        -- Check if NewStockQty is negative
        IF @NewStockQty < 0
            THROW 51000, 'Stock quantity cannot be negative.', 1;

        -- Proceed with updating stock (example code)
        UPDATE Products SET StockQuantity = @NewStockQty WHERE ProductID = 1;
    END TRY

    -- Start a CATCH block to handle the error
    BEGIN CATCH
        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH


	insert into Departments  (DepartmentID , Name)
	values (1,'Business')

	Declare @errorNumber int = @@Error ; 
	if	@errorNumber <>   0 
	begin 
		print 'an error occurred during the insert operation '; 
		print 'the error number is : '+cast (@errorNumber as varchar); 
	end 



	-- use Row affected 
	update Employees set DepartmentID = 3 where DepartmentID=4 ; 
	select @@ROWCOUNT as RowsAffected ; 