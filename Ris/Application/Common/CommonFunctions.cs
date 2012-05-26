using System;
using System.Collections.Generic;
using System.Text;

namespace ClearCanvas.Ris.Application.Common
{
    public class CommonFunctions
    {
        public static string GetUniqueMrnID()
        {
            string result = DateTime.Now.Ticks.ToString();
            return result;
        }
    }
}
