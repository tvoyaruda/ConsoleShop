using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure;
using Domain;

namespace BLL
{
    public class OrderController
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orders)
        {
            _orderRepository = orders;
        }

        public IEnumerable<OrderEntity> GetAllOrders() =>
            _orderRepository.GetAll();

        public IEnumerable<OrderEntity> GetAllCustomerOrders(int customerId) =>
            _orderRepository.GetOrdersByCustomerId(customerId);

        public bool CreateOrder(int customerId, int productId, ProductController products, UserController users)
        {

            UserEntity user = users.GetUserById(customerId); // how to use productService and userService here??
            ProductEntity product = products.GetProductById(productId);
            if (product == null || user == null)
                return false;
            OrderEntity order = new OrderEntity()
            {
                State = OrderState.New,
                ProductId = productId,
                CustomerId = customerId
            };
            _orderRepository.Add(order);
            return true;
        }

        public bool UpdateOrderState(int orderId, int customerId, int stateId)
        {
            OrderEntity changeOrder = _orderRepository.GetById(orderId);
            if (changeOrder.State != OrderState.CanceledByUser)
            {
                _orderRepository.UpdateOrderState(orderId, (OrderState)stateId);
                return true;
            }
            return false;
        }
    }
}
