using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using System.Linq;

namespace Infrastructure
{
    public class ProductRepository: ListRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(ListContext<ProductEntity> context) : base(context) { }

        public IEnumerable<ProductEntity> GetProductsByName(string name)
        {
            Func<ProductEntity, bool> rule = p => p.Name.ToLower().Contains(name.ToLower());
            return Context.ContextList.Where(rule);
        }
    }
}
