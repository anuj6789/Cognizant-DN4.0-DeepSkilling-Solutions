-- stored_procedures.sql

-- Procedure: Get employee count by department
DELIMITER $$
CREATE PROCEDURE sp_GetEmployeeCountByDepartment(
    IN dep_id INT,
    OUT emp_count INT
)
BEGIN
    SELECT COUNT(*) INTO emp_count
    FROM Employees
    WHERE DepartmentID = dep_id;
END $$
DELIMITER ;
