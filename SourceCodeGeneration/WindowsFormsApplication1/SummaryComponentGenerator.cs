using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:SummaryComponent object constructor fields list
    ///{2}:Set Contructor value
    ///{3}:Declare Field List
    ///
    [Component]
    public class SummaryComponentGenerator : GerneratorBase
    {
        public SummaryComponentGenerator(DataSet data)
            : base(data)
        {
            template = "{0}SummaryComponent.gen.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            GeneratedContent = content.Replace("{0}", ObjectName);
            GeneratedContent = GeneratedContent.Replace("{1}", GetSummaryFields().GetSummarytableFields(ObjectName));     
            base.Generate();
        }
    }
}
