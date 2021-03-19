using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageBlog”的 XML 注释
    public partial class MasterPageBlog : System.Web.UI.MasterPage
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageBlog”的 XML 注释
    {
        Profile profile = new Profile();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageBlog.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageBlog.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Session["Account"] != null)
            {
                login_func.Style["display"] = "none";
                register_func.Style["display"] = "none";
                profileUrl.Style["display"] = "block";
                logout.Style["display"] = "block";
                appGroup.Style["display"] = "block";

                string ID = Session["Account"].ToString();
#pragma warning disable CS1587 // XML 注释没有放在有效语言元素上
                if (ID.Length == 7)///If Student
                {
#pragma warning restore CS1587 // XML 注释没有放在有效语言元素上
                    profileimg.Src = profile.GetStudentIcon(profile, ID);
                    profileUrl.HRef += "?id=" + Session["Account"].ToString();
                }
#pragma warning disable CS1587 // XML 注释没有放在有效语言元素上
                else if (ID.Length == 9)///If Sensei
                {
#pragma warning restore CS1587 // XML 注释没有放在有效语言元素上
                    profileimg.Src = profile.GetTeacherIcon(profile, ID);
                    profileUrl.HRef += "?id=" + Session["Account"].ToString();
                }
#pragma warning disable CS1587 // XML 注释没有放在有效语言元素上
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
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageBlog.btn_logout_Click(object, EventArgs)”的 XML 注释
        protected void btn_logout_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageBlog.btn_logout_Click(object, EventArgs)”的 XML 注释
        {
            Session["Account"] = null;
            Response.Redirect("./index.aspx");
        }
    }
}