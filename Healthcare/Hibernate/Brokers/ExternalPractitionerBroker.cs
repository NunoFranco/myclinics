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

using System.Collections.Generic;
using ClearCanvas.Enterprise.Hibernate.Hql;

namespace ClearCanvas.Healthcare.Hibernate.Brokers
{
	public partial class ExternalPractitionerBroker
	{
		#region IExternalPractitionerBroker Members

		public IList<Order> GetRelatedOrders(ExternalPractitioner practitioner)
		{
			HqlFrom hqlFrom = new HqlFrom(typeof(Order).Name, "o");
			HqlProjectionQuery query = new HqlProjectionQuery(hqlFrom);

			OrderSearchCriteria criteria = new OrderSearchCriteria();
            //criteria.OrderingPractitioner.EqualTo(practitioner);
			query.Conditions.AddRange(HqlCondition.FromSearchCriteria("o", criteria));

			return ExecuteHql<Order>(query);
		}

		public IList<Visit> GetRelatedVisits(ExternalPractitioner practitioner)
		{
			HqlFrom hqlFrom = new HqlFrom(typeof(Visit).Name, "v");
			hqlFrom.Joins.Add(new HqlJoin("v.Practitioners", "vp"));
			HqlProjectionQuery query = new HqlProjectionQuery(hqlFrom);

			VisitPractitionerSearchCriteria criteria = new VisitPractitionerSearchCriteria();
			criteria.Practitioner.EqualTo(practitioner);
			query.Conditions.AddRange(HqlCondition.FromSearchCriteria("vp", criteria));

			return ExecuteHql<Visit>(query);
		}

		#endregion
	}
}
