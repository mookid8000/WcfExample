using System.Reflection;
using Server.AppServices.Api;

namespace Server.AppServices
{
    class DetermineServerVersionByLookingAtAssemblyInfo : IDetermineServerVersion
    {
        public string GetVersionString()
        {
            var versionString = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            return versionString;
        }
    }
}