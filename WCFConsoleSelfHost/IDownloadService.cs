using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFConsoleSelfHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIDownloadService" in both code and config file together.
    [ServiceContract]
    public interface IDownloadService
    {
        [OperationContract]
        string GetData();

        [OperationContract]
        File DownloadDocument();
    }
    [DataContract]
    public class File
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public byte[] Content { get; set; }
    }

}
