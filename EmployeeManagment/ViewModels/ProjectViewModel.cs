namespace EmployeeManagment.ViewModels
{
    public class ProjectViewModel
    {
        public string ProjectName {  get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal Budget {  get; set; }
    }
}
