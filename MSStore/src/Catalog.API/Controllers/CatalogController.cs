using Catalog.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Catalog.API.Controllers
{
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
        }
    }
}