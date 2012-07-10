using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:AddResponse object constructor fields list
    ///{2}:Set Contructor value
    ///{3}:Declare Field List
    ///
    [Common]
    public class DeleteResponseGenerator : GerneratorBase
    {

        public DeleteResponseGenerator(DataSet data)
            : base(data)
        {
            template = "Delete{0}Response.gen.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            GeneratedContent = content.Replace("{0}", ObjectName);       
            base.Generate();
        }
    }
}
