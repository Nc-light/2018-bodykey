using System;
using System.Text;
using System.Web;
using System.Net;
using log4net;

namespace bodykey.pushData
{

    public class client : System.Web.IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ILog logs = LogManager.GetLogger("client");
            string requestType = context.Request["requestType"];
            string uri = "http://2018-bodykey.amway.eekui.link/pushData";

            if(requestType=="WebClient")
            {
                WebClient client = new WebClient();
                Byte[] pageData = client.DownloadData(uri);
                //string pageHtml = Encoding.UTF8.GetString(pageData);

                logs.Fatal("WebClient:" + DateTime.Now.ToLongTimeString());
            }
            else if (requestType == "HttpWebRequest")
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri); 

                logs.Fatal("HttpWebRequest:" + DateTime.Now.ToLongTimeString());
            }

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
