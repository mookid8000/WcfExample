using System.Reflection;
using log4net;
using Server.AppServices.Api;

namespace Server.AppServices
{
    class DetermineServerVersionByLookingAtAssemblyInfo : IDetermineServerVersion
    {
        static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string GetVersionString()
        {
            Log.DebugFormat("Determining version of currently executing assembly");

            var versionString = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            return versionString;
        }
    }
}