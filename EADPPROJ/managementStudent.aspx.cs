using EADPPROJ.App_Code;
using System;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementEditPersonalInfo”的 XML 注释
    public partial class managementEditPersonalInfo : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementEditPersonalInfo”的 XML 注释
    {

        Management management = new Management();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementEditPersonalInfo.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementEditPersonalInfo.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (IsPostBack)
            {
                if (search.Text != "")
                {
                    if (search.Text.Length == 7 && management.CheckSearchTextSubstringIsNumeric(search.Text.Substring(0, 5)) == true)
                    {
                        try
                        {
                            PersonalInfo.SelectCommand = "SELECT * FROM [tb_Student] WHERE [AdminNo] = '" + search.Text + "'";
                            PersonalInfo.DataBind();
                            GridView1.DataBind();
                        }
                        catch (Exception)
                        {
                            GridView1.Visible = false;
                            NoData.Visible = true;
                        }

                    }
                    else if (search.Text.Length > 7)
                    {
                        try
                        {
                            PersonalInfo.SelectCommand = "SELECT * FROM [tb_Student] WHERE [Name] LIKE '%" + search.Text + "%'";
                            PersonalInfo.DataBind();
                            GridView1.DataBind();
                        }
                        catch (Exception)
                        {
                            GridView1.Visible = false;
                            NoData.Visible = true;
                        }

                    }
                    else if (search.Text.Length < 7)
                    {
                        try
                        {
                            PersonalInfo.SelectCommand = "SELECT * FROM [tb_Student] WHERE [AdminNo] LIKE '%" + search.Text + "%' OR [Name] LIKE '%" + search.Text + "%'";
                            PersonalInfo.DataBind();
                            GridView1.DataBind();
                        }
                        catch (Exception)
                        {
                            GridView1.Visible = false;
                            NoData.Visible = true;
                        }

                    }
                    else
                    {
                        try
                        {
                            PersonalInfo.SelectCommand = "SELECT * FROM [tb_Student] WHERE [Name] LIKE '%" + search.Text + "%'";
                            PersonalInfo.DataBind();
                            GridView1.DataBind();
                        }
                        catch (Exception)
                        {
                            GridView1.Visible = false;
                            NoData.Visible = true;
                        }

                    }

                }
                else
                {
                    PersonalInfo.SelectCommand = "SELECT * FROM [tb_Student] ORDER BY [AdminNo]";
                    PersonalInfo.DataBind();
                    GridView1.DataBind();
                }

            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementEditPersonalInfo.btn_Delete_Click(object, EventArgs)”的 XML 注释
        protected void btn_Delete_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementEditPersonalInfo.btn_Delete_Click(object, EventArgs)”的 XML 注释
        {
            var btn_Delete = (Button)sender;
            GridViewRow row = (GridViewRow)btn_Delete.NamingContainer;
            string AdminNo = row.Cells[0].Text;
            management.DeleteSelectedStudentInfo(AdminNo);
            Session["successDelete"] = "true";
            Response.Redirect("./managementStudent.aspx");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementEditPersonalInfo.btn_Change_Click(object, EventArgs)”的 XML 注释
        protected void btn_Change_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementEditPersonalInfo.btn_Change_Click(object, EventArgs)”的 XML 注释
        {
            var change = (Button)sender;
            GridViewRow row = (GridViewRow)change.NamingContainer;
            TextBox newGrad = (TextBox)row.Cells[5].FindControl("newGraduation");
            int grad = Convert.ToInt32(newGrad.Text);
            string AdminNo = row.Cells[0].Text;
            management.EditGraduationYear(grad, AdminNo);
            Session["successEdit"] = "true";
            Response.Redirect("./managementStudent.aspx");
        }
    }
}