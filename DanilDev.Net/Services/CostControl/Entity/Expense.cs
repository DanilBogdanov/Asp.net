using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanilDev.Services.CostControl.Entity
{
    public class Expense
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public Expense Parent { get; set; }  
        public User User { get; set; }
    }
}
