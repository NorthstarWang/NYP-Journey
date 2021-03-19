using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“login”的 XML 注释
    public partial class login : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“login”的 XML 注释
    {
        Login_Class login_class = new Login_Class();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“login.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“login.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Session["Account"]!=null)
            {
                Response.Redirect("./Index.aspx");
            }
#pragma warning disable CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            if(Session["Wrong"] == "true")
#pragma warning restore CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.onload = function Show(){$('#loginErrorModal').modal('show');}", true);
                Session["Wrong"] = null;
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“login.btnForget_Click(object, EventArgs)”的 XML 注释
        protected void btnForget_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“login.btnForget_Click(object, EventArgs)”的 XML 注释
        {
            Response.Redirect("~/forgetPwd.aspx");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“login.btnLogin_Click(object, EventArgs)”的 XML 注释
        protected void btnLogin_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“login.btnLogin_Click(object, EventArgs)”的 XML 注释
        {
            
            if (username.Text.Length.ToString() == "7")
            {
                    login_class.AdminNo = username.Text;
                    login_class.Password = password.Text;
                if (login_class.LoginStudent(login_class).Tables[0].Rows.Count != 0)
                {
                    Session["LoginSuccess"] = "true";
                    Session["Account"] = username.Text;
                    Response.Redirect("./Index.aspx");
                }
                else
                {
                    Session["Wrong"] = "true";
                    Response.Redirect("./login.aspx");
                }
                
            }
            else if (username.Text.Length.ToString() == "9")
            {
                login_class.NRIC = username.Text;
                login_class.Password = password.Text;
                if(login_class.LoginTeacher(login_class).Tables[0].Rows.Count != 0)
                {
                    Session["LoginSuccess"] = "true";
                    Session["Account"] = username.Text;
                    Response.Redirect("./Index.aspx");
                }
                else
                {
                    Session["Wrong"] = "true";
                    Response.Redirect("./login.aspx");
                }
            }
            else
            {
                login_class.Username = username.Text;
                login_class.Password = password.Text;
                if (login_class.LoginAdmin(login_class).Tables[0].Rows.Count != 0)
                {
                    Session["LoginSuccess"] = "true";
                    Session["Account"] = username.Text;
                    Response.Redirect("./Index.aspx");
                }
                else
                {
                    Session["Wrong"] = "true";
                    Response.Redirect("./login.aspx");
                }
            }
        }
    }
}