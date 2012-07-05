using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:Detail object constructor fields list
    ///{2}:Set Contructor value
    ///{3}:Declare Field List
    public class DetailGenerator : GerneratorBase
    {
         
        public DetailGenerator(DataSet data)
            : base(data)
        {
            template = "{0}Detail.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            content = content.Replace("{0}", ObjectName);
            content = content.Replace("{1}", GetDetailFields().GetConstructorParameterFields());
            content = content.Replace("{2}", GetDetailFields().SetConstructorParameterFields ());
            content = content.Replace("{3}", GetDetailFields().GetDeclareFields());
            GeneratedContent = content.Replace("{4}", GetSummaryFields().GetContructorFields ());
           
            base.Generate();
        }
    }
}
