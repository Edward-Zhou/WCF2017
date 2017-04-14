using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFAPIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            lib.DuplexCallBack cb = new lib.DuplexCallBack();
            InstanceContext context = new InstanceContext(cb);
            WCFDuplexNetTcpService.WCFDuplexNetTcpClient client = new WCFDuplexNetTcpService.WCFDuplexNetTcpClient(context);
            client.WriteData(123);
            Console.WriteLine("123");
            Console.ReadLine();
        }
    }
}
