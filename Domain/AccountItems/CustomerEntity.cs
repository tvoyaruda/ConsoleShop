using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CustomerEntity : UserEntity, IUpdatebly<CustomerEntity>
    {
        public void Update(CustomerEntity customer)
        {
            if (!string.IsNullOrEmpty(customer.Name))
                this.Name = customer.Name;
            if (!string.IsNullOrEmpty(customer.Surname))
                this.Surname = customer.Surname;
            if (customer.DateOfBirth != default)
                this.DateOfBirth = customer.DateOfBirth;
            if (!string.IsNullOrEmpty(customer.Email))
                this.Email = customer.Email;
            if (!string.IsNullOrEmpty(customer.Password))
                this.Password = customer.Password;
        }
    }
}
