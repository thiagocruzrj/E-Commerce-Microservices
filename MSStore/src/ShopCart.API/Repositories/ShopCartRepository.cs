using Newtonsoft.Json;
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
            _shopCartContext = shopCartContext ?? throw new ArgumentException(nameof(shopCartContext));
        }

        public async Task<ShoppingCart> GetShopCart(string userName)
        {
            var shopCart = await _shopCartContext.Redis.StringGetAsync(userName);

            if (shopCart.IsNullOrEmpty)
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(shopCart);
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
