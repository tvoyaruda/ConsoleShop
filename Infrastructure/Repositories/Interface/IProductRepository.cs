using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Infrastructure
{
    public interface IProductRepository: IRepository<ProductEntity>
    {
        IEnumerable<ProductEntity> GetProductsByName(string name);
    }
}
