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

        public Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            throw new System.NotImplementedException();
        }

        public Task<CatalogModel> GetCatalogById(string id)
        {
            throw new System.NotImplementedException();
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