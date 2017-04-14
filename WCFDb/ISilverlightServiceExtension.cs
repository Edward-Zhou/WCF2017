using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;

namespace WCFDb
{
    [ServiceContract(Namespace = "")]
    public interface ISilverlightServiceExtension
    {
        [OperationContract]
        string GetValue();
    }
}