using System;
using System.Reflection;
using System.ServiceModel;
using log4net;
using Server.Service;

namespace Server
{
    class Program
    {
        static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main()
        {
            ServiceHost host = null;

            Log.Debug("DEBUG");
            Log.Info("INFO");
            Log.Warn("WARN");
            Log.Error("ERROR");
            Log.Info("----------------------------------------------------------------");

            try
            {
                Log.Info("Creating host...");
                host = new ServiceHost(typeof(MyServer));

                Log.Info("Opening listener...");
                host.Open();

                Log.Info("Listening...");
                Console.ReadKey();
                Log.Info("Shutting down...");
            }
            catch(Exception e)
            {
                Log.Error(e);
            }
            finally
            {
                if (host != null)
                {
                    try
                    {
                        host.Close();

                        Log.Info("Host closed...");
                    }
                    catch(Exception e)
                    {
                        Log.Error(e);
                    }
                }
            }

            Log.Info("The end.");
        }
    }
}
