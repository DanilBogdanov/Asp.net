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
        public Employee GetEmployee(long id)
        {
            return _dbContext.EmployeeDirectoryEmployees
                .Include(imp => imp.Organization)
                .Include(imp => imp.Department)
                .Single(emp => emp.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            _dbContext.EmployeeDirectoryEmployees.Add(employee);
            _dbContext.SaveChanges();
        }
        public void UpdateEmployee(Employee employee)
        {
            _dbContext.EmployeeDirectoryEmployees.Update(employee);
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

        public List<Organization> GetOrganizations()
        {
            return _dbContext.EmployeeDirectoryOrganizations.ToList();
        }

        public Organization GetOrganization(long id)
        {
            return _dbContext.EmployeeDirectoryOrganizations.Single(organization => organization.Id == id);
        }

        public void AddOrganization(Organization organization)
        {
            _dbContext.EmployeeDirectoryOrganizations.Add(organization);
            _dbContext.SaveChanges();
        }

        public void UpdateOrganization(Organization organization)
        {
            _dbContext.EmployeeDirectoryOrganizations.Update(organization);
            _dbContext.SaveChanges();
        }

        public void DelOrganization(long id)
        {
            if (id != 0)
            {
                var organization = _dbContext.EmployeeDirectoryOrganizations.Single(org => org.Id == id);
                _dbContext.EmployeeDirectoryOrganizations.Remove(organization);
                _dbContext.SaveChanges();
            }
        }

        public List<Department> GetDepartments()
        {
            return _dbContext.EmployeeDirectoryDepartmens
                .Include(dep => dep.Organization)
                .ToList();
        }


    }
}
