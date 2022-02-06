using System;

namespace DanilDev.Services.CostControl.Entity
{
    public class Transaction
    {
        public long Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public Account AccountFrom { get; set; }
        public Account AccountTo { get; set; }
        public Income Income { get; set; }
        public decimal Amount { get; set; }
        public Expense Expense { get; set; }
        public User User { get; set; }
    }
}
