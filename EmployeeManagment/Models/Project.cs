using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmployeeManagment.Models
{
    public class Project
    {
        public Guid id { get; set; }
        public string ProjectName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        
        public decimal Budget { get; set; }
        [JsonIgnore]
      
        public Guid ProjectManagmenrId { get; set; }
        [JsonIgnore]
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
