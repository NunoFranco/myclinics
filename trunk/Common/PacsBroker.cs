using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Threading;
namespace ClearCanvas.Common
{
    public class PacsBroker
    {
        private static PluginInfo _PACS_Security = null;
        private static PluginInfo _PACS_Security_ViewWinform = null;
        public static string GetConnectedText(string hostname)
        {
            try
            {
                object result = InvokeMethodFromPlugin(PACS_Security, "PacsCommunicator", "GetConnectedText", new string[] { hostname });
                if (result == null)
                    return "";
                return result.ToString();
            }
            catch (Exception ex)
            {
                Platform.Log(LogLevel.Error, ex);
            }
            return "";
        }
        public static PluginInfo PACS_Security_ViewWinform
        {
            get
            {
                if (_PACS_Security_ViewWinform == null)
                {
                    foreach (var item in Platform.PluginManager.Plugins)
                    {
                        if (item.Assembly.FullName.Contains("PACS_Security.View.WinForm"))//Get out Pacs Security Assembly
                        {
                            _PACS_Security_ViewWinform = item;
                            break;
                        }
                    }
                }
                return _PACS_Security_ViewWinform;
            }
        }
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

        public static object InvokeMethodFromPlugin(PluginInfo p, string classname, string methodName, params string[] param)
        {
            try
            {
                MethodInfo method = p.Assembly.CreateInstance(p.Assembly.GetName().Name + "." + classname, true).GetType().GetMethod(methodName);//.GetMethod("LoadLoginForm");
                return method.Invoke(null, param);
            }
            catch (Exception ex)
            {
                Platform.Log(LogLevel.Error, "System error");
                Platform.Log(LogLevel.Error, ex);
                return null;
            }

        }
        public object InvokeMethodFromPlugin(PluginInfo p, string classname, string methodName)
        {
            MethodInfo showlogin = p.Assembly.CreateInstance(p.Assembly.GetName().Name + "." + classname, true).GetType().GetMethod(methodName);//.GetMethod("LoadLoginForm");
            //MethodInfo GetLoginMessage = p.Assembly.CreateInstance(p.Assembly.GetName().Name + "." + classname, true).GetType().GetMethod("GetLoginMessage");
            return showlogin.Invoke(null, null);
        }

        public static bool IsRisRunning()
        {
            if (Thread.CurrentPrincipal.Identity.Name != "")
            {
                return true;
            }
            return false;
        }

        public static bool isConnectedServer(string hostname)
        {

            object result = PacsBroker.InvokeMethodFromPlugin(PacsBroker.PACS_Security, "PacsCommunicator", "isConnect", hostname);
            bool isConnectedServer;
            if (!bool.TryParse(result.ToString(), out isConnectedServer))
            {
                Platform.ShowMessageBox("System error, Application termiated");
                Platform.Log(LogLevel.Error, "Pacscomunication isConnect return error result");
                throw new Exception("System error");
            }
            //string txt=ConnectedText(server.Host);
            //if (txt != "")
            //    server.NameOfServer = server.NameOfServer.Replace(txt, "");

            //if (isConnectedServer)
            //{
            //    server.NameOfServer += txt;
            //}
            return isConnectedServer;
        }
        public static object ProcessLogout(string hostname)
        {
            return InvokeMethodFromPlugin(PacsBroker.PACS_Security, "PacsCommunicator", "proccessLogout", hostname);
        }
        public static object ProcessLogin(string hostname, string port,string servername)
        {
            string[] param = new string[] { hostname, port, servername };
            return InvokeMethodFromPlugin(PacsBroker.PACS_Security_ViewWinform, "Launcher", "LoadLoginForm", param);
        }
        public static bool isNeedLogin()
        {
            object result = InvokeMethodFromPlugin(PacsBroker.PACS_Security, "PacsCommunicator", "IsNeedLogin", null);
            return Convert.ToBoolean(result.ToString());
        }
        public static string GetCurrentPacsUserName(string servername)
        {
            object result = InvokeMethodFromPlugin(PacsBroker.PACS_Security, "PacsCommunicator", "GetCurrentPacsUserName", servername);
            if (result == null)
                return "";
            return result.ToString();
        }
    }
}
