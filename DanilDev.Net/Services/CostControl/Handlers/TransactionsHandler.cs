using DanilDev.Services.CostControl.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DanilDev.Services.CostControl.Handlers
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

        public List<Transaction> GetAll(User user, DateTime dateFrom, DateTime dateTo)
        {
            return _dbContext.CostControlTransactions
                .Where(transaction => transaction.User == user &&
                                      transaction.Date >= dateFrom &&
                                      transaction.Date < dateTo)
                .ToList();
        }

        public List<Transaction> GetByType(User user, TransactionType transactionType, DateTime dateFrom, DateTime dateTo)
        {
            return _dbContext.CostControlTransactions
                .Where(transaction => transaction.User == user &&
                                      transaction.Type == transactionType &&
                                      transaction.Date >= dateFrom &&
                                      transaction.Date < dateTo)
                .ToList();
        }

        public List<Transaction> GetByIncome(User user, Income income, DateTime dateFrom, DateTime dateTo)
        {
            return _dbContext.CostControlTransactions
                .Where(transaction => transaction.User == user &&
                                      transaction.Type == TransactionType.Incoming &&
                                      transaction.Income == income &&
                                      transaction.Date >= dateFrom &&
                                      transaction.Date < dateTo)
                .ToList();
        }

        public List<Transaction> GetByExpense(User user, Expense expense, DateTime dateFrom, DateTime dateTo)
        {
            return _dbContext.CostControlTransactions
                .Where(transaction => transaction.User == user &&
                                      transaction.Type == TransactionType.Outgoing &&
                                      transaction.Expense == expense &&
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

        public void Delete(Transaction transaction)
        {
            _dbContext.CostControlTransactions.Remove(transaction);
            _dbContext.SaveChanges();
        }

        private void ChangeBalance(Transaction transaction)
        {
            switch (transaction.Type)
            {
                case TransactionType.Incoming:
                    {
                        _balancesHandler.AddAmount(transaction.AccountTo, transaction.Amount);
                        break;
                    }
                case TransactionType.Outgoing:
                    {
                        _balancesHandler.SubtractAmount(transaction.AccountFrom, transaction.Amount);
                        break;
                    }
                case TransactionType.Transfer:
                    {
                        _balancesHandler.SubtractAmount(transaction.AccountFrom, transaction.Amount);
                        _balancesHandler.AddAmount(transaction.AccountTo, transaction.Amount);
                        break;
                    }
                case TransactionType.Correction:
                    {
                        _balancesHandler.AddAmount(transaction.AccountTo, transaction.Amount);
                        break;
                    }
            }
        }

        /// <summary>
        /// Undo changes by transactions
        /// </summary>        
        private void UndoChangeBalance(Transaction transaction)
        {
            switch (transaction.Type)
            {
                case TransactionType.Incoming:
                    {
                        _balancesHandler.SubtractAmount(transaction.AccountTo, transaction.Amount);
                        break;
                    }
                case TransactionType.Outgoing:
                    {
                        _balancesHandler.AddAmount(transaction.AccountFrom, transaction.Amount );
                        break;
                    }
                case TransactionType.Transfer:
                    {
                        _balancesHandler.AddAmount(transaction.AccountFrom, transaction.Amount);
                        _balancesHandler.SubtractAmount(transaction.AccountTo, transaction.Amount);
                        break;
                    }
                case TransactionType.Correction:
                    {
                        _balancesHandler.SubtractAmount(transaction.AccountTo, transaction.Amount);
                        break;
                    }
            }
        }
    }
}
