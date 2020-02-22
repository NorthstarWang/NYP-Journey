using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
    public partial class invitationCode : System.Web.UI.Page
    {
        Login_Class login = new Login_Class();
        Notification notification = new Notification();
        protected void Page_Load(object sender, EventArgs e)
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Session["code"]=login.fillInInvitationCode(code.Text, Session["Account"].ToString());
            notification.invitationCodeNotification(notification, Session["Account"].ToString());
            notification.invitationCodeUseNotification(notification, login.getUserFromCode(code.Text));
            Response.Redirect("invitationCode.aspx");
        }
    }
}