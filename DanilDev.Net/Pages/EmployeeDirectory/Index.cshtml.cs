using DanilDev.Services.EmploeesDirectory;
using DanilDev.Services.EmploeesDirectory.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DanilDev.Pages.EmployeeDirectory
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeDirectoryService _employeeDirectoryService;
        public List<Employee> Employees { get; set; }


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
            Employees = _employeeDirectoryService.GetEmployees();
        }


    }
}
