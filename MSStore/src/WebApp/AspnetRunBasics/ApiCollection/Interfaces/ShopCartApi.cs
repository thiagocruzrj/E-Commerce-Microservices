using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection.Interfaces
{
    interface ShopCartApi
    {
        Task<ShopCartModel> GetShopCart(string userName);
        Task<ShopCartModel> UpdateShopCart(ShopCartModel model);
        Task CheckoutShopCart(ShopCartCheckoutModel model);
    }
}