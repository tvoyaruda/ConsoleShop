using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AdminEntity: AccountEntity, IUpdatebly<AdminEntity>
    {
        public void Update(AdminEntity admin)
        {
            if (!string.IsNullOrEmpty(admin.Name))
                this.Name = admin.Name;
            if (!string.IsNullOrEmpty(admin.Surname))
                this.Surname = admin.Surname;
            if (admin.DateOfBirth != default)
                this.DateOfBirth = admin.DateOfBirth;
            if (!string.IsNullOrEmpty(admin.Email))
                this.Email = admin.Email;
            if (!string.IsNullOrEmpty(admin.Password))
                this.Password = admin.Password;
        }
    }
}
