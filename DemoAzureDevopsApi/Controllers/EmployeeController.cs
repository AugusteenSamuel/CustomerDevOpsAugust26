using Microsoft.AspNetCore.Mvc;
 
namespace DemoAzureDevopsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
          new Employee{Id = 1,Name = "John",Department = "IT",Salary = 50000},
          new Employee{Id = 2,Name = "David",Department = "HR",Salary = 45000},
          new Employee{Id=3, Name="Samuel", Department="Payroll", Salary=15000}
        };
 
        // GET: api/Employee
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(employees);
        }
 
        // GET: api/Employee/1
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault(x => x.Id == id);
 
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
 
            return Ok(employee);
        }
 
        // POST: api/Employee
        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            employee.Id = employees.Count + 1;
 
            employees.Add(employee);
 
            return CreatedAtAction(
                nameof(GetEmployee),
                new { id = employee.Id },
                employee);
        }
 
        // PUT: api/Employee/1
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = employees.FirstOrDefault(x => x.Id == id);
 
            if (existingEmployee == null)
            {
                return NotFound("Employee not found");
            }
 
            existingEmployee.Name = employee.Name;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;
 
            return Ok(existingEmployee);
        }
 
        // DELETE: api/Employee/1
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(x => x.Id == id);
 
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
 
            employees.Remove(employee);
 
            return Ok("Employee deleted successfully");
        }
    }
 
    public class Employee
    {
        public int Id { get; set; }
 
        public string Name { get; set; } = string.Empty;
 
        public string Department { get; set; } = string.Empty;
 
        public decimal Salary { get; set; }
    }
}
 