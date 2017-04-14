using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace WCFSample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,        InstanceContextMode = InstanceContextMode.PerSession)]
    public class SampleService : ISample
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public List<int> GetEvenNumbers()
        {

            System.Diagnostics.Debug.WriteLine("Thread {0} started processing GetEvenNumbers at {1}",
                Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            List<int> listEvenNumbers = new List<int>();
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(200);
                if (i % 2 == 0)
                {
                    listEvenNumbers.Add(i);
                }
            }
            System.Diagnostics.Debug.WriteLine("Thread {0} completed processing GetEvenNumbers at {1}",
                Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            return listEvenNumbers;
        }

        public List<int> GetOddNumbers()
        {
            System.Diagnostics.Debug.WriteLine("Thread {0} started processing GetOddNumbers at {1}",
                Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            List<int> listOddNumbers = new List<int>();
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(200);
                if (i % 2 != 0)
                {
                    listOddNumbers.Add(i);
                }
            }
            System.Diagnostics.Debug.WriteLine("Thread {0} completed processing GetOddNumbers at {1}",

               Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());

            return listOddNumbers;

        }
    }
}
