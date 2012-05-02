using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
namespace ClearCanvas.Common.Utilities
{
    public class ObjectSerialization
    {
        public static string Serialize<T>(object obj)
        {
            XmlSerializer serial = new XmlSerializer(typeof(T));
            StringWriter sw = new StringWriter();
            serial.Serialize(sw, obj);
            return sw.ToString();
        }
        public static T DeSerialze<T>(string xmlObject)
        {
            XmlSerializer serial = new XmlSerializer(typeof(T));
            System.IO.MemoryStream ms = new System.IO.MemoryStream(ASCIIEncoding.ASCII.GetBytes(xmlObject));
            TextReader reader = new StringReader(xmlObject);
            return (T)serial.Deserialize(reader);
        }
    }
}
