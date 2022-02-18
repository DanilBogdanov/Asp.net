using DanilDev.Services.EmploeesDirectory;
using DanilDev.Services.EmploeesDirectory.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DanilDev.Pages.EmployeeDirectory.Departments
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

            Department department = new Department
            {
                Name = departmentName,
                Organization = departmentOrganization
            };

            _employeeDirectoryService.AddDepartment(department);
            return Redirect(referrer);
        }

        private void LoadProperties()
        {
            Organizations = _employeeDirectoryService.GetOrganizations();
        }
    }
}
