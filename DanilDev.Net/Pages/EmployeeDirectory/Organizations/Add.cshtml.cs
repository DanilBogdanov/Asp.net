using DanilDev.Services.EmploeesDirectory;
using DanilDev.Services.EmploeesDirectory.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DanilDev.Pages.EmployeeDirectory.Organizations
{
    public class AddModel : PageModel
    {
        private readonly EmployeeDirectoryService _employeeDirectoryService;
        public List<Organization> Organizations { get; set; }
        


        public AddModel(EmployeeDirectoryService employeeDirectoryService)
        {
            _employeeDirectoryService = employeeDirectoryService;
        }

        public void OnGet()
        {
            
        }

        public RedirectResult OnPost(
            string referrer,
            string organizationName            
            )
        {
            Organization organization = new Organization
            {
                Name = organizationName                
            };

            _employeeDirectoryService.AddOrganization(organization);
            return Redirect(referrer);
        }        
    }
}
