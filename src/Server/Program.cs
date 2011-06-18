using System;
using System.ServiceModel;
using Server.Service;

namespace Server
{
    class Program
    {
        static void Main()
        {
            ServiceHost host = null;

            try
            {
                host = new ServiceHost(typeof(MyServer));
                host.Open();

                Console.WriteLine("Listening...");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (host != null)
                {
                    try
                    {
                        host.Close();
                    }
                    catch{}
                }
            }
        }
    }
}
