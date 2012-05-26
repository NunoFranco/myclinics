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

using System.Collections.Generic;
using System.Net;
using ClearCanvas.Common;
using ClearCanvas.Dicom.Network.Scp;

namespace ClearCanvas.Ris.Shreds.MwlServer
{
	public class MwlServer
	{
		#region Private Members
		private readonly List<DicomScp<MwlServerContext>> _listenerList = new List<DicomScp<MwlServerContext>>();
		#endregion

		#region Private Methods

		private void StartListeners()
		{
			MwlServerContext context = new MwlServerContext();

			if (MwlServerSettings.Default.ListenIPV4)
			{
				DicomScp<MwlServerContext> ipV4Scp = new DicomScp<MwlServerContext>(context, AssociationVerifier.Verify);

				ipV4Scp.ListenPort = MwlServerSettings.Default.ListenerPort;
				ipV4Scp.AeTitle = MwlServerSettings.Default.AETitle;

				if (ipV4Scp.Start(IPAddress.Any))
					_listenerList.Add(ipV4Scp);
				else
				{
					Platform.Log(LogLevel.Error, "Unable to add IPv4 SCP handler");
				}
			}

			if (MwlServerSettings.Default.ListenIPV6)
			{
				DicomScp<MwlServerContext> ipV6Scp = new DicomScp<MwlServerContext>(context, AssociationVerifier.Verify);

				ipV6Scp.ListenPort = MwlServerSettings.Default.ListenerPort;
				ipV6Scp.AeTitle = MwlServerSettings.Default.AETitle;

				if (ipV6Scp.Start(IPAddress.IPv6Any))
					_listenerList.Add(ipV6Scp);
				else
				{
					Platform.Log(LogLevel.Error, "Unable to add IPv6 SCP handler");
				}
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Method called when starting the DICOM SCP.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The method starts a <see cref="DicomScp{DicomScpParameters}"/> instance for each server partition configured in
		/// the database.  It assumes that the combination of the configured AE Title and Port for the 
		/// partition is unique.  
		/// </para>
		/// </remarks>
		public void Run()
		{
			StartListeners();
		}

		/// <summary>
		/// Method called when stopping the DICOM SCP.
		/// </summary>
		public void Stop()
		{
			foreach (DicomScp<MwlServerContext> scp in _listenerList)
			{
				scp.Stop();
			}
		}

		#endregion
	}
}
