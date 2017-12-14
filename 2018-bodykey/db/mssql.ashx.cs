using System;
using System.Collections;
using System.Web;
using NCD.DB;

namespace bodykey.db
{

    public class mssql : System.Web.IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            DBO dbo = new DBO();
            int num = dbo.GetRecordNum("select AccountId from BulkJob_Account");
            context.Response.Write("nissan num:" + num + "<br><br>");



            using(ReadSet rs = new ReadSet("select * from BulkJob_Account"))
            {
                while(rs.Read())
                {
                    Hashtable dataMap = rs.Map;
                    context.Response.Write("name:" + rs.GetString(dataMap, "AccountName") + "<br>");
                }
                rs.Dispose();
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
