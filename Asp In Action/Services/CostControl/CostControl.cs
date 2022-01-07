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
            _costControlContext =  context;
        }
        
        public User GetUser(string name)
        {
            var users = _costControlContext.Users;
            User user = users.Include(i => i.Incomes).Include(e => e.Expenses).Where(user => user.Name == name).First();
            return user;
        } 

        public void SaveChanges()
        {
            _costControlContext.SaveChanges();
        }
    }
}
