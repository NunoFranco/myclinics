using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:ListRequest object constructor fields list
    ///{2}:Set Contructor value
    ///{3}:Declare Field List
    public class ListRequestGenerator : GerneratorBase
    {
         
        public ListRequestGenerator(DataSet data)
            : base(data)
        {
            template = "List{0}sRequest.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            content = content.Replace("{0}", ObjectName);
            GeneratedContent = content.Replace("{1}", GetSummaryFields().GetDeclareFields ());
          
            base.Generate();
        }
    }
}
