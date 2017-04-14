﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFAsync
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWCFAsync
    {

        [OperationContract]
        string GetData(int value);
        [OperationContract]
        Task<string> GetAsync(int value);
        [OperationContract]
        string GetSync(int value);



        // TODO: Add your service operations here
    }


}
