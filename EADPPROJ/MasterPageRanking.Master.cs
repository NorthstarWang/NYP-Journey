using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
    public partial class MasterPageRanking : System.Web.UI.MasterPage
    {
        Profile profile = new Profile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
            {

                string ID = Session["Account"].ToString();
                if (ID.Length == 7)///If Student
                {
                    profileimg.Src = profile.GetStudentIcon(profile, ID);
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
                Session["ErrorAccount"] = "true";
                Response.Redirect("./index.aspx");
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["Account"] = null;
            Response.Redirect("./index.aspx");
        }
    }
}