using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using System.Linq;

namespace Infrastructure
{
    public class UserRepository : ListRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ListContext<UserEntity> context) : base(context) { }

        public IEnumerable<UserEntity> GetByUserRole(int role)
            => Context.ContextList.Where(c => (int)c.Role == role);

        public UserEntity GetByEmail(string email)
            => Context.ContextList.First(c => c.Email == email);

        public UserEntity GetByEmailAndPass(string email, string pass)
            => Context.ContextList.First(c => c.Email == email && c.Password == pass);
    }
}
