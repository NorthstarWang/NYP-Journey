using EADPPROJ.App_Code;
using System;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“registerTeacher”的 XML 注释
    public partial class registerTeacher : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“registerTeacher”的 XML 注释
    {
        Registration registration = new Registration();
        Notification notification = new Notification();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“registerTeacher.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“registerTeacher.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Session["Account"] != null)
            {
                Response.Redirect("./Index.aspx");
            }
            else
            {

            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“registerTeacher.register_Click(object, EventArgs)”的 XML 注释
        protected void register_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“registerTeacher.register_Click(object, EventArgs)”的 XML 注释
        {
            DateTime date_of_birth = Convert.ToDateTime(DOB.Text);
            string nric_text = NRIC.Text.ToString();
            if (NRIC.Text.Length.ToString() != "9" || Char.IsNumber(nric_text[8]) || Char.IsNumber(nric_text[0]))
            {
                Response.Write("<script>alert('Invalid NRIC')</script>");
            }
            else if (pwd.Text != repwd.Text)
            {
                Response.Write("<script>alert('Password and Re-Type Password should be the same!')</script>");
            }
            else
            {
                try
                {
                    registration.NRIC = NRIC.Text;
                    registration.Password = pwd.Text;
                    registration.Mail = mail.Text;
                    registration.Name = name.Text;
                    registration.DOB = date_of_birth;
                    registration.Sex = gender.Items[gender.SelectedIndex].Value;
                    registration.RegisterTeacher(registration);
                    registration.GenerateTeacherProfile(registration);
                    notification.RegistrationWelcome(notification, registration.NRIC);
                    Session["Account"] = NRIC.Text;
                    registration.generateInvitationCode(NRIC.Text);
                    Session["Welcome"] = "true";
                    Response.Redirect("./index.aspx");
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('This NRIC has already registered!')</script>");
                }


            }
        }
    }
}