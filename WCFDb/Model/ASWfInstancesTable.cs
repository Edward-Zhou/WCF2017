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
    
    public partial class ASWfInstancesTable
    {
        public long Id { get; set; }
        public string WorkflowInstanceId { get; set; }
        public long LatestRecordNumber { get; set; }
        public int LastEventSourceId { get; set; }
        public string LastEventStatus { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime LastModifiedTime { get; set; }
        public int CurrentDuration { get; set; }
        public int ExceptionCount { get; set; }
        public Nullable<System.DateTime> LastAbortedTime { get; set; }
    }
}
