using DanilDev.Services.EmploeesDirectory;
using DanilDev.Services.EmploeesDirectory.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DanilDev.Pages.EmployeeDirectory.Employees
{
    [IgnoreAntiforgeryToken]
    public class EditModel : PageModel
    {
        private readonly EmployeeDirectoryService _employeeDirectoryService;
        public List<Organization> Organizations { get; set; }
        public List<Department> Departments { get; set; }
        [BindProperty(SupportsGet = true)]
        public long Id { get; set; }
        public Employee Employee { get; set; }

        public EditModel(EmployeeDirectoryService employeeDirectoryService)
        {
            _employeeDirectoryService = employeeDirectoryService;
        }

        public void OnGet()
        {
            LoadProperties();
        }

        public RedirectResult OnPost (
            string referrer,
            string employeeFullName,
            long employeeOrganizationId,
            long employeeDepartamentId,
            string employeePosition,
            string employeeEmail,
            string employeePhone
            )
        {
            LoadProperties();

            var employeeOrganization = Organizations.Find(org => org.Id == employeeOrganizationId);
            var employeeDepartment = Departments.Find(dep => dep.Id == employeeDepartamentId);


            Employee.FullName = employeeFullName;
            Employee.Organization = employeeOrganization;
            Employee.Department = employeeDepartment;
            Employee.Position = employeePosition;
            Employee.Email = employeeEmail;
            Employee.Phone = employeePhone;
            

            _employeeDirectoryService.UpdateEmployee(Employee);
            return Redirect(referrer);
        }

        private void LoadProperties()
        {
            Organizations = _employeeDirectoryService.GetOrganizations();
            Departments = _employeeDirectoryService.GetDepartments();
            Employee = _employeeDirectoryService.GetEmployee(Id);
        }
    }
}
