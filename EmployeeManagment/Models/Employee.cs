using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmployeeManagment.Models
{
    public class Employee
    {
        public Guid id {  get; set; }
        public string FirsteName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
       public string Position { get; set; }
        public DateOnly DateOfHire { get; set; }
        public Decimal Salary { get;set; }
      
        public Guid? DepartmentId { get;set; }
        [JsonIgnore]
        public Department Department { get; set; }
        [JsonIgnore]
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
        [JsonIgnore]
        public ICollection<Attendance> Attendances { get; set; }


    }
}
