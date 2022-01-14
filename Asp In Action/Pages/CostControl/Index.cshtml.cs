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
        public string Type { get; set; }
        
        private CostControlService _costService;
        public CostControlUser CurrentUser { get; set; }
        public IndexModel(CostControlService costControlService, 
            UserManager<ApplicationUser> userManager)
        {
            _costService = costControlService;
            _userManager = userManager;
        }

        public void OnGet()
        {
            //CurrentUser = _costService.GetUser("Danil");
            //CurrentUser.Incomes.Add(new Income { Name = "Card1", Balance=100500 });
            //_costService.SaveChanges();
            
        }

        public void OnPost()
        {
        }




    }
}
