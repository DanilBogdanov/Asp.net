using DanilDev.Services.EmploeesDirectory.Entity;
using DanilDev.Services.EmploeesDirectory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DanilDev.Pages.EmployeeDirectory.Departments
{
    [IgnoreAntiforgeryToken]
    public class EditModel : PageModel
    {
        private readonly EmployeeDirectoryService _employeeDirectoryService;
        public List<Organization> Organizations { get; set; }
        [BindProperty(SupportsGet = true)]
        public long Id { get; set; }
        public Department Department { get; set; }

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
            string departmentName,
            long departmentOrganizationId
            )
        {
            LoadProperties();

            var departmentOrganization = Organizations.Find(org => org.Id == departmentOrganizationId);

            Department.Name = departmentName;
            Department.Organization = departmentOrganization;

            _employeeDirectoryService.UpdateDepartment(Department);
            return Redirect(referrer);
        }

        private void LoadProperties()
        {
            Organizations = _employeeDirectoryService.GetOrganizations();
            Department = _employeeDirectoryService.GetDepartment(Id);
        }
    }
}
