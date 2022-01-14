using System;

namespace Asp_In_Action.Services.CostControl.Entity
{
    public class CostControlTransaction
    {
        public int Id { get; set; }
        public CostControlTransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public CostControlIncome Income { get; set; }
        public decimal Amount { get; set; }
        public CostControlExpense Expense { get; set; }

    }
}
