using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    ///{0}:objectname
    ///{1}:Services object constructor fields list
    ///{2}:Set Contructor value
    ///{3}:Declare Field List
    ///
    [Services]
    public class ServicesGenerator : GerneratorBase
    {
         
        public ServicesGenerator(DataSet data)
            : base(data)
        {
            template = "{0}Service.Generated.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            GeneratedContent = content.Replace("{0}", ObjectName);       
            base.Generate();
        }
    }
}
