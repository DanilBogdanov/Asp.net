using Asp_In_Action.Data;
using Asp_In_Action.Services.CostControl;
using Asp_In_Action.Services.CostControl.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Asp_In_Action.Pages.CostControl.Accounts
{
    public class AddModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CostControlService _costControlService;
        public AddModel(CostControlService costControlService,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _costControlService = costControlService;
        }
        public void OnGet()
        {

        }

        public RedirectResult OnPost(string accountName,
            string accountDescription,
            decimal accountBalance, 
            string referrer)
        {
            //get Identity user
            ApplicationUser appUser = _userManager.GetUserAsync(HttpContext.User).Result;
            //get CostControlUser of email
            var costControlUser = _costControlService.GetUserByEmail(appUser?.Email);

            
            Account account = new Account { Name = accountName, Description = accountDescription, 
                User = costControlUser };
            _costControlService.AddAccount(account, accountBalance);
            
            return Redirect(referrer);
        }
    }
}
