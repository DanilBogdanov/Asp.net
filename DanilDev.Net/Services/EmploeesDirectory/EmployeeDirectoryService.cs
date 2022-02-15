using DanilDev.Services.EmploeesDirectory.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanilDev.Services.EmploeesDirectory
{
    public class EmployeeDirectoryService
    {
        private readonly EmployeeDirectoryContext _dbContext;

        public EmployeeDirectoryService(EmployeeDirectoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetEmployees()
        {
            return _dbContext.EmployeeDirectoryEmployees
                .Include(empl => empl.Organization)
                .Include(empl => empl.Department)
                .ToList();
        }

        public List<Organization> GetOrganizations()
        {
            return _dbContext.EmployeeDirectoryOrganizations.ToList();
        }

        public List<Department> GetDepartments()
        {
            return _dbContext.EmployeeDirectoryDepartmens.ToList();
        }

        public void AddEmployee(Employee employee)
        {
            _dbContext.EmployeeDirectoryEmployees.Add(employee);
            _dbContext.SaveChanges();
        }

        public void DelEmployee(long id)
        {
            if (id != 0)
            {
                var employee = _dbContext.EmployeeDirectoryEmployees.Single(empl => empl.Id == id);
                _dbContext.EmployeeDirectoryEmployees.Remove(employee);
                _dbContext.SaveChanges();
            }
        }
    }
}
