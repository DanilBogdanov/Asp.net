using DanilDev.Data;
using DanilDev.Services.CostControl;
using DanilDev.Services.CostControl.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace DanilDev.Pages.CostControl.Transactions
{
    [IgnoreAntiforgeryToken]
    public class DelModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CostControlService _costControlService;
        private User _costControlUser;
        public DelModel(UserManager<ApplicationUser> userManager, CostControlService costControlService)
        {
            _userManager = userManager;
            _costControlService = costControlService;
        }        

        public RedirectResult OnPost(
            long transactToDelId,
            string referrer)
        {

            Debug.WriteLine(transactToDelId);
            //get Identity user
            ApplicationUser appUser = _userManager.GetUserAsync(HttpContext.User).Result;             
            //get CostControlUser of email
            _costControlUser = _costControlService.GetUserByEmail(appUser?.Email);

            var transactionToDel = _costControlService.GetTransaction(_costControlUser, transactToDelId);
            _costControlService.DelTransaction(transactionToDel);

            return Redirect(referrer);
        }
    }
}
