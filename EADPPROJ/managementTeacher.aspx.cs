using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementEditTeacherInfo”的 XML 注释
    public partial class managementEditTeacherInfo : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementEditTeacherInfo”的 XML 注释
    {
        Management management = new Management();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementEditTeacherInfo.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementEditTeacherInfo.Page_Load(object, EventArgs)”的 XML 注释
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementEditTeacherInfo.Delete_Click(object, EventArgs)”的 XML 注释
        protected void Delete_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementEditTeacherInfo.Delete_Click(object, EventArgs)”的 XML 注释
        {
            var btn_Delete = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn_Delete.NamingContainer;
            string NRIC = row.Cells[0].Text;
            management.DeleteSelectedTeacherInfo(NRIC);
            Response.Redirect("./managementTeacher.aspx");
        }
    }
}