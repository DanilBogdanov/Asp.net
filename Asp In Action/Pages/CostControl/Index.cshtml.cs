using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using Asp_In_Action.Services.CostControl;
using Asp_In_Action.Services.CostControl.Entity;
using System.Collections.Generic;

namespace Asp_In_Action.Pages.CostControl
{
    public class IndexModel : PageModel
    {
        public string Type { get; set; }
        
        private CostControlService _costService;
        public User CurrentUser { get; set; }
        public IndexModel(CostControlService costControlService)
        {
            _costService = costControlService;
        }

        public void OnGet()
        {
            CurrentUser = _costService.GetUser("Danil");
            //CurrentUser.Incomes.Add(new Income { Name = "Card1", Balance=100500 });
            //_costService.SaveChanges();
            
        }

        public void OnPost()
        {
        }




    }
}
