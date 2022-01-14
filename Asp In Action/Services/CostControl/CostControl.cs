using Asp_In_Action.Services.CostControl.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public CostControlUser GetUserByEmail(string email)
        {
            return _costControlContext.Users
                .Where(user => user.Email == email)
                .FirstOrDefault();
        }

        public List<CostControlIncome> GetIncomes(CostControlUser costControlUser)
        {
            return _costControlContext.Users
                .Where(user => user == costControlUser)
                .Include(user => user.Incomes)
                .First()
                .Incomes
                .ToList();
        }

        /*public List<CostControlAccount> GetAccounts(CostControlUser costControlUser)
        {

        }*/

        public void SaveChanges()
        {
            _costControlContext.SaveChanges();
        }
    }
}
