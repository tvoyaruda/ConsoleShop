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
            if (!string.IsNullOrEmpty(product.Name))
                this.Name = product.Name;
            if (!string.IsNullOrEmpty(product.Category))
                this.Category = product.Category;
            if (product.Price != default)
                this.Price = product.Price;
        }
    }
}
