using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
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

        public IEnumerable<CatalogModel> ProductList { get; set; } = new List<CatalogModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _catalogApi.GetCatalog();
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _catalogApi.GetCatalogById(productId);

            var userName = "testUser";
            var shopCart = await _shopCartApi.GetShopCart(userName);

            shopCart.Items.Add(new ShopCartItemModel
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1,
                Color = "black"
            });

            var shopCartUpdated = await _shopCartApi.UpdateShopCart(shopCart);
            return RedirectToPage("Cart");
        }
    }
}
