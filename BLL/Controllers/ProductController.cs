using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure;
using Domain;

namespace BLL
{
    public class ProductController
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository products)
        {
            _productRepository = products;
        }

        public IEnumerable<ProductEntity> GetAllProducts() => _productRepository.GetAll();

        public IEnumerable<ProductEntity> GetProductsByName(string name) => _productRepository.GetProductsByName(name);

        public ProductEntity GetProductById(int Id) => _productRepository.GetById(Id);

        public bool CreateProduct(ProductEntity product)
        {
            if (_productRepository.GetProductsByName(product.Name) != null)
                return false;
            _productRepository.Add(product);
            return true;
        }

        public bool UpdateProductInfo(ProductEntity product)
        {
            if (_productRepository.GetById(product.Id) == null)
                return false;
            _productRepository.Update(product);
            return true;
        }
    }
}
