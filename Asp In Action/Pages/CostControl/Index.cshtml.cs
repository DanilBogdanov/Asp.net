using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

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
        public void OnGet()
        {
            HttpMethod = "OnGet";
        }

        public void OnPost()
        {
            HttpMethod = "OnPost";
            Debug.WriteLine(HttpMethod);
        }

        //public void OnPostAddExpense()
        //{
        //    Message = "OnPostAddExpense";
        //} 
    }
}
