using Asp_In_Action.Services.CostControl.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Asp_In_Action.Services.CostControl
{
    public class CostControlContext : DbContext
    {
        public CostControlContext(DbContextOptions<CostControlContext> options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }

        public DbSet<User> CostControlUsers { get; set; }
        public DbSet<Account> CostControlAccounts { get; set; }
        public DbSet<Expense> CostControlExpenses { get; set; }
        public DbSet<Income> CostControlIncomes { get; set; }
        public DbSet<Transaction> CostControlTransactions { get; set; }
        public DbSet<Balance> CostControlBalances { get; set; }
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

