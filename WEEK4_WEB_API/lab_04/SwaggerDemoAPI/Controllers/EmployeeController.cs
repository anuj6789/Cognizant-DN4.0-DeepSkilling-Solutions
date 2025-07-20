using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SwaggerDemoAPI.Models;
using SwaggerDemoAPI.Filters;

namespace SwaggerDemoAPI.Controllers
{
    [ApiController]
    [Route("api/emp")]
    [ServiceFilter(typeof(CustomAuthFilter))]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Alice",
                Salary = 60000,
                Permanent = true,
                Department = new Department { Id = 1, Name = "IT" },
                Skills = new List<Skill> {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = "SQL" }
                },
                DateOfBirth = new DateTime(1990, 5, 1)
            }
        };

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<Employee>> GetAll()
        {
            return Ok(employees);
        }

        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee emp)
        {
            emp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(emp);
            return Ok(emp);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee emp)
        {
            var existing = employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return NotFound("Employee not found");

            existing.Name = emp.Name;
            existing.Salary = emp.Salary;
            existing.Permanent = emp.Permanent;
            existing.Department = emp.Department;
            existing.Skills = emp.Skills;
            existing.DateOfBirth = emp.DateOfBirth;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found");

            employees.Remove(emp);
            return Ok($"Deleted employee {id}");
        }
    }
}
