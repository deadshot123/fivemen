﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.4984
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=2.0.50727.1432.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="Service1HttpBinding", Namespace="http://sms.www.axcantech.cn")]
public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback addShortMessageUCOperationCompleted;
    
    private System.Threading.SendOrPostCallback unRegisterUCOperationCompleted;
    
    private System.Threading.SendOrPostCallback registerUCOperationCompleted;
    
    /// <remarks/>
    public Service1() {
        this.Url = "http://192.168.7.156:800/SmsGateway/services/Service1";
    }
    
    /// <remarks/>
    public event addShortMessageUCCompletedEventHandler addShortMessageUCCompleted;
    
    /// <remarks/>
    public event unRegisterUCCompletedEventHandler unRegisterUCCompleted;
    
    /// <remarks/>
    public event registerUCCompletedEventHandler registerUCCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://sms.www.axcantech.cn", ResponseNamespace="http://sms.www.axcantech.cn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("out", IsNullable=true)]
    public string addShortMessageUC([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string in0, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string in1) {
        object[] results = this.Invoke("addShortMessageUC", new object[] {
                    in0,
                    in1});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginaddShortMessageUC(string in0, string in1, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("addShortMessageUC", new object[] {
                    in0,
                    in1}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndaddShortMessageUC(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void addShortMessageUCAsync(string in0, string in1) {
        this.addShortMessageUCAsync(in0, in1, null);
    }
    
    /// <remarks/>
    public void addShortMessageUCAsync(string in0, string in1, object userState) {
        if ((this.addShortMessageUCOperationCompleted == null)) {
            this.addShortMessageUCOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddShortMessageUCOperationCompleted);
        }
        this.InvokeAsync("addShortMessageUC", new object[] {
                    in0,
                    in1}, this.addShortMessageUCOperationCompleted, userState);
    }
    
    private void OnaddShortMessageUCOperationCompleted(object arg) {
        if ((this.addShortMessageUCCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.addShortMessageUCCompleted(this, new addShortMessageUCCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://sms.www.axcantech.cn", ResponseNamespace="http://sms.www.axcantech.cn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("out", IsNullable=true)]
    public string unRegisterUC([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string in0, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string in1) {
        object[] results = this.Invoke("unRegisterUC", new object[] {
                    in0,
                    in1});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginunRegisterUC(string in0, string in1, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("unRegisterUC", new object[] {
                    in0,
                    in1}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndunRegisterUC(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void unRegisterUCAsync(string in0, string in1) {
        this.unRegisterUCAsync(in0, in1, null);
    }
    
    /// <remarks/>
    public void unRegisterUCAsync(string in0, string in1, object userState) {
        if ((this.unRegisterUCOperationCompleted == null)) {
            this.unRegisterUCOperationCompleted = new System.Threading.SendOrPostCallback(this.OnunRegisterUCOperationCompleted);
        }
        this.InvokeAsync("unRegisterUC", new object[] {
                    in0,
                    in1}, this.unRegisterUCOperationCompleted, userState);
    }
    
    private void OnunRegisterUCOperationCompleted(object arg) {
        if ((this.unRegisterUCCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.unRegisterUCCompleted(this, new unRegisterUCCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://sms.www.axcantech.cn", ResponseNamespace="http://sms.www.axcantech.cn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("out", IsNullable=true)]
    public string registerUC([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string in0, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string in1) {
        object[] results = this.Invoke("registerUC", new object[] {
                    in0,
                    in1});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginregisterUC(string in0, string in1, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("registerUC", new object[] {
                    in0,
                    in1}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndregisterUC(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void registerUCAsync(string in0, string in1) {
        this.registerUCAsync(in0, in1, null);
    }
    
    /// <remarks/>
    public void registerUCAsync(string in0, string in1, object userState) {
        if ((this.registerUCOperationCompleted == null)) {
            this.registerUCOperationCompleted = new System.Threading.SendOrPostCallback(this.OnregisterUCOperationCompleted);
        }
        this.InvokeAsync("registerUC", new object[] {
                    in0,
                    in1}, this.registerUCOperationCompleted, userState);
    }
    
    private void OnregisterUCOperationCompleted(object arg) {
        if ((this.registerUCCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.registerUCCompleted(this, new registerUCCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
public delegate void addShortMessageUCCompletedEventHandler(object sender, addShortMessageUCCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class addShortMessageUCCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal addShortMessageUCCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
public delegate void unRegisterUCCompletedEventHandler(object sender, unRegisterUCCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class unRegisterUCCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal unRegisterUCCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
public delegate void registerUCCompletedEventHandler(object sender, registerUCCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class registerUCCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal registerUCCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
