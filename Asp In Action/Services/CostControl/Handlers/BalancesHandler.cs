using DanilDev.Services.CostControl.Entity;
using System.Linq;

namespace DanilDev.Services.CostControl.Handlers
{
    internal class BalancesHandler
    {
        private readonly CostControlContext _dbContext;

        public BalancesHandler(CostControlContext dbContext)
        {
            _dbContext = dbContext;
        }

        public decimal GetAmount(Account account)
        {
            return GetBalance(account).Amount;
        }

        public void SetAmount(Account account, decimal amount)
        {
            var balance = GetBalance(account);
            balance.Amount = amount;
            UpdateBalance(balance);
        }

        public void AddAmount (Account account, decimal amount)
        {
            var balance = GetBalance(account);
            balance.Amount += amount;
            UpdateBalance(balance);
        }

        public void SubtractAmount(Account account, decimal amount)
        {
            var balance = GetBalance(account);
            balance.Amount -= amount;
            UpdateBalance(balance);
        }       

        private Balance GetBalance(Account account)
        {
            Balance balance = _dbContext.CostControlBalances.SingleOrDefault(balance => balance.Account == account);
            if (balance == null)
            {
                balance = new Balance { Account = account };
                _dbContext.CostControlBalances.Add(balance);
                _dbContext.SaveChanges();
            }
            return balance;
        }

        private void UpdateBalance(Balance balance)
        {
            _dbContext.CostControlBalances.Update(balance);
            _dbContext.SaveChanges();
        }
    }
}
