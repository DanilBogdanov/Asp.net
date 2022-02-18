using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanilDev.Services.EmploeesDirectory.Entity
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }        
        public Organization Organization { get; set; }
        public long OrganizationId { get; set; }
    }
}
