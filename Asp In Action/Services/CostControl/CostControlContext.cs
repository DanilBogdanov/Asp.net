using Asp_In_Action.Services.CostControl.Entity;
using Microsoft.EntityFrameworkCore;

namespace Asp_In_Action.Services.CostControl
{
    public class CostControlContext : DbContext
    {
        public CostControlContext(DbContextOptions<CostControlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses{ get; set; }
        public DbSet<Income> Incomes{ get; set; }
        public DbSet<Balance> Balances { get; set; }
        
    }
}
