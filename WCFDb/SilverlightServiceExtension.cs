using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;

namespace WCFDb
{
    //[ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SilverlightServiceExtension:ISilverlightServiceExtension
    {
        public string GetValue()
        {
            return "Hello Value"; ;
        }
    }
}