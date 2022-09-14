using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderEntity : BaseEntity, IUpdatebly<OrderEntity>
    {
        public int CustomerId { get; set; }
        public DateTime CreatedTime { get; set; }
        public int ProductId { get; set; }
        public OrderState State { get; set; }
        public override string ToString()
        {
            return $"{Id} - {CustomerId} - {ProductId} - {State}";
        }

        public void Update(OrderEntity order)
        {
            if (order.CustomerId != default)
                this.CustomerId = order.CustomerId;
            if (order.CreatedTime != default)
                this.CreatedTime = order.CreatedTime;
            if (order.ProductId != default)
                this.ProductId = order.ProductId;
            if (order.State != default)
                this.State = order.State;
        }
    }
}
