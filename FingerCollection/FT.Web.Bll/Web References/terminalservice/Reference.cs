﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.4984
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 2.0.50727.4984 版自动生成。
// 
#pragma warning disable 1591

namespace FT.Web.Bll.terminalservice {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="TerminalStatusServiceSoap", Namespace="http://tempuri.org/")]
    public partial class TerminalStatusService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback CloseComputerOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetMachineMacOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetMachineCodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetHotPrinterStatusOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetInvoicePrinterStatusOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public TerminalStatusService() {
            this.Url = global::FT.Web.Bll.Properties.Settings.Default.FT_Web_Bll_terminalservice_TerminalStatusService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event CloseComputerCompletedEventHandler CloseComputerCompleted;
        
        /// <remarks/>
        public event GetMachineMacCompletedEventHandler GetMachineMacCompleted;
        
        /// <remarks/>
        public event GetMachineCodeCompletedEventHandler GetMachineCodeCompleted;
        
        /// <remarks/>
        public event GetHotPrinterStatusCompletedEventHandler GetHotPrinterStatusCompleted;
        
        /// <remarks/>
        public event GetInvoicePrinterStatusCompletedEventHandler GetInvoicePrinterStatusCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CloseComputer", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void CloseComputer() {
            this.Invoke("CloseComputer", new object[0]);
        }
        
        /// <remarks/>
        public void CloseComputerAsync() {
            this.CloseComputerAsync(null);
        }
        
        /// <remarks/>
        public void CloseComputerAsync(object userState) {
            if ((this.CloseComputerOperationCompleted == null)) {
                this.CloseComputerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCloseComputerOperationCompleted);
            }
            this.InvokeAsync("CloseComputer", new object[0], this.CloseComputerOperationCompleted, userState);
        }
        
        private void OnCloseComputerOperationCompleted(object arg) {
            if ((this.CloseComputerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CloseComputerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetMachineMac", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetMachineMac() {
            object[] results = this.Invoke("GetMachineMac", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetMachineMacAsync() {
            this.GetMachineMacAsync(null);
        }
        
        /// <remarks/>
        public void GetMachineMacAsync(object userState) {
            if ((this.GetMachineMacOperationCompleted == null)) {
                this.GetMachineMacOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMachineMacOperationCompleted);
            }
            this.InvokeAsync("GetMachineMac", new object[0], this.GetMachineMacOperationCompleted, userState);
        }
        
        private void OnGetMachineMacOperationCompleted(object arg) {
            if ((this.GetMachineMacCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMachineMacCompleted(this, new GetMachineMacCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetMachineCode", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetMachineCode() {
            object[] results = this.Invoke("GetMachineCode", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetMachineCodeAsync() {
            this.GetMachineCodeAsync(null);
        }
        
        /// <remarks/>
        public void GetMachineCodeAsync(object userState) {
            if ((this.GetMachineCodeOperationCompleted == null)) {
                this.GetMachineCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMachineCodeOperationCompleted);
            }
            this.InvokeAsync("GetMachineCode", new object[0], this.GetMachineCodeOperationCompleted, userState);
        }
        
        private void OnGetMachineCodeOperationCompleted(object arg) {
            if ((this.GetMachineCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMachineCodeCompleted(this, new GetMachineCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetHotPrinterStatus", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetHotPrinterStatus() {
            object[] results = this.Invoke("GetHotPrinterStatus", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetHotPrinterStatusAsync() {
            this.GetHotPrinterStatusAsync(null);
        }
        
        /// <remarks/>
        public void GetHotPrinterStatusAsync(object userState) {
            if ((this.GetHotPrinterStatusOperationCompleted == null)) {
                this.GetHotPrinterStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetHotPrinterStatusOperationCompleted);
            }
            this.InvokeAsync("GetHotPrinterStatus", new object[0], this.GetHotPrinterStatusOperationCompleted, userState);
        }
        
        private void OnGetHotPrinterStatusOperationCompleted(object arg) {
            if ((this.GetHotPrinterStatusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetHotPrinterStatusCompleted(this, new GetHotPrinterStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetInvoicePrinterStatus", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetInvoicePrinterStatus() {
            object[] results = this.Invoke("GetInvoicePrinterStatus", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetInvoicePrinterStatusAsync() {
            this.GetInvoicePrinterStatusAsync(null);
        }
        
        /// <remarks/>
        public void GetInvoicePrinterStatusAsync(object userState) {
            if ((this.GetInvoicePrinterStatusOperationCompleted == null)) {
                this.GetInvoicePrinterStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetInvoicePrinterStatusOperationCompleted);
            }
            this.InvokeAsync("GetInvoicePrinterStatus", new object[0], this.GetInvoicePrinterStatusOperationCompleted, userState);
        }
        
        private void OnGetInvoicePrinterStatusOperationCompleted(object arg) {
            if ((this.GetInvoicePrinterStatusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetInvoicePrinterStatusCompleted(this, new GetInvoicePrinterStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void CloseComputerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void GetMachineMacCompletedEventHandler(object sender, GetMachineMacCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMachineMacCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetMachineMacCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void GetMachineCodeCompletedEventHandler(object sender, GetMachineCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMachineCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetMachineCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void GetHotPrinterStatusCompletedEventHandler(object sender, GetHotPrinterStatusCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetHotPrinterStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetHotPrinterStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void GetInvoicePrinterStatusCompletedEventHandler(object sender, GetInvoicePrinterStatusCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetInvoicePrinterStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetInvoicePrinterStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591