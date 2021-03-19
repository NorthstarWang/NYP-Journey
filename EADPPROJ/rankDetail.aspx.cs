using EADPPROJ.App_Code;
using System;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“rankDetail”的 XML 注释
    public partial class rankDetail : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“rankDetail”的 XML 注释
    {
        Profile profile = new Profile();
        Question question = new Question();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“rankDetail.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“rankDetail.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Request.QueryString["type"] == "Blog")
            {
                userRank.Visible = false;
                questionRank.Visible = false;
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    LinkButton profile = (LinkButton)item.FindControl("viewProfile");
                    LinkButton blog = (LinkButton)item.FindControl("viewBlog");
                    HiddenField poster = (HiddenField)item.FindControl("posterId");
                    HiddenField id = (HiddenField)item.FindControl("blogId");
                    profile.PostBackUrl = "./profile.aspx?id=" + poster.Value;
                    blog.PostBackUrl = "./blogDetail.aspx?id=" + id.Value;
                }
                foreach (RepeaterItem item in Repeater2.Items)
                {
                    LinkButton profile = (LinkButton)item.FindControl("viewProfile");
                    LinkButton blog = (LinkButton)item.FindControl("viewBlog");
                    HiddenField poster = (HiddenField)item.FindControl("posterId");
                    HiddenField id = (HiddenField)item.FindControl("blogId");
                    profile.PostBackUrl = "./profile.aspx?id=" + poster.Value;
                    blog.PostBackUrl = "./blogDetail.aspx?id=" + id.Value;
                }
            }
            else if (Request.QueryString["type"] == "User")
            {
                blogRank.Visible = false;
                questionRank.Visible = false;
                foreach (RepeaterItem item in Repeater3.Items)
                {
                    HiddenField id = (HiddenField)item.FindControl("username");
                    LinkButton viewProfile = (LinkButton)item.FindControl("viewProfile");
                    viewProfile.PostBackUrl = "./profile.aspx?id=" + id.Value;
                }
                foreach (RepeaterItem item in Repeater4.Items)
                {
                    HiddenField id = (HiddenField)item.FindControl("username");
                    LinkButton viewProfile = (LinkButton)item.FindControl("viewProfile");
                    viewProfile.PostBackUrl = "./profile.aspx?id=" + id.Value;
                }
                foreach (RepeaterItem item in Repeater5.Items)
                {
                    HiddenField id = (HiddenField)item.FindControl("username");
                    LinkButton viewProfile = (LinkButton)item.FindControl("viewProfile");
                    viewProfile.PostBackUrl = "./profile.aspx?id=" + id.Value;

                }
                foreach (RepeaterItem item in Repeater6.Items)
                {
                    HiddenField id = (HiddenField)item.FindControl("username");
                    LinkButton viewProfile = (LinkButton)item.FindControl("viewProfile");
                    viewProfile.PostBackUrl = "./profile.aspx?id=" + id.Value;
                }
            }
            else if (Request.QueryString["type"] == "Question")
            {
                blogRank.Visible = false;
                userRank.Visible = false;
                foreach (RepeaterItem item in Repeater7.Items)
                {
                    HiddenField id = (HiddenField)item.FindControl("questionCode");
                    Label title = (Label)item.FindControl("title");
                    Label poster = (Label)item.FindControl("poster");
                    LinkButton viewProfile = (LinkButton)item.FindControl("viewProfile");
                    LinkButton viewQuestion = (LinkButton)item.FindControl("viewQuestion");
                    title.Text = question.GetQuestionTitle(question, Convert.ToInt32(id.Value));
                    poster.Text = question.GetQuestionPoster(question, Convert.ToInt32(id.Value));
                    viewProfile.PostBackUrl = "./profile.aspx?id=" + question.GetQuestionPoster(question, Convert.ToInt32(id.Value));
                    viewQuestion.PostBackUrl = "./questionDetail.aspx?id=" + id.Value;
                }
                foreach (RepeaterItem item in Repeater8.Items)
                {
                    HiddenField id = (HiddenField)item.FindControl("questionCode");
                    Label title = (Label)item.FindControl("title");
                    Label poster = (Label)item.FindControl("poster");
                    LinkButton viewProfile = (LinkButton)item.FindControl("viewProfile");
                    LinkButton viewQuestion = (LinkButton)item.FindControl("viewQuestion");
                    title.Text = question.GetQuestionTitle(question, Convert.ToInt32(id.Value));
                    poster.Text = question.GetQuestionPoster(question, Convert.ToInt32(id.Value));
                    viewProfile.PostBackUrl = "./profile.aspx?id=" + question.GetQuestionPoster(question, Convert.ToInt32(id.Value));
                    viewQuestion.PostBackUrl = "./questionDetail.aspx?id=" + id.Value;
                }
            }
            else
            {
                Session["illegal"] = true;
                Response.Redirect("./rank.aspx");
            }

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“rankDetail.GetName(string)”的 XML 注释
        protected string GetName(string id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“rankDetail.GetName(string)”的 XML 注释
        {
            if (id.Length == 7)
            {
                return profile.GetStudentName(profile, id);
            }
            else if (id.Length == 9)
            {
                return profile.GetTeacherName(profile, id);
            }
            else
            {
                return "Admin";
            }
        }
    }
}