using System;
using System.Text;
using System.Web;
using log4net;

namespace bodykey.pushData
{

    public class index : System.Web.IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ILog logs = LogManager.GetLogger("PushData");
            UTF8Encoding utf8e = new UTF8Encoding();
            string pushData = utf8e.GetString(context.Request.BinaryRead(context.Request.ContentLength));
            logs.Info("run pushData("+DateTime.Now.ToLongTimeString()+")" + pushData);
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
