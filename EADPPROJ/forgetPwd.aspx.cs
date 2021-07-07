using EADPPROJ.App_Code;
using System;
using System.Data;

namespace EADPPROJ
{
    public partial class forgetPwd : System.Web.UI.Page
    {
        ForgetPassword forgetPassword = new ForgetPassword();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            if (username.Text.Length.ToString() == "7")
            {
                try
                {
                    forgetPassword.AdminNo = username.Text;
                    ds = forgetPassword.GetStudentMail(forgetPassword, "tb_Student");
                    string name = Convert.ToString(ds.Tables[0].Rows[0]["Mail"]);
                    ds = forgetPassword.GetStudentPassword(forgetPassword, "tb_Student");
                    string password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                    forgetPassword.SendMail(forgetPassword, name, password);
                    Response.Write("<script>alert('Please Check Your Email')</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('This account does not exist')</script>");
                }

            }
            else if (username.Text.Length.ToString() == "9")
            {
                try
                {
                    forgetPassword.NRIC = username.Text;
                    ds = forgetPassword.GetTeacherMail(forgetPassword, "tb_Teacher");
                    string name = Convert.ToString(ds.Tables[0].Rows[0]["Mail"]);
                    ds = forgetPassword.GetTeacherPassword(forgetPassword, "tb_Teacher");
                    string password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                    forgetPassword.SendMail(forgetPassword, name, password);
                    Response.Write("<script>alert('Please Check Your Email')</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('This account does not exist')</script>");
                }
            }
            else
            {
                try
                {
                    forgetPassword.Username = username.Text;
                    ds = forgetPassword.GetAdminMail(forgetPassword, "tb_Admin");
                    string name = Convert.ToString(ds.Tables[0].Rows[0]["Mail"]);
                    ds = forgetPassword.GetAdminPassword(forgetPassword, "tb_Admin");
                    string password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                    forgetPassword.SendMail(forgetPassword, name, password);
                    Response.Write("<script>alert('Please Check Your Email')</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('This account does not exist')</script>");
                }
            }

        }
    }
}