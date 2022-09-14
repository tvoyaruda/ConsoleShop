using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class AccountEntity: BaseEntity, IUpdatebly<AccountEntity>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; } = UserRoles.Customer;
        public override string ToString()
        {
            return $"{Id} - {Name} - {Surname} - {DateOfBirth} - {Email}";
        }

        public void Update(AccountEntity account)
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
