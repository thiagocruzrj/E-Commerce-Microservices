namespace Catalog.API.Settings
{
    public interface ICatalogDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string CollectionName { get; set; }
    }
}
