using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:Summary object constructor fields list
    ///{2}:Set Contructor value
    ///{3}:Declare Field List
    ///
    [Common]
    public class SummaryGenerator : GerneratorBase
    {
         
        public SummaryGenerator(DataSet data)
            : base(data)
        {
            template = "{0}Summary.gen.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            content = content.Replace("{0}", ObjectName);
            content = content.Replace("{1}", GetSummaryFields().GetConstructorParameterFields());
            content = content.Replace("{2}", GetSummaryFields().SetConstructorParameterFields ());
            GeneratedContent = content.Replace("{3}", GetSummaryFields().GetContractDeclareFields());
            base.Generate();
        }
    }
}
