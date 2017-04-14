using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFAsync
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WCFAsync : IWCFAsync
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public async Task<string> GetAsync(int value)
        {
            try
            {
                DateTime start = DateTime.Now;
                var myTask = Task.Factory.StartNew(() => {
                    System.Threading.Thread.Sleep(5000);
                   return value.ToString();
                } );

                var result =await myTask;
                DateTime end = DateTime.Now;
                //if (end.Subtract(start).Seconds > 3)
                //{
                //    throw new FaultException("Time Out");
                //}
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.ToString());
            }
        }
        public string GetSync(int value)
        {
            System.Threading.Thread.Sleep(5000);
            return value.ToString();
        }
    }
}
