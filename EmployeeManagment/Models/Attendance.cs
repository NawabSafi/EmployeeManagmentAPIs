using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagment.Models
{
    public class Attendance
    {
        public Guid id { get; set; }

        [ForeignKey("EmployeeId")]
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public Employee Employee { get; set; }
        public enum Status{
            Present,
            Absent,
            Leave
        }
    }
}
