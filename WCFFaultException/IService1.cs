using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFFaultException
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [FaultContract(typeof(MyCustomException))]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class CustomFault: CommunicationException
    {
        [DataMember]
        public string ErrorMsg { get; set; }
        
    }
    [Serializable]
    public class MyCustomException : Exception
    {
        public MyCustomException()
        {
        }
        public MyCustomException(string message) : base(message)
        {
        }
        public MyCustomException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected MyCustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
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
