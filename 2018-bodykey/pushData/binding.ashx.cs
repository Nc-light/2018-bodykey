using System;
using System.Web.Configuration;
using System.Web;
using bodykey.App_Code;

namespace bodykey.pushData
{

    public class binding : System.Web.IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string appId = WebConfigurationManager.AppSettings["appId"];
            string appSecret = WebConfigurationManager.AppSettings["appSecret"];
            string timestamp = Common.GetTimestamp();
            string nonce = Common.GetRandomString(8, true, true, true, false, "");
            string deviceId = context.Request["deviceId"];

            if (string.IsNullOrWhiteSpace(deviceId))
                deviceId = "b1020801a380";

            string checksum = Common.SH1(appId + appSecret + timestamp + nonce);
            //string msg = "appId:" + appId + "<br>";
            //msg += "appSecret:" + appSecret + "<br>";
            //msg += "timestamp:" + timestamp + "<br>";
            //msg += "nonce:" + nonce + "<br>";
            //msg += "checksum:" + checksum + "<br>";

            //context.Response.Write("msg:"+msg);

            string url = "http://open.lifesense.com/openapi_service/device/api/bindDevice";
            url += "?appid=" + appId;
            url += "&timestamp=" + timestamp;
            url += "&nonce=" + nonce;
            url += "&checksum=" + checksum;

            string datas = "{\"deviceId\":\"" + deviceId + "\",\"mobile\":\"18565287488\",\"userNo\":\"0\"}";

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
