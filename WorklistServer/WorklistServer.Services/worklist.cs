using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorklistServer.Services
{
    class worklist
    {
        public string AE { get; set; }
        public int Port { get; set; }
        public string strConnect { get; set; }
        public worklist()
        {
            AE = System.Configuration.ConfigurationSettings.AppSettings["AE"];
            Port =int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Port"]);
            strConnect = System.Configuration.ConfigurationSettings.AppSettings["StrConn"];
        }
    }
}
