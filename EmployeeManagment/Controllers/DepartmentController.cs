using EmployeeManagment.Data;
using EmployeeManagment.Models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public DepartmentController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartment(DepartmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var department = await _context.Departments
                                            .FirstOrDefaultAsync(d => d.DepartmentName == viewModel.DepartmentName);
            if (department != null)
            {
                return BadRequest("Department Already Exists");
            }
            var dep = new Department
            {
                DepartmentName = viewModel.DepartmentName,
               
            };
            _context.Departments.Add(dep);
            await _context.SaveChangesAsync();
            return Ok("Department Added Successfully");
        }

        [HttpPost("AssignManager")]
        public IActionResult AssignManagerToDepartment(string departmentname,string ManagerName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var department = _context.Departments.FirstOrDefault(x=>x.DepartmentName==departmentname);
            if (department == null)
            {
                return BadRequest("Department Not Found");
            }
            var Manager = _context.Employees.FirstOrDefault(e => e.FirsteName == ManagerName);
            if(Manager == null)
            {
                return BadRequest("Employee Not Found");
            }
            department.ManagerId = Manager.id;
            _context.SaveChanges();
            return Ok("Manager Assign");
        }
        [HttpGet("GetEmployees")]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees(string DepartmentName) {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var employees = _context.Departments
                           .Where(d => d.DepartmentName == DepartmentName)
                           .SelectMany(d => d.Employees) 
                           .ToList();
            if (employees == null || !employees.Any())
            {
                return NotFound("No employees found for the specified department.");
            }

            return Ok(employees);
        }

    }
}
