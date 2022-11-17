using System.Collections.Generic;
using Week3.Domain.Entities;

namespace Week3.Services.Abstract
{
    public interface IProductService
    {
        public List<Product> GetAll();
        public Product Add(Product entity);
        public Product Update(Product entity);
        public Product GetById(int id);
        public bool Delete(int Id);
    }
}
