﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_In_Action.Services.CostControl.Entity
{
    public class Income
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }       
        public Income Parent { get; set; }
        public decimal Balance { get; set; }    
    }
}
