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
using System.Text;
using NHibernate.Cfg;
using NHibernate.Dialect;

namespace ClearCanvas.Enterprise.Hibernate.Ddl
{
    /// <summary>
    /// Defines an interface for generating DDL scripts to create, upgrade or drop a relational database.
    /// </summary>
    public interface IDdlScriptGenerator
    {
        /// <summary>
        /// Returns a set of scripts that will be executed as part of creating the database.  The scripts
        /// will be executed in the order they are returned.
        /// </summary>
        /// <param name="config">The persistent store (database) that DDL should be generated for</param>
        /// <returns>A set of scripts</returns>
        string[] GenerateCreateScripts(Configuration config);

		/// <summary>
		/// Returns a set of scripts that will be executed to upgrade the database from a previous version.  The scripts
		/// will be executed in the order they are returned.
		/// </summary>
		/// <param name="config"></param>
		/// <param name="baselineModel"></param>
		/// <returns></returns>
    	string[] GenerateUpgradeScripts(Configuration config, RelationalModelInfo baselineModel);

        /// <summary>
        /// Returns a set of scripts that will be executed as part of dropping the database.  The scripts
        /// will be executed in the order they are returned.
        /// </summary>
        /// <param name="config">The persistent store (database) that DDL should be generated for</param>
        /// <returns>A set of scripts</returns>
        string[] GenerateDropScripts(Configuration config);
    }
}