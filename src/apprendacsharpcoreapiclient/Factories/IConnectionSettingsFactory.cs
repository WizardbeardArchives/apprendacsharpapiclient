namespace ApprendaAPIClient.Factories
{
    /// <summary>
    /// Produces connection settings, and allows injection of new methods to do so 
    /// </summary>
    public interface IConnectionSettingsFactory
    {
        IConnectionSettings GetConnectionSettings();
    }
}
