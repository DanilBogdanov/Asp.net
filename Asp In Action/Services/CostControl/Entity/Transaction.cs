using System;

namespace Asp_In_Action.Services.CostControl.Entity
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Income Income { get; set; }
        public decimal Amount { get; set; }
        public Expense Expense { get; set; }

    }
}
