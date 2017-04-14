    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Wrapped,
                UriTemplate = "PostJsonBody/")]
        string PostJsonBody();
        [OperationContract]
        [WebGet]
        string GetUserName(int id);
        [OperationContract]
        [WebGet]
        string GetValue(int value);
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetData(int value,out string returnValue);
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json, UriTemplate = "CPSendInfo")]
        int COSendTubeInfo(int LstData, out string ErrMsg);
        [OperationContract]
        [WebInvoke(Method = "POST",
                    UriTemplate = "/LoginRest",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare)]
        LoginInfo LoginRest(LoginInfo login);
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        [OperationContract]
        [WebGet(UriTemplate = "/DownloadFile/{pDate}/{pMD5}", ResponseFormat = WebMessageFormat.Json)]
        StreamResultModel DownloadFile(string pDate, string pMD5);
        [WebGet]
        Stream Download();
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/PostJson",RequestFormat =WebMessageFormat.Json)]
        string PostJson(Headers headers);
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        Headers GetJson();
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/PutJson", RequestFormat = WebMessageFormat.Json)]
        string PutJson(Headers headers);


        // TODO: Add your service operations here
    }
    [DataContract]
    public struct StreamResultModel
    {
        [DataMember(Order = 1)]
        public string code { get; set; }
        [DataMember(Order = 2)]
        public string message { get; set; }
        //[DataMember(Order = 3)]
        //public Stream data { get; set; }
        [DataMember(Order = 4)]
        public byte[] byteData { get; set; }
    }

    [DataContract]
    public class LoginInfo
    {
        [DataMember]
        public Headers headers { get; set; }
    }

    [DataContract]
    public class Headers
    {
        [DataMember]
        public string loginname { get; set; }

        [DataMember]
        public string password { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
