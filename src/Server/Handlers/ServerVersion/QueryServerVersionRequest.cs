using System.Runtime.Serialization;
using Server.Service;

namespace Server.Handlers.ServerVersion
{
    [DataContract]
    public class QueryServerVersionRequest : Request {}
}