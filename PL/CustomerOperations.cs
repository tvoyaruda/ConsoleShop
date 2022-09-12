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
    public class CustomerOperations : BaseOperations<CustomerService>
    {
        public CustomerOperations() : base() 
        {
            _userService = new CustomerService();
        }

        public override bool ShowAvalibleOperations(IDataContext dataContext, ref IOperations operations)
        {

            Console.WriteLine("\n\nCustomer");
            Console.WriteLine($"Hello {currentUser.Name}!");
            Console.WriteLine($"Enter 0 for exit");
            Console.WriteLine("1. Products list");
            Console.WriteLine("2. Find product");
            Console.WriteLine("3. Show orders");
            Console.WriteLine("4. New order");
            Console.WriteLine("5. Cancel an order");
            Console.WriteLine("6. Receive an order");
            Console.WriteLine("7. Change info");
            Console.WriteLine("8. Log Out");
            switch (int.Parse(Console.ReadLine()))
            {
                case 0:
                    return false;
                case 1:
                    ShowProducts(dataContext);
                    break;
                case 2:
                    FindProduct(dataContext);
                    break;
                case 3:
                    ShowOrders(dataContext);
                    break;
                case 4:
                    CreateNewOrder(dataContext);
                    break;
                case 5:
                    CancelOrder(dataContext);
                    break;
                case 6:
                    ReceivedOrder(dataContext);
                    break;
                case 7:
                    ChangeInfo(dataContext);
                    break;
                case 8:
                    operations = LogOut();
                    break;
                default:
                    break;
            }
            return true;
        }

        private void ShowOrders(IDataContext dataContext)
        {
            Console.WriteLine("Your orders:");
            foreach (var o in _userService.ViewOrders(currentUser.Id, dataContext))
            {
                Console.WriteLine(o);
            }
        }

        private IOperations LogOut()
        {
            currentUser = null;
            return OperationsSelector.GetOperations(currentUser?.GetType().Name);
        }

        private void CreateNewOrder(IDataContext dataContext)
        {
            ShowProducts(dataContext);
            Console.WriteLine("Enter product id");
            int prodId = int.Parse(Console.ReadLine());
            if(_userService.CreateOrder(currentUser.Id, prodId, dataContext))
            {
                Console.WriteLine("Order created!");
                ShowOrders(dataContext);
            }
            else
                Console.WriteLine("Wrong product id! Try to order again");
        }

        private void ShowProducts(IDataContext dataContext)
        {
            foreach (var p in _userService.ListOfProduct(dataContext))
                Console.WriteLine(p);
        }


        private void CancelOrder(IDataContext dataContext)
        {
            ShowOrders(dataContext);
            Console.WriteLine("Enter order id to cancel it");
            int orderId = int.Parse(Console.ReadLine());
            if (_userService.CancelOrder(orderId, dataContext))
            {
                Console.WriteLine("Order canceled!");
                ShowOrders(dataContext);
            }
            else
                Console.WriteLine("This order can't be canceled");
        }

        private void ReceivedOrder(IDataContext dataContext)
        {
            ShowOrders(dataContext);
            Console.WriteLine("Enter order id to receive it");
            int orderId = int.Parse(Console.ReadLine());
            if (_userService.ReceivedOrder(orderId, currentUser.Id, dataContext))
            {
                Console.WriteLine("Order received!");
                ShowOrders(dataContext);
            }
            else
                Console.WriteLine("This order can't be received");
        }

        private void ChangeInfo(IDataContext dataContext)
        {
            Console.WriteLine("Your actual information:");
            Console.WriteLine($"1. Name: {currentUser.Name}");
            Console.WriteLine($"2. Surname: {currentUser.Surname}");
            Console.WriteLine($"3. Date of birth: {currentUser.DateOfBirth}");
            Console.WriteLine($"4. Email: {currentUser.Email}");
            Console.WriteLine($"5. Password: {currentUser.Password}");

            Console.WriteLine("Enter code of information for changing:");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter new name:");
                    currentUser.Name = Console.ReadLine();
                    Console.WriteLine($"New name: {currentUser.Name}");
                    break;
                case 2:
                    Console.WriteLine("Enter new surname:");
                    currentUser.Surname = Console.ReadLine();
                    Console.WriteLine($"New surname: {currentUser.Surname}");
                    break;
                case 4:
                    Console.WriteLine("Enter new email:");
                    currentUser.Email = Console.ReadLine();
                    Console.WriteLine($"New email: {currentUser.Email}");
                    break;
                case 5:
                    Console.WriteLine("Enter new password:");
                    currentUser.Password = Console.ReadLine();
                    Console.WriteLine($"New password: {currentUser.Password}");
                    break;
                default:
                    break;
            }
            if(_userService.ChangeUserInfo(currentUser, dataContext))
                Console.WriteLine("Change saved!");
            else
                Console.WriteLine("Some problem. Try again");

        }
    }
}
