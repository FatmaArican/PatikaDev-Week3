using System.Collections.Generic;
using Week3.Data.Abstract;
using Week3.Domain.Entities;
using Week3.Services.Abstract;

namespace Week3.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product entity)
        {
          return  _productRepository.Add(entity);
        }
        public Product Update(Product entity)
        {
            return _productRepository.Update(entity);
        }
        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }
    }
}
