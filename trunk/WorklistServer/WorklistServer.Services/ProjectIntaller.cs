using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace WorklistServer.Services
{
    [RunInstaller(true)]
    public partial class ProjectIntaller : Installer
    {
        public ProjectIntaller()
        {
            InitializeComponent();
        }
    }
}
