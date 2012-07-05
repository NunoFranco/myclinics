using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:AddRequest object constructor fields list
    ///{2}:Set Contructor value
    ///{3}:Declare Field List
    public class DeleteRequestGenerator : GerneratorBase
    {

        public DeleteRequestGenerator(DataSet data)
            : base(data)
        {
            template = "Delete{0}Request.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            GeneratedContent = content.Replace("{0}", ObjectName);       
            base.Generate();
        }
    }
}
