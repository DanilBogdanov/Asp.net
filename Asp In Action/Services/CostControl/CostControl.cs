using Asp_In_Action.Services.CostControl.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Asp_In_Action.Services.CostControl
{
    public class CostControlService
    {
        private CostControlContext _costControlContext;
        public CostControlService(CostControlContext context)
        {
            _costControlContext = context;
        }

        public User GetUserByEmail(string email)
        {
            User user = _costControlContext.CostControlUsers
                .Where(user => user.Email == email)
                .FirstOrDefault();
            if (user == null)
            {
                user = new User { Email=email};
                _costControlContext.CostControlUsers.Add(user);
                _costControlContext.SaveChanges();
            }
            return user;

        }

        /*public List<Income> GetIncomes(User costControlUser)
        {
            return _costControlContext.CostControlUsers
                .Where(user => user == costControlUser)
                .Include(user => user.Incomes)
                .First()
                .Incomes
                .ToList();
        }*/

        public List<Account> GetAccounts(User costControlUser)
        {
            return _costControlContext.CostControlAccounts
                .Where(account => account.User == costControlUser)
                .ToList();
        }

        public void AddAccount(Account account)
        {
            _costControlContext.CostControlAccounts.Add(account);
            _costControlContext.SaveChanges();
        }

        //to del
        public void SaveChanges()
        {
            _costControlContext.SaveChanges();
        }
    }
}
