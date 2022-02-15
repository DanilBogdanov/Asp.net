using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanilDev.Services.EmploeesDirectory
{
    public class EmployeeDirectoryService
    {
        private readonly EmployeeDirectoryContext _dbContext;

        public EmployeeDirectoryService(EmployeeDirectoryContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
