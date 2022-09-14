using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using System.Linq;

namespace Data
{
    public class OrderRepository : ListRepository<OrderEntity, OrderListDataContext>
    {
        public OrderRepository(OrderListDataContext context) : base(context) { }

        public IEnumerable<OrderEntity> GetOrdersByCustomerId(int customerId)
            => Context.DataList.Where(e => e.CustomerId == customerId);

        public void UpdateOrderState(int orderId, OrderState orderState) 
            => Context.DataList.First(e => e.Id == orderId).State = orderState;
    }
}
