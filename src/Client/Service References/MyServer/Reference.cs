﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.MyServer {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Request", Namespace="http://schemas.datacontract.org/2004/07/Server.Service")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.MyServer.QueryServerVersionRequest))]
    public partial class Request : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="QueryServerVersionRequest", Namespace="http://schemas.datacontract.org/2004/07/Server.Handlers.ServerVersion")]
    [System.SerializableAttribute()]
    public partial class QueryServerVersionRequest : Client.MyServer.Request {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Response", Namespace="http://schemas.datacontract.org/2004/07/Server.Service")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.MyServer.QueryServerVersionResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.MyServer.FaultReponse))]
    public partial class Response : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="QueryServerVersionResponse", Namespace="http://schemas.datacontract.org/2004/07/Server.Handlers.ServerVersion")]
    [System.SerializableAttribute()]
    public partial class QueryServerVersionResponse : Client.MyServer.Response {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VersionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Version {
            get {
                return this.VersionField;
            }
            set {
                if ((object.ReferenceEquals(this.VersionField, value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FaultReponse", Namespace="http://schemas.datacontract.org/2004/07/Server.Service")]
    [System.SerializableAttribute()]
    public partial class FaultReponse : Client.MyServer.Response {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://trifork.com/wcf/unit_test_sample", ConfigurationName="MyServer.IMyServer")]
    public interface IMyServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://trifork.com/wcf/unit_test_sample/IMyServer/Process", ReplyAction="http://trifork.com/wcf/unit_test_sample/IMyServer/ProcessResponse")]
        Client.MyServer.Response Process(Client.MyServer.Request request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyServerChannel : Client.MyServer.IMyServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyServerClient : System.ServiceModel.ClientBase<Client.MyServer.IMyServer>, Client.MyServer.IMyServer {
        
        public MyServerClient() {
        }
        
        public MyServerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyServerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyServerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyServerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.MyServer.Response Process(Client.MyServer.Request request) {
            return base.Channel.Process(request);
        }
    }
}