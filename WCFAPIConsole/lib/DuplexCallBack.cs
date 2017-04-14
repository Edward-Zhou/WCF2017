using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFAPIConsole.lib
{
    class DuplexCallBack : WCFDuplexNetTcpService.IWCFDuplexNetTcpCallback
    {

        public void IWillCallBack(string value)
        {
            string cki;
            do
            {
                cki = Console.ReadLine();
                Console.WriteLine("test");
                Console.WriteLine(cki);
            } while (1==1);

            
            //Console.ReadKey();
        }
    }
}
