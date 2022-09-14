using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using System.Linq;

namespace Data
{
    public class CustomerRepository : ListRepository<CustomerEntity, CustomerListContext>
    {
        public CustomerEntity GetByEmail(string email)
            => Context.DataList.First(c => c.Email == email);

        public CustomerEntity GetByEmailAndPass(string email, string pass)
            => Context.DataList.First(c => c.Email == email && c.Password == pass);
    }
}
