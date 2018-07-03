using System;
using Apprenda.Testing.RestAPITestTools.Repositories;

namespace Apprenda.Testing.RestAPITestTools.ValueItems.Implementation
{
    /// <summary>
    /// Smoke test application which is also able to know it should destroy itself on the platform once disposed
    /// </summary>
    public class CreatedSmokeTestApplication : SmokeTestApplication, IDisposable
    {


        private readonly ISmokeTestApplicationRepository _smokeTestApplicationRepository;
        private readonly IApprendaTestSession _session;
        public bool WasCreated { get; set; }


        public CreatedSmokeTestApplication(ISmokeTestApplication source, ISmokeTestApplicationRepository smokeTestApplicationRepository, IApprendaTestSession session)
        {
            AppAlias = source.AppAlias;
            SmokeTestApplicationName = source.SmokeTestApplicationName;
            _smokeTestApplicationRepository = smokeTestApplicationRepository;
            _session = session;
        }

      
        public override async void Dispose()
        {
            //the repo will decide whether or not we want to get rid of this application to keep clean
            await _smokeTestApplicationRepository.MarkAsNoLongerUsedByTest(_session, this);
        }
    }
}
