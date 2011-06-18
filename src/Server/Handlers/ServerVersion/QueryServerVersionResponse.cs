using System.Runtime.Serialization;
using Server.Service;

namespace Server.Handlers.ServerVersion
{
    [DataContract]
    public class QueryServerVersionResponse : Response
    {
        [DataMember]
        public string Version { get; set; }
    }
}