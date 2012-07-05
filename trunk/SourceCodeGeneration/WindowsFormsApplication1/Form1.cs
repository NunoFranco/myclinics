using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GerneratorBase.SufNameSpace = string.IsNullOrEmpty(this.textBox1.Text) ? "" : "." + this.textBox1.Text;
            foreach (var item in lbFiles.Items)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(item.ToString());

                var type = typeof(GerneratorBase);

                List<Type> listOfDerivedClasses = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => x.IsSubclassOf(type))
                    .ToList();
                foreach (var derived in listOfDerivedClasses)
                {
                    var instance = Activator.CreateInstance(derived, ds);

                    MethodInfo method = derived.GetMethod("Generate");
                    method.Invoke(instance, null);
                    // etc.
                }
                MessageBox.Show("Done");
            }


        }
    }
}
