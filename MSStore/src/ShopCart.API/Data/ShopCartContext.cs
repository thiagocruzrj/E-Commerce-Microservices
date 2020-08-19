using ShopCart.API.Data.Interfaces;
using StackExchange.Redis;

namespace ShopCart.API.Data
{
    public class ShopCartContext : IShopCartContext
    {
        private readonly ConnectionMultiplexer _redisConnection;

        public ShopCartContext(ConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            Redis = _redisConnection.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}