using DanilDev.Services.EmploeesDirectory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanilDev.Pages.EmployeeDirectory.Employees
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
            long employeeToDelId,
            string referrer)
        {
            _employeeDirectoryService.DelEmployee(employeeToDelId);
            return Redirect(referrer);
        }
    }
}
