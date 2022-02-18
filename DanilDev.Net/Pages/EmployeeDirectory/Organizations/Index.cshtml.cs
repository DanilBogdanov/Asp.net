using DanilDev.Services.EmploeesDirectory;
using DanilDev.Services.EmploeesDirectory.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace DanilDev.Pages.EmployeeDirectory.Organizations
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeDirectoryService _employeeDirectoryService;
        public List<Organization> Organizations { get; set; }
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
            var org = _employeeDirectoryService.GetOrganizations();

            if (q != null)
            {
                Organizations = FilterByQuery(org);
            }
            else
            {
                Organizations = org;
            }

        }

        private List<Organization> FilterByQuery(List<Organization> employees)
        {
            return employees.Where(org => ((org.Name != null) && org.Name.Contains(q))).ToList();
        }

    }
}
