# Employee Management System SQL Project

A simple employee management system using SQL, featuring stored procedures for data retrieval and manipulation.

## Contents

- `schema.sql` — Table creation scripts for Departments and Employees.
- `data.sql` — Sample data for both tables.
- `stored_procedures.sql` — Stored procedures to:
  - Retrieve employees by department.
  - Insert new employees.
  - Get the count of employees in a department.
- `OUTPUT1.jpg`, `OUTPUT2.jpg` — Example output screenshots.

## How to Use

1. Run `schema.sql` to create all tables.
2. Run `data.sql` to insert sample data.
3. Run `stored_procedures.sql` to create stored procedures.
4. Test the procedures using:
   - `CALL sp_GetEmployeesByDepartment(1);`
   - `CALL sp_InsertEmployee('Alice', 'Williams', 3, 8000.00, '2022-05-10');`
   - `SET @count = 0; CALL sp_GetEmployeeCountByDepartment(3, @count); SELECT @count;`
5. See screenshots for sample output.

## Example

Retrieve all employees in a department or count employees using stored procedures.
