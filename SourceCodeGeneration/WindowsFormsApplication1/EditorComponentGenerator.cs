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
    public class EditorComponentGenerator : GerneratorBase
    {
        public EditorComponentGenerator(DataSet data)
            : base(data)
        {
            template = "{0}EditorComponent.gen.cs";
        }
        public override void Generate()
        {
            string content = GetTemplateContent(template);
            GeneratedContent = content.Replace("{0}", ObjectName);
            GeneratedContent = GeneratedContent.Replace("{1}",GetDetailFields().GetPresentationModelFields());     
            base.Generate();
        }
    }
}
