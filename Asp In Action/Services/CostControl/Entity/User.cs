using System.Collections.Generic;

namespace Asp_In_Action.Services.CostControl.Entity
{
    public class User
    {
        public int Id { get; set; }
        //public int GlobalUserId { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Income> Incomes { get; set; } = new List<Income>();
        public List<Expense> Expenses { get; set; } = new List<Expense>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction> ();
    }
}
