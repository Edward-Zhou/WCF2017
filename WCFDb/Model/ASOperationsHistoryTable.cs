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
    
    public partial class ASOperationsHistoryTable
    {
        public long Id { get; set; }
        public string UserLogin { get; set; }
        public int OperationId { get; set; }
        public string Parameters { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public string Log { get; set; }
        public System.DateTime StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
    }
}
