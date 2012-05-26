using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using WorklistServer.Listener;
using ClearCanvas.Dicom.Network;
namespace WorklistServer.Services
{
    public partial class WorklistService : ServiceBase
    {
        WorklistListener listener;
        public WorklistService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            worklist wl = new worklist();
            listener = new WorklistListener(wl.AE, wl.Port, wl.strConnect);

            listener.StartListening();
        }

        protected override void OnStop()
        {
            listener.StopListening();
        }
    }
}
