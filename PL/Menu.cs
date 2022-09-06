using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using BLL;

namespace PL
{
    public class Menu
    {
        private readonly IDataContex _dataContex;
        private AccountEntity _user;
        private readonly CustomerService _customerService;
        private readonly GuestService _guestService;

        private string Profile => _user == null ? "Guest" : $"{_user.GetType().Name}";
        private string Email => _user == null ? "" : $"{_user.Email}";

        public Menu()
        {
            _dataContex = new DataContex();
            _customerService = new CustomerService(_dataContex);
            _guestService = new GuestService(_dataContex);
        }

        public void Run()
        {
            bool continueCode = true ;
            while(continueCode)
                continueCode = ShowAvalibleOperations(Profile);

        }

        private bool ShowAvalibleOperations(string role)
        {
            Console.WriteLine($"Profile: {Profile} {Email}");
            Console.WriteLine($"Enter 0 for exit");
            switch (role)
            {
                case "Guest":
                    Console.WriteLine("2. Find prod");
                    Console.WriteLine("3. Sign in");
                    Console.WriteLine("4. Log in");
                    int com1 = int.Parse(Console.ReadLine());
                    if (com1 == 0)
                        return false;
                    ChooseGuestOperation(com1);
                    break;
                case "UserEntity":
                    Console.WriteLine("2. Find prod");
                    Console.WriteLine("3. Show orders");
                    int com2 = int.Parse(Console.ReadLine());
                    if (com2 == 0)
                        return false;
                    ChooseUserOperation(com2);
                    break;
                default:
                    Console.Clear();
                    break;
            }
            return true;
        }

        private void ChooseGuestOperation(int command)
        {
            switch(command)
            {
                case 2:
                    Console.WriteLine("Input value");
                    string name = Console.ReadLine();
                    foreach (var p in _guestService.SearchbyName(name))
                    {
                        Console.WriteLine($"{p.Id} - {p.Name} - {p.Category} - {p.Price}");
                    }
                    break;
                case 3:
                    SignIn();
                    break;
                case 4:
                    LogIn();
                    break;
                default:
                    break;
            }
        }

        private void ChooseUserOperation(int command)
        {
            switch (command)
            {
                case 2:
                    Console.WriteLine("Input value");
                    string name = Console.ReadLine();
                    foreach(var p in _customerService.SearchbyName(name))
                    {
                        Console.WriteLine($"{p.Id} - {p.Name} - {p.Category} - {p.Price}");
                    }
                    break;
                case 3:
                    foreach (var p in _customerService.ViewOrders(_user.Id))
                    {
                        Console.WriteLine($"{p.Id} - {p.Product.Name} - {p.Product.Price} - {p.State}");
                    }
                    break;
                default:
                    break;
            }
        }

        private void SignIn()
        {
            Console.WriteLine("Input your email");
            string email = Console.ReadLine();
            Console.WriteLine("Input your password");
            string password = Console.ReadLine();
            Console.WriteLine("Input your name");
            string name = Console.ReadLine();
            Console.WriteLine("Input your surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Input your year of birth");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Input your month of birth");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Input your day of birth");
            int day = int.Parse(Console.ReadLine());
            UserEntity newUser = new UserEntity
            {
                Id = 0,
                Name = name,
                Surname = surname,
                DateOfBirth = new DateTime(year, month, day),
                Email = email,
                Password = password
            };

            if (_guestService.RegisterNewAccount(newUser))
            {
                Console.WriteLine("User added!");
                this._user = newUser;
            }
        }

        private void LogIn()
        {
            Console.WriteLine("Input your email");
            string email = Console.ReadLine();
            Console.WriteLine("Input your password");
            string password = Console.ReadLine();
            this._user = _guestService.LogIn(email, password);
        }
    }
}
