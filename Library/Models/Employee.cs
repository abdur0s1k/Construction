namespace YourProjectNamespace.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int DepartmentID { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Department Department { get; set; }
    }
}
