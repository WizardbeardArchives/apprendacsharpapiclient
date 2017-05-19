namespace ApprendaAPIClient
{
    public class ConnectionSettings : IConnectionSettings
    {
        public string AppsUrl { get; set; }
        public IUserLogin UserLogin { get; set; }
        public IUserLogin AdminUserLogin { get; set; }

        public string IntegrationTestResourcesDirectory { get; set; }
        public string RepositoryServer { get; set; }
        public string AdminTenantAlias { get; set; }
    }
}
