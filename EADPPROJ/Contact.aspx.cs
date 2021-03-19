using System;
using System.Data.SqlClient;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Contact”的 XML 注释
    public partial class Contact : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Contact”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Contact.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Contact.Page_Load(object, EventArgs)”的 XML 注释
        {

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Contact.btnSubmit_Click(object, EventArgs)”的 XML 注释
        protected void btnSubmit_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Contact.btnSubmit_Click(object, EventArgs)”的 XML 注释
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EducationDB.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Contact (Name,Email_ID,Subject_Of_Complaint,Complaint) values('" + tbName.Text + "', '" + tbEmail.Text + "', '" + tbSubject.Text + "', '" + tbComplaint.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Complaint Successfully Sent!!";
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Contact.btnClear_Click(object, EventArgs)”的 XML 注释
        protected void btnClear_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Contact.btnClear_Click(object, EventArgs)”的 XML 注释
        {
            tbName.Text = "";
            tbEmail.Text = "";
            tbSubject.Text = "";
            tbComplaint.Text = "";
        }
    }
}