using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using System.Linq;

namespace Data
{
    public class AdminRepository : ListRepository<AdminEntity, AdminListContext>
    {
        public AdminEntity GetByEmail(string email)
            => Context.DataList.First(c => c.Email == email);

        public AdminEntity GetByEmailAndPass(string email, string pass)
            => Context.DataList.First(c => c.Email == email && c.Password == pass);
    }
}
