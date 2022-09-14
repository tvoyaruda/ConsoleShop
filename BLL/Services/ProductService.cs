using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Entities;

namespace BLL
{
    public class ProductService
    {
        private readonly ProductRepository products;

        public ProductService(ProductListDataContext context)
        {
            products = new ProductRepository(context);
        }

        public IEnumerable<ProductEntity> GetAllProducts() => products.GetAll();

        public IEnumerable<ProductEntity> GetProductsByName(string name) => products.GetProductsByName(name);

        public ProductEntity GetProductById(int Id) => products.GetById(Id);

        public bool CreateProduct(ProductEntity product)
        {
            if (products.GetProductsByName(product.Name) != null)
                return false;
            products.Create(product);
            return true;
        }

        public bool UpdateProductInfo(ProductEntity product)
        {
            if (products.GetById(product.Id) == null)
                return false;
            products.Update(product);
            return true;
        }
    }
}
