using System;
using System.Collections.Generic;
using System.Text;

namespace ClearCanvas.Enterprise.Common
{
    public class Common
    {
        /// <summary>
        /// value will be populated after login successfully cannot use this value at server side.
        /// </summary>
        public static class CurrentLoginUserProfile
        {
            public static string CurrentUserName;
            public static string CurrentClinicCode;
            public static object CurrentClinicOID;
            public static EntityRef CurrentClinicRef;

        }
        public static string ClinicUserNameSplitter = "~@~";
        public static string EncryptUserName(string userName, string clinicCode, string ClinicOID)
        {
            return clinicCode + ClinicUserNameSplitter + userName + ClinicUserNameSplitter + ClinicOID.ToString();
        }

        public static void DecryptUsername(string username, ref string loginUsername, ref string cliniccode)
        {

            cliniccode = username.Substring(0, username.IndexOf(ClinicUserNameSplitter));
            loginUsername = username.Replace(loginUsername + ClinicUserNameSplitter, "");
        }
        public static string GetClinicCode(string encryptUserName)
        {
            if (encryptUserName==null || encryptUserName.IndexOf(ClinicUserNameSplitter) == -1)
                return encryptUserName;
            string[] tmp = encryptUserName.Split(new string[] { ClinicUserNameSplitter }, StringSplitOptions.RemoveEmptyEntries);
            return tmp[0];
            
        }
        public static string GetLoginUserName(string encryptUserName)
        {
            if (encryptUserName == null || encryptUserName.IndexOf(ClinicUserNameSplitter) == -1)
                return encryptUserName;
            string[] tmp = encryptUserName.Split(new string[] { ClinicUserNameSplitter }, StringSplitOptions.RemoveEmptyEntries);
            return tmp[1];
            //return encryptUserName.Replace(GetClinicCode(encryptUserName) + ClinicUserNameSplitter, "");
        }

        public static object GetClinicOID(string encryptUserName)
        {
            if (encryptUserName == null || encryptUserName.IndexOf(ClinicUserNameSplitter) == -1)
                return encryptUserName;
            string[] tmp = encryptUserName.Split(new string[] { ClinicUserNameSplitter }, StringSplitOptions.RemoveEmptyEntries);
            return new Guid(tmp[2]);
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsSystemAdmin { get { return GetLoginUserName(System.Threading.Thread.CurrentPrincipal.Identity.Name).ToLower() == "sa"; } }
    }
}
