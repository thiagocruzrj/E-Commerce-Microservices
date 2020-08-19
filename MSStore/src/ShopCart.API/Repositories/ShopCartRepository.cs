using ShopCart.API.Data.Interfaces;
using ShopCart.API.Entities;
using ShopCart.API.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ShopCart.API.Repositories
{
    public class ShopCartRepository : IShopCartRepository
    {
        private readonly IShopCartContext _shopCartContext;

        public ShopCartRepository(IShopCartContext shopCartContext)
        {
            _shopCartContext = shopCartContext;
        }

        public Task<ShoppingCart> GetShopCart(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> UpdateShopCart(ShoppingCart shopCart)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteShopCart(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
