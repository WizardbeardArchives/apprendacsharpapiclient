using System.Threading.Tasks;
using Apprenda.Testing.RestAPITestTools.ValueItems;
using ApprendaAPIClient.Factories;
// ReSharper disable once RedundantUsingDirective

namespace Apprenda.Testing.RestAPITestTools.Repositories
{
    public interface ISmokeTestSettingsRepository : IConnectionSettingsFactory
    {
        Task<ISmokeTestSettings> GetSmokeTestSettings();
    }
}
