using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.ServiceModel;
using ClearCanvas.Dicom;
using ClearCanvas.Common;

namespace WorklistServer
{
    public partial class WorklistServerConfig_View : Form
    {
        
        public string AE { get; set; }
        public int Port { get; set; }
        public string ConnectionString { get; set; }
        WorklistServer.Listener.WorklistListener listner;
        worklist wlMem = new worklist();
        public WorklistServerConfig_View()
        {
            InitializeComponent();
            FilWorklistInfor();
            GetListener();
        }
        public void FilWorklistInfor()
        {
            wlMem = new worklist();
            AE = wlMem.AE;
            Port = wlMem.Port;
            ConnectionString = wlMem.strConnect;
        }
        public void GetListener()
        {
            if (listner == null)
            {
                listner = new WorklistServer.Listener.WorklistListener(AE, Port, ConnectionString);
            }
        }
        private void WorklistServerConfig_View_Load(object sender, EventArgs e)
        {
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            FilWorklistInfor();
            this.txtAE.Text = AE;
            this.txtPort.Text = Port.ToString();
        }
        
        private void btnstart_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                FilWorklistInfor();
                Restart();
            }

        }
        public void Restart()
        {
            stop();
            listner = new WorklistServer.Listener.WorklistListener(AE, Port, ConnectionString);
            start();
        }
        bool validation()
        {
            AE = this.txtAE.Text;
            Port = int.Parse(this.txtPort.Text);
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void shToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void owToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void WorklistServerConfig_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listner != null)
            {
                listner.StopListening();
                listner = null;
                Application.Exit();
            }
        }
        public void start()
        {
            try
            {

                GetListener();
                listner.StartListening();
                this.btnStart.Enabled = false;
                this.btnStop.Enabled = true;

                MessageBox.Show(ConstMessage.StartSuccess);
                Platform.Log(LogLevel.Info, ConstMessage.StartSuccess);
                Platform.Log(LogLevel.Info, "Connected Database :" + ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ConstMessage.StopFailed,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Platform.Log(LogLevel.Info, ex.Message + " \n " + ex.StackTrace);
            }
        }
        public void stop()
        {
            try
            {
                listner.StopListening();

                MessageBox.Show(ConstMessage.StopSuccess);
                Platform.Log(LogLevel.Info, ConstMessage.StopSuccess);
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ConstMessage.StopFailed);
                Platform.Log(LogLevel.Info, ex.Message + " \n " + ex.StackTrace);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stop();
        }
    }
}
