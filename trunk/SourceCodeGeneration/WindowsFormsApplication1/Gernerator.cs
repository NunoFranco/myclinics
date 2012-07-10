using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
namespace WindowsFormsApplication1
{
    public class GerneratorBase
    {
        public static string SufNameSpace { get; set; }
        public static string DetectNSTemplate = "using {0};" + System.Environment.NewLine;
        public DeclareFiledList GetSummaryFields()
        {

            DataTable dtProperty = ds.Tables["property"];
            DataTable dtManyToOne = ds.Tables["many-to-one"];
            DataTable dtcomponent = ds.Tables["component"];
            DeclareFiledList Summaryfields = new DeclareFiledList();
            if (dtProperty != null)
            {
                foreach (DataRow item in dtProperty.Rows)
                {
                    Summaryfields.FiledList.Add(new Field() { Name = item["name"].ToString(), TypeName = item["type"].ToString() });
                }
            }
            if (dtManyToOne != null)
            {
                foreach (DataRow item in dtManyToOne.Rows)
                {
                    string classname = item["class"].ToString();
                    if (classname.Contains(","))//Classname,Assembly
                    {
                        classname = classname.Substring(0, classname.IndexOf(","));
                        string fullClassName = classname;
                        if (classname.Contains("."))
                        {
                            int Lastindex = classname.LastIndexOf(".") + 1;

                            classname = classname.Substring(Lastindex, classname.Length - Lastindex);
                            string objecnamespace = string.Format(DetectNSTemplate, fullClassName.Substring(0, fullClassName.LastIndexOf(".")));
                            //DetectedNS = DetectedNS.Replace(objecnamespace, "");//make sure there is no duplcate NS
                            //DetectedNS += objecnamespace;

                        }
                    }
                    if (!classname.EndsWith("Enum"))
                    {
                        classname += "Summary";
                    }
                    Summaryfields.FiledList.Add(new Field() { Name = item["name"].ToString(), TypeName = classname });
                }
            }
            if (dtcomponent != null)
            {
                foreach (DataRow item in dtcomponent.Rows)
                {
                    Summaryfields.FiledList.Add(new Field() { Name = item["name"].ToString(), TypeName = item["class"].ToString() });
                }
            }
            return Summaryfields;
        }
        public DeclareFiledList GetListFields()
        {
            DeclareFiledList Listfields = new DeclareFiledList();
            DataTable dtcompositeelement = ds.Tables["composite-element"];
            DataTable dtidbag = ds.Tables["idbag"];
            DataTable dtset = ds.Tables["set"];
            DataTable dtonetomany = ds.Tables["one-to-many"];
            //if (dtcompositeelement != null)
            //{
            //    foreach (DataRow item in dtcompositeelement.Rows)
            //    {
            //        Detailfields.FiledList.Add(new Field() { Name = item["name"].ToString(), TypeName = item["class"].ToString() });
            //    }
            //}
            if (dtidbag != null)
            {
                foreach (DataRow item in dtidbag.Rows)
                {
                    Listfields.FiledList.Add(new Field() { Name = item["name"].ToString(), TypeName = "List<" + (dtcompositeelement.Select("idbag_id=" + item["idbag_id"]))[0]["class"].ToString() + ">" });
                }
            }
            if (dtset != null)
            {
                foreach (DataRow item in dtset.Rows)
                {
                    Listfields.FiledList.Add(new Field() { Name = item["name"].ToString(), TypeName = "List<" + (dtonetomany.Select("set_id=" + item["set_id"]))[0]["class"].ToString() + "Summary>" });
                }
            }
            return Listfields;
        }
        public DeclareFiledList GetDetailFields()
        {
            DeclareFiledList Detailfields = new DeclareFiledList();
            Detailfields.FiledList = Copy<List<Field>>(GetSummaryFields().FiledList);
            Detailfields.FiledList.AddRange(GetListFields().FiledList);
            return Detailfields;
        }
        public static T Copy<T>(T obj)
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter f = new BinaryFormatter();
            f.Serialize(m, obj);
            m.Seek(0, SeekOrigin.Begin);
            return (T)f.Deserialize(m);
        }

        public string ObjectName
        {
            get
            {
                DataTable dtClass = ds.Tables["class"];
                if (dtClass == null)
                {
                    throw new Exception("Mapping Class Not found");
                }
                return objectNamespace + ds.Tables["class"].Rows[0]["name"].ToString();
            }
        }
        public string xmlFilename = "";
        public string generatedText = ".gen";
        public string template { get; set; }
        public string objectNamespace = "";//"ClearCanvas.Healthcare.";
        public string GeneratedTemplateName
        {
            get
            {
                return string.Format(template, ObjectName);
            }
        }
        public static string CommonNS { get; set; }
        public static string ServiceNS { get; set; }
        public static string ComponentNS { get; set; }
        public static string ComponentControlNS { get; set; }
        public static string SuffixNS { get; set; }
        public static string EntityNS { get; set; }
        public string DetectedNS { get; set; }
        public static string templateFolder = "..\\..\\templates";
        public static string Type;
        public static string _GeneratedFilePath = "..\\..\\Generated";
        public string GeneratedFilePath
        {
            get
            {
                return Path.Combine(_GeneratedFilePath, Type);
            }

        }
        public string GeneratedContent = "";
        public DataSet ds = new DataSet();
        public GerneratorBase(DataSet dataset)
        {
            ds = dataset;
        }
        public virtual void GenerateNamSpace()
        {
            GeneratedContent = replaceNameSpace(GeneratedContent);
        }

        public string replaceNameSpace(string text)
        {
            text = text.Replace(NS_NAME.suffixNameSpance, SuffixNS);
            text = text.Replace(NS_NAME.commonNameSpance, CommonNS);
            text = text.Replace(NS_NAME.serviceNameSpance, ServiceNS);
            text = text.Replace(NS_NAME.componentNameSpance, ComponentNS);
            text = text.Replace(NS_NAME.componentControlNameSpance, ComponentControlNS);
            text = text.Replace(NS_NAME.entityNameSpance, EntityNS);
            text = text.Replace(NS_NAME.detectedNamespace, DetectedNS);
            return text;
        }
        public virtual void Generate()
        {
            if (string.IsNullOrEmpty(GeneratedContent))
                return;
            DirectoryInfo dir = new DirectoryInfo(GeneratedFilePath);
            if (!dir.Exists)
                dir.Create();
            GenerateNamSpace();
            if (!string.IsNullOrEmpty(GeneratedContent))
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(GeneratedFilePath, GeneratedTemplateName), false))
                {
                    sw.Write(GeneratedContent);
                }
            }
            FileInfo f = new FileInfo(Path.Combine(Path.Combine(templateFolder, Type), template.Replace(generatedText, "")));
            if (f.Exists)
            {

                string partialContent = "";
                using (StreamReader fr = new StreamReader(f.FullName))
                {
                    partialContent = fr.ReadToEnd();
                }
                partialContent = replaceNameSpace(partialContent);
                partialContent = partialContent.Replace("{0}", ObjectName);

                using (StreamWriter sw = new StreamWriter(Path.Combine(GeneratedFilePath, GeneratedTemplateName.Replace(generatedText, "")), false))
                {
                    sw.Write(partialContent);
                }
            }
        }
        public FileInfo GetTemplate(string fname)
        {
            FileInfo f = new FileInfo(Path.Combine(Path.Combine(templateFolder, Type), fname));
            if (f.Exists)
                return f;
            return null;
        }
        public string GetTemplateContent(string fname)
        {
            if (!GetTemplate(fname).Exists)
            {
                return "";
            }

            using (StreamReader sr = new StreamReader(GetTemplate(fname).OpenRead()))
            {
                string content = sr.ReadToEnd();
                return content;
            }
        }
        public void SaveGeneratedFile()
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(string.Format(template, ObjectName), GeneratedFilePath), false))
            {
                sw.Write(GeneratedContent);
            }
        }
    }
    public class NS_NAME
    {

        public const string entityNameSpance = "{$EntityNS}";
        public const string commonNameSpance = "{$CommonNS}";
        public const string suffixNameSpance = "{$Suffix}";
        public const string serviceNameSpance = "{$ServiceNS}";
        public const string componentNameSpance = "{$componentNS}";
        public const string componentControlNameSpance = "{$componentControlNS}";
        public const string detectedNamespace = "{$detectedNS}";
    }
    public class MappingObject
    {

    }
}
