using System.Text.Json.Serialization;

namespace EmployeeManagment.Models
{
    public class EmployeeProject
    {
        public int  Guid  { get; set; }
        [JsonIgnore]
        public Guid EmployeeId { get; set; }
        [JsonIgnore]
        public Guid ProjectId { get; set; }
        public string Role { get;set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }    
    }
}
