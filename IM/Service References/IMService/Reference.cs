﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace IM.IMService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="IMService.IIMSLogStateChange")]
    public interface IIMSLogStateChange {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIMSLogStateChange/changeLogState", ReplyAction="http://tempuri.org/IIMSLogStateChange/changeLogStateResponse")]
        string changeLogState(string userName, string Pwd, bool logState);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIMSLogStateChange/getFrdList", ReplyAction="http://tempuri.org/IIMSLogStateChange/getFrdListResponse")]
        string getFrdList(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIMSLogStateChange/registUser", ReplyAction="http://tempuri.org/IIMSLogStateChange/registUserResponse")]
        string registUser(string userName, string pwd, string sex, string age);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIMSLogStateChange/getOnlineList", ReplyAction="http://tempuri.org/IIMSLogStateChange/getOnlineListResponse")]
        string getOnlineList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIMSLogStateChange/addFrd", ReplyAction="http://tempuri.org/IIMSLogStateChange/addFrdResponse")]
        string addFrd(string userName, string destName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IIMSLogStateChangeChannel : IM.IMService.IIMSLogStateChange, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IMSLogStateChangeClient : System.ServiceModel.ClientBase<IM.IMService.IIMSLogStateChange>, IM.IMService.IIMSLogStateChange {
        
        public IMSLogStateChangeClient() {
        }
        
        public IMSLogStateChangeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IMSLogStateChangeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IMSLogStateChangeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IMSLogStateChangeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string changeLogState(string userName, string Pwd, bool logState) {
            return base.Channel.changeLogState(userName, Pwd, logState);
        }
        
        public string getFrdList(string userName) {
            return base.Channel.getFrdList(userName);
        }
        
        public string registUser(string userName, string pwd, string sex, string age) {
            return base.Channel.registUser(userName, pwd, sex, age);
        }
        
        public string getOnlineList() {
            return base.Channel.getOnlineList();
        }
        
        public string addFrd(string userName, string destName) {
            return base.Channel.addFrd(userName, destName);
        }
    }
}
