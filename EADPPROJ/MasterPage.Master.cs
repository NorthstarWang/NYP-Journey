using EADPPROJ.App_Code;
using System;
using System.Web.UI;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPage”的 XML 注释
    public partial class MasterPage : System.Web.UI.MasterPage
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPage”的 XML 注释
    {
        Profile profile = new Profile();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPage.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPage.Page_Load(object, EventArgs)”的 XML 注释
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
                login_func.Style["display"] = "block";
                register_func.Style["display"] = "block";
                profileUrl.Style["display"] = "none";
                logout.Style["display"] = "none";
            }
#pragma warning disable CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            if (Session["Welcome"] == "true")
#pragma warning restore CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.onload = function Show(){$('#welcomeModal').modal('show');}", true);
                Session["Welcome"] = null;
            }

#pragma warning disable CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            if (Session["ErrorAccount"] == "true")
#pragma warning restore CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.onload = function Show(){$('#loginModal').modal('show');}", true);
                Session["ErrorAccount"] = null;
            }
#pragma warning disable CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            if (Session["LoginSuccess"] == "true")
#pragma warning restore CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.onload = function Show(){$('#loginSuccessModal').modal('show');}", true);
                Session["LoginSuccess"] = null;
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPage.btn_logout_Click(object, EventArgs)”的 XML 注释
        protected void btn_logout_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPage.btn_logout_Click(object, EventArgs)”的 XML 注释
        {
            Session["Account"] = null;
            Response.Redirect("./index.aspx");
        }
    }
}