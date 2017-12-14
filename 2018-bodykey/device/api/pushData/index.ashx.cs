using System;
using System.Web;
using log4net;

namespace bodykey.device.api.pushData
{

    public class index : System.Web.IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ILog logs = LogManager.GetLogger("PushData");

            logs.Info("run2 PushData:" + DateTime.Now.ToLongTimeString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
