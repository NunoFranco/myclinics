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
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Hibernate;
using ClearCanvas.Enterprise.Hibernate.Hql;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Healthcare.Workflow.Modality;
using ClearCanvas.Workflow;

namespace ClearCanvas.Healthcare.Hibernate.Brokers
{
    /// <summary>
    /// Implementation of <see cref="IModalityWorklistItemBroker"/>.
    /// </summary>
    [ExtensionOf(typeof(BrokerExtensionPoint))]
    public class ModalityWorklistItemBroker : WorklistItemBrokerBase<WorklistItem>, IModalityWorklistItemBroker
    {
        #region Private Helpers

		protected override HqlProjectionQuery BuildWorklistItemSearchQuery(WorklistItemSearchCriteria[] where, bool countQuery)
		{
			// need to set the correct time field
			// ProcedureScheduledStartTime seems like a reasonable choice for tech homepage search,
			// as it gives a general sense of when the procedure occurs in time, regardless of the procedure step
			CollectionUtils.ForEach(where,
				delegate(WorklistItemSearchCriteria sc)
				{
					sc.TimeField = WorklistTimeField.ProcedureScheduledStartTime;
				});

			HqlProjectionQuery query = countQuery ? CreateBaseCountQuery(where) : CreateBaseItemQuery(where);
			query.Conditions.Add(ConditionActiveProcedureStep);

			AddConditions(query, where, true, !countQuery);

			return query;
		}

		#endregion
    }
}
