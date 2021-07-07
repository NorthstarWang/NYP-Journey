using System;

namespace EADPPROJ
{
    public partial class Register : System.Web.UI.Page
    {
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

        protected void identity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void next_Click(object sender, EventArgs e)
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