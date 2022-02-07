using DanilDev.Services.CostControl.Entity;
using DanilDev.Services.CostControl.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DanilDev.Services.CostControl
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

        public List<Account> GetAccounts(User costControlUser) => _accountHandler.GetAll(costControlUser);
        public List<(Account, decimal amount)> GetAccountsWithBalance(User costControlUser)
        {
            List<(Account, decimal amount)> accountsWithBalance = new List<(Account, decimal amount)>();
            var accountList = _accountHandler.GetAll(costControlUser);

            foreach (var account in accountList)
            {
                decimal amount = _balancesHandler.GetAmount(account);
                accountsWithBalance.Add((account, amount));
            }

            return accountsWithBalance;
        }

        public void AddAccount(Account account, decimal balance)
        {
            _accountHandler.Add(account);
            Transaction transaction =
                new Transaction
                {
                    Type = TransactionType.Correction,
                    Description = "Create Account",
                    AccountTo = account,
                    Amount = balance,
                    User = account.User
                };
            _transactionsHandler.Add(transaction);
        }

        public List<Income> GetIncomes(User costControlUser) => _incomesHandler.GetAll(costControlUser);
        public List<(Income, decimal amount)> GetIncomesWithAmount(User costControlUser, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            var listResult = new List<(Income, decimal amount)>();
            foreach (var income in GetIncomes(costControlUser))
            {
                decimal amount = 0;
                foreach (var transact in _transactionsHandler.GetByIncome(costControlUser, income, dateTimeFrom, dateTimeTo))
                {
                    amount += transact.Amount;
                }

                listResult.Add((income, amount));
            }

            return listResult;
        }
        public void AddIncome(Income income) => _incomesHandler.Add(income);


        public List<Expense> GetExpenses(User costControlUser) => _expenseHandler.GetAll(costControlUser);
        public List<(Expense, decimal amount)> GetExpensesWithAmount(User costControlUser, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            var listResult = new List<(Expense, decimal amount)>();
            foreach (var expense in GetExpenses(costControlUser))
            {
                decimal amount = 0;
                foreach (var transact in _transactionsHandler.GetByExpense(costControlUser, expense, dateTimeFrom, dateTimeTo))
                {
                    amount += transact.Amount;
                }

                listResult.Add((expense, amount));
            }

            return listResult;
        }
        public void AddExpense(Expense expense) => _expenseHandler.Add(expense);


        public List<Transaction> GetTransactions(User costControlUser) => _transactionsHandler.GetAll(costControlUser);
        /// <summary>
        /// Get Transactions for user between the given dates.
        /// dataTimeFrom include, dataTimeTo exclude
        /// </summary>        
        public List<Transaction> GetTransactions(User costControlUser, DateTime dateTimeFrom, DateTime dateTimeTo) =>
            _transactionsHandler.GetAll(costControlUser, dateTimeFrom, dateTimeTo);

        public void AddTransaction(Transaction transaction) => _transactionsHandler.Add(transaction);

        private void SetDefaultValues(User user)
        {
            //set Accounts
            var accountCash = new Account { Name = "Cash", User = user, Description = "Cash" };
            var accountCard = new Account { Name = "Card", User = user, Description = "Credit Card" };
            AddAccount(accountCash, 5000);
            AddAccount(accountCard, 10000);

            //set Incomes
            var incomeSalary = new Income { Name = "Salary", User = user, Description = "Salary" };
            AddIncome(incomeSalary);

            //set Expense
            var expenseFood = new Expense { Name = "Food", User = user, Description = "Food" };
            var expenseCar = new Expense { Name = "Car", User = user, Description = "Car" };
            var expenseBills = new Expense { Name = "Bills", User = user, Description = "Bills" };
            AddExpense(expenseFood);
            AddExpense(expenseCar);
            AddExpense(expenseBills);

            //set test transactions
            var transactionSalary = new Transaction
            {
                Type = TransactionType.Incoming,
                Description = "just salary",
                User = user,
                AccountTo = accountCash,
                Date = System.DateTime.Now,
                Income = incomeSalary,
                Amount = 80000,
            };
            var transactionTransfer = new Transaction
            {
                Type = TransactionType.Transfer,
                Description = "bancomat",
                User = user,
                Date = System.DateTime.Now,
                AccountFrom = accountCash,
                AccountTo = accountCard,
                Amount = 30000
            };
            var transactionFood = new Transaction
            {
                Type = TransactionType.Outgoing,
                Description = "food at work",
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
