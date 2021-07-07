using EADPPROJ.App_Code;
using System;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
    public partial class managementEditTeacherInfo : System.Web.UI.Page
    {
        Management management = new Management();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (search.Text != "")
                {
                    if (search.Text.Length == 9 && management.CheckSearchTextSubstringIsNumeric(search.Text.Substring(1, 7)) == true)
                    {
                        try
                        {
                            TeacherInfo.SelectCommand = "SELECT * FROM [tb_Teacher] WHERE [NRIC] = '" + search.Text + "'";
                            TeacherInfo.DataBind();
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
                            TeacherInfo.SelectCommand = "SELECT * FROM [tb_Teacher] WHERE [Name] LIKE '%" + search.Text + "%'";
                            TeacherInfo.DataBind();
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
                            TeacherInfo.SelectCommand = "SELECT * FROM [tb_Teacher] WHERE [NRIC] LIKE '%" + search.Text + "%' OR [Name] LIKE '%" + search.Text + "%'";
                            TeacherInfo.DataBind();
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
                            TeacherInfo.SelectCommand = "SELECT * FROM [tb_Teacher] WHERE [NRIC] LIKE '%" + search.Text + "%'";
                            TeacherInfo.DataBind();
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
                    TeacherInfo.SelectCommand = "SELECT * FROM [tb_Teacher] ORDER BY [NRIC]";
                    TeacherInfo.DataBind();
                    GridView1.DataBind();
                }


            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            var btn_Delete = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn_Delete.NamingContainer;
            string NRIC = row.Cells[0].Text;
            management.DeleteSelectedTeacherInfo(NRIC);
            Response.Redirect("./managementTeacher.aspx");
        }
    }
}