using DanilDev.Services.CostControl.Entity;
using DanilDev.Services.EmploeesDirectory.Entity;
using DanilDev.Services.Prices.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DanilDev.Data
{
    public class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> EmployeeDirectoryEmployees { get; set; }
        public DbSet<Organization> EmployeeDirectoryOrganizations { get; set; }
        public DbSet<Department> EmployeeDirectoryDepartmens { get; set; }


        public DbSet<User> CostControlUsers { get; set; }
        public DbSet<Account> CostControlAccounts { get; set; }
        public DbSet<Expense> CostControlExpenses { get; set; }
        public DbSet<Income> CostControlIncomes { get; set; }
        public DbSet<Transaction> CostControlTransactions { get; set; }
        public DbSet<Balance> CostControlBalances { get; set; }

        public DbSet<Price> Prices { get; set; }
        public DbSet<Column> PricesColumns { get; set; }
        public DbSet<Line> PricesLines { get; set; }
        public DbSet<Item> PricesItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<decimal, double>(
                v => (double)v,
                v => (decimal)v
            );

            modelBuilder
               .Entity<Balance>()
                .Property(e => e.Amount)
                .HasConversion(converter);

            modelBuilder
                .Entity<Transaction>()
                .Property(e => e.Amount)
                .HasConversion(converter);
        }
    }
}
