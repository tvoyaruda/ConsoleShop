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
        public bool CreateCustomer(CustomerEntity newAccount, IRepository context)
        {
            if (context.GetAdminByEmail(newAccount.Email) != null)
                return false;
            context.AddCustomer(newAccount);
            return true;
        }
        public AccountEntity LogIn(string email, string password, IRepository context)
        {
            return (AccountEntity) context.GetAdminByEmailAndPass(email, password) ??
                context.GetCustomerByEmailAndPass(email, password);
        }
    }
}
