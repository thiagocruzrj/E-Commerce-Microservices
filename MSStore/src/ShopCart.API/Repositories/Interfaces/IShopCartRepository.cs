using ShopCart.API.Entities;
using System.Threading.Tasks;

namespace ShopCart.API.Repositories.Interfaces
{
    public interface IShopCartRepository
    {
        Task<ShoppingCart> GetShopCart(string userName);
        Task<ShoppingCart> UpdateShopCart(ShoppingCart shopCart);
        Task<bool> DeleteShopCart(string userName);
    }
}