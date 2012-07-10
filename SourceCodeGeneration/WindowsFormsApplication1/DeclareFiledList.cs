using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    [Serializable()]
    public class Field
    {
        public static Dictionary<string, string> TypeMapping = new Dictionary<string, string>();
        public Field()
        {
            if (TypeMapping.Keys.Count == 0)
            {
                TypeMapping.Add("String", "string");
                TypeMapping.Add("DateTime", "DateTime");
                TypeMapping.Add("Double", "double");
                TypeMapping.Add("Decimal", "decimal");
                TypeMapping.Add("int", "int");
                TypeMapping.Add("Boolean", "bool");
            }
        }
        public string Name { get; set; }
        private string _type = "";
        public string TypeName
        {
            get
            {
                if (TypeMapping.ContainsKey(_type))
                    return TypeMapping[_type];
                return _type;
            }
            set
            {
                _type = value;
            }
        }
    }
    public class DeclareFiledList
    {
        public List<Field> FiledList { get; set; }
        public DeclareFiledList()
        {
            FiledList = new List<Field>();
        }

        public string GetDeclareFields()
        {
            string result = "";
            string filetemplat = "[DataMember]" + System.Environment.NewLine + "public " + "{0} {1};" + System.Environment.NewLine;
            foreach (var item in FiledList)
            {
                result += string.Format(filetemplat, item.TypeName, item.Name);
            }
            return result;
        }

        public string GetConstructorParameterFields()
        {
            string result = "";
            string filetemplat = "{0} {1}," + System.Environment.NewLine;
            foreach (var item in FiledList)
            {
                result += string.Format(filetemplat, item.TypeName, "_" + item.Name.ToLower());
            }
            result = result.Remove(result.LastIndexOf(","));
            return result;
        }
        public string SetConstructorParameterFields()
        {
            string result = "";
            string filetemplat = "{0} = {1};" + System.Environment.NewLine;
            foreach (var item in FiledList)
            {
                result += string.Format(filetemplat, item.Name, "_" + item.Name.ToLower());
            }
            //result = result.Remove(result.LastIndexOf(",")); 
            return result;
        }
        public string GetUpdateToDetailFields()
        {
            string result = "";
            string filetemplat = "detail.{0} = obj.{0};" + System.Environment.NewLine;
            foreach (var item in FiledList)
            {
                result += string.Format(filetemplat, item.Name);
            }
            return result;
        }

        public string GetUpdateFromDetailFields()
        {
            string result = "";
            string filetemplat = "obj.{0} = detail.{0};" + System.Environment.NewLine;
            foreach (var item in FiledList)
            {
                result += string.Format(filetemplat, item.Name);
            }
            return result;
        }

        public string GetContructorFields()
        {
            string result = "";
            string filetemplat = "{0}," + System.Environment.NewLine;
            foreach (var item in FiledList)
            {
                result += string.Format(filetemplat, item.Name);
            }
            return result.EndsWith("," + System.Environment.NewLine ) ? result.Substring(0, result.Length - 3) : result;//Remove last "," - 3 because contain new line 2 chars
        }
        public string GetAssemblerContructorFields()
        {
            string result = "";
            string filetemplat = "obj.{0}," + System.Environment.NewLine;
            foreach (var item in FiledList)
            {
                result += string.Format(filetemplat, item.Name);
            }
            return result.EndsWith("," + System.Environment.NewLine ) ? result.Substring(0, result.Length - 3) : result;//Remove last "," - 3 because contain new line 2 chars
        }

        public string GetSummarytableFields(string objectname)
        {
            string result = "";
            string filetemplat = @" this.Columns.Add(new TableColumn<{0}Summary, {1}>(SR.Title{0}{2}Column ,
                delegate({0}Summary obj) { return obj.{2}; },
                0.5f));" + System.Environment.NewLine;
            foreach (var item in FiledList)
            {
                result += string.Format(filetemplat, item.Name);
            }
            return result.EndsWith("," + System.Environment.NewLine) ? result.Substring(0, result.Length - 3) : result;//Remove last "," - 3 because contain new line 2 chars
}
    }
}
