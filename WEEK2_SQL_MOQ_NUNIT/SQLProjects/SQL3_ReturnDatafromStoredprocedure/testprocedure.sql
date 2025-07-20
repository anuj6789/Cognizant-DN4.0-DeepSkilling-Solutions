
SET @count = 0;


CALL sp_GetEmployeeCountByDepartment(3, @count);


SELECT @count AS EmployeeCount;
