using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Infrastructure
{
    public interface IOrderRepository: IRepository<OrderEntity>
    {
        IEnumerable<OrderEntity> GetOrdersByCustomerId(int customerId);

        void UpdateOrderState(int orderId, OrderState orderState);
    }
}
