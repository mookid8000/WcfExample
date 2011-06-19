using System.Reflection;
using System.Security.Principal;
using log4net;

namespace Server.Security
{
    public class CustomPrincipal : IPrincipal
    {
        static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        readonly IIdentity identity;

        public CustomPrincipal(IIdentity identity)
        {
            this.identity = identity;
        }

        public bool IsInRole(string role)
        {
            Log.InfoFormat("Checking if {0} is in role: {1}", identity.Name, role);
            return true;
        }

        public IIdentity Identity
        {
            get { return identity; }
        }
    }
}