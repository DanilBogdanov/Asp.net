using Asp_In_Action.Services.CostControl.DAL.Entity;
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
        
    }
}
