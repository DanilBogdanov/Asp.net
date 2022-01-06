using Asp_In_Action.Services.CostControl.Entity;
using System.Collections.Generic;

namespace Asp_In_Action.Services.CostControl
{
    public class CostControlService
    {
        private CostControlContext _CostControlContext;
        public CostControlService(CostControlContext context)
        {
            _CostControlContext =  context;
        }
        public string GetMessage()
        {
            return "Hello from service";
        }

        public List<User> GetUsers()
        {
            return new List<User>(_CostControlContext.Users);
        } 
    }
}
