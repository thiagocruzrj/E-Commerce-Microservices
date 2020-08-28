using System;
using System.Linq;
using System.Threading.Tasks;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class CartModel : PageModel
    {
        private readonly IShopCartApi _shopCartApi;

        public CartModel(IShopCartApi shopCartApi)
        {
            _shopCartApi = shopCartApi ?? throw new ArgumentNullException(nameof(shopCartApi));
        }

        public ShopCartModel Cart { get; set; } = new ShopCartModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "testUser";
            Cart = await _shopCartApi.GetShopCart(userName);

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            var userName = "testUser";
            var basket = await _shopCartApi.GetShopCart(userName);

            var item = basket.Items.Single(x => x.ProductId == productId);
            basket.Items.Remove(item);

            var basketUpdated = await _shopCartApi.UpdateShopCart(basket);

            return RedirectToPage();
        }
    }
}