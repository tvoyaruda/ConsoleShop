using Entities;
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
    public class GuestOperations : IOperations
    {
        private readonly GuestService _guestService;

        public GuestOperations(IDataContex contex)
        {
            _guestService = new GuestService(contex);
        }

        public bool ShowAvalibleOperations(AccountEntity account)
        {
            Console.WriteLine("Guest");
            Console.WriteLine("2. Find prod");
            Console.WriteLine("3. Sign in");
            Console.WriteLine("4. Log in");
            return true;
        }
    }
}
