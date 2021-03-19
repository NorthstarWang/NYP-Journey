using System;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Register”的 XML 注释
    public partial class Register : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Register”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Register.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Register.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Session["Account"] != null)
            {
                Response.Redirect("./Index.aspx");
            }
            else
            {

            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Register.identity_SelectedIndexChanged(object, EventArgs)”的 XML 注释
        protected void identity_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Register.identity_SelectedIndexChanged(object, EventArgs)”的 XML 注释
        {

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Register.next_Click(object, EventArgs)”的 XML 注释
        protected void next_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Register.next_Click(object, EventArgs)”的 XML 注释
        {
            if (identityStudent.Checked)
            {
                Response.Redirect("registerStudent.aspx");
            }
            else if (identityTeacher.Checked)
            {
                Response.Redirect("registerTeacher.aspx");
            }
            else
            {
                Session["NoChoice"] = "true";
                Response.Redirect("registerType.aspx");
            }

        }
    }
}