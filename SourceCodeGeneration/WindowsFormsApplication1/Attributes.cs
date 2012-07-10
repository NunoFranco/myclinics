using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Common:Attribute 
    {
        public string Name { get; set; }
    }
    public class Services : Attribute
    {
        public string Name { get; set; }
    }
    public class Component : Attribute
    {
        public string Name { get; set; }
    }
}
