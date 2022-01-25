using Asp_In_Action.Services.CostControl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp_In_Action.Services.CostControl.Handlers
{
    internal class AccountsHandler
    {
        private readonly CostControlContext _costControlContext;

        public AccountsHandler(CostControlContext costControlContext)
        {
            _costControlContext = costControlContext;
        }

        public List<Account> GetAll(User user)
        {
            return _costControlContext.CostControlAccounts
                .Where(account => account.User == user)
                .ToList();
        }

        public void Add(Account account)
        {
            _costControlContext.CostControlAccounts.Add(account);
            _costControlContext.SaveChanges();
        }        
    }
}
