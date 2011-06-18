using Microsoft.Practices.Unity;
using Server.AppServices;
using Server.AppServices.Api;
using Server.AppServices.Exceptions;
using Server.Handlers.ServerVersion;

namespace Server.Service
{
    public class MyServer : IMyServer
    {
        #region service implementation internals
        static readonly UnityContainer Container = BuildContainer();

        static UnityContainer BuildContainer()
        {
            var container = new UnityContainer();

            // possibly replace this tedious bit with some kind of auto-registration
            container.RegisterType<IRequestHandler<QueryServerVersionRequest>, QueryServerVersionHandler>()
                .RegisterType<IDetermineServerVersion, DetermineServerVersionByLookingAtAssemblyInfo>();

            return container;
        }
        #endregion

        public Response Process(Request request)
        {
            try
            {
                // try processing the request
                return ProcessRequest(request);
            }
            catch (DomainException e)
            {
                // map exceptions with friendly messages to FaultResponse
                // (in this example, all exceptions derived from DomainException
                // will be caught)
                return new FaultReponse {ErrorMessage = e.Message};
            }

            // all other exceptions should "bubble up", allowing WCF to handle them
        }

        Response ProcessRequest(Request request)
        {
            // close IRequestHandler<> with concrete type of the incoming request
            var requestType = request.GetType();
            var handlerType = typeof(IRequestHandler<>).MakeGenericType(requestType);

            // obtain instance of implementation from IoC container
            var handlerInstance = Container.Resolve(handlerType);

            // invoke the process method (matches the signature specified in the
            // IRequestHandler<TRequest> interface
            return (Response) handlerInstance.GetType()
                                  .GetMethod("Process")
                                  .Invoke(handlerInstance, new object[] {request});
        }
    }
}