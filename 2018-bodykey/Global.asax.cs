using System;
using System.Web;
using System.IO;
using log4net;

namespace bodykey
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\config\\Log4Net.config"));
        }

        protected void Application_BeginRequest()
        {
            ILog log = LogManager.GetLogger("Global");
            log.Info("global:"+Request.Url.ToString());
        }
    }
}
