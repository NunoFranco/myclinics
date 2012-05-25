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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Hibernate.Hql;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Common;
using System.Reflection;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.Enterprise.Hibernate
{
    /// <summary>
    /// NHibernate implementation of <see cref="IEnumBroker"/>.
    /// </summary>
    [ExtensionOf(typeof(BrokerExtensionPoint))]
    public class EnumBroker : Broker, IEnumBroker
    {
        #region IEnumBroker Members

        public IList<EnumValue> Load(Type enumValueClass, bool includeDeactivated, object clinicOID)
        {
            return LoadTable<EnumValue>(enumValueClass, includeDeactivated, clinicOID);
        }

        public IList<TEnumValue> Load<TEnumValue>(bool includeDeactivated, object clinicOID) where TEnumValue : EnumValue
        {
            return LoadTable<TEnumValue>(typeof(TEnumValue), includeDeactivated, clinicOID);
        }

        public EnumValue Find(Type enumValueClass, object enumID, object clinicOID)
        {
            Platform.CheckForNullReference(enumID, "enumID");
            return this.Context.LoadEnumValue(enumValueClass, enumID, true);
        }

        public TEnumValue Find<TEnumValue>(object enumID)
            where TEnumValue : EnumValue
        {
            return (TEnumValue)Find(typeof(TEnumValue), enumID,System.Guid.Empty );
        }


        public TEnumValue Find<TEnumValue>(string Code, object Clinicoid)
        {
            HqlQuery q = new HqlQuery(string.Format("from {0}", typeof(TEnumValue).FullName));
            q.Conditions.Add(new HqlCondition("Code_ = ?", Code));
            q.Conditions.Add(new HqlCondition("ClinicOID_ = ?", Clinicoid));
            q.Cacheable = true;
            return ExecuteHql<TEnumValue>(q)[0];
        }

        public EnumValue TryFind(Type enumValueClass, object enumID, object clinicOID)
        {
            Platform.CheckForNullReference(enumID, "enumID");

            EnumValue foundEnumValue = CollectionUtils.SelectFirst(
                Load(enumValueClass, false, clinicOID),
                delegate(EnumValue enumValue) { return enumValue.OID == enumID; });

            if (foundEnumValue == null)
                throw new EnumValueNotFoundException(enumValueClass, enumID.ToString(), null);

            return foundEnumValue;
        }

        public TEnumValue TryFind<TEnumValue>(object enumID, object clinicOID)
            where TEnumValue : EnumValue
        {
            return (TEnumValue)TryFind(typeof(TEnumValue), enumID, clinicOID);
        }

        public EnumValue AddValue(Type enumValueClass, string code, string value, string description, float displayOrder, bool deactivated, object clinicOID)
        {
            EnumValue ev = (EnumValue)Activator.CreateInstance(enumValueClass, true);

            UpdateValue(ev, code, value, description, displayOrder, deactivated, clinicOID);


            this.Context.Session.Save(ev);

            return ev;
        }

        public EnumValue UpdateValue(Type enumValueClass, object enumID, string code, string value, string description, float displayOrder, bool deactivated, object clinicOID)
        {
            EnumValue ev = this.Context.LoadEnumValue(enumValueClass, enumID, false);

            UpdateValue(ev, code, value, description, displayOrder, deactivated, clinicOID);

            return ev;
        }

        public void RemoveValue(Type enumValueClass, object enumID, object clinicOID)
        {
            EnumValue ev = this.Context.LoadEnumValue(enumValueClass, enumID, true);
            this.Context.Session.Delete(ev);
        }

        #endregion

        private IList<T> LoadTable<T>(Type enumValueClass, bool includeDeactivated, object clinicOID)
        {
            HqlQuery q = new HqlQuery(string.Format("from {0}", enumValueClass.FullName));
            System.Guid _clinicoid = System.Guid.Empty;
            if (clinicOID != null)
                _clinicoid = (System.Guid)clinicOID;
            // bug : NHibernate does not properly convert property to column name, therefore we use the column name for now
            if (!includeDeactivated)
                q.Conditions.Add(new HqlCondition("Deactivated_ = ?", false));
            if (_clinicoid != System.Guid.Empty && clinicOID != null)
                q.Conditions.Add(new HqlCondition("ClinicOID_ = ?", clinicOID));

            // bug : NHibernate does not properly convert property to column name, therefore we use the column name for now
            q.Sorts.Add(new HqlSort("DisplayOrder_", true, 0));

            // caching these queries will be very efficient, because the tables rarely change
            q.Cacheable = true;
            return ExecuteHql<T>(q);
        }

        private void UpdateValue(EnumValue ev, string code, string value, string description, float displayOrder, bool deactivated, object clinicOID)
        {
            EnterpriseClinic currentClinic = new EnterpriseClinic();
            this.Context.Session.Clear();
            this.Context.Session.Load(currentClinic, clinicOID);

            SetEnumValueProperty(ev, "Code", code);
            SetEnumValueProperty(ev, "Value", value);
            SetEnumValueProperty(ev, "Description", description);
            SetEnumValueProperty(ev, "DisplayOrder", displayOrder);
            SetEnumValueProperty(ev, "Deactivated", deactivated);
            SetEnumValueProperty(ev, "Clinic", currentClinic);
        }

        private static void SetEnumValueProperty(EnumValue ev, string property, object value)
        {
            MethodInfo setter = typeof(EnumValue).GetProperty(property).GetSetMethod(true);
            setter.Invoke(ev, new object[] { value });
        }
    }
}
