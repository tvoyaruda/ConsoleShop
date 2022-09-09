using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name} - {Category} - {Price}";
        }

        public void Update(ProductEntity product)
        {
            if (product.Name != null)
                this.Name = product.Name;
            if (product.Category != null)
                this.Category = product.Category;
            if (product.Price != 0)
                this.Price = product.Price;
        }
    }
}
