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

        public async Task<ShopCartModel> GetShopCart(string userName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.ShopCartPath)
                                .AddToPath("UserName")
                                .AddToPath(userName)
                                .HttpMethod(HttpMethod.Get)
                                .GetHttpMessage();

            return await SendRequest<ShopCartModel>(message);
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