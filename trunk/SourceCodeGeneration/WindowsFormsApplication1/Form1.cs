using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddfiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedlg = new OpenFileDialog();
            filedlg.Multiselect = true;
            filedlg.Filter = "*.xml|*.xml";
            if (filedlg.ShowDialog() == DialogResult.OK)
            {
                //foreach (var item in filedlg.FileNames )
                //{
                this.lbFiles.Items.AddRange(filedlg.FileNames);
                //}
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selecteditems = new ListBox.SelectedObjectCollection(lbFiles);
            int count = selecteditems.Count;
            while (selecteditems.Count > 0)
            {
                count = selecteditems.Count - 1;
                lbFiles.Items.Remove(selecteditems[count]);
            }
        }
        public void SaveSetting()
        {
            NSSeeting.Default.Common_NS = this.txtCommonNS.Text;
            NSSeeting.Default.ComponentControl_NS = this.txtComponentControlNS.Text;
            NSSeeting.Default.Component_NS = this.txtComponentNS.Text;
            NSSeeting.Default.Entity_NS = this.txtEntityNS.Text;
            NSSeeting.Default.Service_NS = this.txtServiceNS.Text;
            NSSeeting.Default.ProjectRoot = this.txtProjectRoot.Text;
            NSSeeting.Default.Save();
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GerneratorBase.SufNameSpace = string.IsNullOrEmpty(this.textBox1.Text) ? "" : "." + this.textBox1.Text;

            GerneratorBase.CommonNS = txtCommonNS.Text;
            GerneratorBase.ServiceNS = txtServiceNS.Text;
            GerneratorBase.EntityNS = txtEntityNS.Text;
            GerneratorBase.ComponentNS = txtComponentNS.Text;
            GerneratorBase.ComponentControlNS = txtComponentControlNS.Text;

            SaveSetting();
            GerneratorBase.Type = this.cboType.Text;
            string conventionName = ".hbm.xml";
            foreach (var item in lbFiles.Items)
            {

                FileInfo f = new FileInfo(item.ToString());
                GerneratorBase.SufNameSpace = "." + f.Name.Replace(conventionName, "");
                GerneratorBase.SuffixNS = "." + f.Name.Replace(conventionName, "") + "s";
                DataSet ds = new DataSet();
                ds.ReadXml(item.ToString());

                var type = typeof(GerneratorBase);

                List<Type> listOfDerivedClasses = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => x.IsSubclassOf(type))
                    .ToList();
                foreach (var derived in listOfDerivedClasses)
                {
                    //Attribute a=GetAttribute(this.cboType.Text).GetType();
                    var att = Attribute.GetCustomAttribute(derived, GetAttribute(this.cboType.Text).GetType());
                    if (att == null)//generate type in selected combobox
                        continue;
                    var instance = Activator.CreateInstance(derived, ds);

                    MethodInfo method = derived.GetMethod("Generate");
                    method.Invoke(instance, null);
                    // etc.
                }
                MessageBox.Show("Done");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(GerneratorBase.templateFolder);
            foreach (var sub in dir.GetDirectories())
            {
                this.cboType.Items.Add(sub.Name);
            }
            if (this.cboType.Items.Count > 0)
            {
                this.cboType.SelectedIndex = 0;
            }
            this.txtCommonNS.Text = NSSeeting.Default.Common_NS;
            this.txtComponentControlNS.Text = NSSeeting.Default.ComponentControl_NS;
            this.txtComponentNS.Text = NSSeeting.Default.Component_NS;
            this.txtEntityNS.Text = NSSeeting.Default.Entity_NS;
            this.txtServiceNS.Text = NSSeeting.Default.Service_NS;
            this.txtProjectRoot.Text = NSSeeting.Default.ProjectRoot;
        }

        public Attribute GetAttribute(string name)
        {
            switch (name.ToLower())
            {
                case "common":
                    return new Common();
                case "services":
                    return new Services();
                case "component":
                    return new Component();
                default:
                    return null;
            }
        }
    }
}
