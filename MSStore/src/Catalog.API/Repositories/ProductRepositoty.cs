using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepositoty : IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
