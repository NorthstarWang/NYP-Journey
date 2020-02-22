using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        Profile profile = new Profile();
        protected void Page_Load(object sender, EventArgs e)
        {
                if (Session["Account"] != null)
                {
                    login_func.Style["display"] = "none";
                    register_func.Style["display"] = "none";
                    profileimg.Style["display"] = "block";
                    logout.Style["display"] = "block";
                appGroup.Style["display"] = "block";

                string ID = Session["Account"].ToString();
                    if (ID.Length == 7)///If Student
                    {
                        profileimg.Src = profile.GetStudentIcon(profile,ID);
                        profileUrl.HRef += "?id=" + Session["Account"].ToString();
                    }
                    else if (ID.Length == 9)///If Sensei
                    {
                        profileimg.Src = profile.GetTeacherIcon(profile, ID);
                        profileUrl.HRef += "?id=" + Session["Account"].ToString();
                    }
                    else///If Admin
                    {
                        profileimg.Src = profile.GetAdminIcon(profile, ID);
                        profileUrl.HRef += "?id=" + Session["Account"].ToString();
                    }
                }
                else
                {
                    login_func.Style["display"] = "block";
                    register_func.Style["display"] = "block";
                    profileimg.Style["display"] = "none";
                    logout.Style["display"] = "none";
                }
            if (Session["Welcome"] == "true")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.onload = function Show(){$('#welcomeModal').modal('show');}", true);
                Session["Welcome"] = null;
            }

            if (Session["ErrorAccount"] == "true")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.onload = function Show(){$('#loginModal').modal('show');}", true);
                Session["ErrorAccount"] = null;
            }
            if (Session["LoginSuccess"] == "true")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.onload = function Show(){$('#loginSuccessModal').modal('show');}", true);
                Session["LoginSuccess"] = null;
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["Account"] = null;
            Response.Redirect("./index.aspx");
        }
    }
}