using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using BLL;

namespace PL
{
    public static class OperationsSelector
    {
        private static Dictionary<UserRoles, IOperations> keyValuePairs = new Dictionary<UserRoles, IOperations>
        {
            {UserRoles.Customer, new CustomerOperations() },
            {UserRoles.Admin, new AdminOperations() }
        };

        public static IOperations GetOperations(UserRoles userRole)
        {
            if(keyValuePairs.ContainsKey(userRole))
                return keyValuePairs[userRole];
            else
                return new GuestOperations();
        }
    }
}
