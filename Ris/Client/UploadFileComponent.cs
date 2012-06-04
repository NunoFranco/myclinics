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

using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.Ris.Application.Common;

namespace ClearCanvas.Ris.Client
{
    /// <summary>
    /// Extension point for views onto <see cref="UploadFileComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class UploadFileComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// UploadFileComponent class.
    /// </summary>
    [AssociateView(typeof(UploadFileComponentViewExtensionPoint))]
    public class UploadFileComponent : ApplicationComponent
    {
        public class uploadFiledetail
        {
            public string FileName { get; set; }
            public string FileFullpath { get; set; }
            public string FileType { get; set; }
        }
        public class FileUploadTable : Table<uploadFiledetail>
        {
            public FileUploadTable()
                : base(2)
            {
                this.Columns.Add(new TableColumn<uploadFiledetail, string>("File Name",
                delegate(uploadFiledetail n) { return (n == null ? "" : n.FileName); },
                0.1f));
                this.Columns.Add(new TableColumn<uploadFiledetail, string>("File Type",
                    delegate(uploadFiledetail n) { return (n == null ? "" : n.FileType); },
                    0.2f));
                this.Columns.Add(new TableColumn<uploadFiledetail, string>("Full Path",
                    delegate(uploadFiledetail n) { return n == null ? "" : n.FileFullpath; },
                    0.2f));
            }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public UploadFileComponent()
        {
        }
        FileUploadTable _uploadtable = new FileUploadTable();
        CrudActionModel _uploadActionModel;

        public ITable UploadTableFiles { get { return _uploadtable; }  }

        public ActionModelNode UploadActionModel { get { return _uploadActionModel; } }
        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
            // TODO prepare the component for its live phase
            _uploadtable = new FileUploadTable();
            _uploadActionModel = new CrudActionModel();
            _uploadActionModel.Add.SetClickHandler(AddUploadFile);
            _uploadActionModel.Edit.SetClickHandler(EditUploadFile);
            _uploadActionModel.Delete.SetClickHandler(DeleteUploadFile);

            base.Start();
        }
        void AddUploadFile()
        {
            System.Windows.Forms.OpenFileDialog flg = new System.Windows.Forms.OpenFileDialog();
            if (flg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var item in flg.FileNames)
                {
                    System.IO.FileInfo finfo = new System.IO.FileInfo(item);
                    uploadFiledetail detial = new uploadFiledetail() { FileFullpath = finfo.FullName, FileType = finfo.Extension, FileName = finfo.Name };
                    _uploadtable.Items.Add(detial);
                }

            }
        }
        void EditUploadFile()
        {
        }
        void DeleteUploadFile()
        {
            _uploadtable.Items.Remove(SelectedUploadFile);
        }
        uploadFiledetail _selectedUploadFile;
        public uploadFiledetail SelectedUploadFile
        {
            get { return _selectedUploadFile; }
            set
            {
                _selectedUploadFile = value;
                this.Modified = true;
            }
        }
        /// <summary>
        /// Called by the host when the application component is being terminated.
        /// </summary>
        public override void Stop()
        {
            // TODO prepare the component to exit the live phase
            // This is a good place to do any clean up
            base.Stop();
        }
        public void Cancel()
        {
            this.Host.Exit();
        }
        public void Accept()
        {
            foreach (var item in _uploadtable.Items )
            {
                AttachedDocumentSummary a = new AttachedDocumentSummary();
                a.ContentUrl = item.FileFullpath;
                a.FileExtension = item.FileType;
                a.DocumentTypeName = "";
                AttachedDocument.UploadFile(a);
            }
            this.ExitCode = ApplicationComponentExitCode.Accepted;
            this.Host.Exit();
        }
    }
}
