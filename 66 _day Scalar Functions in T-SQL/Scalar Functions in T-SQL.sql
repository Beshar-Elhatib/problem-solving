



CREATE FUNCTION dbo.getAverageGrade (@subject NVARCHAR(50))
RETURNS DECIMAL(5,2)
AS  
BEGIN  
	RETURN (
		SELECT ISNULL(AVG(CAST(Grade AS DECIMAL(5,2))), 0)
		FROM Students 
		WHERE Subject = @subject
	);
END;


	print [dbo].[getAverageGrade] ('Math');
		
		
PRINT 'MATH AVRAGE: ' + CAST(dbo.getAverageGrade('Math') AS NVARCHAR(10));
GO

SELECT 
    T.Name AS TeacherName, 
    T.Subject,
    (SELECT AVG(Grade)  FROM Students WHERE Subject = T.Subject) AS SubjectAverageGrade
FROM Teachers T;