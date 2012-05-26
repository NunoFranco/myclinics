#region License

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

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Shreds.MwlServer.Configuration
{
	/// <summary>
	/// Helper class for designers who want to persist complex objects as settings
	/// using the JsmlSerializer class.
	/// 
	/// XmlEncodedSettingsHelper works in collaboration with the IXmlDocumentExchanger
	/// and IDefaultSettingsProvider interfaces. The TSection class must implement 
	/// IXmlDocumentExchanger, and the TDataContract must implement IDefaultSettingsProvder.
	/// The JsmlSerializer class is of course, also used.
	/// 
	/// TDataContract should be designed and decorated as a [DataContract], with the
	/// properties that you want persisted decorated with [DataMember]. TDataContract
	/// is essentially the class that encapsulates the settings you want to persist.
	/// This class must implement IDefaultSettingsProvider in order to provide a set
	/// of defaults in case no settings have ever been persisted.
	/// 
	/// TSection is the class automatically created with the Designer in studio when you
	/// create a Settings configuration. The recommended way of using this, is to create
	/// a setting whose type is System.Xml.XmlDocument. This settings member will hold
	/// the XML document that describes the TDataContract class. TSection must implement
	/// IXmlDocumentExchanger so that XmlEncodedSettingsHelper will be able to retrieve
	/// and store the XML document that contains the serialized settings.
	/// </summary>
	/// <example>
	/// public settingsHelper = new XmlEncodedSettingsHelper&lt;HL7ReceiverSettingsSection, HL7ReceiverSettings&gt;();
	/// HL7ReceiverSettings mySettings = XmlEncodedSettingsHelper.Get();
	/// mySettings.SettingA = 445;
	/// XmlEncodedSettingsHelper.Store(mySettings);
	/// </example>
	/// <see cref="JsmlSerializer"/>
	/// <see cref="IXmlDocumentExchanger"/>
	/// <see cref="IDefaultSettingsProvider"/>
	/// <typeparam name="TSection">Studio-generated settings class that has an XmlDocument member embeeded in it for the serialized settings</typeparam>
	/// <typeparam name="TDataContract">[DataContract]-decorated class that encapsulates the settings to be persisted</typeparam>
	sealed public class XmlEncodedSettingsHelper<TSection, TDataContract>
		where TSection : IXmlDocumentExchanger, new()
		where TDataContract : IDefaultSettingsSource<TDataContract>, new()
	{
		private TDataContract _settingsObject;

		public XmlEncodedSettingsHelper()
		{
			TSection sectionObject = new TSection();
			XmlDocument settingsDocument = sectionObject.GetDocument();

			if (null != settingsDocument)
			{
				_settingsObject = JsmlSerializer.Deserialize<TDataContract>(settingsDocument.InnerXml);
			}
			else
			{
				// either there's nothing in the file or it doesn't exist perhaps
				_settingsObject = new TDataContract();
				_settingsObject = _settingsObject.GetDefaultSettings();
			}
		}

		public TDataContract Get()
		{
			return _settingsObject;
		}

		public void Store(TDataContract settingsObject)
		{
			TSection sectionObject = new TSection();
			XmlDocument objectAsXml = new XmlDocument();
			objectAsXml.LoadXml(JsmlSerializer.Serialize(settingsObject, typeof(TDataContract).Name, false));
			sectionObject.StoreDocument(objectAsXml);
		}
	}
}
