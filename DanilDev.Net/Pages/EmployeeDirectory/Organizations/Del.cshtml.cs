using DanilDev.Services.EmploeesDirectory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanilDev.Pages.EmployeeDirectory.Organizations
{
    [IgnoreAntiforgeryToken]
    public class DelModel : PageModel
    {
        private readonly EmployeeDirectoryService _employeeDirectoryService;

        public DelModel(EmployeeDirectoryService employeeDirectoryService)
        {
            _employeeDirectoryService = employeeDirectoryService;
        }

        public RedirectResult OnPost(
            long organizationToDelId,
            string referrer)
        {
            _employeeDirectoryService.DelOrganization(organizationToDelId);
            return Redirect(referrer);
        }
    }
}
