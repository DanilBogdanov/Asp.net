﻿using DanilDev.Services.CostControl.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DanilDev.Services.CostControl.Handlers
{
    internal class IncomesHandler
    {
        private readonly CostControlContext _dbContext;

        public IncomesHandler(CostControlContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Income> GetAll(User user)
        {
            return _dbContext.CostControlIncomes
                .Where(income => income.User == user)
                .ToList();
        }

        public void Add(Income income)
        {
            _dbContext.CostControlIncomes.Add(income);
            _dbContext.SaveChanges();
        }
    }
}
