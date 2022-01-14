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

        public DbSet<CostControlUser> Users { get; set; }
        public DbSet<CostControlAccount> Accounts { get; set; }
        public DbSet<CostControlExpense> Expenses { get; set; }
        public DbSet<CostControlIncome> Incomes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Expense foodD = new Expense { Id = 1, Name = "Food", Description = "All food" };
            //Expense petrolD = new Expense { Id = 2, Name = "Petrol", Description = "All petrol" };
            //Expense homeD = new Expense { Id = 3, Name = "Home", Description = "All home expense" };
            //Expense foodA = new Expense { Id = 4, Name = "Food", Description = "All food" };
            //Expense petrolA = new Expense { Id = 5, Name = "Petrol", Description = "All petrol" };
            //Expense homeA = new Expense { Id = 6, Name = "Home", Description = "All home expense" };

            //Income cashD = new Income { Id = 1, Name = "Cash" };
            //Income creditD = new Income { Id = 2, Name = "Credit Card" };
            //Income cashA = new Income { Id = 3, Name = "Cash" };
            //Income creditA = new Income { Id = 4, Name = "Credit Card" };

            /*CostControlUser danil = new CostControlUser { Id = 1, Name = "Danil" };
            CostControlUser alice = new CostControlUser { Id = 2, Name = "Alice" };*/

            //danil.Incomes.Add(cashD);
            //danil.Incomes.Add(creditD);
            //danil.Expenses.Add(homeD);
            //danil.Expenses.Add(petrolD);
            //danil.Expenses.Add(foodD);
            //alice.Incomes.Add(cashA);
            //alice.Incomes.Add(creditA);
            //alice.Expenses.Add(homeA);
            //alice.Expenses.Add(petrolA);
            //alice.Expenses.Add(foodA);

           /* modelBuilder.Entity<CostControlUser>().HasData(
                new CostControlUser[]
                {
                    danil, alice
                });
*/

        }


    }
}
