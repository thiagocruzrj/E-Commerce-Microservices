using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunBasics.ApiCollection.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogApi _catalogApi;
        private readonly IShopCartApi _shopCartApi;

        public IndexModel(ICatalogApi catalogApi, IShopCartApi shopCartApi)
        {
            _catalogApi = catalogApi ?? throw new ArgumentNullException(nameof(catalogApi));
            _shopCartApi = shopCartApi ?? throw new ArgumentNullException(nameof(shopCartApi));
        }

        public IEnumerable<Entities.Product> ProductList { get; set; } = new List<Entities.Product>();

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _productRepository.GetProducts();
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _cartRepository.AddItem("test", productId);
            return RedirectToPage("Cart");
        }
    }
}
