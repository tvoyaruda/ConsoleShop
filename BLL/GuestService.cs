using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace BLL
{
    public class GuestService : BaseService
    {
        public bool RegisterNewAccount(UserEntity newAccount, IDataContext context)
        {
            if (context.Customers.Find(c => c.Email == newAccount.Email) != null)
                return false;
            newAccount.Id = context.Customers.LastOrDefault().Id + 1;
            context.Customers.Add(newAccount);
            return true;
        }
        public AccountEntity LogIn(string email, string password, IDataContext context)
        {
            return (AccountEntity) context.Customers.Find(c => c.Email == email && c.Password == password) ??
                context.Admins.Find(c => c.Email == email && c.Password == password);
        }
    }
}
