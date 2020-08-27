using AspnetRunBasics.ApiCollection.Infra;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using AspnetRunBasics.Settings;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection
{
    public class ShopCartApi : BaseHttpClientWithFactory, IShopCartApi
    {
        private readonly IApiSettings _settings;

        public ShopCartApi(IHttpClientFactory factory, IApiSettings settings) : base(factory)
        {
            _settings = settings;
        }

        public Task<ShopCartModel> GetShopCart(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<ShopCartModel> UpdateShopCart(ShopCartModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task CheckoutShopCart(ShopCartCheckoutModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}