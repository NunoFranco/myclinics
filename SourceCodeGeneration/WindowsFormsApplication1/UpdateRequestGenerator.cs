using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:UpdateRequest object constructor fields list
    ///{2}:Set Contructor value
    ///{3}:Declare Field List
    ///
    [Common]
    public class UpdateRequestGenerator : GerneratorBase
    {
         
        public UpdateRequestGenerator(DataSet data)
            : base(data)
        {
            template = "Update{0}Request.Generated.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            GeneratedContent = content.Replace("{0}", ObjectName);       
            base.Generate();
        }
    }
}
