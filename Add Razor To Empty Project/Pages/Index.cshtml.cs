using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Add_Razor_To_Empty_Project.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Debug.WriteLine("OnGet index");
        }
    }
}
