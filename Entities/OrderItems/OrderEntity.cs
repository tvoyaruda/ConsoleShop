using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public AccountEntity Customer { get; set; }
        public DateTime CreatedTime { get; set; }
        public ProductEntity Product { get; set; }
        public OrderState State { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Product.Name} - {Product.Price} - {State}";
        }
    }
}
