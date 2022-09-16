using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using System.Linq;

namespace Infrastructure
{
    public class OrderRepository : ListRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(ListContext<OrderEntity> context) : base(context) { }

        public IEnumerable<OrderEntity> GetOrdersByCustomerId(int customerId)
            => Context.ContextList.Where(e => e.CustomerId == customerId);

        public void UpdateOrderState(int orderId, OrderState orderState) 
            => Context.ContextList.First(e => e.Id == orderId).State = orderState;
    }
}
