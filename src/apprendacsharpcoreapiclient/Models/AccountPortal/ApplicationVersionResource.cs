namespace ApprendaAPIClient.Models.AccountPortal
{
    public class ApplicationVersionResource
    {
        public string Href { get; set; }
        public string ProviderName { get; set; }
        public string ApplicationAlias { get; set; }
        public string ApplicationDescription { get; set; }
        public string ApplicationName { get; set; }
        public ResourceBase Plans { get; set; }
        public ResourceBase Securables { get; set; }
        public string VersionAlias { get; set; }
        public string VersionDescription { get; set; }
        public string Stage { get; set; }
        public ResourceBase Subscriptions { get; set; }
    }
}
