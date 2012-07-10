using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:ListResponse object constructor fields list
    ///{2}:Set Contructor value
    ///{3}:Declare Field List
    ///
    [Common]
    public class ListResponseGenerator : GerneratorBase
    {
         
        public ListResponseGenerator(DataSet data)
            : base(data)
        {
            template = "List{0}sResponse.Generated.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            GeneratedContent = content.Replace("{0}", ObjectName);       
            base.Generate();
        }
    }
}
