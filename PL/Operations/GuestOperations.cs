using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using BLL;


namespace PL
{
    public class GuestOperations : BaseOperations
    {
        public Dictionary<int, Action> Operations;

        public GuestOperations(ListDataContext context) : base(context)
        {
            Operations = new Dictionary<int, Action>();
            Operations.Add(1, SignUp);
            Operations.Add(2, FindProduct);
            Operations.Add(3, LogIn);
        }

        public override bool ShowAvailableOperations(UserEntity user, out bool continueApp)
        {
            Console.WriteLine("\n\nGuest");
            Console.WriteLine($"Enter 0 for exit");
            Console.WriteLine("1. Sign up");
            Console.WriteLine("2. Find prod");
            Console.WriteLine("3. Log in");
            continueApp = true;
            Action action;
            int command;
            while (continueApp)
            {
                int.TryParse(Console.ReadLine(), out command);
                if(command == 0)
                    continueApp = false;
                Operations.TryGetValue(command, out action);
                if (action != null)
                    action.Invoke();
            }
            return true;
        }

        private void SignUp()
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
            CustomerEntity newUser = new CustomerEntity
            {
                Name = name,
                Surname = surname,
                DateOfBirth = new DateTime(year, month, day),
                Email = email,
                Password = password
            };

            if (userController.CreateCustomer(newUser))
            {
                Console.WriteLine("User added!");
                currentUser = newUser;
            }
            else
            {
                Console.WriteLine("Something went wrong..Try again");
                currentUser = null;
            }
        }

        private void LogIn()
        {
            Console.WriteLine("Input your email");
            string email = Console.ReadLine();
            Console.WriteLine("Input your password");
            string password = Console.ReadLine();
            currentUser = userController.LogIn(email, password);
        }
    }
}
