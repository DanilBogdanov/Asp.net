using Asp_In_Action.Services.CostControl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp_In_Action.Services.CostControl.Handlers
{
    internal class TransactionsHandler
    {
        private CostControlContext _dbContext;
        private BalancesHandler _balancesHandler;

        public TransactionsHandler(CostControlContext dbContext, BalancesHandler balancesHandler)
        {
            _dbContext = dbContext;
            _balancesHandler = balancesHandler;
        }

        public List<Transaction> GetAll(User user)
        {
            return _dbContext.CostControlTransactions
                .Where(transaction => transaction.User == user)
                .ToList();
        }

        public List<Transaction> GetByPeriod(User user, DateTime dateFrom, DateTime dateTo)
        {
            return _dbContext.CostControlTransactions
                .Where(transaction => transaction.User == user &&
                                      transaction.Date >= dateFrom &&
                                      transaction.Date < dateTo)
                .ToList();
        }

        public void Add(Transaction transaction)
        {
            ChangeBalance(transaction);
            _dbContext.CostControlTransactions.Add(transaction);
            _dbContext.SaveChanges();
        }

        private void ChangeBalance(Transaction transaction)
        {
            switch (transaction.Type)
            {
                case TransactionType.Incoming:
                    {
                        Balance balance = _balancesHandler.Get(transaction.AccountTo);
                        balance.Amount += transaction.Amount;
                        _balancesHandler.Update(balance);
                        break;
                    }
                case TransactionType.Outgoing:
                    {
                        Balance balance = _balancesHandler.Get(transaction.AccountFrom);
                        balance.Amount -= transaction.Amount;
                        _balancesHandler.Update(balance);
                        break;
                    }
                case TransactionType.Transfer:
                    {
                        Balance balanceFrom = _balancesHandler.Get(transaction.AccountFrom);
                        balanceFrom.Amount -= transaction.Amount;
                        _balancesHandler.Update(balanceFrom);
                        Balance balanceTo = _balancesHandler.Get(transaction.AccountTo);
                        balanceTo.Amount += transaction.Amount;
                        _balancesHandler.Update(balanceTo);
                        break;
                    }
                case TransactionType.Correction:
                    {
                        Balance balance = _balancesHandler.Get(transaction.AccountTo);
                        balance.Amount = transaction.Amount;
                        _balancesHandler.Update(balance);
                        break;
                    }
            }
        }        
    }
}
