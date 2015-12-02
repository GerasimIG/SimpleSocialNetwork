﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleSocialNetwork.WebUI.MessageServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MessageDto", Namespace="http://schemas.datacontract.org/2004/07/SimpleSocialNetwork.BusinessServices")]
    [System.SerializableAttribute()]
    public partial class MessageDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateSentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FromUserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MsgTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ToUserIdField;
        
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
        public System.DateTime DateSent {
            get {
                return this.DateSentField;
            }
            set {
                if ((this.DateSentField.Equals(value) != true)) {
                    this.DateSentField = value;
                    this.RaisePropertyChanged("DateSent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FromUserId {
            get {
                return this.FromUserIdField;
            }
            set {
                if ((this.FromUserIdField.Equals(value) != true)) {
                    this.FromUserIdField = value;
                    this.RaisePropertyChanged("FromUserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MsgText {
            get {
                return this.MsgTextField;
            }
            set {
                if ((object.ReferenceEquals(this.MsgTextField, value) != true)) {
                    this.MsgTextField = value;
                    this.RaisePropertyChanged("MsgText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ToUserId {
            get {
                return this.ToUserIdField;
            }
            set {
                if ((this.ToUserIdField.Equals(value) != true)) {
                    this.ToUserIdField = value;
                    this.RaisePropertyChanged("ToUserId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MessageServiceReference.IMessageService")]
    public interface IMessageService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBaseServiceOf_Message_MessageDto/Add", ReplyAction="http://tempuri.org/IBaseServiceOf_Message_MessageDto/AddResponse")]
        void Add(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBaseServiceOf_Message_MessageDto/Add", ReplyAction="http://tempuri.org/IBaseServiceOf_Message_MessageDto/AddResponse")]
        System.Threading.Tasks.Task AddAsync(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBaseServiceOf_Message_MessageDto/Remove", ReplyAction="http://tempuri.org/IBaseServiceOf_Message_MessageDto/RemoveResponse")]
        void Remove(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBaseServiceOf_Message_MessageDto/Remove", ReplyAction="http://tempuri.org/IBaseServiceOf_Message_MessageDto/RemoveResponse")]
        System.Threading.Tasks.Task RemoveAsync(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBaseServiceOf_Message_MessageDto/Update", ReplyAction="http://tempuri.org/IBaseServiceOf_Message_MessageDto/UpdateResponse")]
        void Update(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBaseServiceOf_Message_MessageDto/Update", ReplyAction="http://tempuri.org/IBaseServiceOf_Message_MessageDto/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBaseServiceOf_Message_MessageDto/GetById", ReplyAction="http://tempuri.org/IBaseServiceOf_Message_MessageDto/GetByIdResponse")]
        SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto GetById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBaseServiceOf_Message_MessageDto/GetById", ReplyAction="http://tempuri.org/IBaseServiceOf_Message_MessageDto/GetByIdResponse")]
        System.Threading.Tasks.Task<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto> GetByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBaseServiceOf_Message_MessageDto/GetAll", ReplyAction="http://tempuri.org/IBaseServiceOf_Message_MessageDto/GetAllResponse")]
        System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBaseServiceOf_Message_MessageDto/GetAll", ReplyAction="http://tempuri.org/IBaseServiceOf_Message_MessageDto/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto>> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageService/GetChatHistory", ReplyAction="http://tempuri.org/IMessageService/GetChatHistoryResponse")]
        System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto> GetChatHistory(int fromUserId, int toUserId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageService/GetChatHistory", ReplyAction="http://tempuri.org/IMessageService/GetChatHistoryResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto>> GetChatHistoryAsync(int fromUserId, int toUserId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageService/GetConversations", ReplyAction="http://tempuri.org/IMessageService/GetConversationsResponse")]
        System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto> GetConversations(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageService/GetConversations", ReplyAction="http://tempuri.org/IMessageService/GetConversationsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto>> GetConversationsAsync(int userId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMessageServiceChannel : SimpleSocialNetwork.WebUI.MessageServiceReference.IMessageService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MessageServiceClient : System.ServiceModel.ClientBase<SimpleSocialNetwork.WebUI.MessageServiceReference.IMessageService>, SimpleSocialNetwork.WebUI.MessageServiceReference.IMessageService {
        
        public MessageServiceClient() {
        }
        
        public MessageServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MessageServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessageServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessageServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Add(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity) {
            base.Channel.Add(entity);
        }
        
        public System.Threading.Tasks.Task AddAsync(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity) {
            return base.Channel.AddAsync(entity);
        }
        
        public void Remove(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity) {
            base.Channel.Remove(entity);
        }
        
        public System.Threading.Tasks.Task RemoveAsync(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity) {
            return base.Channel.RemoveAsync(entity);
        }
        
        public void Update(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity) {
            base.Channel.Update(entity);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto entity) {
            return base.Channel.UpdateAsync(entity);
        }
        
        public SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto GetById(int id) {
            return base.Channel.GetById(id);
        }
        
        public System.Threading.Tasks.Task<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
        
        public System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto> GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto> GetChatHistory(int fromUserId, int toUserId, int quantity) {
            return base.Channel.GetChatHistory(fromUserId, toUserId, quantity);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto>> GetChatHistoryAsync(int fromUserId, int toUserId, int quantity) {
            return base.Channel.GetChatHistoryAsync(fromUserId, toUserId, quantity);
        }
        
        public System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto> GetConversations(int userId) {
            return base.Channel.GetConversations(userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SimpleSocialNetwork.WebUI.MessageServiceReference.MessageDto>> GetConversationsAsync(int userId) {
            return base.Channel.GetConversationsAsync(userId);
        }
    }
}