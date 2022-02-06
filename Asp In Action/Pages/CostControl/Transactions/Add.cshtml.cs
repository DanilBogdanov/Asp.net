using DanilDev.Data;
using DanilDev.Services.CostControl;
using DanilDev.Services.CostControl.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DanilDev.Pages.CostControl.Transactions
{
    public class AddModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CostControlService _costControlService;    
        private User _costControlUser;
        [BindProperty(SupportsGet = true)]
        public string Type { get; set; } 
        public List<Account> Accounts { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
        public AddModel(UserManager<ApplicationUser> userManager, CostControlService costControlService)
        {
            _userManager = userManager;
            _costControlService = costControlService;
        }

        public void OnGet()
        {
            LoadProperties();
        }

        public RedirectResult OnPost(
            TransactionType transactionType,
            long transactionAccountFromId,
            long transactionAccountToId,
            long transactionIncomeId,
            long transactionExpenseId,
            string transactionDescription,
            decimal transactionAmount,
            string referrer)
        {
            LoadProperties();

            var accountFrom = Accounts.Find(acc => acc.Id == transactionAccountFromId);
            var accountTo = Accounts.Find(acc => acc.Id == transactionAccountToId);
            var income = Incomes.Find(income => income.Id == transactionIncomeId);
            var expense = Expenses.Find(expense => expense.Id == transactionExpenseId);

            Transaction transaction = new Transaction
            {
                Type = transactionType,
                AccountFrom = accountFrom,
                AccountTo = accountTo,
                Income = income,
                Expense = expense,
                Description = transactionDescription,
                Amount = transactionAmount,
                User = _costControlUser
            };

            _costControlService.AddTransaction(transaction);

            return Redirect(referrer);
        }

        private void LoadProperties()
        {
            //get Identity user
            ApplicationUser appUser = _userManager.GetUserAsync(HttpContext.User).Result;
            //get CostControlUser of email
            _costControlUser = _costControlService.GetUserByEmail(appUser?.Email);
            Accounts = _costControlService.GetAccounts(_costControlUser);
            Incomes = _costControlService.GetIncomes(_costControlUser);
            Expenses = _costControlService.GetExpenses(_costControlUser);
        }
    }
}
