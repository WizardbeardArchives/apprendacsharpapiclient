namespace ApprendaAPIClient.Models.DeveloperPortal
{
    public enum ApplicationVersionStage
    {
        /// <summary>
        /// Identifies a version that exists only as binary and text meta-data on the system, and cannot be executed against.
        /// An application in this state can be modified for future deployment
        /// </summary>
        Definition,

        /// <summary>
        /// Identifies a version that is actively being hosted by Apprenda, but in a unpublished, provider only mode that blocks
        /// public provisioning and access rights, as well as various other system level rights.
        /// </summary>
        Sandbox,

        /// <summary>
        /// Identifies a version that is considered ready for tenant consumption, and that can be accessed by authorized tenants
        /// </summary>
        Published,

        /// <summary>
        /// Identifies a version that is defunct but stored on the platform for auditing purposes.
        /// </summary>
        Archived
    }
}
