using System;

namespace AspnetRunBasics.ApiCollection.Infra
{
    public class ApiBuilder
    {
        private readonly string _fullUrl;
        private UriBuilder _builder;

        public ApiBuilder(string url)
        {
            _fullUrl = url;
            _builder = new UriBuilder(url);
        }

        public Uri GetUri() => _builder.Uri;

        public ApiBuilder Scheme(string scheme)
        {
            _builder.Scheme = scheme;
            return this;
        }

        public ApiBuilder Host(string host)
        {
            _builder.Host = host;
            return this;
        }

        public ApiBuilder AddToPatch(string patch)
        {
            IncluedePatch(patch);
            return this;
        }

        public ApiBuilder SetPatch(string patch)
        {
            _builder.Path = patch;
            return this;
        }
    }
}