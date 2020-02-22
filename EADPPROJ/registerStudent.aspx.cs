using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
    public partial class registerStudent : System.Web.UI.Page
    {
        Registration registration = new Registration();
        Notification notification = new Notification();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
            {
                Response.Redirect("./Index.aspx");
            }
            else
            {

            }
        }

        protected void register_Click(object sender, EventArgs e)
        {   int graduationInt = Convert.ToInt32(graduation.Text);
            if (adminNo.Text.Length.ToString()!="7" || Convert.ToInt32(adminNo.Text.Substring(0,2)) <17 || Convert.ToInt32(adminNo.Text.Substring(0, 2)) > 23)
            {
                Response.Write("<script>alert('Invalid Admin Number')</script>");
            }
            else if(pwd.Text != repwd.Text)
            {
                Response.Write("<script>alert('Password and Re-Type Password should be the same!')</script>");
            }
            else if(graduationInt < 2019 || graduationInt > 2023)
            {
                Response.Write("<script>alert('Invalid Graduation Year')</script>");
            }
            else 
            {
                    registration.AdminNo = adminNo.Text;
                    registration.Password = pwd.Text;
                    registration.Mail = mail.Text;
                    registration.Name = name.Text;
                    registration.Graduation = graduationInt;
                    registration.Sex = gender.Items[gender.SelectedIndex].Value;
                    registration.School = School.Items[School.SelectedIndex].Value;
                    registration.RegisterStudent(registration);
                    registration.GenerateStudentProfile(registration);
                    notification.RegistrationWelcome(notification, registration.AdminNo);
                    registration.generateInvitationCode(adminNo.Text);
                    Session["Account"] = adminNo.Text;
                    Session["Welcome"] = "true";
                    Response.Redirect("./index.aspx");
                

            }
            
        }
    }
}