using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Asp_In_Action.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            Debug.WriteLine("new Privacy Model");
            _logger = logger;
        }

        public void OnGet()
        {
            Debug.WriteLine("OnGet Privacy");
            
        }

        
    }
}
