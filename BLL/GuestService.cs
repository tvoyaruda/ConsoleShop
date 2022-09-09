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
        public bool RegisterNewAccount(UserEntity newAccount, IDataContex contex)
        {
            if (contex.Customers.Find(c => c.Email == newAccount.Email) != null)
                return false;
            newAccount.Id = contex.Customers.LastOrDefault().Id + 1;
            contex.Customers.Add(newAccount);
            return true;
        }
        public AccountEntity LogIn(string email, string password, IDataContex contex)
        {
            return (AccountEntity) contex.Customers.Find(c => c.Email == email && c.Password == password) ??
                contex.Admins.Find(c => c.Email == email && c.Password == password);
        }
    }
}
