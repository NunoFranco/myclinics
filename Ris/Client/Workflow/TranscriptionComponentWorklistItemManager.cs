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

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.ReportingWorkflow;
using ClearCanvas.Ris.Application.Common.TranscriptionWorkflow;

namespace ClearCanvas.Ris.Client.Workflow
{
	public class TranscriptionComponentWorklistItemManager : WorklistItemManager<ReportingWorklistItem, ITranscriptionWorkflowService>
	{
		public TranscriptionComponentWorklistItemManager(string folderName, EntityRef worklistRef, string worklistClassName)
			: base(folderName, worklistRef, worklistClassName)
		{
		}

		protected override IContinuousWorkflowComponentMode GetMode<TWorklistITem>(ReportingWorklistItem worklistItem)
		{
			if (worklistItem == null)
				return TranscriptionComponentModes.Review;

			switch (worklistItem.ActivityStatus.Code)
			{
				case StepState.Scheduled:
					return TranscriptionComponentModes.Create;
				case StepState.InProgress:
					return TranscriptionComponentModes.Edit;
				default:
					return TranscriptionComponentModes.Review;
			}
		}

		protected override string TaskName
		{
			get { return "Transcribing"; }
		}
	}

	public class TranscriptionComponentModes
	{
		public static IContinuousWorkflowComponentMode Create = new CreateTranscriptionComponentMode();
		public static IContinuousWorkflowComponentMode Edit = new EditTranscriptionComponentMode();
		public static IContinuousWorkflowComponentMode Review = new ReviewTranscriptionComponentMode();
	}

	public class EditTranscriptionComponentMode : ContinuousWorkflowComponentMode
	{
		public EditTranscriptionComponentMode() : base(false, false, false)
		{
		}
	}

	public class CreateTranscriptionComponentMode : ContinuousWorkflowComponentMode
	{
		public CreateTranscriptionComponentMode() : base(true, true, true)
		{
		}
	}

	public class ReviewTranscriptionComponentMode : ContinuousWorkflowComponentMode
	{
		public ReviewTranscriptionComponentMode() : base(false, false, false)
		{
		}
	}
}