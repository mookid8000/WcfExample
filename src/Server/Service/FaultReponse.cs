using System.Runtime.Serialization;

namespace Server.Service
{
    [DataContract]
    public class FaultReponse : Response
    {
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}