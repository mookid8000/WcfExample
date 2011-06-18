using System.ServiceModel;

namespace Server.Service
{
    [ServiceContract(Namespace = "http://trifork.com/wcf/unit_test_sample")]
    public interface IMyServer
    {
        [OperationContract]
        Response Process(Request request);
    }
}