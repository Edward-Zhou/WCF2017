﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFAPI.WCFSecurityModeNoneReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WCFSecurityModeNone")]
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCFSecurityModeNoneReference.IWCFSecurityModeNone")]
    public interface IWCFSecurityModeNone {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSecurityModeNone/GetData", ReplyAction="http://tempuri.org/IWCFSecurityModeNone/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSecurityModeNone/GetData", ReplyAction="http://tempuri.org/IWCFSecurityModeNone/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSecurityModeNone/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IWCFSecurityModeNone/GetDataUsingDataContractResponse")]
        WCFAPI.WCFSecurityModeNoneReference.CompositeType GetDataUsingDataContract(WCFAPI.WCFSecurityModeNoneReference.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSecurityModeNone/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IWCFSecurityModeNone/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WCFAPI.WCFSecurityModeNoneReference.CompositeType> GetDataUsingDataContractAsync(WCFAPI.WCFSecurityModeNoneReference.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCFSecurityModeNoneChannel : WCFAPI.WCFSecurityModeNoneReference.IWCFSecurityModeNone, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WCFSecurityModeNoneClient : System.ServiceModel.ClientBase<WCFAPI.WCFSecurityModeNoneReference.IWCFSecurityModeNone>, WCFAPI.WCFSecurityModeNoneReference.IWCFSecurityModeNone {
        
        public WCFSecurityModeNoneClient() {
        }
        
        public WCFSecurityModeNoneClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WCFSecurityModeNoneClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFSecurityModeNoneClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFSecurityModeNoneClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public WCFAPI.WCFSecurityModeNoneReference.CompositeType GetDataUsingDataContract(WCFAPI.WCFSecurityModeNoneReference.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WCFAPI.WCFSecurityModeNoneReference.CompositeType> GetDataUsingDataContractAsync(WCFAPI.WCFSecurityModeNoneReference.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}