namespace Apprenda.Testing.RestAPITestTools.ValueItems
{
    public interface IEnvironmentFeaturesAvailable
    {
        bool IsExternalUserStore { get; }
        bool IsMultipleNodes { get; }
    }
}
