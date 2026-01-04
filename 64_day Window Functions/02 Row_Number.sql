use C21_DB1;

select * from students order by grade desc;

--Assigns a unique integer to each row within the result set.

SELECT 
    StudentID, 
    Name, 
    Subject, 
    Grade,
    ROW_NUMBER() OVER (ORDER BY Grade DESC) AS RowNum
FROM 
    Students order by grade desc;



	

	select *from Students ; 

	select  * from Students order by Grade desc ; 


	select 
	StudentID ,
	Name , 
	Subject , 
	Grade , 
	ROW_NUMBER () over (Order By Grade desc)as RowNum 
	from Students order by grade desc ; 

	select 
	StudentID , 
	Name , 
	Subject ,
	Grade , 
	RANK () over  (order by Grade desc) as RowNum 
	from Students order by Grade desc ; 

	select 
	StudentID , 
	Name ,  
	Subject ,
	Grade , 
	 DENSE_RANK ()  over  (order by Grade desc) as RowNum 
	from Students order by Grade desc ; 

	select 
	StudentID , 
	Name ,  
	Subject ,
	Grade , 
	 RANK ()  over  (partition by subject  order by  Grade desc ) as GradeRank  
	from Students  ;  

	select 
	StudentID , 
	Name , 
	Subject, 
	Grade , 
	avg (Grade ) over (partition by subject )as subjectAVG , 
	sum (Grade ) over (partition by subject )as SubjectTotal
	from Students order by subject ; 

	

select 
	Name , 
	Subject, 
	lag (Grade , 1 ) over (order by Grade desc) as previousGrade, 
	Grade , 
	lead (Grade  , 1 ) over (order by Grade desc ) as NextGrade 
from Students order by Grade  desc  ; 

