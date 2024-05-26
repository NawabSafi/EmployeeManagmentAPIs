using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmployeeManagment.Models
{
    public class Department
    {
        public Guid id { get; set; }

        public string DepartmentName { get; set; }
       
        public Guid ManagerId { get; set; }
        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; }
    }
}
