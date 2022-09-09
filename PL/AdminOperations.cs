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
    class AdminOperations : BaseOperations<AdminService>
    {
        public AdminOperations() : base() 
        {
            _userService = new AdminService();
        }

        public override bool ShowAvalibleOperations(IDataContex dataContex, ref IOperations operations)
        {
            Console.WriteLine("\n\nAdmin");
            Console.WriteLine($"Hello {currentUser.Name}!");
            Console.WriteLine($"Enter 0 for exit");
            Console.WriteLine("1. Products list");
            Console.WriteLine("2. Find product");
            Console.WriteLine("3. Show orders");
            Console.WriteLine("4. New order");
            Console.WriteLine("5. Change order state");
            Console.WriteLine("6. View customer info");
            Console.WriteLine("7. Change customer info");
            Console.WriteLine("8. Add new product");
            Console.WriteLine("9. Change product info");
            Console.WriteLine("10. Log Out");
            switch (int.Parse(Console.ReadLine()))
            {
                case 0:
                    return false;
                case 1:
                    ShowProducts(dataContex);
                    break;
                case 2:
                    FindProduct(dataContex);
                    break;
                case 3:
                    ShowOrders(dataContex);
                    break;
                case 4:
                    CreateNewOrder(dataContex);
                    break;
                case 5:
                    ChangeOrderStatus(dataContex);
                    break;
                case 6:
                    ShowCustomers(dataContex);
                    break;
                case 7:
                    ChangeInfo(dataContex);
                    break;
                case 8:
                    AddNewProduct(dataContex);
                    break;
                case 9:
                    ChangeProductInfo(dataContex);
                    break;
                case 10:
                    operations = LogOut();
                    break;
                default:
                    break;
            }
            return true;
        }

        private void ShowOrders(IDataContex dataContex)
        {
            Console.WriteLine("All orders:");
            foreach (var o in _userService.GetOrders(dataContex))
            {
                Console.WriteLine(o);
            }
        }

        private void ShowProducts(IDataContex dataContex)
        {
            Console.WriteLine("All products:");
            foreach (var p in _userService.GetProducts(dataContex))
                Console.WriteLine(p);
        }

        private void ShowCustomers(IDataContex dataContex)
        {
            Console.WriteLine("All customers:");
            foreach (var p in _userService.GetCustomers(dataContex))
                Console.WriteLine(p);
        }

        private IOperations LogOut()
        {
            currentUser = null;
            return OperationsForAccount.GetOperations(currentUser?.GetType().Name);
        }

        private void CreateNewOrder(IDataContex dataContex)
        {
            ShowProducts(dataContex);
            Console.WriteLine("Enter product id");
            int prodId = int.Parse(Console.ReadLine());
            ShowCustomers(dataContex);
            Console.WriteLine("Enter customer id");
            int custId = int.Parse(Console.ReadLine());
            if (_userService.CreateOrder(custId, prodId, dataContex))
            {
                Console.WriteLine("Order created!");
                ShowOrders(dataContex);
            }
            else
                Console.WriteLine("Wrong product id! Try to order again");
        }

        private void ChangeOrderStatus(IDataContex dataContex)
        {
            ShowOrders(dataContex);
            Console.WriteLine("Enter order id to change its state:");
            int orderId = int.Parse(Console.ReadLine());
            OrderStates();
            Console.WriteLine("Enter order state id:");
            int orderState = int.Parse(Console.ReadLine()) + 1;
            if (_userService.ChangeOrderStatus(orderId, orderState, dataContex))
            {
                Console.WriteLine("Order state changed!");
                ShowOrders(dataContex);
            }
            else
                Console.WriteLine("This order can't be changed!");
        }

        private void OrderStates()
        {
            Console.WriteLine("Order states:");
            Console.WriteLine("1. " + OrderState.PaymentReceived);
            Console.WriteLine("2. " + OrderState.Sent);
            Console.WriteLine("3. " + OrderState.Received);
            Console.WriteLine("4. " + OrderState.Completed);
            Console.WriteLine("5. " + OrderState.CanceledByAdmin);
        }


        private void ChangeInfo(IDataContex dataContex)
        {
            AccountEntity customer = new UserEntity();
            ShowCustomers(dataContex);
            Console.WriteLine("Enter customer id");
            customer.Id = int.Parse(Console.ReadLine());
            Console.WriteLine($"1. Name");
            Console.WriteLine($"2. Surname");
            Console.WriteLine($"3. Date of birth");
            Console.WriteLine($"4. Email");
            Console.WriteLine($"5. Password");
            Console.WriteLine("Enter code of information for changing:");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter new name:");
                    customer.Name = Console.ReadLine();
                    Console.WriteLine($"New name: {customer.Name}");
                    break;
                case 2:
                    Console.WriteLine("Enter new surname:");
                    customer.Surname = Console.ReadLine();
                    Console.WriteLine($"New surname: {customer.Surname}");
                    break;
                case 4:
                    Console.WriteLine("Enter new email:");
                    customer.Email = Console.ReadLine();
                    Console.WriteLine($"New email: {customer.Email}");
                    break;
                case 5:
                    Console.WriteLine("Enter new password:");
                    customer.Password = Console.ReadLine();
                    Console.WriteLine($"New password: {customer.Password}");
                    break;
                default:
                    break;
            }
            if (_userService.ChangeUserInfo(customer, dataContex))
                Console.WriteLine("Change saved!");
            else
                Console.WriteLine("Some problem. Try again");
        }

        private void ChangeProductInfo(IDataContex dataContex)
        {
            ProductEntity product = new ProductEntity();
            ShowProducts(dataContex);
            Console.WriteLine("Enter product id");
            product.Id = int.Parse(Console.ReadLine());
            Console.WriteLine($"1. Name");
            Console.WriteLine($"2. Category");
            Console.WriteLine($"3. Price");
            Console.WriteLine("Enter code of information for changing:");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter new name:");
                    product.Name = Console.ReadLine();
                    Console.WriteLine($"New name: {product.Name}");
                    break;
                case 2:
                    Console.WriteLine("Enter new category:");
                    product.Category = Console.ReadLine();
                    Console.WriteLine($"New category: {product.Category}");
                    break;
                case 3:
                    Console.WriteLine("Enter new price:");
                    product.Price = decimal.Parse(Console.ReadLine());
                    Console.WriteLine($"New price: {product.Price}");
                    break;
                default:
                    break;
            }
            if (_userService.ChangeProductInfo(product, dataContex))
                Console.WriteLine("Change saved!");
            else
                Console.WriteLine("Some problem. Try again");
        }

        private void AddNewProduct(IDataContex dataContex)
        {
            ProductEntity product = new ProductEntity();
            ShowProducts(dataContex);
            Console.WriteLine("Enter product name:");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter product category:");
            product.Category = Console.ReadLine();
            Console.WriteLine("Enter product price:");
            product.Price = decimal.Parse(Console.ReadLine());
            if (_userService.AddNewProduct(product, dataContex))
                Console.WriteLine("Product added!");
            else
                Console.WriteLine("Something went wrong..Try again");
        }
    }
}
