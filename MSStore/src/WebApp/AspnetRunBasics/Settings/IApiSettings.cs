namespace AspnetRunBasics.Settings
{
    public interface IApiSettings
    {
        string BaseAddress { get; set; }
        string CatalogPath { get; set; }
        string ShopCartPath { get; set; }
        string OrderPath { get; set; }
    }
}