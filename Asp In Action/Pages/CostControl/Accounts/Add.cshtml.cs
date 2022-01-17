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

        public RedirectResult OnPost(string AccountName,
            string AccountDescription,
            decimal AccountBalance, 
            string referrer)
        {
            //get Identity user
            ApplicationUser appUser = _userManager.GetUserAsync(HttpContext.User).Result;
            //get CostControlUser of email
            var costControlUser = _costControlService.GetUserByEmail(appUser?.Email);

            /*var httpuser = HttpContext.User;
            var appUserTask = _userManager.GetUserAsync(httpuser);
            ApplicationUser appUser = appUserTask.Result;
            */
            Account account = new Account { Name = AccountName, Description = AccountDescription, 
                Balance = AccountBalance, User = costControlUser };
            _costControlService.AddAccount(account);
            Debug.WriteLine(referrer);
            //return Redirect(Request.Headers["Referer"].ToString());
            return Redirect(referrer);
        }
    }
}
