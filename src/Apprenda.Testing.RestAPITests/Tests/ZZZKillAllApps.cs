using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Apprenda.Testing.RestAPITests.Tests
{
    public class ZZZKillAllApps : ApprendaAPITest
    {
        public ZZZKillAllApps(ITestOutputHelper helper) : base(helper)
        {
        }

        /// <summary>
        /// Does cleanup by destroying apps.  Be careful, as this will eliminate any non-smoke test apps as well.
        /// TODO - work on storing all apps made somewhere, and instead deleting them there
        /// </summary>
        /// <returns></returns>
        [Trait("Cleanup", "true")]
        [Fact(Skip = "Cant control order yet")]
        public async Task DestroyAllApps()
        {
            using (var session = await StartSession())
            {
                var client = await session.GetClient();

                var apps = await client.GetApplications();

                foreach (var app in apps)
                {
                    var res = await client.DeleteApplication(app.Alias);
                }
            }
        }
    }
}
