using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“invitationCode”的 XML 注释
    public partial class invitationCode : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“invitationCode”的 XML 注释
    {
        Login_Class login = new Login_Class();
        Notification notification = new Notification();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“invitationCode.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“invitationCode.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Session["Account"] != null)
            {
                if (Session["code"] != null)
                {
                    Response.Write("<script language='javascript'>alert('" + Session["code"].ToString() + "');</script>");
                    Session["code"] = null;
                }
                codeno.Text = login.getInvitationCode(Session["Account"].ToString());
            }
            else
            {
                Session["ErrorAccount"] = "true";
                Response.Redirect("./index.aspx");
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“invitationCode.btnSubmit_Click(object, EventArgs)”的 XML 注释
        protected void btnSubmit_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“invitationCode.btnSubmit_Click(object, EventArgs)”的 XML 注释
        {
            Session["code"]=login.fillInInvitationCode(code.Text, Session["Account"].ToString());
            notification.invitationCodeNotification(notification, Session["Account"].ToString());
            notification.invitationCodeUseNotification(notification, login.getUserFromCode(code.Text));
            Response.Redirect("invitationCode.aspx");
        }
    }
}