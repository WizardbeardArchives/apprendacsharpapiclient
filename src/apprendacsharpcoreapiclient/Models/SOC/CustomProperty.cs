using System.Collections.Generic;

namespace ApprendaAPIClient.Models.SOC
{
    public class CustomPropertyValueOptions
    {
        public List<string> PossibleValues { get; set; }
        public List<string> DefaultValues { get; set; }
        public bool AllowCustomValues { get; set; }
    }

    public class CustomPropertyDeveloperOptions
    {
        public bool IsVisible { get; set; }
        public VisibilityOptions VisibilityOptions { get; set; }
    }

    public class VisibilityOptions
    {
        public bool IsEditableByDeveloper { get; set; }
        public bool IsRequiredForDeployment { get; set; }
    }

    public class CustomPropertyApplicabilityOption
    {
        public bool IsApplied { get; set; }
        public bool AllowMultipleValues { get; set; }
    }

    public class CustomPropertyApplicationComponentOptions
    {
        public bool UserInterfaces { get; set; }
        public bool JavaWebApplications { get; set; }
        public bool WindowsServices { get; set; }
        public bool LinuxServices { get; set; }
        public bool Databases { get; set; }
    }

    public class CustomPropertyApplicationOptions : CustomPropertyApplicabilityOption
    {
        public bool IsComponentLevel { get; set; }
        public CustomPropertyApplicationComponentOptions ApplicationComponentLevelOptions { get; set; }
    }

    public class CustomPropertyApplicabilityOptionCollection
    {
        public CustomPropertyApplicationOptions Applications { get; set; }
        public CustomPropertyApplicabilityOption ComputeServers { get; set; }
        public CustomPropertyApplicabilityOption DatabaseServers { get; set; }
        public CustomPropertyApplicabilityOption ResourcePolicies { get; set; }
        public CustomPropertyApplicabilityOption StorageQuotas { get; set; }
    }

    public class CustomProperty
    {
        public string Href { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public CustomPropertyValueOptions ValueOptions { get; set; }
        public CustomPropertyDeveloperOptions DeveloperOptions { get; set; }
        public CustomPropertyApplicabilityOptionCollection Applicability { get; set; }
    }
}
