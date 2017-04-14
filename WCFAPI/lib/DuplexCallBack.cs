using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFAPI.lib
{
    class DuplexCallBack : WCFDuplexNetTcpService.IWCFDuplexNetTcpCallback
    {

        public void IWillCallBack(string value)
        {
            Console.WriteLine("Test");
            //Console.ReadKey();
        }
    }
}
