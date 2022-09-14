using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CustomerEntity : AccountEntity
    {
        public override void Update(AccountEntity account)
        {
            if (!string.IsNullOrEmpty(account.Name))
                this.Name = account.Name;
            if (!string.IsNullOrEmpty(account.Surname))
                this.Surname = account.Surname;
            if (account.DateOfBirth != default)
                this.DateOfBirth = account.DateOfBirth;
            if (!string.IsNullOrEmpty(account.Email))
                this.Email = account.Email;
            if (!string.IsNullOrEmpty(account.Password))
                this.Password = account.Password;
        }
    }
}
