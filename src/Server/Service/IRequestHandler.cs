namespace Server.Service
{
    /// <summary>
    /// Implement this interface in order to handle request of a given type. There
    /// must be exactly one implementation of each request type.
    /// </summary>
    /// <typeparam name="TRequest">Type of request to handle</typeparam>
    public interface IRequestHandler<in TRequest> where TRequest : Request
    {
        /// <summary>
        /// Process the request.
        /// </summary>
        /// <param name="request">Request to handle</param>
        /// <returns>Some derivation of response</returns>
        Response Process(TRequest request);
    }
}