using Microsoft.Maui.Controls;

namespace RefuseServiceDispatchApp.Models
{
    public class Employee
    {
        public enum RoleType { Thrower, Driver, Management }

        private RoleType _role;

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleType Role { get; set; }
        public DateTime? CdlExpiration { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
    }
}