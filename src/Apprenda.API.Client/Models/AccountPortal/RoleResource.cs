namespace ApprendaAPIClient.Models.AccountPortal
{
    public class RoleResource
    {
        public string Href { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public ResourceBase Users { get; set; }

        public ResourceBase Roles { get; set; }

        public ResourceBase Securables { get; set; }
        public string Id { get; set; }
    }
}
