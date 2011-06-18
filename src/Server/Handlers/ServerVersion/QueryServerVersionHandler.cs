using Server.AppServices.Api;
using Server.Service;

namespace Server.Handlers.ServerVersion
{
    public class QueryServerVersionHandler : IRequestHandler<QueryServerVersionRequest>
    {
        readonly IDetermineServerVersion determineServerVersion;

        public QueryServerVersionHandler(IDetermineServerVersion determineServerVersion)
        {
            this.determineServerVersion = determineServerVersion;
        }

        public Response Process(QueryServerVersionRequest request)
        {
            var versionString = determineServerVersion.GetVersionString();

            return new QueryServerVersionResponse { Version = versionString };
        }
    }
}