using AspnetRunBasics.Models;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection.Interfaces
{
    public interface IShopCartApi
    {
        Task<ShopCartModel> GetShopCart(string userName);
        Task<ShopCartModel> UpdateShopCart(ShopCartModel model);
        Task CheckoutShopCart(ShopCartCheckoutModel model);
    }
}