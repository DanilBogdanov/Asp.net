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
        private readonly CostControlContext _dbContext;

        private readonly BalancesHandler _balancesHandler;
        private readonly TransactionsHandler _transactionsHandler;
        private readonly AccountsHandler _accountHandler;
        private readonly IncomesHandler _incomesHandler;
        private readonly ExpensesHandler _expenseHandler;

        public CostControlService(CostControlContext costControlContext)
        {
            _dbContext = costControlContext;

            _balancesHandler = new BalancesHandler(_dbContext);
            _transactionsHandler = new TransactionsHandler(_dbContext, _balancesHandler);
            _accountHandler = new AccountsHandler(_dbContext);
            _incomesHandler = new IncomesHandler(_dbContext);
            _expenseHandler = new ExpensesHandler(_dbContext);
        }

        public User GetUserByEmail(string userEmail)
        {
            User user = _dbContext.CostControlUsers
                .Where(user => user.Email == userEmail)
                .FirstOrDefault();
            if (user == null)
            {
                user = new User { Email = userEmail };
                _dbContext.CostControlUsers.Add(user);
                _dbContext.SaveChanges();
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
            Transaction transaction = new Transaction { Type = TransactionType.Correction, AccountTo = account, Amount = balance };
            _transactionsHandler.Add(transaction);
        }

        public List<Income> GetIncomes(User costControlUser) => _incomesHandler.GetAll(costControlUser);

        public void AddIncome(Income income) => _incomesHandler.Add(income);


        public List<Expense> GetExpenses(User costControlUser) => _expenseHandler.GetAll(costControlUser);

        public void AddExpense(Expense expense) => _expenseHandler.Add(expense);


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
                Amount = 80000,
            };
            var transactionTransfer = new Transaction
            {
                Type = TransactionType.Transfer,
                User = user,
                Date = System.DateTime.Now,
                AccountFrom = accountCash,
                AccountTo = accountCard,
                Amount = 30000
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
