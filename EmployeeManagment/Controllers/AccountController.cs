using EmployeeManagment.Models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace EmployeeManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> usermanager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }
      [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model == null)
                {
                    return BadRequest();
                }

            }
  
          

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email=model.Email,
                PhonenNumber=model.PhoneNumber,
        };
            var result=await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                return Ok("User Create " +model.UserName);

            }
          
            return BadRequest();
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound("User not Found");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
            if (result.Succeeded)
            {
                return Ok("User logged in");
            }
            return BadRequest("User Not Logged in");
        }

    }
}
