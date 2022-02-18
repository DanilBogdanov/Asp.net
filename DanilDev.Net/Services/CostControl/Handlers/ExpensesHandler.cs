using DanilDev.Data;
using DanilDev.Services.CostControl.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DanilDev.Services.CostControl.Handlers
{
    internal class ExpensesHandler
    {
        private readonly ProjectsDbContext _dbContext;

        public ExpensesHandler(ProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Expense> GetAll(User user)
        {
            return _dbContext.CostControlExpenses
                .Where(expense => expense.User == user)
                .ToList();
        }

        public void Add(Expense expense)
        {
            _dbContext.CostControlExpenses.Add(expense);
            _dbContext.SaveChanges();
        }
    }
}
