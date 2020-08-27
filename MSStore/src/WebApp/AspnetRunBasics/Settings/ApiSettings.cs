namespace AspnetRunBasics.Settings
{
    public class ApiSettings : IApiSettings
    {
        public string BaseAddress { get; set; }
        public string CatalogPath { get; set; }
        public string ShopCartPath { get; set; }
        public string OrderPath { get; set; }
    }
}