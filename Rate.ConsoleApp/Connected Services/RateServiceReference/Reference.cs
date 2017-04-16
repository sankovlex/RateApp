﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rate.ConsoleApp.RateServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Currency", Namespace="http://schemas.datacontract.org/2004/07/Rate.Models.Domain")]
    [System.SerializableAttribute()]
    public partial class Currency : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateCreateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PurchasePriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal SellingPriceField;
        
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
        public System.DateTime DateCreate {
            get {
                return this.DateCreateField;
            }
            set {
                if ((this.DateCreateField.Equals(value) != true)) {
                    this.DateCreateField = value;
                    this.RaisePropertyChanged("DateCreate");
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal PurchasePrice {
            get {
                return this.PurchasePriceField;
            }
            set {
                if ((this.PurchasePriceField.Equals(value) != true)) {
                    this.PurchasePriceField = value;
                    this.RaisePropertyChanged("PurchasePrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal SellingPrice {
            get {
                return this.SellingPriceField;
            }
            set {
                if ((this.SellingPriceField.Equals(value) != true)) {
                    this.SellingPriceField = value;
                    this.RaisePropertyChanged("SellingPrice");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Paging", Namespace="http://schemas.datacontract.org/2004/07/Rate.Models.OptionalParams")]
    [System.SerializableAttribute()]
    public partial class Paging : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SkipField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TakeField;
        
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
        public int Skip {
            get {
                return this.SkipField;
            }
            set {
                if ((this.SkipField.Equals(value) != true)) {
                    this.SkipField = value;
                    this.RaisePropertyChanged("Skip");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Take {
            get {
                return this.TakeField;
            }
            set {
                if ((this.TakeField.Equals(value) != true)) {
                    this.TakeField = value;
                    this.RaisePropertyChanged("Take");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CurrencyFilter", Namespace="http://schemas.datacontract.org/2004/07/Rate.Models.OptionalParams")]
    [System.SerializableAttribute()]
    public partial class CurrencyFilter : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> EndDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrderByField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> StartDateField;
        
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
        public System.Nullable<System.DateTime> EndDate {
            get {
                return this.EndDateField;
            }
            set {
                if ((this.EndDateField.Equals(value) != true)) {
                    this.EndDateField = value;
                    this.RaisePropertyChanged("EndDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrderBy {
            get {
                return this.OrderByField;
            }
            set {
                if ((object.ReferenceEquals(this.OrderByField, value) != true)) {
                    this.OrderByField = value;
                    this.RaisePropertyChanged("OrderBy");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> StartDate {
            get {
                return this.StartDateField;
            }
            set {
                if ((this.StartDateField.Equals(value) != true)) {
                    this.StartDateField = value;
                    this.RaisePropertyChanged("StartDate");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RateServiceReference.IRateService")]
    public interface IRateService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRateService/AddCurrency", ReplyAction="http://tempuri.org/IRateService/AddCurrencyResponse")]
        void AddCurrency(Rate.ConsoleApp.RateServiceReference.Currency currency);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRateService/AddCurrency", ReplyAction="http://tempuri.org/IRateService/AddCurrencyResponse")]
        System.Threading.Tasks.Task AddCurrencyAsync(Rate.ConsoleApp.RateServiceReference.Currency currency);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRateService/GetCurrencies", ReplyAction="http://tempuri.org/IRateService/GetCurrenciesResponse")]
        Rate.ConsoleApp.RateServiceReference.Currency[] GetCurrencies(Rate.ConsoleApp.RateServiceReference.Paging paging, Rate.ConsoleApp.RateServiceReference.CurrencyFilter filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRateService/GetCurrencies", ReplyAction="http://tempuri.org/IRateService/GetCurrenciesResponse")]
        System.Threading.Tasks.Task<Rate.ConsoleApp.RateServiceReference.Currency[]> GetCurrenciesAsync(Rate.ConsoleApp.RateServiceReference.Paging paging, Rate.ConsoleApp.RateServiceReference.CurrencyFilter filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRateService/GetLastCurrency", ReplyAction="http://tempuri.org/IRateService/GetLastCurrencyResponse")]
        Rate.ConsoleApp.RateServiceReference.Currency GetLastCurrency(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRateService/GetLastCurrency", ReplyAction="http://tempuri.org/IRateService/GetLastCurrencyResponse")]
        System.Threading.Tasks.Task<Rate.ConsoleApp.RateServiceReference.Currency> GetLastCurrencyAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRateServiceChannel : Rate.ConsoleApp.RateServiceReference.IRateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RateServiceClient : System.ServiceModel.ClientBase<Rate.ConsoleApp.RateServiceReference.IRateService>, Rate.ConsoleApp.RateServiceReference.IRateService {
        
        public RateServiceClient() {
        }
        
        public RateServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RateServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RateServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RateServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddCurrency(Rate.ConsoleApp.RateServiceReference.Currency currency) {
            base.Channel.AddCurrency(currency);
        }
        
        public System.Threading.Tasks.Task AddCurrencyAsync(Rate.ConsoleApp.RateServiceReference.Currency currency) {
            return base.Channel.AddCurrencyAsync(currency);
        }
        
        public Rate.ConsoleApp.RateServiceReference.Currency[] GetCurrencies(Rate.ConsoleApp.RateServiceReference.Paging paging, Rate.ConsoleApp.RateServiceReference.CurrencyFilter filter) {
            return base.Channel.GetCurrencies(paging, filter);
        }
        
        public System.Threading.Tasks.Task<Rate.ConsoleApp.RateServiceReference.Currency[]> GetCurrenciesAsync(Rate.ConsoleApp.RateServiceReference.Paging paging, Rate.ConsoleApp.RateServiceReference.CurrencyFilter filter) {
            return base.Channel.GetCurrenciesAsync(paging, filter);
        }
        
        public Rate.ConsoleApp.RateServiceReference.Currency GetLastCurrency(string name) {
            return base.Channel.GetLastCurrency(name);
        }
        
        public System.Threading.Tasks.Task<Rate.ConsoleApp.RateServiceReference.Currency> GetLastCurrencyAsync(string name) {
            return base.Channel.GetLastCurrencyAsync(name);
        }
    }
}
