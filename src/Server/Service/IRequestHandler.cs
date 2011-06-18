namespace Server.Service
{
    public interface IRequestHandler<in TRequest>
    {
        Response Process(TRequest request);
    }
}