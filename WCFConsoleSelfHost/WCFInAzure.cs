using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFConsoleSelfHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFInAzure" in both code and config file together.
    public class WCFInAzure : IWCFInAzure
    {
        public string GetString()
        {
            return "Hello World";
        }
    }
}
