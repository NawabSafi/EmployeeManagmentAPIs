using EmployeeManagment.Data;
using EmployeeManagment.Models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeeProjectController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpPost("AddEmployeeToProject")]
        public IActionResult AddEmployee(EmployeeProjectViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = _context.Employees.FirstOrDefault(e => e.FirsteName == viewModel.EmployeeName);
            if(employee == null)
            {
                return NotFound("Employee Not found");
            }
            var project = _context.Projects.FirstOrDefault(p => p.ProjectName==viewModel.ProjectName);
            if(project == null)
            {
                return NotFound("Ptoject Not found");
            }
            var EmpProject = new EmployeeProject
            {
                Role = viewModel.Role,
                EmployeeId=employee.id,
                ProjectId=project.id,
            };
            _context.Add(EmpProject);
            _context.SaveChanges();
            return Ok();
        }
    }
}
