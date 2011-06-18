using System;
using Client.MyServer;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MyServerClient client = null;

            try
            {
                client = new MyServerClient();

                var response = client.Process(new QueryServerVersionRequest());

                if (response is QueryServerVersionResponse)
                {
                    Console.WriteLine(((QueryServerVersionResponse)response).Version);
                }
                else if (response is FaultReponse)
                {
                    Console.WriteLine(((FaultReponse)response).ErrorMessage);
                }
                else
                {
                    Console.WriteLine("Unexpected response type: {0}", response.GetType());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (client != null)
                {
                    try
                    {
                        client.Close();
                    }
                    catch { }
                }
            }
        }
    }
}