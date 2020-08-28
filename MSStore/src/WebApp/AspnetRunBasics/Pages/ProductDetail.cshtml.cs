using System;
using System.Threading.Tasks;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class ProductDetailModel : PageModel
    {
        private readonly ICatalogApi _catalogApi;
        private readonly IShopCartApi _shopCartApi;

        public ProductDetailModel(ICatalogApi catalogApi, IShopCartApi shopCartApi)
        {
            _catalogApi = catalogApi ?? throw new ArgumentNullException(nameof(catalogApi));
            _shopCartApi = shopCartApi ?? throw new ArgumentNullException(nameof(shopCartApi));
        }

        public CatalogModel Product { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(string productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            Product = await _catalogApi.GetCatalogById(productId);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _catalogApi.GetCatalogById(productId);

            var userName = "testUser";
            var basket = await _shopCartApi.GetShopCart(userName);

            basket.Items.Add(new ShopCartItemModel
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = Quantity,
                Color = Color
            });

            var basketUpdated = await _shopCartApi.UpdateShopCart(basket);

            return RedirectToPage("Cart");
        }
    }
}