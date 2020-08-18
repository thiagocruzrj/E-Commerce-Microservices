namespace Catalog.API.Settings
{
    public class CatalogDbSettings : ICatalogDbSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
