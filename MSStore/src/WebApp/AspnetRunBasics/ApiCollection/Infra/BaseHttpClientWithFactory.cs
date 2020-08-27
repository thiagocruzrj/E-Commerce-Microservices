using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

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

        public virtual async Task<T> SendRequest<T>(HttpRequestMessage request) where T : class
        {
            var client = GetHttpClient();

            var response = await client.SendAsync(request);

            T result = null;

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>(GetFormatters());
            }

            return result;
        }

        protected virtual IEnumerable<MediaTypeFormatter> GetFormatters()
        {
            return new List<MediaTypeFormatter> { new JsonMediaTypeFormatter() };
        }
    }
}