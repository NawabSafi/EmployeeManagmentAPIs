using Microsoft.AspNetCore.Identity;


namespace EmployeeManagment.Models
{
    public class ApplicationUser :IdentityUser
    {
     
    
        public string PhonenNumber { get; set; }
    }
}
