using DanilDev.Services.EmploeesDirectory;
using DanilDev.Services.EmploeesDirectory.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace DanilDev.Pages.EmployeeDirectory.Departments
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeDirectoryService _employeeDirectoryService;
        public List<Department> Departments { get; set; }
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
            var dep = _employeeDirectoryService.GetDepartments();

            if (q != null)
            {
                Departments = FilterByQuery(dep);
            }
            else
            {
                Departments = dep;
            }

        }

        private List<Department> FilterByQuery(List<Department> departments)
        {
            return departments.Where(e => ((e.Name != null) && e.Name.Contains(q))
                                    || ((e.Organization != null) && e.Organization.Name.Contains(q))
                                    )
                                    .ToList();
        }

    }
}
