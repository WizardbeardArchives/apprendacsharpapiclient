namespace ApprendaAPIClient.Models.AccountPortal
{
    public class SecurableResource
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Href { get; set; }

        public bool? IsRuntime { get; set; }

        public ResourceBase Roles { get; set; }
        public ResourceBase ApplicationVersion { get; set; }
    }
}
