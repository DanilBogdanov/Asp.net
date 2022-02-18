using DanilDev.Services.EmploeesDirectory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanilDev.Pages.EmployeeDirectory.Departments
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
            long departmentToDelId,
            string referrer)
        {
            _employeeDirectoryService.DelDepartment(departmentToDelId);
            return Redirect(referrer);
        }
    }
}
