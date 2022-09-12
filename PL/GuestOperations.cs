using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using BLL;


namespace PL
{
    public class GuestOperations : BaseOperations<GuestService>
    {
        public GuestOperations() : base() 
        {
            _userService = new GuestService();
        }

        public override bool ShowAvalibleOperations(IDataContext dataContext,ref IOperations operations)
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
                    operations = SignUp(dataContext);
                    break;
                case 2:
                    FindProduct(dataContext);
                    break;
                case 3:
                    operations = LogIn(dataContext);
                    break;
                default:
                    break;
            }
            return true;
        }

        private IOperations SignUp(IDataContext dataContext)
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

            if (_userService.RegisterNewAccount(newUser, dataContext))
            {
                Console.WriteLine("User added!");
                currentUser = newUser;
            }
            else
            {
                Console.WriteLine("Something went wrong..Try again");
                currentUser = null;
            }
            IOperations newOperations = OperationsSelector.GetOperations(currentUser?.GetType().Name);
            newOperations.SetUser(currentUser);
            return newOperations;
        }

        private IOperations LogIn(IDataContext dataContext)
        {
            Console.WriteLine("Input your email");
            string email = Console.ReadLine();
            Console.WriteLine("Input your password");
            string password = Console.ReadLine();
            currentUser = _userService.LogIn(email, password, dataContext);
            IOperations newOperations = OperationsSelector.GetOperations(currentUser?.GetType().Name);
            newOperations.SetUser(currentUser);
            return newOperations;
        }
    }
}
