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
using ClearCanvas.Common;
using ClearCanvas.Healthcare;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare.Alerts
{
    [ExtensionOf(typeof(OrderAlertExtensionPoint))]
    public class InvalidVisitAlert : OrderAlertBase
    {
        public override AlertNotification Test(Order order, IPersistenceContext context)
        {
            List<string> reasons = new List<string>();
            if (order.Visit == null)
            {
                // This should never happen in production because an order must have a visit
                reasons.Add("This order is missing a visit");
            }
            else
            {
                // Check Visit status
                if (order.Visit.Status.Code != VisitStatus.AA.ToString())
                    reasons.Add("Visit Status is not active");

                // Check Visit date
                if (order.Visit.AdmitTime == null)
                {
                    // This should never happen in production since visit admit date should always be created from HIS
                    reasons.Add("Visit date is missing");                    
                }
                else if (order.ScheduledStartTime != null)
                {
                    if (order.Visit.AdmitTime.Value.Date > order.ScheduledStartTime.Value.Date)
                        reasons.Add("Visit date is in the future");
                    else if (order.Visit.AdmitTime.Value.Date < order.ScheduledStartTime.Value.Date)
                        reasons.Add("Visit date is in the past");
                }
            }

            if (reasons.Count > 0)
                return new AlertNotification(this.GetType(), reasons);

            return null;
        }
    }
}