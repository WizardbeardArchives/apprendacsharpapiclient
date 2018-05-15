using Apprenda.Testing.RestAPITestTools.Repositories;
using ApprendaAPIClient.Services;

namespace Apprenda.Testing.RestAPITestTools.Services.Implementation
{
    /// <summary>
    /// Allows static reference to a pass through settings factory
    /// </summary>
    public class SettingsFactory
    {
        private static readonly ITelemetryReportingService ReportingService;

        static SettingsFactory()
        {
            ReportingService = new ConsoleTelemetryService();
        }
        public static ISmokeTestSettingsRepository Instance =>new JsonFileSettingsFactory(ReportingService);
    }
}
