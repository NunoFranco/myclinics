#region License

// Copyright (c) 2009, ClearCanvas Inc.
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
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.PackageProcedureAdmin;
using ClearCanvas.Enterprise.Core.Modelling;

namespace ClearCanvas.Ris.Application.Services
{
    internal class PackageProcedureAssembler
    {
        public PackageProcedureSummary GetPackageProcedureSummary(PackageProcedure rptGroup, IPersistenceContext context)
        {
            EnumValueInfo category = GetCategoryEnumValueInfo(rptGroup.GetType());
            return new PackageProcedureSummary(rptGroup.GetRef(), rptGroup.Code , rptGroup.Name , rptGroup.IsAutoPrice,rptGroup.ManualUnitPrice );
        }

        public PackageProcedureDetail GetPackageProcedureDetail(PackageProcedure rptGroup, IPersistenceContext context)
        {
            PackageProcedureDetail detail = new PackageProcedureDetail();

            detail.Name = rptGroup.Name;
            detail.Code  = rptGroup.Code ;
            detail.IsAutoPrice  = rptGroup.IsAutoPrice ;
            detail.ManualUnitPrice = rptGroup.ManualUnitPrice ;
                        

            ProcedureTypeAssembler assembler = new ProcedureTypeAssembler();
            detail.ProcedureTypes = CollectionUtils.Map<ProcedureType, ProcedureTypeSummary, List<ProcedureTypeSummary>>(
                rptGroup.ProcedureTypes,
                delegate (ProcedureType rpt)
                    {
                        return assembler.CreateSummary(rpt);
                    });

            return detail;
        }

        public EnumValueInfo GetCategoryEnumValueInfo(Type groupClass)
        {
            // this is a bit hokey but avoids having to modify the client code that is expecting an EnumValueInfo
            return new EnumValueInfo(groupClass.AssemblyQualifiedName, TerminologyTranslator.Translate(groupClass));
        }

        public void UpdatePackageProcedure(PackageProcedure group, PackageProcedureDetail detail, IPersistenceContext context)
        {
            group.Name = detail.Name;
            group.Code  = detail.Code ;
            group.IsAutoPrice = detail.IsAutoPrice ;
            group.ManualUnitPrice = detail.ManualUnitPrice ;
            
            group.ProcedureTypes.Clear();
            detail.ProcedureTypes.ForEach(
                delegate(ProcedureTypeSummary summary)
                    {
                        group.ProcedureTypes.Add(context.Load<ProcedureType>(summary.ProcedureTypeRef));
                    });
        }
    }
}