using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace BLL
{
    public class AdminService: BaseService
    {
        public IEnumerable<OrderEntity> GetAllOrders(IRepository context) =>
            context.GetOrders();

        public bool CreateOrder(int customerId, int productId, IRepository context)
        {
            CustomerEntity user = context.GetCustomerById(customerId);
            ProductEntity product = context.GetProductById(productId);
            if (product == null || user == null)
                return false;
            OrderEntity order = new OrderEntity()
            {
                State = OrderState.New,
                Product = product,
                Customer = user
            };
            context.AddOrder(order);
            return true;
        }

        public bool UpdateOrderState(int orderId, int stateId, IRepository context)
        {
            OrderEntity changeOrder = context.GetOrderById(orderId);
            if (changeOrder.State != OrderState.CanceledByUser)
            {
                context.UpdateOrderState(orderId, (OrderState)stateId);
                return true;
            }
            return false;
        }


        public void UpdateOrderStateAsCanceled(int orderId, IRepository context) =>
            context.UpdateOrderState(orderId, OrderState.CanceledByAdmin);


        public IEnumerable<CustomerEntity> GetAllCustomers(IRepository context) =>
            context.GetCustomers();        

        public bool UpdateCustomerInfo(CustomerEntity user, IRepository context)
        {
            if (context.GetCustomerById(user.Id) == null)
                return false;
            context.UpdateCustomer(user);
            return true;
        }


        public IEnumerable<ProductEntity> GetAllProducts(IRepository context) => context.GetProducts();

        public bool CreateProduct(ProductEntity product, IRepository context)
        {
            if (context.GetProductsByName(product.Name) != null)
                return false;
            context.AddProduct(product);
            return true;
        }

        public bool UpdateProductInfo(ProductEntity product, IRepository context)
        {
            if (context.GetProductById(product.Id) == null)
                return false;
            context.UpdateProduct(product);
            return true;
        }
    }
}
