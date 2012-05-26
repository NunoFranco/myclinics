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

using System.Security.Permissions;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.WorkingShiftAdmin;
using AuthorityTokens = ClearCanvas.Ris.Application.Common.AuthorityTokens;

namespace ClearCanvas.Ris.Application.Services.Admin.WorkingShiftlAdmin
{
	[ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IWorkingShiftAdminService))]
    public class ProtocolAdminService : ApplicationServiceBase, IWorkingShiftAdminService
    {
        #region IWorkingShiftAdminService Members

        [ReadOperation]
		public ListWorkingShiftsResponse ListWorkingShifts(ListWorkingShiftsRequest request)
		{
			var where = new WorkingShiftSearchCriteria();
			where.Name.SortAsc(0);
			if (!request.IncludeDeactivated)
				where.Deactivated.EqualTo(false);

			var wss = this.PersistenceContext.GetBroker<IWorkingShiftBroker>().Find(where, request.Page);

            var assembler = new WorkingShiftAssembler();
			return new ListWorkingShiftsResponse(
				CollectionUtils.Map<WorkingShift, WorkingShiftSummary>(
					wss,
					ws => assembler.CreateWorkingShiftSummary (ws)));
		}

		[ReadOperation]
		public LoadWorkingShiftForEditResponse LoadWorkingShiftForEdit(LoadWorkingShiftForEditRequest request)
		{
			var ws = this.PersistenceContext.Load<WorkingShift>(request.WorkingShiftRef);

			var assembler = new WorkingShiftAssembler();
			return new LoadWorkingShiftForEditResponse(assembler.CreateWorkingShiftDetail (ws));
		}

		[UpdateOperation]
		public AddWorkingShiftResponse AddWorkingShift(AddWorkingShiftRequest request)
		{
			var assembler = new WorkingShiftAssembler();
			var ws = new WorkingShift();
			assembler.UpdateWorkingShift(ws, request.WorkingShift,PersistenceContext );
			this.PersistenceContext.Lock(ws, DirtyState.New);

			this.PersistenceContext.SynchState();

			return new AddWorkingShiftResponse(assembler.CreateWorkingShiftSummary (ws));
		}

		[UpdateOperation]
		public UpdateWorkingShiftResponse UpdateWorkingShift(UpdateWorkingShiftRequest request)
		{
			var ws = this.PersistenceContext.Load<WorkingShift>(request.WorkingShift.WorkingShiftRef);
			var assembler = new WorkingShiftAssembler();
			assembler.UpdateWorkingShift (ws, request.WorkingShift,PersistenceContext );

			this.PersistenceContext.SynchState();

			return new UpdateWorkingShiftResponse(assembler.CreateWorkingShiftSummary(ws));
		}

		[UpdateOperation]
		public DeleteWorkingShiftResponse DeleteWorkingShift(DeleteWorkingShiftRequest request)
		{
			try
			{
				var broker = this.PersistenceContext.GetBroker<IWorkingShiftBroker>();
				var item = broker.Load(request.WorkingShiftRef, EntityLoadFlags.Proxy);
				broker.Delete(item);

				this.PersistenceContext.SynchState();

				return new DeleteWorkingShiftResponse();
			}
			catch (PersistenceException)
			{
				throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete,
					TerminologyTranslator.Translate(typeof(WorkingShift))));
			}
		}

		
		#endregion
	}
}
