using System.Collections.Generic;
using System;

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

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int DepartmentID { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Department Department { get; set; }
    }

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
