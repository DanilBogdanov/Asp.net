﻿namespace Asp_In_Action.Services.CostControl.Entity
{
    public class Balance
    {
        public long Id { get; set; }        
        public Account Account { get; set; }
        public decimal Amount { get; set; }
    }
}
