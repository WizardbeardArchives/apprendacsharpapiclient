namespace Apprenda.Testing.RestAPITestTools.ValueItems
{
    /// <summary>
    /// Describes how the test can run in parallel
    /// </summary>
    public enum TestIsolationLevel
    {
        /// <summary>
        /// Test doesn't care about if other tests run at the same time
        /// </summary>
        None,

        /// <summary>
        /// Requires that the appAlias being used in the test is not used by any other test during the run
        /// </summary>
        IsolatedApplication,

        /// <summary>
        /// The test requires that no other test runs at the same time
        /// </summary>
        CompletelyIsolated,

        /// <summary>
        /// Requires that no other test has run previously.  Likely not yet supported
        /// </summary>
        NewPlatformOnly
    }
}
