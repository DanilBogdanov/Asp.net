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
        
        public List<Account> Accounts { get; set; }
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
            //get Identity user
            ApplicationUser appUser = _userManager.GetUserAsync(HttpContext.User).Result;
            //get CostControlUser of email
            var costControlUser = _costControlService.GetUserByEmail(appUser?.Email);

            Accounts = _costControlService.GetAccounts(costControlUser); 
            Incomes = _costControlService.GetIncomes(costControlUser);
            Expenses = _costControlService.GetExpenses(costControlUser);
            Transactions = _costControlService.GetTransactions(costControlUser);
        }

        public void OnPost()
        {
        }




    }
}
