using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFHttpListenerApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHttpListenerService" in both code and config file together.
    [ServiceContract]
    public interface IHttpListenerService
    {
        [OperationContract]
        void DoWork();
    }
}
