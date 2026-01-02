/* ============================================================
   File: People_StoredProcedures.sql
   Description: Stored Procedures for managing People table
   Database: SQL Server
   ============================================================ */

USE C21_DB1;
GO

/* ============================================================
   SP_AddNewPerson
   Purpose: Adds a new person and returns the new PersonID
   ============================================================ */
IF OBJECT_ID('SP_AddNewPerson', 'P') IS NOT NULL
    DROP PROCEDURE SP_AddNewPerson;
GO

CREATE PROCEDURE SP_AddNewPerson 
    @FirstName NVARCHAR(100), 
    @LastName NVARCHAR(100), 
    @Email NVARCHAR(255),
    @NewPersonID INT OUTPUT
AS
BEGIN
    INSERT INTO People (FirstName, LastName, Email)
    VALUES (@FirstName, @LastName, @Email);

    SET @NewPersonID = CAST(SCOPE_IDENTITY() AS INT);
END
GO

/* ============================================================
   SP_GetAllPeople
   Purpose: Returns all records from People table
   ============================================================ */
IF OBJECT_ID('SP_GetAllPeople', 'P') IS NOT NULL
    DROP PROCEDURE SP_GetAllPeople;
GO

CREATE PROCEDURE SP_GetAllPeople
AS
BEGIN
    SELECT * FROM People;
END
GO

/* ============================================================
   SP_GetPersonByID
   Purpose: Returns a person by PersonID
   ============================================================ */
IF OBJECT_ID('SP_GetPersonByID', 'P') IS NOT NULL
    DROP PROCEDURE SP_GetPersonByID;
GO

CREATE PROCEDURE SP_GetPersonByID
    @PersonID INT
AS
BEGIN
    SELECT * FROM People WHERE PersonID = @PersonID;
END
GO

/* ============================================================
   SP_GetPersonByID2
   Purpose: Returns person info using OUTPUT parameters
   ============================================================ */
IF OBJECT_ID('SP_GetPersonByID2', 'P') IS NOT NULL
    DROP PROCEDURE SP_GetPersonByID2;
GO

CREATE PROCEDURE SP_GetPersonByID2
    @PersonID INT,
    @FirstName NVARCHAR(100) OUTPUT,
    @LastName NVARCHAR(100) OUTPUT,
    @Email NVARCHAR(255) OUTPUT,
    @IsFound BIT OUTPUT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM People WHERE PersonID = @PersonID)
    BEGIN
        SELECT 
            @FirstName = FirstName,
            @LastName = LastName,
            @Email = Email
        FROM People
        WHERE PersonID = @PersonID;

        SET @IsFound = 1;
    END
    ELSE
        SET @IsFound = 0;
END
GO

/* ============================================================
   SP_UpdatePerson
   Purpose: Updates a person's information
   ============================================================ */
IF OBJECT_ID('SP_UpdatePerson', 'P') IS NOT NULL
    DROP PROCEDURE SP_UpdatePerson;
GO

CREATE PROCEDURE SP_UpdatePerson
    @PersonID INT,
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255)
AS
BEGIN
    UPDATE People
    SET FirstName = @FirstName,
        LastName = @LastName,
        Email = @Email
    WHERE PersonID = @PersonID;
END
GO

/* ============================================================
   SP_DeletePerson
   Purpose: Deletes a person by PersonID
   ============================================================ */
IF OBJECT_ID('SP_DeletePerson', 'P') IS NOT NULL
    DROP PROCEDURE SP_DeletePerson;
GO

CREATE PROCEDURE SP_DeletePerson
    @PersonID INT
AS
BEGIN
    DELETE FROM People WHERE PersonID = @PersonID;
END
GO

/* ============================================================
   SP_CheckPersonExists
   Purpose: Checks if a person exists
   Returns: 1 = Exists, 0 = Not Exists
   ============================================================ */
IF OBJECT_ID('SP_CheckPersonExists', 'P') IS NOT NULL
    DROP PROCEDURE SP_CheckPersonExists;
GO

CREATE PROCEDURE SP_CheckPersonExists
    @PersonID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM People WHERE PersonID = @PersonID)
        RETURN 1;
    ELSE
        RETURN 0;
END
GO

 EXEC  sp_helptext SP_CheckPersonExists ;