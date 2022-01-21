using Asp_In_Action.Services.CostControl.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
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

        public List<Account> GetAccounts(User costControlUser)
        {
            return _costControlContext.CostControlAccounts
                .Where(account => account.User == costControlUser)
                .ToList();
        }

        public void AddAccount(Account account)
        {
            _costControlContext.CostControlAccounts.Add(account);
            _costControlContext.SaveChanges();
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

        public List<Transaction> GetTransactions(User costControlUser)
        {
            return _costControlContext.CostControlTransactions
                .Where(expense => expense.User == costControlUser)
                .ToList();
        }

        public void AddTransaction(Expense expense)
        {
            _costControlContext.CostControlExpenses.Add(expense);
            _costControlContext.SaveChanges();
        }

        private void SetDefaultValues(User user)
        {
            //set Accounts
            var accountCash = new Account { Name = "Cash", User = user };
            var accountCard = new Account { Name = "Card", User = user };
            AddAccount(accountCash);
            AddAccount(accountCard);

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

            var transactionSalary = new Transaction { Date = System.DateTime.Now, User = user , 
                Type = TransactionType.Incoming, Amount = 80_000, Income = incomeSalary};
        }
    }
}
