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
        private static Dictionary<Type, IOperations> keyValuePairs = new Dictionary<Type, IOperations>
        {
            {typeof(CustomerEntity), new CustomerOperations() },
            {typeof(AdminEntity), new AdminOperations() }
        };

        public static IOperations GetOperations(Type accountType)
        {
            if(keyValuePairs.ContainsKey(accountType))
                return keyValuePairs[accountType];
            else
                return new GuestOperations();
        }
    }
}
