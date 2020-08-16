using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Catalog.API.Data
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if(!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Samsung Note 10 Plus",
                    Summary = "Test Summary",
                    Description = "Test Description",
                    Price = 600.00M,
                    Category = "Smartphone"
                },
                new Product()
                {
                    Name = "Samsung Note 10",
                    Summary = "Test Summary",
                    Description = "Test Description",
                    Price = 500.00M,
                    Category = "Smartphone"
                },
                new Product()
                {
                    Name = "Samsung S10 Plus",
                    Summary = "Test Summary",
                    Description = "Test Description",
                    Price = 450.00M,
                    Category = "Smartphone"
                },
                new Product()
                {
                    Name = "Iphone X",
                    Summary = "Test Summary",
                    Description = "Test Description",
                    Price = 700.00M,
                    Category = "Smartphone"
                },
            };
        }
    }
}
