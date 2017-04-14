using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFDuplexNetTcp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract =typeof(WCFDuplexNetTcpCallBack))]
    public interface IWCFDuplexNetTcp
    {

        [OperationContract(IsOneWay =true)]
        void WriteData(int value);
    }
    public interface WCFDuplexNetTcpCallBack
    {
        [OperationContract(IsOneWay = true)]
        void IWillCallBack(string value);
    }

}
