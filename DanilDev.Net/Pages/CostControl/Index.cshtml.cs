using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using DanilDev.Services.CostControl;
using DanilDev.Services.CostControl.Entity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using DanilDev.Data;
using System;

namespace DanilDev.Pages.CostControl
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private CostControlService _costControlService;
        public ApplicationUser AppUser { get; set; }

        public DateInterval ByInterval { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Interval { get; set; }
        
        public List<(Account account, decimal balance)> Accounts { get; set; }
        public List<(Income income, decimal amount)> Incomes { get; set; }
        public List<(Expense expense, decimal amount)> Expenses { get; set; }
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
            var dateNow = DateTime.Now;
            var dateFrom = new DateTime(dateNow.Year, dateNow.Month, 1);
            var dateTo = dateFrom.AddMonths(1);
            Debug.WriteLine($"dateFrom-{dateFrom}");
            Debug.WriteLine($"dateTo-{dateTo}");
            LoadProperties(dateFrom, dateTo);
            Console.WriteLine("");
        }

        public void OnGetWeek()
        {
            ByInterval = DateInterval.ByWeek;
            //LoadProperties();

        }

        public void OnGetMonth()
        {
            ByInterval = DateInterval.ByMonth;
            //LoadProperties();
        }

        public void OnGetPeriod()
        {
            ByInterval = DateInterval.ByPeriod;
            //LoadProperties();
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
        private void LoadProperties(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            //get Identity user
            AppUser = _userManager.GetUserAsync(HttpContext.User).Result;
            //get CostControlUser of email
            var costControlUser = _costControlService.GetUserByEmail(AppUser?.Email);

            Accounts = _costControlService.GetAccountsWithBalance(costControlUser);
            Incomes = _costControlService.GetIncomesWithAmount(costControlUser, dateTimeFrom, dateTimeTo);
            Expenses = _costControlService.GetExpensesWithAmount(costControlUser, dateTimeFrom, dateTimeTo);

            //TODO
            Transactions = _costControlService.GetTransactions(costControlUser);
        }

    }
}
