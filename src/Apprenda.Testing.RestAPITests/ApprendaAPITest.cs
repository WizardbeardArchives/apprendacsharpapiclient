using Apprenda.Testing.RestAPITestTools;
using Apprenda.Testing.RestAPITestTools.Repositories;
using Apprenda.Testing.RestAPITestTools.Services.Implementation;
using ApprendaAPIClient.Services;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests
{
    /// <inheritdoc />
    /// <summary>
    /// A smoke test using very basic reporting and other injections
    /// </summary>
    public abstract class ApprendaAPITest : BaseSmokeTest
    {
        protected ApprendaAPITest(ISmokeTestSettingsRepository connectionSettingsFactory, ITelemetryReportingService logger):
            base(connectionSettingsFactory, new SimpleLocalSmokeTestApplicationRepository(connectionSettingsFactory), logger)
        {

        }

        protected ApprendaAPITest(ITelemetryReportingService logger) 
            : this(new JsonFileSettingsFactory(logger), logger)
        {
            
        }

        protected ApprendaAPITest(ITestOutputHelper helper) : this(new GauntletLogger(helper))
        {
            
        }
    }
}
