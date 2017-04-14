﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFAPI.WCFDataTableService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WCFDataTable")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCFDataTableService.IWCFDataTable")]
    public interface IWCFDataTable {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFDataTable/GetData", ReplyAction="http://tempuri.org/IWCFDataTable/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFDataTable/GetData", ReplyAction="http://tempuri.org/IWCFDataTable/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFDataTable/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IWCFDataTable/GetDataUsingDataContractResponse")]
        WCFAPI.WCFDataTableService.CompositeType GetDataUsingDataContract(WCFAPI.WCFDataTableService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFDataTable/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IWCFDataTable/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WCFAPI.WCFDataTableService.CompositeType> GetDataUsingDataContractAsync(WCFAPI.WCFDataTableService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFDataTable/ReturnDataTable", ReplyAction="http://tempuri.org/IWCFDataTable/ReturnDataTableResponse")]
        System.Data.DataTable ReturnDataTable();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFDataTable/ReturnDataTable", ReplyAction="http://tempuri.org/IWCFDataTable/ReturnDataTableResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> ReturnDataTableAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCFDataTableChannel : WCFAPI.WCFDataTableService.IWCFDataTable, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WCFDataTableClient : System.ServiceModel.ClientBase<WCFAPI.WCFDataTableService.IWCFDataTable>, WCFAPI.WCFDataTableService.IWCFDataTable {
        
        public WCFDataTableClient() {
        }
        
        public WCFDataTableClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WCFDataTableClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFDataTableClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFDataTableClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public WCFAPI.WCFDataTableService.CompositeType GetDataUsingDataContract(WCFAPI.WCFDataTableService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WCFAPI.WCFDataTableService.CompositeType> GetDataUsingDataContractAsync(WCFAPI.WCFDataTableService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public System.Data.DataTable ReturnDataTable() {
            return base.Channel.ReturnDataTable();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ReturnDataTableAsync() {
            return base.Channel.ReturnDataTableAsync();
        }
    }
}