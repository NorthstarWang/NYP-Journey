using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using EADPPROJ.App_Code;
using System.Data.SqlClient;
using System.Data;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Global”的 XML 注释
    public class Global : HttpApplication
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Global”的 XML 注释
    {
        Database data = new Database();

        private System.ComponentModel.IContainer components = null;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Global.Engine”的 XML 注释
        public static UChat.ChatEngine.IChatEngine Engine = new UChat.ChatEngine.ChatEngine();
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Global.Engine”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Global.Global()”的 XML 注释
        public Global()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Global.Global()”的 XML 注释
        {
            InitializeComponent();
        }
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 10;
            Session["IP"] = Request.UserHostAddress;
            Session["LoginTime"] = DateTime.Now;
            Session["Browser"] = Request.Browser.Browser;
            Session["OS"] = Request.Browser.Platform;
        }
        void Session_End(object sender, EventArgs e)
        {
            Session["LeaveTime"] = DateTime.Now;
            if (Session["Account"] == null)
            {
                SqlParameter[] prams = {
                data.MakeInParam("@IP",  SqlDbType.VarChar, 50, Session["IP"]),
                data.MakeInParam("@LoginTime",  SqlDbType.VarChar, 50, Session["LoginTime"]),
                data.MakeInParam("@LeaveTime",  SqlDbType.VarChar, 50, Session["LeaveTime"]),
                data.MakeInParam("@Browser",  SqlDbType.VarChar, 50, Session["Browser"]),
                data.MakeInParam("@OS",  SqlDbType.VarChar, 50, Session["OS"]),
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50, "Guest")
                };
                data.RunProc("INSERT INTO tb_ConnectionRecord (IP,LoginTime,LeaveTime,Browser,OS,Username) VALUES(@IP,@LoginTime,@LeaveTime,@Browser,@OS,@Username)", prams);
            }
            else
            {
                SqlParameter[] prams = {
                data.MakeInParam("@IP",  SqlDbType.VarChar, 50, Session["IP"]),
                data.MakeInParam("@LoginTime",  SqlDbType.VarChar, 50, Session["LoginTime"]),
                data.MakeInParam("@LeaveTime",  SqlDbType.VarChar, 50, Session["LeaveTime"]),
                data.MakeInParam("@Browser",  SqlDbType.VarChar, 50, Session["Browser"]),
                data.MakeInParam("@OS",  SqlDbType.VarChar, 50, Session["OS"]),
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50, Session["Account"])
                };
                data.RunProc("INSERT INTO tb_ConnectionRecord (IP,LoginTime,LeaveTime,Browser,OS,Username) VALUES(@IP,@LoginTime,@LeaveTime,@Browser,@OS,@Username)", prams);
            }
            
        }
    }
}