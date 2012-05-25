using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Hibernate;
namespace ClearCanvas.Healthcare
{
    public class Common
    {
        public static ClearCanvas.Enterprise.Common.EntityRef GetClinicRef(string clinicCode, IUpdateContext context)
        {

            EntityRef ClinicRef = GetClinic(clinicCode,context).GetRef();
            return ClinicRef;
        }
        public static Facility GetClinic(string clinicCode, IUpdateContext context)
        {
            Facility CurrentClinic;
            FacilitySearchCriteria cri = new FacilitySearchCriteria();
            cri.Code.EqualTo(clinicCode);
            CurrentClinic = context.GetBroker<Brokers.IFacilityBroker>().FindOne(cri);
            return CurrentClinic;
        }
        public static  T ConvertToSystemEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        public static EnumBroker broker { get { return new EnumBroker(); } }
        public static TEnum ConvertSystemEnumTohbmEnum<TEnum>(object code, object clinicID)
        {
            return (TEnum)broker.Find<TEnum>(code.ToString(), clinicID);

        }
        public static bool IsEqual(EnumValue  DBenumCode, object SystemEnum)
        {
            return DBenumCode.Code  == SystemEnum.ToString();
        }
    }
}
