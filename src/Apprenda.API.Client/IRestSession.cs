namespace ApprendaAPIClient
{
    /// <summary>
    /// Exposes a pre-existing session token to maintain an existing session between requests or instances of <see cref="IApprendaApiClient"/>
    /// </summary>
    public interface IRestSession
    {
        /// <summary>
        /// Gets the Apprenda session token.
        /// </summary>
        string ApprendaSessionToken { get; }
    }
}