using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using Asp_In_Action.Services.CostControl;
using Asp_In_Action.Services.CostControl.Entity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Asp_In_Action.Data;

namespace Asp_In_Action.Pages.CostControl
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private CostControlService _costControlService;

        public DateInterval ByInterval { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Interval { get; set; }
        
        public List<(Account account, decimal amount)> Accounts { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<Transaction> Transactions { get; set; }

        public IndexModel(CostControlService costControlService,
            UserManager<ApplicationUser> userManager)
        {
            _costControlService = costControlService;
            _userManager = userManager;
        }

        public void OnGet()
        {
            ByInterval = DateInterval.ByMonth;            
            LoadProperties();
        }

        public void OnGetWeek()
        {
            ByInterval = DateInterval.ByWeek;
            LoadProperties();
        }

        public void OnGetMonth()
        {
            ByInterval = DateInterval.ByMonth;
            LoadProperties();
        }

        public void OnGetPeriod()
        {
            ByInterval = DateInterval.ByPeriod;
            LoadProperties();
        }

        public void OnPost()
        {
        }

        public enum DateInterval
        {
            ByWeek,
            ByMonth,
            ByPeriod
        }
        private void LoadProperties()
        {
            //get Identity user
            ApplicationUser appUser = _userManager.GetUserAsync(HttpContext.User).Result;
            //get CostControlUser of email
            var costControlUser = _costControlService.GetUserByEmail(appUser?.Email);

            Accounts = _costControlService.GetAccountsWithBalance(costControlUser);
            Incomes = _costControlService.GetIncomes(costControlUser);
            Expenses = _costControlService.GetExpenses(costControlUser);

            //TODO
            Transactions = _costControlService.GetTransactions(costControlUser);
        }

    }
}
