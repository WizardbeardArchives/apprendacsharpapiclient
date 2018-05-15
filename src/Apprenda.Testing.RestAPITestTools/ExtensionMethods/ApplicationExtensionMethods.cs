using System;
using IO.Swagger.Model;

namespace Apprenda.Testing.RestAPITestTools.ExtensionMethods
{
    public static class ApplicationExtensionMethods
    {
        public static bool IsInStage(this EnrichedApplication app, string desiredState)
        {
            if (app == null)
            {
                //throw new ArgumentException("Application is null!");
                return false;
            }

            if (app.CurrentVersion == null)
            {
                //throw new ArgumentException($"Current version of application ${app.Alias} is null");
                return false;
            }

            if (string.IsNullOrWhiteSpace(app.CurrentVersion.Stage))
            {
                //throw new ArgumentException($"No stage listed for version ${app.CurrentVersion.Alias} of application {app.Alias}");
                return false;
            }

            return string.Equals(app.CurrentVersion.Stage, desiredState, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool IsCurrentlyPromoting(this EnrichedApplication app)
        {
            return app.IsInStage("promoting") || app.IsInStage("started");
        }
    }
}
