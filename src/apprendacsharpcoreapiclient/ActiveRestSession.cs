using System;

namespace ApprendaAPIClient
{
    /// <summary>
    /// Provides clients access to a shared or existing authenticated REST session
    /// </summary>
    /// <seealso cref="ApprendaAPIClient.IRestSession" />
    public sealed class ActiveRestSession : IRestSession
    {
        public ActiveRestSession(string apprendaSessionToken)
        {
            if (string.IsNullOrWhiteSpace(apprendaSessionToken)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(apprendaSessionToken));
            this.ApprendaSessionToken = apprendaSessionToken;
        }

        /// <inheritdoc />
        public string ApprendaSessionToken { get; }
    }
}