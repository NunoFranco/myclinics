using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:Summary object constructor fields list
    ///{2}:Detail object constructor fields list
    ///{3}:Update object Value fields list
    public class AssemblerGenerator : GerneratorBase
    {
         
        public AssemblerGenerator(DataSet data)
            : base(data)
        {
            template = "{0}Assembler.cs";
        }
        public override void Generate()
        {

            string content = GetTemplateContent(template);
            //GeneratedContent = string.Format(content, ObjectName,
            //    GetSummaryFields().GetConstructorParameterFields(),
            //    GetDetailFields().GetConstructorParameterFields(), GetDetailFields().GetUpdateFromDetailFields());
            content = content.Replace("{0}", ObjectName);
            content = content.Replace("{1}", GetSummaryFields().GetAssemblerContructorFields  ());
            content = content.Replace("{2}", GetDetailFields().GetAssemblerContructorFields());
            GeneratedContent = content.Replace("{3}", GetDetailFields().GetUpdateFromDetailFields());
            //GeneratedContent = string.Format(content, "", "", "", "");
            base.Generate();
        }
    }
}
