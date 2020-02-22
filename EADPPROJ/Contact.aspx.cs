using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EducationDB.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Contact (Name,Email_ID,Subject_Of_Complaint,Complaint) values('" + tbName.Text + "', '" + tbEmail.Text + "', '" + tbSubject.Text + "', '" + tbComplaint.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Complaint Successfully Sent!!";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbEmail.Text = "";
            tbSubject.Text = "";
            tbComplaint.Text = "";
        }
    }
}