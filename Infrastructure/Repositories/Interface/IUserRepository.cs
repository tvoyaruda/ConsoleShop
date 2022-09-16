using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Infrastructure
{
    public interface IUserRepository: IRepository<UserEntity>
    {
        IEnumerable<UserEntity> GetByUserRole(int role);

        UserEntity GetByEmail(string email);

        UserEntity GetByEmailAndPass(string email, string pass);
    }
}
