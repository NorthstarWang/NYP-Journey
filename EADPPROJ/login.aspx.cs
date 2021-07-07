using EADPPROJ.App_Code;
using System;
using System.Web.UI;

namespace EADPPROJ
{
    public partial class login : System.Web.UI.Page
    {
        Login_Class login_class = new Login_Class();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
            {
                Response.Redirect("./Index.aspx");
            }
 
            if (Session["Wrong"] == "true")
 
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.onload = function Show(){$('#loginErrorModal').modal('show');}", true);
                Session["Wrong"] = null;
            }
        }

        protected void btnForget_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/forgetPwd.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
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
                if (login_class.LoginTeacher(login_class).Tables[0].Rows.Count != 0)
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