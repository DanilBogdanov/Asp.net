using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using Asp_In_Action.Services.CostControl;

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
            
        }

        public void OnPost()
        {
            HttpMethod = "OnPost";
            Message = _costService.GetMessage();
            Debug.WriteLine(HttpMethod);
        }

        //public void OnPostAddExpense()
        //{
        //    Message = "OnPostAddExpense";
        //} 
    }
}
