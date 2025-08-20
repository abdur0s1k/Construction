namespace YourProjectNamespace.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int Floor { get; set; }
        public string Phone { get; set; }
        public string DepartmentHead { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<ProjectWork> ProjectWorks { get; set; }
    }
}
