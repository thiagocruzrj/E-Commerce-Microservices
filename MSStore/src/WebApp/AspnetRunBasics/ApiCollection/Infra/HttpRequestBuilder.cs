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
    }
}
