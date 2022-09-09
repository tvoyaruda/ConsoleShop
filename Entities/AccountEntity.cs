using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class AccountEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name} - {Surname} - {DateOfBirth} - {Email}";
        }
        public void Update(AccountEntity account)
        {
            if(account.Name != null)
                this.Name = account.Name;
            if (account.Surname != null)
                this.Surname = account.Surname;
            if (account.DateOfBirth != null)
                this.DateOfBirth = account.DateOfBirth;
            if (account.Email != null)
                this.Email = account.Email;
            if (account.Password != null)
                this.Password = account.Password;
        }
    }
}
