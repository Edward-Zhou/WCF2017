﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFAPI.WCFDuplexNetTcpService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCFDuplexNetTcpService.IWCFDuplexNetTcp", CallbackContract=typeof(WCFAPI.WCFDuplexNetTcpService.IWCFDuplexNetTcpCallback))]
    public interface IWCFDuplexNetTcp {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFDuplexNetTcp/WriteData")]
        void WriteData(int value);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFDuplexNetTcp/WriteData")]
        System.Threading.Tasks.Task WriteDataAsync(int value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCFDuplexNetTcpCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFDuplexNetTcp/IWillCallBack")]
        void IWillCallBack(string value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCFDuplexNetTcpChannel : WCFAPI.WCFDuplexNetTcpService.IWCFDuplexNetTcp, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WCFDuplexNetTcpClient : System.ServiceModel.DuplexClientBase<WCFAPI.WCFDuplexNetTcpService.IWCFDuplexNetTcp>, WCFAPI.WCFDuplexNetTcpService.IWCFDuplexNetTcp {
        
        public WCFDuplexNetTcpClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public WCFDuplexNetTcpClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public WCFDuplexNetTcpClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WCFDuplexNetTcpClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WCFDuplexNetTcpClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void WriteData(int value) {
            base.Channel.WriteData(value);
        }
        
        public System.Threading.Tasks.Task WriteDataAsync(int value) {
            return base.Channel.WriteDataAsync(value);
        }
    }
}
