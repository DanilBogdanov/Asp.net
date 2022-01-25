using Asp_In_Action.Services.CostControl.Entity;
using System.Linq;

namespace Asp_In_Action.Services.CostControl.Handlers
{
    public class BalancesHandler
    {
        private readonly CostControlContext _costControlContext;

        public BalancesHandler(CostControlContext costControlContext)
        {
            _costControlContext = costControlContext;
        }

        public Balance Get(Account account)
        {
            Balance balance = _costControlContext.CostControlBalances.SingleOrDefault(balance => balance.Account == account);
            if (balance == null)
            {
                balance = new Balance { Account = account };
                _costControlContext.CostControlBalances.Add(balance);
                _costControlContext.SaveChanges();
            }
            return balance;
        }

        public void Update(Balance balance)
        {
            _costControlContext.CostControlBalances.Update(balance);
            _costControlContext.SaveChanges();
        }
    }
}
