using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using System.Linq;

namespace Data
{
    public class ProductRepository: ListRepository<ProductEntity, ProductListDataContext>
    {
        public ProductRepository(ProductListDataContext context) : base(context) { }

        public IEnumerable<ProductEntity> GetProductsByName(string name)
        {
            Func<ProductEntity, bool> rule = p => p.Name.ToLower().Contains(name.ToLower());
            return Context.DataList.Where(rule);
        }
    }
}
