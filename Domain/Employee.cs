using System;
using System.Linq;

namespace Domain
{
    public class Employee
    {
        public User UserInfo { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string ServiceLine { get; set; }
        public string Role { get; set; }

    }
}
