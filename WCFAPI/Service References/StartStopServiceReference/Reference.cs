﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFAPI.StartStopServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StartStopServiceReference.IStartStopService")]
    public interface IStartStopService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStartStopService/StartService", ReplyAction="http://tempuri.org/IStartStopService/StartServiceResponse")]
        string StartService();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStartStopService/StartService", ReplyAction="http://tempuri.org/IStartStopService/StartServiceResponse")]
        System.Threading.Tasks.Task<string> StartServiceAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStartStopService/StopService", ReplyAction="http://tempuri.org/IStartStopService/StopServiceResponse")]
        string StopService();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStartStopService/StopService", ReplyAction="http://tempuri.org/IStartStopService/StopServiceResponse")]
        System.Threading.Tasks.Task<string> StopServiceAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStartStopServiceChannel : WCFAPI.StartStopServiceReference.IStartStopService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StartStopServiceClient : System.ServiceModel.ClientBase<WCFAPI.StartStopServiceReference.IStartStopService>, WCFAPI.StartStopServiceReference.IStartStopService {
        
        public StartStopServiceClient() {
        }
        
        public StartStopServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StartStopServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StartStopServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StartStopServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string StartService() {
            return base.Channel.StartService();
        }
        
        public System.Threading.Tasks.Task<string> StartServiceAsync() {
            return base.Channel.StartServiceAsync();
        }
        
        public string StopService() {
            return base.Channel.StopService();
        }
        
        public System.Threading.Tasks.Task<string> StopServiceAsync() {
            return base.Channel.StopServiceAsync();
        }
    }
}
