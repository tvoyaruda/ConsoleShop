using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using System.Linq;

namespace Data
{
    public class UserRepository : ListRepository<AccountEntity, UserListDataContext>
    {
        public UserRepository(UserListDataContext context) : base(context) { }

        public IEnumerable<AccountEntity> GetByUserRole(int role)
            => Context.DataList.Where(c => (int)c.Role == role);

        public AccountEntity GetByEmail(string email)
            => Context.DataList.First(c => c.Email == email);

        public AccountEntity GetByEmailAndPass(string email, string pass)
            => Context.DataList.First(c => c.Email == email && c.Password == pass);
    }
}
