using EmployeeManagment.Data;
using EmployeeManagment.Models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public ProjectController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpPost("AddProject")]
        public IActionResult AddProject(ProjectViewModel projectviewmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (projectviewmodel == null)
            {
                return BadRequest(string.Empty);
            }
            var project = new Project
            {
                ProjectName = projectviewmodel.ProjectName,
                StartDate = projectviewmodel.StartDate,
                EndDate = projectviewmodel.EndDate,
                Budget=projectviewmodel.Budget,
            };
            _context.Add(project);
            _context.SaveChanges();
            return Ok(project);
        }
        [HttpGet("GetAllProject")]
        public ActionResult<IEnumerable<Project>> GetAllProjects()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var projects = _context.Projects.ToList();
            if(projects is null)
            {
                return BadRequest("No project found");
            }
            return Ok();
        }
    }
}
