using DanilDev.Data;
using DanilDev.Services.CostControl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DanilDev.Services.CostControl.Handlers
{
    internal class AccountsHandler
    {
        private readonly ProjectsDbContext _dbContext;

        public AccountsHandler(ProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Account> GetAll(User user)
        {
            return _dbContext.CostControlAccounts
                .Where(account => account.User == user)
                .ToList();
        }

        public void Add(Account account)
        {
            _dbContext.CostControlAccounts.Add(account);
            _dbContext.SaveChanges();
        }        
    }
}
