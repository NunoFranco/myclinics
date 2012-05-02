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

using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Authentication;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Common.Admin.AuthorityGroupAdmin;
using ClearCanvas.Enterprise.Common.Admin.UserAdmin;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Authentication.Brokers;

namespace ClearCanvas.Enterprise.Authentication.Admin.UserAdmin
{
    internal class UserAssembler
    {
        internal UserSummary GetUserSummary(User user)
        {
            return new UserSummary(user.UserName, user.DisplayName, user.CreationTime, user.ValidFrom, user.ValidUntil,
                user.LastLoginTime, user.Enabled);
        }

        internal UserDetail GetUserDetail(User user)
        {
            AuthorityGroupAssembler assembler = new AuthorityGroupAssembler();

        	List<AuthorityGroupSummary> groups = CollectionUtils.Map<AuthorityGroup, AuthorityGroupSummary>(
        		user.AuthorityGroups,
        		delegate(AuthorityGroup group)
        		{
        			return assembler.CreateAuthorityGroupSummary(group);
        		});
				
            return new UserDetail(user.UserName, user.DisplayName, user.CreationTime, user.ValidFrom, user.ValidUntil,
                user.LastLoginTime, user.Enabled, groups);
        }

        internal void UpdateUser(User user, UserDetail detail, IPersistenceContext context)
        {
            // do not update user.UserName
            // do not update user.Password
            user.DisplayName = detail.DisplayName;
            user.ValidFrom = detail.ValidFrom;
            user.ValidUntil = detail.ValidUntil;
            user.Enabled = detail.Enabled;

            // process authority groups
			List<AuthorityGroup> authGroups = CollectionUtils.Map<AuthorityGroupSummary, AuthorityGroup>(
				detail.AuthorityGroups,
                delegate(AuthorityGroupSummary group)
                {
                	return context.Load<AuthorityGroup>(group.AuthorityGroupRef, EntityLoadFlags.Proxy);
                });

            user.AuthorityGroups.Clear();
			user.AuthorityGroups.AddAll(authGroups);
        }
    }
}