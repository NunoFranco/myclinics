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
using System.Collections;
using Iesi.Collections;

namespace ClearCanvas.Enterprise.Support
{
    public class CollectionFieldExchange<TInfoElement> : FieldExchange
    {
        private IInfoExchange _elementConversion;

        public CollectionFieldExchange(
            GetFieldValueDelegate classFieldGetter,
            SetFieldValueDelegate classFieldSetter,
            GetFieldValueDelegate infoFieldGetter,
            SetFieldValueDelegate infoFieldSetter,
            IInfoExchange elementConversion)
            : base(classFieldGetter, classFieldSetter, infoFieldGetter, infoFieldSetter)
        {
            _elementConversion = elementConversion;
        }

        public override void SetInfoFieldFromObject(DomainObject pobj, DomainObjectInfo info, IPersistenceContext pctx)
        {
            IEnumerable pobjCollection = (IEnumerable)GetClassFieldValue(pobj);
            if (pobjCollection != null && pctx.IsCollectionLoaded(pobjCollection))
            {
                List<TInfoElement> infoCollection = new List<TInfoElement>();
                foreach (object element in pobjCollection)
                {
                    infoCollection.Add((TInfoElement)_elementConversion.GetInfoFromObject(element, pctx));
                }
                SetInfoFieldValue(info, infoCollection);
            }
        }

        public override void SetObjectFieldFromInfo(DomainObject pobj, DomainObjectInfo info, IPersistenceContext pctx)
        {
            IList infoCollection = (IList)GetInfoFieldValue(info);
            if (infoCollection != null)
            {
                IEnumerable pobjCollection = (IEnumerable)GetClassFieldValue(pobj);
                foreach (object element in infoCollection)
                {
                    if (pobjCollection is IList)
                    {
                        (pobjCollection as IList).Add(_elementConversion.GetObjectFromInfo(element, pctx));
                    }
                    else if (pobjCollection is ISet)
                    {
                        (pobjCollection as ISet).Add(_elementConversion.GetObjectFromInfo(element, pctx));
                    }
                }
            }
        }
    }
}