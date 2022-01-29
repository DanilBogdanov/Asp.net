using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_In_Action.Services.CostControl.Entity
{
    public class Income
    {
        public long Id { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }       
        public Income Parent { get; set; } 
        public User User { get; set; }
    }
}
