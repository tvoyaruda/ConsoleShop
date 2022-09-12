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
    public abstract class BaseOperations<T> : IOperations where T : BaseService
    {
        protected T _userService;
        protected AccountEntity currentUser;
        public abstract bool ShowAvalibleOperations(IDataContext dataContext, ref IOperations operations);

        public void SetUser(AccountEntity user)
        {
            currentUser = user;
        }

        protected void FindProduct(IDataContext dataContext)
        {
            Console.WriteLine("Input name of product");
            string name = Console.ReadLine();
            foreach (var p in _userService.SearchbyName(name, dataContext))
            {
                Console.WriteLine(p);
            }
        }
    }
}
