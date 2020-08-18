namespace Catalog.API.Settings
{
    public interface ICatalogDbSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}