namespace ApprendaAPIClient.Models.SOC
{
    public class Cloud : ResourceBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string RootUrl { get; set; }

        public string Description { get; set; }

        public string InfrastructureProvider { get; set; }

        public string CloudType { get; set; }

        public string State { get; set; }
    }
}
