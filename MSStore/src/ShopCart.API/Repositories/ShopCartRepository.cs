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
            var getShopCart = await _shopCartContext.Redis.StringGetAsync(userName);

            if (getShopCart.IsNullOrEmpty)
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(getShopCart);
        }

        public async Task<ShoppingCart> UpdateShopCart(ShoppingCart shopCart)
        {
            var updatedShopCart = await _shopCartContext.Redis.StringSetAsync(shopCart.UserName, JsonConvert.SerializeObject(shopCart));

            if(!updatedShopCart)
            {
                return null;
            }

            return await GetShopCart(shopCart.UserName);
        }

        public Task<bool> DeleteShopCart(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
