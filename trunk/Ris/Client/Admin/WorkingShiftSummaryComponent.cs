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
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.WorkingShiftAdmin;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.Desktop.Tools;
using ClearCanvas.Enterprise.Desktop;

namespace ClearCanvas.Ris.Client.Admin
{
    [MenuAction("launch", "global-menus/Admin/Working Shift", "Launch")]
    [ActionPermission("launch", ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.WorkingShift)]
    [ExtensionOf(typeof(DesktopToolExtensionPoint))]
    public class WorkingShiftAdminTool : Tool<IDesktopToolContext>
    {
        private IWorkspace _workspace;

        public void Launch()
        {
            if (_workspace == null)
            {
                try
                {
                    WorkingShiftSummaryComponent component = new WorkingShiftSummaryComponent();

                    _workspace = ApplicationComponent.LaunchAsWorkspace(
                        this.Context.DesktopWindow,
                        component,
                        SR.WorkingShiftSummaryComponetTitle );
                    _workspace.Closed += delegate { _workspace = null; };

                }
                catch (Exception e)
                {
                    // failed to launch component
                    ExceptionHandler.Report(e, this.Context.DesktopWindow);
                }
            }
            else
            {
                _workspace.Activate();
            }
        }
    }

    public class WorkingShiftSummaryTable : Table<WorkingShiftSummary>
    {
        public WorkingShiftSummaryTable()
        {
            this.Columns.Add(new TableColumn<WorkingShiftSummary, string>(SR.WorkingShiftNameColumn,
                delegate(WorkingShiftSummary item)
                {
                    return item.Name;
                },
                0.3f));

            this.Columns.Add(new TableColumn<WorkingShiftSummary, string>(SR.WorkingShiftDescriptionColumn,
                delegate(WorkingShiftSummary item)
                {
                    return item.Description;
                },
                0.6f));
            this.Columns.Add(new TableColumn<WorkingShiftSummary, DateTime? >(SR.WorkingShiftStartTimeColumn ,
                delegate(WorkingShiftSummary item)
                {
                    return item.StartTime ;
                },
                0.6f));
            this.Columns.Add(new TableColumn<WorkingShiftSummary, DateTime? >(SR.WorkingShiftEndTimeColumn ,
                delegate(WorkingShiftSummary item)
                {
                    return item.EndTime ;
                },
                0.6f));
        }
    }

    /// <summary>
    /// Extension point for views onto <see cref="WorkingShiftSummaryComponent"/>
    /// </summary>
    [ExtensionPoint]
    public class WorkingShiftSummaryComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// ProcedureTypeGroupSummaryComponent class
    /// </summary>
    [AssociateView(typeof(WorkingShiftSummaryComponentViewExtensionPoint))]
    public class WorkingShiftSummaryComponent : SummaryComponentBase<WorkingShiftSummary, WorkingShiftSummaryTable, ListWorkingShiftsRequest>
    {
        protected override bool SupportsDelete
        {
            get { return true; }
        }

        /// <summary>
        /// Override this method to perform custom initialization of the action model,
        /// such as adding permissions or adding custom actions.
        /// </summary>
        /// <param name="model"></param>
        protected override void InitializeActionModel(AdminActionModel model)
        {
            base.InitializeActionModel(model);

            model.Add.SetPermissibility(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.WorkingShift);
            model.Edit.SetPermissibility(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.WorkingShift);
            model.ToggleActivation.SetPermissibility(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.WorkingShift);
        }

        /// <summary>
        /// Gets the list of items to show in the table, according to the specifed first and max items.
        /// </summary>
        /// <returns></returns>
        protected override IList<WorkingShiftSummary> ListItems(ListWorkingShiftsRequest request)
        {
            ListWorkingShiftsResponse listResponse = null;
            Platform.GetService<IWorkingShiftAdminService>(
                delegate(IWorkingShiftAdminService service)
                {
                    listResponse = service.ListWorkingShifts(request);
                });

            return listResponse.WorkingShifts;
        }

        /// <summary>
        /// Called to handle the "add" action.
        /// </summary>
        /// <param name="addedItems"></param>
        /// <returns>True if items were added, false otherwise.</returns>
        protected override bool AddItems(out IList<WorkingShiftSummary> addedItems)
        {
            addedItems = new List<WorkingShiftSummary>();
            WorkingShiftEditorComponent editor = new WorkingShiftEditorComponent();
            ApplicationComponentExitCode exitCode = ApplicationComponent.LaunchAsDialog(
                this.Host.DesktopWindow, editor, SR.TitleAddWorkingShift);
            if (exitCode == ApplicationComponentExitCode.Accepted)
            {
                addedItems.Add(editor.WSSummary);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Called to handle the "edit" action.
        /// </summary>
        /// <param name="items">A list of items to edit.</param>
        /// <param name="editedItems">The list of items that were edited.</param>
        /// <returns>True if items were edited, false otherwise.</returns>
        protected override bool EditItems(IList<WorkingShiftSummary> items, out IList<WorkingShiftSummary> editedItems)
        {
            editedItems = new List<WorkingShiftSummary>();
            WorkingShiftSummary item = CollectionUtils.FirstElement(items);

            WorkingShiftEditorComponent editor = new WorkingShiftEditorComponent(item.WorkingShiftRef);
            ApplicationComponentExitCode exitCode = ApplicationComponent.LaunchAsDialog(
                this.Host.DesktopWindow, editor, string.Format(SR.TitlaUpdateWorkingShift, item.Name));
            if (exitCode == ApplicationComponentExitCode.Accepted)
            {
                editedItems.Add(editor.WSSummary );
                return true;
            }
            return false;
        }

        /// <summary>
        /// Called to handle the "delete" action, if supported.
        /// </summary>
        /// <param name="items"></param>
        /// <returns>True if items were deleted, false otherwise.</returns>
        protected override bool DeleteItems(IList<WorkingShiftSummary> items, out IList<WorkingShiftSummary> deletedItems, out string failureMessage)
        {
            failureMessage = null;
            deletedItems = new List<WorkingShiftSummary>();

            foreach (WorkingShiftSummary item in items)
            {
                try
                {
                    Platform.GetService<IWorkingShiftAdminService>(
                        delegate(IWorkingShiftAdminService service)
                        {
                            service.DeleteWorkingShift(new DeleteWorkingShiftRequest(item.WorkingShiftRef));
                        });

                    deletedItems.Add(item);
                }
                catch (Exception e)
                {
                    failureMessage = e.Message;
                }
            }

            return deletedItems.Count > 0;
        }

        /// <summary>
        /// Called to handle the "toggle activation" action, if supported
        /// </summary>
        /// <param name="items">A list of items to edit.</param>
        /// <param name="editedItems">The list of items that were edited.</param>
        /// <returns>True if items were edited, false otherwise.</returns>
        protected override bool UpdateItemsActivation(IList<WorkingShiftSummary> items, out IList<WorkingShiftSummary> editedItems)
        {
            List<WorkingShiftSummary> results = new List<WorkingShiftSummary>();
            foreach (WorkingShiftSummary item in items)
            {
                Platform.GetService<IWorkingShiftAdminService>(
                    delegate(IWorkingShiftAdminService service)
                    {
                        WorkingShiftDetail detail = service.LoadWorkingShiftForEdit(
                            new LoadWorkingShiftForEditRequest(item.WorkingShiftRef)).WorkingShift;
                        detail.Deactivated = !detail.Deactivated;
                        WorkingShiftSummary summary = service.UpdateWorkingShift(
                            new UpdateWorkingShiftRequest(detail)).WorkingShift;

                        results.Add(summary);
                    });
            }

            editedItems = results;
            return true;
        }

        /// <summary>
        /// Compares two items to see if they represent the same item.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected override bool IsSameItem(WorkingShiftSummary x, WorkingShiftSummary y)
        {
            return x.WorkingShiftRef.Equals(y.WorkingShiftRef, true);
        }
    }
}
