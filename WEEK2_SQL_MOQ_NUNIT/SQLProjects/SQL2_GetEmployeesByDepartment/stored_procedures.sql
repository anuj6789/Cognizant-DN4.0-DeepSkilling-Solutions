
DELIMITER $$
CREATE PROCEDURE sp_GetEmployeesByDepartment(IN dep_id INT)
BEGIN
    SELECT *
    FROM Employees
    WHERE DepartmentID = dep_id;
END $$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE sp_InsertEmployee(
    IN p_FirstName VARCHAR(50),
    IN p_LastName VARCHAR(50),
    IN p_DepartmentID INT,
    IN p_Salary DECIMAL(10,2),
    IN p_JoinDate DATE
)
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (p_FirstName, p_LastName, p_DepartmentID, p_Salary, p_JoinDate);
END $$
DELIMITER ;


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
