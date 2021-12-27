using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Add_Razor_To_Empty_Project.Pages
{
    public class MyModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }
        [BindProperty(SupportsGet =true)]
        public int Age { get; set; }
        public string Test { get; set; }
        [BindProperty(SupportsGet =true)]
        public string Name { get; set; }
        public void OnGet()
        {
            Name = $"+{Name}+";
            Debug.WriteLine("OnGet My");
        }


    }
}