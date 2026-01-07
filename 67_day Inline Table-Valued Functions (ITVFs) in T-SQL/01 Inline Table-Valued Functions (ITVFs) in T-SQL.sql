
CREATE FUNCTION dbo.GetStudentsBySubject
(
    @Subject NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Students
    WHERE Subject = @Subject
)

select * from dbo.GetStudentsBySubjec('Math')
select AVG(Grade) as GradeAVG from dbo.GetStudentsBySubjec('Math')
