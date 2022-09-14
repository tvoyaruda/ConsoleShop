using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace BLL
{
    public class CustomerService: BaseService
    {
        public IEnumerable<ProductEntity> GetAllProducts(IRepository context) => context.GetProducts();

        public IEnumerable<OrderEntity> GetAllCustomerOrders(int customerId, IRepository context) =>
            context.GetOrdersByCustomerId(customerId);

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

        public bool UpdateOrderStateAsCanceled(int orderId, int userId, IRepository context)
        {
            OrderEntity changeOrder = context.GetOrderById(orderId);
            if(changeOrder != null && changeOrder.Customer.Id == userId && changeOrder.State == OrderState.New)
            {
                context.UpdateOrderState(orderId, OrderState.CanceledByUser);
                return true;
            }
            return false;
        }

        public bool UpdateOrderStateAsReceived(int orderId, int userId, IRepository context)
        {
            OrderEntity changeOrder = context.GetOrderById(orderId);
            if (changeOrder != null 
                    && changeOrder.Customer.Id == userId 
                        && changeOrder.State != OrderState.CanceledByUser 
                            && changeOrder.State != OrderState.CanceledByAdmin)
            {
                context.UpdateOrderState(orderId, OrderState.Received);
                return true;
            }
            return false;
        }

        public bool UpdateCustomerInfo(CustomerEntity customer, IRepository context)
        {
            AccountEntity findCustomer = context.GetCustomerById(customer.Id);
            if (findCustomer == null)
                return false;
            context.UpdateCustomer(customer);
            return true;
        }
    }
}
