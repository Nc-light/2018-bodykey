using System;
using System.Web;
using System.Web.UI;

namespace bodykey
{

    public class test : System.Web.IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            context.Response.Write(context.Request["u"]+"<br><br>");
            context.Response.Write(context.Request.QueryString["u"] + "<br><br>");
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
