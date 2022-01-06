using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_In_Action.Services.CostControl.Entity
{
    public class Balance
    {
        public int Id { get; set; }
        public User User { get; set; }

        public List<Income> Incomessssss { get; set; } = new List<Income>();
    }
}
