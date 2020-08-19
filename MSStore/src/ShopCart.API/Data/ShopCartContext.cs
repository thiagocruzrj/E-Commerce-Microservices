using ShopCart.API.Data.Interfaces;
using StackExchange.Redis;
using System;

namespace ShopCart.API.Data
{
    public class ShopCartContext : IShopCartContext
    {
        private readonly IConnectionMultiplexer _redisConnection;

        public ShopCartContext(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            Redis = _redisConnection.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}