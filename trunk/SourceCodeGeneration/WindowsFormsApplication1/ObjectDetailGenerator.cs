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
    public class ObjectDetailGenerator : GerneratorBase
    {
         
        public ObjectDetailGenerator(DataSet data)
            : base(data)
        {
            template = "{0}ObjectDetail.cs";
        }
        public override void Generate()
        {

            string content = GetTemplateContent(template);
            //GeneratedContent = string.Format(content, ObjectName,
            //    GetSummaryFields().GetConstructorParameterFields(),
            //    GetDetailFields().GetConstructorParameterFields(), GetDetailFields().GetUpdateFromDetailFields());
            content = content.Replace("{0}", ObjectName);
            content = content.Replace("{1}", GetSummaryFields().GetConstructorParameterFields());
            content = content.Replace("{2}", GetDetailFields().GetConstructorParameterFields());
            GeneratedContent = content.Replace("{3}", GetDetailFields().GetUpdateFromDetailFields());
            //GeneratedContent = string.Format(content, "", "", "", "");
            base.Generate();
        }
    }
}
