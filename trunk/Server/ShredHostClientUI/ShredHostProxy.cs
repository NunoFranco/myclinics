﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Server.ShredHost
{
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class WcfDataShred : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string _descriptionField;
        
        private int _idField;
        
        private bool _isRunningField;
        
        private string _nameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string _description
        {
            get
            {
                return this._descriptionField;
            }
            set
            {
                this._descriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int _id
        {
            get
            {
                return this._idField;
            }
            set
            {
                this._idField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool _isRunning
        {
            get
            {
                return this._isRunningField;
            }
            set
            {
                this._isRunningField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string _name
        {
            get
            {
                return this._nameField;
            }
            set
            {
                this._nameField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IShredHost")]
public interface IShredHost
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShredHost/GetShreds", ReplyAction="http://tempuri.org/IShredHost/GetShredsResponse")]
    ClearCanvas.Server.ShredHost.WcfDataShred[] GetShreds();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShredHost/StartShred", ReplyAction="http://tempuri.org/IShredHost/StartShredResponse")]
    bool StartShred(ClearCanvas.Server.ShredHost.WcfDataShred shred);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShredHost/StopShred", ReplyAction="http://tempuri.org/IShredHost/StopShredResponse")]
    bool StopShred(ClearCanvas.Server.ShredHost.WcfDataShred shred);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IShredHostChannel : IShredHost, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class ShredHostClient : System.ServiceModel.ClientBase<IShredHost>, IShredHost
{
    
    public ShredHostClient()
    {
    }
    
    public ShredHostClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ShredHostClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ShredHostClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ShredHostClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public ClearCanvas.Server.ShredHost.WcfDataShred[] GetShreds()
    {
        return base.Channel.GetShreds();
    }
    
    public bool StartShred(ClearCanvas.Server.ShredHost.WcfDataShred shred)
    {
        return base.Channel.StartShred(shred);
    }
    
    public bool StopShred(ClearCanvas.Server.ShredHost.WcfDataShred shred)
    {
        return base.Channel.StopShred(shred);
    }
}