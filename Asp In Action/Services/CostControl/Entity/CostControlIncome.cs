using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_In_Action.Services.CostControl.Entity
{
    public class CostControlIncome
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }       
        public CostControlIncome Parent { get; set; }            
    }
}
