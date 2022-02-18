using DanilDev.Services.EmploeesDirectory;
using DanilDev.Services.EmploeesDirectory.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanilDev.Pages.EmployeeDirectory.Organizations
{
    [IgnoreAntiforgeryToken]
    public class EditModel : PageModel
    {
        private readonly EmployeeDirectoryService _employeeDirectoryService;
        [BindProperty(SupportsGet = true)]
        public long Id { get; set; }
        public Organization Organization { get; set; }

        public EditModel(EmployeeDirectoryService employeeDirectoryService)
        {
            _employeeDirectoryService = employeeDirectoryService;
        }

        public void OnGet()
        {
            LoadProperties();
        }

        public RedirectResult OnPost(
            string referrer,
            string organizationName            
            )
        {
            LoadProperties();

            Organization.Name = organizationName;   

            _employeeDirectoryService.UpdateOrganization(Organization);
            return Redirect(referrer);
        }

        private void LoadProperties()
        {
            Organization = _employeeDirectoryService.GetOrganization(Id);
        }
    }
}
