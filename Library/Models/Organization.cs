namespace YourProjectNamespace.Models
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string BusinessType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string DirectorFullName { get; set; }

        public ICollection<Contract> Contracts { get; set; }
    }
}
