namespace YourProjectNamespace.Models
{
    public class Contract
    {
        public int ContractID { get; set; }
        public string ContractNumber { get; set; }
        public DateTime ContractDate { get; set; }
        public int OrganizationID { get; set; }
        public decimal ContractValue { get; set; }

        public Organization Organization { get; set; }
        public ICollection<ProjectWork> ProjectWorks { get; set; }
    }
}
