using System;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using log4net;
using Microsoft.Practices.Unity;
using Server.AppServices;
using Server.AppServices.Api;
using Server.AppServices.Exceptions;
using Server.Handlers.ServerVersion;

namespace Server.Service
{
    /// <summary>
    /// Server instance is a singleton, allowing all initialization to happen in the constructor
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyServer : IMyServer
    {
        #region service implementation internals

        static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        readonly UnityContainer container = new UnityContainer();

        public MyServer()
        {
            Log.Debug("Service instance created!");

            // possibly replace this tedious bit with some kind of auto-registration
            container.RegisterType<IRequestHandler<QueryServerVersionRequest>, QueryServerVersionHandler>()
                .RegisterType<IDetermineServerVersion, DetermineServerVersionByLookingAtAssemblyInfo>();
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
            catch(Exception e)
            {
                Log.Error("Unhandled exception", e);

                // all other exceptions should "bubble up", allowing WCF to handle them
                throw;
            }
        }

        Response ProcessRequest(Request request)
        {
            var stopwatch = Stopwatch.StartNew();
            Log.DebugFormat("Received request of type {0}", request.GetType());

            // close IRequestHandler<> with concrete type of the incoming request
            var requestType = request.GetType();
            var handlerType = typeof(IRequestHandler<>).MakeGenericType(requestType);

            // obtain instance of implementation from IoC container
            var handlerInstance = container.Resolve(handlerType);

            Log.DebugFormat("Dispatching request to handler of type {0}", handlerInstance.GetType());

            // invoke the process method (matches the signature specified in the
            // IRequestHandler<TRequest> interface);
            var response = (Response) handlerInstance.GetType()
                                          .GetMethod("Process")
                                          .Invoke(handlerInstance, new object[] {request});

            Log.DebugFormat("Returning response of type {0} (processing took {1:0.000 s})", response.GetType(), stopwatch.Elapsed.TotalSeconds);

            return response;
        }
    }
}