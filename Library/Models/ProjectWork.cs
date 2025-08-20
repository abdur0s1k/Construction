namespace YourProjectNamespace.Models
{
    public class ProjectWork
    {
        public int ProjectWorkID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ContractID { get; set; }
        public int DepartmentID { get; set; }

        public Contract Contract { get; set; }
        public Department Department { get; set; }
    }
}
