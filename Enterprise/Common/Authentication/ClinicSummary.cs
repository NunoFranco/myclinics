using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace ClearCanvas.Enterprise.Common.Authentication
{
    [DataContract]
    public class ClinicSummary
    {

        [DataMember]
        public string ClinicCode { get; set; }

        [DataMember]
        public string CliniName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public EntityRef ClinicRef;

        public ClinicSummary(string code, string name, string addr, EntityRef fRef)
        {
            ClinicCode = code;
            CliniName = name;
            Address = addr;
            ClinicRef = fRef;
        }

        
    }


   
}
