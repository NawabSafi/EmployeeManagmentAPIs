using EmployeeManagment.Data;
using EmployeeManagment.Models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmployeeManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewModel employeeViewModel)
        {
            // Check if employeeViewModel is null
            if (employeeViewModel == null)
            {
                return BadRequest("Invalid employee data.");
            }




            var employe = _context.Employees.FirstOrDefault(e => e.Email == employeeViewModel.Email);
            if (employe != null)
            {
                return BadRequest("Employee Already Exist");
            }


            // Create a new Employee object
            var employee = new Employee
            {
                id = Guid.NewGuid(),
                FirsteName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                Email = employeeViewModel.Email,
                Salary = employeeViewModel.Salary,
                DateOfBirth = employeeViewModel.DateOfBirth,
                DateOfHire = employeeViewModel.DateOfHire,
                Position = employeeViewModel.Position,
                Gender = employeeViewModel.Gender,

            };

            // Add the employee to the database
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Ok(employee);
        }

        [HttpPost("AssignDepartment")]
        public  IActionResult AssignDepartment(string departmentName,string empName){
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var emp =  _context.Employees
     .FirstOrDefault(x =>x.FirsteName==empName);
            if(emp == null)
            {
                return NotFound("Employee Not Found");
            }
            var department =  _context.Departments.FirstOrDefault(d => d.DepartmentName == departmentName);
            if (department == null)
            {
                return NotFound("Department Not Found");
            }
            emp.DepartmentId = department.id;
            _context.Employees.Add(emp);
            _context.SaveChanges();

            return Ok("Department Assign too " + emp);

        }

    }
}
