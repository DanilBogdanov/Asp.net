using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanilDev.Services.EmploeesDirectory.Entity
{
    public class Employee
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public Organization Organization { get; set; }
        public Department Department { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
