using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:LoadForEdit object constructor fields list
    ///{2}:Set Contructor value
    ///{3}:Declare Field List
    ///
    [Common]
    public class LoadForEditGenerator : GerneratorBase
    {
         
        public LoadForEditGenerator(DataSet data)
            : base(data)
        {
            template = "Load{0}ForEditResponse.Generated.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            GeneratedContent = content.Replace("{0}", ObjectName);       
            base.Generate();
        }
    }
}
