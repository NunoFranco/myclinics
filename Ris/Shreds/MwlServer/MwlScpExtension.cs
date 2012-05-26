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
using System.Threading;
using ClearCanvas.Common;
using ClearCanvas.Dicom.Network;
using ClearCanvas.Dicom.Network.Scp;
using ClearCanvas.Dicom;

namespace ClearCanvas.Ris.Shreds.MwlServer
{
	[ExtensionOf(typeof (DicomScpExtensionPoint<MwlServerContext>))]
	class MwlScpExtension : IDicomScp<MwlServerContext> /*, BaseScp */
    ///<summary>
    /// Plugin for handling DICOM Query Requests implementing the <see cref="IDicomScp{TContext}"/> interface.
    ///</summary>
    {
        private const int ALERT_DICOM_QUERY_NOTALLOWED = 100;
        private const string COMPONENT_NAME = "MWL SCP";

        #region Private members

        private readonly List<SupportedSop> _list = new List<SupportedSop>();

		private DicomPresContextResult OnVerifyAssociation(AssociationParameters association, byte pcid)
		{
			return DicomPresContextResult.Accept;
		}

        #endregion

        #region Contructors

        /// <summary>
        /// Public default constructor.  Implements the Find and Move services for 
        /// Patient Root and Study Root queries.
        /// </summary>
		public MwlScpExtension()
        {
			SupportedSop sop = new SupportedSop();
			sop.SopClass = SopClass.ModalityWorklistInformationModelFind;
			sop.SyntaxList.Add(TransferSyntax.ExplicitVrLittleEndian);
			sop.SyntaxList.Add(TransferSyntax.ImplicitVrLittleEndian);
			_list.Add(sop);
			
        }

        #endregion


		#region IDicomScp<MwlServerContext> Members

		public IList<SupportedSop> GetSupportedSopClasses()
		{
			return _list;
		}

		public bool OnReceiveRequest(DicomServer server, ServerAssociationParameters association, byte presentationID, ClearCanvas.Dicom.DicomMessage message)
		{
			Platform.Log(LogLevel.Debug, String.Format("Received MWL query request from {0} at ip {1}:{2}", association.CallingAE, association.RemoteEndPoint.Address, association.RemoteEndPoint.Port));

			DicomAttributeCollection data = message.DataSet;

			MwlServerExtensionPoint ep = new MwlServerExtensionPoint();

			IList<DicomMessage> resultsList = null;

			try
			{
				IQueryConnector connector = ep.CreateExtension() as IQueryConnector;
				resultsList = connector.Query(message, association.CallingAE);
			}
			catch (NotSupportedException e)
			{
				server.SendCFindResponse(presentationID, message.MessageId, new DicomMessage(),
										 DicomStatuses.QueryRetrieveOutOfResources);
				return true;
			}

			int i = 0;
			foreach (DicomMessage response in resultsList)
			{
				server.SendCFindResponse(presentationID, message.MessageId, response,
										 DicomStatuses.Pending);
				++i;
			}

			server.SendCFindResponse(presentationID, message.MessageId, new DicomMessage(),
						 DicomStatuses.Success);

			return true;
		}

		public void SetContext(MwlServerContext context)
		{
			// do nothing for now; we don't know what kind of context information we would need yet
			return;
		}

		public DicomPresContextResult VerifyAssociation(AssociationParameters association, byte pcid)
		{
			// Let the subclass perform the verification
			DicomPresContextResult result = OnVerifyAssociation(association, pcid);
			if (result != DicomPresContextResult.Accept)
			{
				Platform.Log(LogLevel.Debug, "Rejecting Presentation Context {0}:{1} in association between {2} and {3}.",
							 pcid, association.GetAbstractSyntax(pcid).Description,
							 association.CallingAE, association.CalledAE);
			}

			return result;
		}

		#endregion
	}
}
