using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum OrderState
    {
        New,
        CanceledByAdmin,
        PaymentReceived,
        Sent,
        Received,
        Completed, 
        CanceledByUser
    }

    public class OrderEntity
    {
        public int Id { get; set; }
        public UserEntity Customer { get; set; }
        public DateTime CreatedTime { get; set; }
        public ProductEntity Product { get; set; }
        public OrderState State { get; set; }
    }
}
