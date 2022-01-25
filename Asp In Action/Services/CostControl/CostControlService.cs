using Asp_In_Action.Services.CostControl.Entity;
using Asp_In_Action.Services.CostControl.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Asp_In_Action.Services.CostControl
{
    public class CostControlService
    {
        private readonly CostControlContext _costControlContext;
        
        private readonly AccountsHandler _accountHandler;
        private readonly TransactionsHandler _transactionsHandler;
        private readonly BalancesHandler _balancesHandler;

        public CostControlService(CostControlContext context)
        {
            _costControlContext = context;

            _balancesHandler = new BalancesHandler(context);
            _accountHandler = new AccountsHandler(context);
            _transactionsHandler = new TransactionsHandler(context, _balancesHandler);
        }

        public User GetUserByEmail(string email)
        {
            User user = _costControlContext.CostControlUsers
                .Where(user => user.Email == email)
                .FirstOrDefault();
            if (user == null)
            {
                user = new User { Email = email };
                _costControlContext.CostControlUsers.Add(user);
                _costControlContext.SaveChanges();
                SetDefaultValues(user);
            }
            return user;

        }

        public List<(Account, decimal amount)> GetAccountsWithBalance(User costControlUser)
        {
            List<(Account, decimal amount)> accountsWithBalance = new List<(Account, decimal amount)>();
            var accountList = _accountHandler.GetAll(costControlUser);
            
            foreach (var account in accountList)
            {
                Balance balance = _balancesHandler.Get(account);
                accountsWithBalance.Add((account, balance.Amount));
            }

            return accountsWithBalance;
        }

        public void AddAccount(Account account, decimal balance)
        {
            _accountHandler.Add(account);
            Transaction transaction = new Transaction {Type = TransactionType.Correction, AccountTo = account, Amount = balance };
            _transactionsHandler.Add(transaction);
        }

        public List<Income> GetIncomes(User costControlUser)
        {
            return _costControlContext.CostControlIncomes
                .Where(income => income.User == costControlUser)
                .ToList();
        }

        public void AddIncome(Income income)
        {
            _costControlContext.CostControlIncomes.Add(income);
            _costControlContext.SaveChanges();
        }

        public List<Expense> GetExpenses(User costControlUser)
        {
            return _costControlContext.CostControlExpenses
                .Where(expense => expense.User == costControlUser)
                .ToList();
        }

        public void AddExpense(Expense expense)
        {
            _costControlContext.CostControlExpenses.Add(expense);
            _costControlContext.SaveChanges();
        }

        public List<Transaction> GetTransactions(User costControlUser) => _transactionsHandler.GetAll(costControlUser);

        /// <summary>
        /// Get Transactions for user between the given dates.
        /// dataTimeFrom include, dataTimeTo exclude
        /// </summary>        
        public List<Transaction> GetTransactions(User costControlUser, DateTime dateTimeFrom, DateTime dateTimeTo) =>
            _transactionsHandler.GetByPeriod(costControlUser, dateTimeFrom, dateTimeTo);

        public void AddTransaction(Transaction transaction) => _transactionsHandler.Add(transaction);        

        private void SetDefaultValues(User user)
        {
            //set Accounts
            var accountCash = new Account { Name = "Cash", User = user };
            var accountCard = new Account { Name = "Card", User = user };
            AddAccount(accountCash, 0);
            AddAccount(accountCard, 0);

            //set Incomes
            var incomeSalary = new Income { Name = "Salary", User = user };
            AddIncome(incomeSalary);

            //set Expense
            var expenseFood = new Expense { Name = "Food", User = user };
            var expenseCar = new Expense { Name = "Car", User = user };
            var expenseBills = new Expense { Name = "Bills", User = user };
            AddExpense(expenseFood);
            AddExpense(expenseCar);
            AddExpense(expenseBills);

            //set test transactions
            var transactionSalary = new Transaction
            {
                Type = TransactionType.Incoming,
                User = user,
                AccountTo = accountCash,
                Date = System.DateTime.Now,
                Income = incomeSalary,
                Amount = 80_000,
            };
            var transactionTransfer = new Transaction
            {
                Type = TransactionType.Transfer,
                User = user,
                AccountFrom = accountCash,
                AccountTo = accountCard,
                Amount = 30_000
            };
            var transactionFood = new Transaction
            {
                Type = TransactionType.Outgoing,
                User = user,
                AccountFrom = accountCash,
                Expense = expenseFood,
                Amount = 1200
            };

            AddTransaction(transactionSalary);
            AddTransaction(transactionTransfer);
            AddTransaction(transactionFood);

        }
    }
}
