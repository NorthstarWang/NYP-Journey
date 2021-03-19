using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“WebForm1”的 XML 注释
    public partial class WebForm1 : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“WebForm1”的 XML 注释
    {   
        Question question = new Question();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“WebForm1.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)        
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“WebForm1.Page_Load(object, EventArgs)”的 XML 注释
        {
            
            if (Session["Account"] != null)
            {
                if (IsPostBack)
                {
                    if (Schooltype.SelectedValue != "All"&& search.Text==null)
                    {
                        Questions.SelectCommand = "SELECT [Id], [Title], [State], [Username], [SchoolType], [LastUpdate], [PostTime],[CreditReward] FROM [tb_Question] WHERE [SchoolType]='" + Schooltype.SelectedValue + "' Order By [LastUpdate] DESC";
                        string school = Schooltype.SelectedValue;
                        Questions.DataBind();
                        GridView1.DataBind();
                        RowCount.Text = GridView1.Rows.Count.ToString() + " Posts of "+ question.GetSpecificSchoolMaxId(question,school)+ " Total Posts";
                    }else if(Schooltype.SelectedValue != "All" && search.Text != null)
                    {
                        Questions.SelectCommand = "SELECT [Id], [Title], [State], [Username], [SchoolType], [LastUpdate], [PostTime],[CreditReward] FROM [tb_Question] WHERE [SchoolType]='" + Schooltype.SelectedValue + "' AND [Title] LIKE '%" + search.Text + "%' Order By [LastUpdate] DESC";
                        string school = Schooltype.SelectedValue;
                        Questions.DataBind();
                        GridView1.DataBind();
                        RowCount.Text = GridView1.Rows.Count.ToString() + " Posts of " + question.GetSpecificSchoolMaxId(question, school) + " Total Posts";
                    }else if (Schooltype.SelectedValue == "All" && search.Text != null)
                    {
                        Questions.SelectCommand = "SELECT [Id], [Title], [State], [Username], [SchoolType], [LastUpdate], [PostTime],[CreditReward] FROM [tb_Question] WHERE [Title] LIKE '%" + search.Text + "%' Order By [LastUpdate] DESC";
                        string school = Schooltype.SelectedValue;
                        Questions.DataBind();
                        GridView1.DataBind();
                        RowCount.Text = GridView1.Rows.Count.ToString() + " Posts of " + question.GetSpecificSchoolMaxId(question, school) + " Total Posts";
                    }
                    else
                    {
                        Questions.SelectCommand = "SELECT [Id], [Title], [State], [Username], [SchoolType], [LastUpdate], [PostTime],[CreditReward] FROM [tb_Question] Order By [LastUpdate] DESC";
                        int rowscount = Convert.ToInt32(question.GetMaxId(question));
                        Questions.DataBind();
                        GridView1.DataBind();
                        RowCount.Text = GridView1.Rows.Count.ToString() + " Posts of " + rowscount.ToString()+" Total Posts";
                    }

                }
                else
                {
                    int rowscount = Convert.ToInt32(question.GetMaxId(question));
                    RowCount.Text = GridView1.Rows.Count.ToString() + " Posts of " + rowscount.ToString() + " Total Posts";
                }
            }
            else
            {
                Response.Redirect("./login.aspx");
            }

        }


#pragma warning disable CS1591 // 缺少对公共可见类型或成员“WebForm1.Btn_Search_Click(object, EventArgs)”的 XML 注释
        protected void Btn_Search_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“WebForm1.Btn_Search_Click(object, EventArgs)”的 XML 注释
        {

        }
    }
}