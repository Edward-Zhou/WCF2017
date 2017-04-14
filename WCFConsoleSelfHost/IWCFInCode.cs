using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFConsoleSelfHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIWCFInCode" in both code and config file together.
    [ServiceContract]
    public interface IWCFInCode
    {
        [WebGet]
        [OperationContract]
        string GetData();
    }
}
