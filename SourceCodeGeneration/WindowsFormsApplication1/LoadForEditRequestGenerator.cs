using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:LoadForEditRequest object constructor fields list
    ///{2}:Set Contructor value
    ///{3}:Declare Field List
    public class LoadForEditRequestGenerator : GerneratorBase
    {
         
        public LoadForEditRequestGenerator(DataSet data)
            : base(data)
        {
            template = "Load{0}ForEditRequest.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            GeneratedContent = content.Replace("{0}", ObjectName);       
            base.Generate();
        }
    }
}
