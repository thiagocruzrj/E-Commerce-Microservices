using System;
using System.Net.Http;

namespace AspnetRunBasics.ApiCollection.Infra
{
    public class BaseHttpClientWithFactory
    {
        private readonly IHttpClientFactory _factory;

        public Uri BaseAddress { get; set; }
        public string BasePath { get; set; }

        public BaseHttpClientWithFactory(IHttpClientFactory factory) => _factory = factory;

        private HttpClient GetHttpClient()
        {
            return _factory.CreateClient();
        }
    }
}