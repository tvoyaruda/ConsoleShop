using Entities;
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
    public class GuestOperations : BaseOperations<GuestService>
    {
        public GuestOperations() : base() 
        {
            _userService = new GuestService();
        }

        public override bool ShowAvalibleOperations(IDataContex dataContex,ref IOperations operations)
        {
            Console.WriteLine("\n\nGuest");
            Console.WriteLine($"Enter 0 for exit");
            Console.WriteLine("1. Sign in");
            Console.WriteLine("2. Find prod");
            Console.WriteLine("3. Log in");
            switch (int.Parse(Console.ReadLine()))
            {
                case 0:
                    return false;
                case 1:
                    operations = SignUp(dataContex);
                    break;
                case 2:
                    FindProduct(dataContex);
                    break;
                case 3:
                    operations = LogIn(dataContex);
                    break;
                default:
                    break;
            }
            return true;
        }

        private IOperations SignUp(IDataContex dataContex)
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

            if (_userService.RegisterNewAccount(newUser, dataContex))
            {
                Console.WriteLine("User added!");
                currentUser = newUser;
            }
            else
            {
                Console.WriteLine("Something went wrong..Try again");
                currentUser = null;
            }
            IOperations newOperations = OperationsForAccount.GetOperations(currentUser?.GetType().Name);
            newOperations.SetUser(currentUser);
            return newOperations;
        }

        private IOperations LogIn(IDataContex dataContex)
        {
            Console.WriteLine("Input your email");
            string email = Console.ReadLine();
            Console.WriteLine("Input your password");
            string password = Console.ReadLine();
            currentUser = _userService.LogIn(email, password, dataContex);
            IOperations newOperations = OperationsForAccount.GetOperations(currentUser?.GetType().Name);
            newOperations.SetUser(currentUser);
            return newOperations;
        }
    }
}
