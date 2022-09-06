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
    class CustomerOperations : IOperations
    {
        private readonly CustomerService _customerService;

        public CustomerOperations(IDataContex contex)
        {
            _customerService = new CustomerService(contex);
        }

        public bool ShowAvalibleOperations(AccountEntity account)
        {
            Console.WriteLine("Customer");
            Console.WriteLine("2. Find prod");
            Console.WriteLine("3. Show orders");
            return true;
        }
    }
}
