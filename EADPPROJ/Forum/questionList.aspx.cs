using EADPPROJ.App_Code;
using System;

namespace EADPPROJ
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Question question = new Question();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Account"] != null)
            {
                if (IsPostBack)
                {
                    if (Schooltype.SelectedValue != "All" && search.Text == null)
                    {
                        Questions.SelectCommand = "SELECT [Id], [Title], [State], [Username], [SchoolType], [LastUpdate], [PostTime],[CreditReward] FROM [tb_Question] WHERE [SchoolType]='" + Schooltype.SelectedValue + "' Order By [LastUpdate] DESC";
                        string school = Schooltype.SelectedValue;
                        Questions.DataBind();
                        GridView1.DataBind();
                        RowCount.Text = GridView1.Rows.Count.ToString() + " Posts of " + question.GetSpecificSchoolMaxId(question, school) + " Total Posts";
                    }
                    else if (Schooltype.SelectedValue != "All" && search.Text != null)
                    {
                        Questions.SelectCommand = "SELECT [Id], [Title], [State], [Username], [SchoolType], [LastUpdate], [PostTime],[CreditReward] FROM [tb_Question] WHERE [SchoolType]='" + Schooltype.SelectedValue + "' AND [Title] LIKE '%" + search.Text + "%' Order By [LastUpdate] DESC";
                        string school = Schooltype.SelectedValue;
                        Questions.DataBind();
                        GridView1.DataBind();
                        RowCount.Text = GridView1.Rows.Count.ToString() + " Posts of " + question.GetSpecificSchoolMaxId(question, school) + " Total Posts";
                    }
                    else if (Schooltype.SelectedValue == "All" && search.Text != null)
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
                        RowCount.Text = GridView1.Rows.Count.ToString() + " Posts of " + rowscount.ToString() + " Total Posts";
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

        protected void Btn_Search_Click(object sender, EventArgs e)
        {

        }
    }
}