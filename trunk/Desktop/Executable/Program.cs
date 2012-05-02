#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections;
using System.Reflection;
using ClearCanvas.Common;
using ClearCanvas.Desktop.View.WinForms;
using System.Windows;
//using PACS_Security;
//using PACS_Security.View.WinForm;n 
#if !MONO

#endif

namespace ClearCanvas.Desktop.Executable
{
    class Program
    {
        #region Longchang added
        private static PluginInfo _PACS_Security = null;
        public static PluginInfo PACS_Security
        {
            get
            {
                if (_PACS_Security == null)
                {
                    foreach (var item in Platform.PluginManager.Plugins)
                    {
                        if (item.Assembly.FullName.Contains("PACS_Security.View.WinForm"))//Get out Pacs Security Assembly
                        {
                        }
                        else if (item.Assembly.FullName.Contains("PACS_Security"))//Get out Pacs Security Assembly
                        {
                            _PACS_Security = item;
                            break;

                        }
                    }
                }
                return _PACS_Security;
            }
        }

        static object InvokeMethodFromPlugin(PluginInfo p, string classname, string methodName)
        {
            MethodInfo showlogin = p.Assembly.CreateInstance(p.Assembly.GetName().Name + "." + classname, true).GetType().GetMethod(methodName);//.GetMethod("LoadLoginForm");
            //MethodInfo GetLoginMessage = p.Assembly.CreateInstance(p.Assembly.GetName().Name + "." + classname, true).GetType().GetMethod("GetLoginMessage");
            return showlogin.Invoke(null, null);
        }

        #endregion
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");
#if !MONO
            SplashScreenManager.DisplaySplashScreen();
#endif
            Platform.PluginManager.PluginLoaded += new EventHandler<PluginLoadedEventArgs>(OnPluginProgress);
            #region Longchang added to Delete tmp file each start app
            if (PACS_Security != null)
            {
                System.Threading.Thread.CurrentThread.Name = System.Guid.NewGuid().ToString();
                //string tmpFilePath = "";
                //object fname=InvokeMethodFromPlugin(PACS_Security, "PacsCommunicator", "GetTmpFileName");
                //object tmpFileExt=InvokeMethodFromPlugin(PACS_Security, "PacsCommunicator", "GetTmpFileExtension");
                //tmpFilePath = fname == null ? "" : fname.ToString();
                //System.IO.FileInfo f = new System.IO.FileInfo(tmpFilePath);
                //System.IO.DirectoryInfo dir = f.Directory;
                //foreach (var item in dir.GetFiles(tmpFileExt.ToString()))
                //{
                //    item.Delete();
                //}
            }
           
            #endregion
            // check for command line arguments
            if (args.Length > 0)
            {
                // for the sake of simplicity, this is a naive implementation (probably needs to change in future)
                // if there is > 0 arguments, assume the first argument is a class name
                // and bundle the subsequent arguments into a secondary array which is 
                // forwarded to the application root class
                string[] args1 = new string[args.Length - 1];
                Array.Copy(args, 1, args1, 0, args1.Length);

                Platform.StartApp(args[0], args1);
            }
            else
            {
                Platform.StartApp();
            }
        }

        private static void OnPluginProgress(object sender, PluginLoadedEventArgs e)
        {
            Platform.CheckForNullReference(e, "e");
#if !MONO
            SplashScreenManager.SetStatus(e.Message);

            if (e.PluginAssembly != null)
                SplashScreenManager.AddAssemblyIcon(e.PluginAssembly);
#endif
        }
    }
}
