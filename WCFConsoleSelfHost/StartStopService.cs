using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace WCFConsoleSelfHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StartStopService" in both code and config file together.
    public class StartStopService : IStartStopService
    {
        public string StartService()
        {
            try
            {
                Program.host.Open();
                Console.WriteLine("web service is open");
                return "web service is open";
            }
            catch (Exception ex)
            {
                //if you close the host, you need to initialize the host
                Program.host = new ServiceHost(typeof(WCFTest));
                Program.host.Open();
                return "web service is open";
            }
        }

        public string StopService()
        {
            Program.host.Close();
            return "web service is stop";
        }
    }
}
