namespace EmployeeManagment.ViewModels
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public DateOnly DateOfHire { get; set; }
        public decimal Salary { get; set; } 
    
    }
}
