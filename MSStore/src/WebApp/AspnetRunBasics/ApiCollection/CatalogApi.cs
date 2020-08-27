using AspnetRunBasics.ApiCollection.Infra;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using AspnetRunBasics.Settings;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection
{
    public class CatalogApi : BaseHttpClientWithFactory, ICatalogApi
    {
        private readonly IApiSettings _settings;

        public CatalogApi(IHttpClientFactory factory, IApiSettings settings) : base(factory)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                            .SetPath(_settings.CatalogPath)
                            .HttpMethod(HttpMethod.Get)
                            .GetHttpMessage();

            return await SendRequest<IEnumerable<CatalogModel>>(message);
        }

        public async Task<CatalogModel> GetCatalogById(string id)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                            .SetPath(_settings.CatalogPath)
                            .AddToPath(id)
                            .HttpMethod(HttpMethod.Get)
                            .GetHttpMessage();

            return await SendRequest<CatalogModel>(message);
        }

        public Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            throw new System.NotImplementedException();
        }

        public Task<CatalogModel> CreateCatalog(CatalogModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}