using System;
using System.Threading.Tasks;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class CheckOutModel : PageModel
    {
        private readonly ICatalogApi _catalogApi;
        private readonly IShopCartApi _shopCartApi;

        public CheckOutModel(ICatalogApi catalogApi, IShopCartApi shopCartApi)
        {
            _catalogApi = catalogApi ?? throw new ArgumentNullException(nameof(catalogApi));
            _shopCartApi = shopCartApi ?? throw new ArgumentNullException(nameof(shopCartApi));
        }

        [BindProperty]
        public ShopCartCheckoutModel Order { get; set; }

        public ShopCartModel Cart { get; set; } = new ShopCartModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "testUser";
            Cart = await _shopCartApi.GetShopCart(userName);

            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var userName = "testUser";
            Cart = await _shopCartApi.GetShopCart(userName);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.UserName = userName;
            Order.TotalPrice = Cart.TotalPrice;

            await _shopCartApi.CheckoutShopCart(Order);

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}