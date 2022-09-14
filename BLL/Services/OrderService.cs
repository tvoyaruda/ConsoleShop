using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Entities;

namespace BLL
{
    public class OrderService
    {
        private readonly OrderRepository orders;
        public OrderService(OrderListDataContext context)
        {
            orders = new OrderRepository(context);
        }

        public IEnumerable<OrderEntity> GetAllOrders() =>
            orders.GetAll();

        public IEnumerable<OrderEntity> GetAllCustomerOrders(int customerId) =>
            orders.GetOrdersByCustomerId(customerId);

        public bool CreateOrder(int customerId, int productId, ProductService products, UserService users)
        {

            AccountEntity user = users.GetUserById(customerId); // how to use productService and userService here??
            ProductEntity product = products.GetProductById(productId);
            if (product == null || user == null)
                return false;
            OrderEntity order = new OrderEntity()
            {
                State = OrderState.New,
                ProductId = productId,
                CustomerId = customerId
            };
            orders.Create(order);
            return true;
        }

        public bool UpdateOrderState(int orderId, int customerId, int stateId)
        {
            OrderEntity changeOrder = orders.GetById(orderId);
            if (changeOrder.State != OrderState.CanceledByUser)
            {
                orders.UpdateOrderState(orderId, (OrderState)stateId);
                return true;
            }
            return false;
        }
    }
}
