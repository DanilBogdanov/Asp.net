using Asp_In_Action.Services.CostControl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp_In_Action.Services.CostControl.Handlers
{
    internal class TransactionsHandler
    {
        private CostControlContext _costControlContext;
        private BalancesHandler _balancesHandler;

        public TransactionsHandler(CostControlContext costControlContext, BalancesHandler balancesHandler)
        {
            _costControlContext = costControlContext;
            _balancesHandler = balancesHandler;
        }

        public List<Transaction> GetAll(User costControlUser)
        {
            return _costControlContext.CostControlTransactions
                .Where(transaction => transaction.User == costControlUser)
                .ToList();
        }

        public List<Transaction> GetByPeriod(User costControlUser, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            return _costControlContext.CostControlTransactions
                .Where(transaction => transaction.User == costControlUser &&
                                      transaction.Date >= dateTimeFrom &&
                                      transaction.Date < dateTimeTo)
                .ToList();
        }

        public void Add(Transaction transaction)
        {
            ChangeBalance(transaction);
            _costControlContext.CostControlTransactions.Add(transaction);
            _costControlContext.SaveChanges();
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
