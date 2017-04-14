using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WCFBaseClass;

namespace WCFBaseClass
{
    [DataContract]
    //[KnownType(typeof(Success<Pet>))]
    public abstract class Fallible<T>
    {
    }

    [DataContract]
    public class Success<T> : Fallible<T>
    {
        [DataMember]
        public T Value { get; set; }
    }

    [DataContract]
    public class Failure<T> : Fallible<T>
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Stack { get; set; }
    }

    [DataContract]
    public class BadIdea<T> : Fallible<T>
    {
        [DataMember]
        public string Because { get; set; }
    }

    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}