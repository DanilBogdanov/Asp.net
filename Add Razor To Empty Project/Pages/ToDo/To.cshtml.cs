using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Add_Razor_To_Empty_Project.Pages.ToDo
{
    public class ToModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet(string message)
        {
            Message = message;
        }
    }
}
