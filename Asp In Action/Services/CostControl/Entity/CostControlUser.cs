using System.Collections.Generic;

namespace Asp_In_Action.Services.CostControl.Entity
{
    public class CostControlUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public List<CostControlAccount> Accounts { get; set; } = new List<CostControlAccount>();
        public List<CostControlIncome> Incomes { get; set; } = new List<CostControlIncome>();
        public List<CostControlExpense> Expenses { get; set; } = new List<CostControlExpense>();
        public List<CostControlTransaction> Transactions { get; set; } = new List<CostControlTransaction> ();
    }
}
