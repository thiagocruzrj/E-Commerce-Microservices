namespace Catalog.API.Settings
{
    public class CatalogDbSettings : ICatalogDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string CollectionName { get; set; }
    }
}