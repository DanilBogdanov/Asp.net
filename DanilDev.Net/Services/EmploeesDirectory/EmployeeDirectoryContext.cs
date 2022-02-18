using DanilDev.Services.EmploeesDirectory.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanilDev.Services.EmploeesDirectory
{
    public class EmployeeDirectoryContext : DbContext
    {
        public EmployeeDirectoryContext(DbContextOptions<EmployeeDirectoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        

        public DbSet<Employee> EmployeeDirectoryEmployees { get; set; }
        public DbSet<Organization> EmployeeDirectoryOrganizations { get; set; }
        public DbSet<Department> EmployeeDirectoryDepartmens { get; set; }
    }
}
