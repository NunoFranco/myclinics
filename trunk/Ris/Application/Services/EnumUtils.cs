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
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.Ris.Application.Services
{
    public class EnumUtils
    {
        /// <summary>
        /// Converts a <see cref="EnumValue"/> to a <see cref="EnumValueInfo"/> object.
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static EnumValueInfo GetEnumValueInfo(EnumValue enumValue)
        {
            //object clinicid = Enterprise.Common.AuthenticationScope.Current.CurrentClinic.ClinicRef.EntityOID;
            return enumValue == null ? null : new EnumValueInfo(enumValue.OID, enumValue.Code, enumValue.Value, enumValue.Clinic.OID, enumValue.Description);
        }
        //public static EnumValueInfo GetEnumValueInfo(EnumValue enumValue,object clinicid )
        //{
        //    //object clinicid = Enterprise.Common.AuthenticationScope.Current.CurrentClinic.ClinicRef.EntityOID;
        //    return enumValue == null ? null : new EnumValueInfo(enumValue.OID, enumValue.Code, enumValue.Value, enumValue.Clinic.OID, enumValue.Description);
        //}
        public static EnumValueInfo GetEnumValueInfo<TEnum>(object code,IPersistenceContext context)
            where TEnum : EnumValue
        {
            //EnumValueClassAttribute attr = CollectionUtils.FirstElement<EnumValueClassAttribute>(
            //    typeof(TEnum).GetCustomAttributes(typeof(EnumValueClassAttribute), false));

            //if (attr == null)
            //    throw new ArgumentException(string.Format("{0} is not marked with the EnumValueClassAttribute", typeof(TEnum).FullName));
            object clinicid = Enterprise.Common.Common.GetClinicOID(System.Threading.Thread.CurrentPrincipal.Identity.Name);
            EnumValue enumValue = context.GetBroker<IEnumBroker>().Find<TEnum>( code.ToString(), clinicid);
            return GetEnumValueInfo(enumValue);
        }
        /// <summary>
        /// Converts a C# enum value to a <see cref="EnumValueInfo"/> object.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="code"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static EnumValueInfo GetEnumValueInfo<TEnum>(object code, object ClinicOID,IPersistenceContext context)
            where TEnum : EnumValue
        {
            //EnumValueClassAttribute attr = CollectionUtils.FirstElement<EnumValueClassAttribute>(
            //    typeof(TEnum).GetCustomAttributes(typeof(EnumValueClassAttribute), false));

            //if (attr == null)
            //    throw new ArgumentException(string.Format("{0} is not marked with the EnumValueClassAttribute", typeof(TEnum).FullName));

            EnumValue enumValue = context.GetBroker<IEnumBroker>().Find<TEnum>(code.ToString(), ClinicOID);
            return GetEnumValueInfo(enumValue);
        }
        //public static EnumValueInfo GetEnumValueInfo<TEnum>(TEnum code, object clinicid, IPersistenceContext context)
        //           where TEnum : struct
        //{
        //    EnumValueClassAttribute attr = CollectionUtils.FirstElement<EnumValueClassAttribute>(
        //        typeof(TEnum).GetCustomAttributes(typeof(EnumValueClassAttribute), false));

        //    if (attr == null)
        //        throw new ArgumentException(string.Format("{0} is not marked with the EnumValueClassAttribute", typeof(TEnum).FullName));

        //    EnumValue enumValue = context.GetBroker<IEnumBroker>().Find(attr.EnumValueClass, code.ToString(), clinicid);
        //    return GetEnumValueInfo(enumValue, clinicid);
        //}
        /// <summary>
        /// Reads the value property of the specified enumValue in a null-safe manner
        /// (e.g returns null if the argument is null).
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayValue(EnumValue enumValue)
        {
            return enumValue == null ? null : enumValue.Value;
        }

        /// <summary>
        /// Gets the value corresponding to the specified enum code.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="code"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetValue<TEnum>(TEnum code,  IPersistenceContext context)
            where TEnum : EnumValue
        {
            object clinicid = Enterprise.Common.Common.GetClinicOID(System.Threading.Thread.CurrentPrincipal.Identity.Name);

            return GetEnumValueInfo<TEnum>(code, clinicid, context).Value;
        }
       
        /// <summary>
        /// Returns a list of <see cref="EnumValueInfo"/> objects representing the active values in the specified enumeration class.
        /// </summary>
        /// <typeparam name="TEnumValue"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<EnumValueInfo> GetEnumValueList<TEnumValue>(IPersistenceContext context)
            where TEnumValue : EnumValue
        {
            //string ClinicCode = Enterprise.Common.Common.GetClinicCode(System.Threading.Thread.CurrentPrincipal.Identity.Name);
            //ClearCanvas.Ris.Application.Services.Admin.FacilityAdmin.FacilityAdminService service = new ClearCanvas.Ris.Application.Services.Admin.FacilityAdmin.FacilityAdminService();
            object clinicid = Enterprise.Common.Common.GetClinicOID (System.Threading.Thread.CurrentPrincipal.Identity.Name); ;
            return CollectionUtils.Map<EnumValue, EnumValueInfo, List<EnumValueInfo>>(context.GetBroker<IEnumBroker>().Load<TEnumValue>(false, clinicid),
                delegate(EnumValue ev)
                {
                    return new EnumValueInfo(ev.OID, ev.Code, ev.Value, clinicid, ev.Description);
                });
        }

        /// <summary>
        /// Converts a <see cref="EnumValueInfo"/> to a subclass of <see cref="EnumValue"/>.
        /// </summary>
        /// <typeparam name="TEnumValue"></typeparam>
        /// <param name="info"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static TEnumValue GetEnumValue<TEnumValue>(EnumValueInfo info, IPersistenceContext context)
            where TEnumValue : EnumValue
        {
            
            return info == null ? null : context.GetBroker<IEnumBroker>().Find<TEnumValue>(info.OID);
        }

        public static TEnumValue GetEnumValue<TEnumValue>(object Code, IPersistenceContext context)
        {
            object clinicid = Enterprise.Common.Common.GetClinicOID(System.Threading.Thread.CurrentPrincipal.Identity.Name); ;
            return context.GetBroker<IEnumBroker>().Find<TEnumValue>(Code.ToString(), clinicid);
        }

        /// <summary>
        /// Converts a <see cref="EnumValueInfo"/> to a C# enum value.  If info is null,
        /// the default (0) value for the enum is returned.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        public static TEnum GetEnumValue<TEnum>(EnumValueInfo info)
            where TEnum : struct
        {

            string code = info != null ? info.Code : Enum.GetName(typeof(TEnum), 0);
            //EnumValue tmp=new EnumValue(info.Code,info.Value , info.Description,info.ClinicOID);
            //tmp.OID=info.OID ;
            return (TEnum)Enum.Parse(typeof(TEnum), code);
        }

        //public static TEnum GetDBEnumValue<TEnum>(EnumValueInfo info)
        //  where TEnum : EnumValue
        //{
        //    if (info == null)
        //        return null;
        //    string code = info != null ? info.Code : Enum.GetName(typeof(TEnum), 0);
        //    EnumValue tmp = new EnumValue(info.Code, info.Value, info.Description);
        //    tmp.OID = info.OID;
        //    return (TEnum)tmp;
        //}
    }
}