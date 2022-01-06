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
        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }
        public string Type { get; set; }
        public string HttpMethod { get; set; }
        [BindProperty(SupportsGet =true)]
        public string Text { get; set; }

        public List<User> Users { get; set; }


        public CostControlService CostControlService { get; set; }

        private CostControlService _costService;

        public IndexModel(CostControlService costControlService)
        {
            _costService = costControlService;
        }

        public void OnGet()
        {
            HttpMethod = "OnGet";
            Message = _costService.GetMessage();          
            Users = _costService.GetUsers();
        }

        public void OnPost()
        {
            HttpMethod = "OnPost";
            Message = _costService.GetMessage();
            Users = _costService.GetUsers();
            Debug.WriteLine(HttpMethod);
        }

        public void OnGetAdd()
        {
            Message = "From Add";
        }
        
        
    }
}
