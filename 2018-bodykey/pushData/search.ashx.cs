using System;
using System.Web;
using System.Web.Configuration;
using bodykey.App_Code;

namespace bodykey.pushData
{

    public class search : System.Web.IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //string sn = "1160039200107392";
            string appId = WebConfigurationManager.AppSettings["appId"];
            string appSecret = WebConfigurationManager.AppSettings["appSecret"];
            string timestamp = Common.GetTimestamp();
            string nonce = Common.GetRandomString(8, true, true, true, false, "");

            string checksum = Common.SH1(appId + appSecret + timestamp + nonce);
            //string msg = "appId:" + appId + "<br>";
            //msg += "appSecret:" + appSecret + "<br>";
            //msg += "timestamp:" + timestamp + "<br>";
            //msg += "nonce:" + nonce + "<br>";
            //msg += "checksum:" + checksum + "<br>";

            string url = "http://open.lifesense.com/openapi_service/device/api/getDeviceinfo";
            url += "?appid=" + appId;
            url += "&timestamp=" + timestamp;
            url += "&nonce=" + nonce;
            url += "&checksum=" + checksum;

            string datas = "{\"keytype\":\"sn\",\"value\":\"1160039200107392\"}";

            string returnMsg = "";
            try
            {
                returnMsg = bodykey.App_Code.HttpService.Post(datas, url, false, 30);
                context.Response.Write(returnMsg);

            }
            catch (Exception ex)
            {
                context.Response.Write("error:" + ex.ToString() + "<br><br>");
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
