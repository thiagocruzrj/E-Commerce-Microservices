using System.Net.Http;

namespace AspnetRunBasics.ApiCollection.Infra
{
    public class HttpRequestBuilder
    {
        private readonly HttpRequestMessage _request;
        private string _baseAddress;
        private readonly ApiBuilder _apiBuilder;

        public HttpRequestBuilder(string uri) : this(new ApiBuilder(uri)) { }
        public HttpRequestBuilder(ApiBuilder apiBuilder)
        {
            _request = new HttpRequestMessage();
            _apiBuilder = apiBuilder;
            _baseAddress = _apiBuilder.GetLeftPart();
        }

        public HttpRequestBuilder AddToPath(string path)
        {
            _apiBuilder.AddToPath(path);
            _request.RequestUri = _apiBuilder.GetUri();

            return this;
        }

        public HttpRequestBuilder SetPath(string path)
        {
            _apiBuilder.SetPath(path);
            _request.RequestUri = _apiBuilder.GetUri();

            return this;
        }

        public HttpRequestBuilder Headers(NameValueCollection headers)
        {
            _request.Headers.Clear();
            foreach (var item in headers.AllKeys)
            {
                _request.Headers.Add(item, headers[item]);
            }

            return this;
        }

        public HttpRequestBuilder Content(HttpContent content)
        {
            _request.Content = content;
            return this;
        }
    }
}
