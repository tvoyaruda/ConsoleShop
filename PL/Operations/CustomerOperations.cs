using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Domain;
using BLL;

namespace PL
{
    public class CustomerOperations : BaseOperations
    {
        public CustomerOperations(ListDataContext context) : base(context)
        {
        }

        public override bool ShowAvailableOperations(UserEntity user, out bool continueApp)
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
            continueApp = true;
            switch (int.Parse(Console.ReadLine()))
            {
                case 0:
                    continueApp = false;
                    break;
                case 1:
                    ShowProducts();
                    break;
                case 2:
                    FindProduct();
                    break;
                case 3:
                    ShowOrders();
                    break;
                case 4:
                    CreateNewOrder();
                    break;
                case 5:
                    UpdateOrderStateAsCanceled();
                    break;
                case 6:
                    UpdateOrderStateAsReceived();
                    break;
                case 7:
                    ChangeInfo();
                    break;
                case 8:
                    LogOut();
                    break;
                default:
                    break;
            }
            return true;
        }

        private void ShowOrders()
        {
            Console.WriteLine("Your orders:");
            foreach (var o in orderController.GetAllCustomerOrders(currentUser.Id))
            {
                Console.WriteLine(o);
            }
        }

        private void LogOut()
        {
            currentUser = null;
        }

        private void CreateNewOrder()
        {
            ShowProducts();
            Console.WriteLine("Enter product id");
            int prodId = int.Parse(Console.ReadLine());
            if(orderController.CreateOrder(currentUser.Id, prodId, productController, userController))
            {
                Console.WriteLine("Order created!");
                ShowOrders();
            }
            else
                Console.WriteLine("Wrong product id! Try to order again");
        }

        private void ShowProducts()
        {
            foreach (var p in productController.GetAllProducts())
                Console.WriteLine(p);
        }


        private void UpdateOrderStateAsCanceled()
        {
            ShowOrders();
            Console.WriteLine("Enter order id to cancel it");
            int orderId = int.Parse(Console.ReadLine());
            if (orderController.UpdateOrderState(orderId, currentUser.Id, (int)OrderState.CanceledByUser))
            {
                Console.WriteLine("Order canceled!");
                ShowOrders();
            }
            else
                Console.WriteLine("This order can't be canceled");
        }

        private void UpdateOrderStateAsReceived()
        {
            ShowOrders();
            Console.WriteLine("Enter order id to receive it");
            int orderId = int.Parse(Console.ReadLine());
            if (orderController.UpdateOrderState(orderId, currentUser.Id, (int)OrderState.Received))
            {
                Console.WriteLine("Order received!");
                ShowOrders();
            }
            else
                Console.WriteLine("This order can't be received");
        }

        private void ChangeInfo()
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
            if(userController.UpdateCustomerInfo((CustomerEntity)currentUser))
                Console.WriteLine("Change saved!");
            else
                Console.WriteLine("Some problem. Try again");

        }
    }
}
