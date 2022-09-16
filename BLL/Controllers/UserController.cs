using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure;
using Domain;

namespace BLL
{
    public class UserController
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository users)
        {
            _userRepository = users;
        }
        public IEnumerable<UserEntity> GetAllUsers() =>
            _userRepository.GetAll();

        public UserEntity GetUserById(int Id) =>
            _userRepository.GetById(Id);

        public IEnumerable<UserEntity> GetAllCustomers() =>
            _userRepository.GetByUserRole((int)UserRoles.Customer);

        public IEnumerable<UserEntity> GetAllAdmins() =>
            _userRepository.GetByUserRole((int)UserRoles.Admin);

        public bool CreateCustomer(CustomerEntity newAccount)
        {
            if(_userRepository.GetByEmail(newAccount.Email) != null)
                return false;
            _userRepository.Add(newAccount);
            return true;
        }
        public UserEntity LogIn(string email, string password)
        {
            return _userRepository.GetByEmailAndPass(email, password);
        }

        public bool UpdateCustomerInfo(CustomerEntity customer)
        {
            if (_userRepository.GetById(customer.Id) == null)
                return false;
            _userRepository.Update(customer);
            return true;
        }

    }
}
