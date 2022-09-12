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
        private static Dictionary<string, IOperations> keyValuePairs = new Dictionary<string, IOperations>
        {
            {"UserEntity", new CustomerOperations() },
            {"AdminEntity", new AdminOperations() }
        };

        public static IOperations GetOperations(string accountType)
        {
            try
            {
                return keyValuePairs[accountType];
            }
            catch
            {
                return new GuestOperations();
            }
        }
    }
}
