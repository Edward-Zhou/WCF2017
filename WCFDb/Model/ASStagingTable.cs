//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFDb.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ASStagingTable
    {
        public long Id { get; set; }
        public long ArchiveId { get; set; }
        public int EventTypeId { get; set; }
        public string E2EActivityId { get; set; }
        public string Computer { get; set; }
        public string EventSource { get; set; }
        public int ProcessId { get; set; }
        public byte TraceLevelId { get; set; }
        public System.DateTime TimeCreated { get; set; }
        public string Data1Str { get; set; }
        public string Data2Str { get; set; }
        public string Data3Str { get; set; }
        public string Data4Str { get; set; }
        public string Data5Str { get; set; }
        public string Data6Str { get; set; }
        public string Data7Str { get; set; }
        public string Data8Str { get; set; }
        public string Data9Str { get; set; }
        public string Data1MaxStr { get; set; }
        public Nullable<int> Data1Int { get; set; }
        public Nullable<int> Data2Int { get; set; }
        public Nullable<int> Data3Int { get; set; }
        public Nullable<long> Data1BigInt { get; set; }
        public string Data1UniqueId { get; set; }
        public string CustomAnnotations { get; set; }
        public string CustomProperties { get; set; }
        public string CustomArguments { get; set; }
    }
}
