using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
    public partial class managementEditPersonalInfo : System.Web.UI.Page
    {

        Management management = new Management();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (search.Text != "")
                {
                    if (search.Text.Length == 7 && management.CheckSearchTextSubstringIsNumeric(search.Text.Substring(0,5))==true)
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

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            var btn_Delete = (Button)sender;
            GridViewRow row = (GridViewRow)btn_Delete.NamingContainer;
            string AdminNo = row.Cells[0].Text;
            management.DeleteSelectedStudentInfo(AdminNo);
            Session["successDelete"] = "true";
            Response.Redirect("./managementStudent.aspx");
        }

        protected void btn_Change_Click(object sender, EventArgs e)
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