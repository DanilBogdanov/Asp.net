using DanilDev.Services.EmploeesDirectory;
using DanilDev.Services.EmploeesDirectory.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DanilDev.Pages.EmployeeDirectory.Departments
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeDirectoryService _employeeDirectoryService;
        public List<Department> Employees { get; set; }
        [BindProperty(SupportsGet = true)]
        public string q { get; set; }

        public IndexModel(EmployeeDirectoryService employeeDirectoryService)
        {
            _employeeDirectoryService = employeeDirectoryService;
        }

        public void OnGet()
        {
            LoadProperties();

        }

        private void LoadProperties()
        {
            var empl = _employeeDirectoryService.GetEmployees();

            if (q != null)
            {
                Employees = FilterByQuery(empl);
            }
            else
            {
                Employees = empl;
            }

        }

        private List<Employee> FilterByQuery(List<Employee> employees)
        {
            return employees.Where(e => ((e.FullName != null) && e.FullName.Contains(q))
                                    || ((e.Organization != null) && e.Organization.Name.Contains(q))
                                    || ((e.Department != null) && e.Department.Name.Contains(q))
                                    || ((e.Position != null) && e.Position.Contains(q))
                                    || ((e.Email != null) && e.Email.Contains(q))
                                    || ((e.Phone != null) && e.Phone.Contains(q))
                                    )
                                    .ToList();
        }

    }
}
