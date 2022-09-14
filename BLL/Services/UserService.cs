using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Entities;

namespace BLL
{
    public class UserService
    {
        private readonly UserRepository users;

        public UserService(UserListDataContext context)
        {
            users = new UserRepository(context);
        }

        public IEnumerable<AccountEntity> GetAllUsers() =>
            users.GetAll();

        public AccountEntity GetUserById(int Id) =>
            users.GetById(Id);

        public IEnumerable<AccountEntity> GetAllCustomers() =>
            users.GetByUserRole((int)UserRoles.Customer);

        public IEnumerable<AccountEntity> GetAllAdmins() =>
            users.GetByUserRole((int)UserRoles.Admin);

        public bool UpdateCustomerInfo(CustomerEntity customer)
        {
            if (users.GetById(customer.Id) == null)
                return false;
            users.Update(customer);
            return true;
        }

    }
}
