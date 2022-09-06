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
        public GuestService(IDataContex contex) : base(contex) { }

        public bool RegisterNewAccount(UserEntity newAccount)
        {
            if (this.Contex.Customers.Find(c => c.Email == newAccount.Email) != null)
                return false;
            newAccount.Id = this.Contex.Customers.LastOrDefault().Id + 1;
            this.Contex.Customers.Add(newAccount);
            return true;
        }
        public AccountEntity LogIn(string email, string password)
        {
            return (AccountEntity) this.Contex.Customers.Find(c => c.Email == email && c.Password == password) ??
                this.Contex.Admins.Find(c => c.Email == email && c.Password == password);
        }
    }
}
