using System;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using log4net;

namespace Server.Security
{
    public class CustomAuthorizationPolicy : IAuthorizationPolicy
    {
        static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        readonly string id;

        public CustomAuthorizationPolicy()
        {
            id = Guid.NewGuid().ToString();
        }

        public string Id
        {
            get { return id; }
        }

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            var identityClaim = evaluationContext.ClaimSets.SelectMany(c => c).Single(c => c.Right == Rights.Identity);
            
            Log.WarnFormat("Identity claim: {0} ({1})", identityClaim.Resource, identityClaim.ClaimType);

            var client = new GenericIdentity("JohnDoe");

            // set the custom principal
            evaluationContext.Properties["Principal"] = new CustomPrincipal(client);
            return true;
        }

        public ClaimSet Issuer
        {
            get { return new DefaultClaimSet(); }
        }
    }
}