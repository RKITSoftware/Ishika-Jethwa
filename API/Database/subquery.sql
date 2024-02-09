use DDL;
-- subquery
 
	(SELECT 
		emp01f02,
		emp01f05 
	FROM 
		emp01 
	WHERE 
		emp01f05 > 
			(SELECT 
				AVG(emp01f05) 
			FROM 
				emp01)) 
	
