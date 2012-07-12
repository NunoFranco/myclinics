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

using System;
using System.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Ris.Application.Common;

namespace ClearCanvas.Ris.Client
{
	/// <summary>
	/// Extension point for views onto <see cref="BiographyNoteComponent"/>
	/// </summary>
	[ExtensionPoint]
	public class BiographyNoteComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

	/// <summary>
	/// BiographyNoteComponent class
	/// </summary>
	[AssociateView(typeof(BiographyNoteComponentViewExtensionPoint))]
	public class BiographyNoteComponent : ApplicationComponent
	{
		private readonly List<PatientNoteDetail> _noteList;
		private readonly BiographyNoteTable _noteTable;
		private PatientNoteDetail _selectedNote;

		/// <summary>
		/// Constructor
		/// </summary>
		public BiographyNoteComponent(List<PatientNoteDetail> notes)
		{
			_noteTable = new BiographyNoteTable(this);
			_noteList = notes;
		}

		public override void Start()
		{
			base.Start();

			_noteTable.Items.AddRange(_noteList);
		}

		public ITable Notes
		{
			get { return _noteTable; }
		}

		public ISelection SelectedNote
		{
			get { return new Selection(_selectedNote); }
			set
			{
				_selectedNote = (PatientNoteDetail)value.Item;
				NoteSelectionChanged();
			}
		}

		public void ShowNoteDetail(PatientNoteDetail notedetail)
		{
			try
			{
				var caegotryChoices = new List<PatientNoteCategorySummary> {notedetail.Category};
				var editor = new PatientNoteEditorComponent(notedetail, caegotryChoices, true);
				LaunchAsDialog(this.Host.DesktopWindow, editor, SR.TitleNoteText);
			}
			catch (Exception e)
			{
				// failed to launch editor
				ExceptionHandler.Report(e, this.Host.DesktopWindow);
			}
		}

		private void NoteSelectionChanged()
		{
			NotifyAllPropertiesChanged();
		}
	}
}