using System;

namespace Apprenda.Testing.RestAPITestTools.ValueItems
{
    public interface ISmokeTestApplication : IDisposable
    {
        /// <summary>
        /// The name the ApplicationRepository will use to retrieve the archive for this app
        /// </summary>
        string SmokeTestApplicationName { get; set; }

        /// <summary>
        /// The Alias of this application on the platform
        /// </summary>
        string AppAlias { get; set; }

        /// <summary>
        /// The ID of the application on the platform
        /// </summary>
        Guid? ApplicationId { get; set; }

        byte[] ArchiveContents { get; set; }

        /// <summary>
        /// Whether or not this app requires an entitlement definition on a new system
        /// </summary>
        bool RequiresEntitlement { get; set; }

    }
}