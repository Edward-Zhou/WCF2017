using System.Runtime.Serialization;

namespace WCFLib
{
    [DataContract]
    public class Station
    {
        [DataMember]
        public int StationId { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Type { get; set; }
    }
}