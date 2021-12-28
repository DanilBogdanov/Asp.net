using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Asp_In_Action.Pages.CostControl
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public void OnGet()
        {
            Message = "OnGet";
        }

        public void OnPost()
        {
            Message = "OnPost";
            Debug.WriteLine(Message);
        }

        //public void OnPostAddExpense()
        //{
        //    Message = "OnPostAddExpense";
        //} 
    }
}
