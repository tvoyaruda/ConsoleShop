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
    public abstract class BaseOperations : IOperations
    {
        protected UserController userController;
        protected ProductController productController;
        protected OrderController orderController;

        public UserEntity currentUser { get; protected set; }

        public BaseOperations(ListDataContext context)
        {
            userController = new UserController(context.Users);
            productController = new ProductController(context.Products);
            orderController = new OrderController(context.Orders);
        }

        public abstract bool ShowAvailableOperations(UserEntity user, out bool continueApp);

        protected void FindProduct()
        {
            Console.WriteLine("Input name of product");
            string name = Console.ReadLine();
            foreach (var p in productController.GetProductsByName(name))
            {
                Console.WriteLine(p);
            }
        }
    }
}
