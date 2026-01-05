
use C21_DB1;
go

select * from Students;

DECLARE @PageNumber AS INT, @RowsPerPage AS INT;
SET @PageNumber = 2;
SET @RowsPerPage = 3;
SELECT StudentID, Name, Subject, Grade
FROM Students
ORDER BY StudentID
OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY;

-- Explanation:
-- 1. @PageNumber is set to 2, indicating the second page is to be retrieved.
-- 2. @RowsPerPage is set to 3, meaning each page will display 3 records.
-- 3. The OFFSET clause skips (2-1)*3 = 3 rows (as this is page 2).
-- 4. The FETCH NEXT clause then fetches the next 3 rows after the offset.
-- 5. The result is records 4, 5, and 6 from the Students table, assuming
--    sequential ordering by StudentID.
