using EADPPROJ.App_Code;
using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
    public partial class profile1 : System.Web.UI.Page
    {
        Profile profile = new Profile();
        Blog blog = new Blog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
            {
                string ID = Request.QueryString["id"].ToString();
                BlogNo.Text = profile.GetBlogNo(profile, ID).ToString();
                if (ID.Length == 7)///If Student
                {
                    headicon.Src = profile.GetStudentIcon(profile, ID);
                    Name.Text = profile.GetStudentName(profile, ID);
                    Identity.Text = "Student of " + profile.GetStudentSchool(profile, ID);
                    QuestionNo.Text = profile.GetStudentQuestionNo(profile, ID);
                    AnswersNo.Text = profile.GetStudentAnswersNo(profile, ID);
                    BestAnswerNo.Text = profile.GetStudentBestSolution(profile, ID).ToString();


                }
                else if (ID.Length == 9)///If Sensei
                {
                    headicon.Src = profile.GetTeacherIcon(profile, ID);
                    Name.Text = profile.GetTeacherName(profile, ID);
                    Identity.Text = "Teacher";
                    QuestionNo.Text = profile.GetTeacherQuestionNo(profile, ID);
                    AnswersNo.Text = profile.GetTeacherAnswersNo(profile, ID);
                    BestAnswerNo.Text = profile.GetTeacherBestSolution(profile, ID).ToString();


                }
                else///If Admin
                {
                    headicon.Src = profile.GetAdminIcon(profile, ID);
                    Name.Text = "Admin";
                    Identity.Text = "NYP";
                    QuestionNo.Text = profile.GetAdminQuestionNo(profile, ID);
                    AnswersNo.Text = profile.GetAdminAnswersNo(profile, ID);
                    BestAnswerNo.Text = profile.GetAdminBestSolution(profile, ID).ToString();

                }


                if (Session["Account"].ToString().Length == 7)
                {
                    profileimg.Src = profile.GetStudentIcon(profile, Session["Account"].ToString());
                }
                else if (Session["Account"].ToString().Length == 9)
                {
                    profileimg.Src = profile.GetTeacherIcon(profile, Session["Account"].ToString());
                }
                else
                {
                    profileimg.Src = profile.GetAdminIcon(profile, Session["Account"].ToString());
                }

                if (GridView1.Rows.Count != 0)
                {
                    HtmlGenericControl commentNo = (HtmlGenericControl)this.commentNo;
                    commentNo.InnerText = GridView1.Rows.Count.ToString() + " Comment";
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        Label content = (Label)GridView1.Rows[i].Cells[0].FindControl("Username");
                        Image icon = (Image)GridView1.Rows[i].Cells[0].FindControl("Icon");
                        icon.ImageUrl = profile.GetIcon(profile, content.Text);

                        Label time = (Label)GridView1.Rows[i].Cells[0].FindControl("postTime");
                        HtmlGenericControl timeAgo = (HtmlGenericControl)GridView1.Rows[i].Cells[0].FindControl("countdown");
                        if ((DateTime.Now - Convert.ToDateTime(time.Text)).TotalHours < 1)
                        {
                            timeAgo.InnerText = "Just Now";
                        }
                        else if ((DateTime.Now - Convert.ToDateTime(time.Text)).TotalHours >= 1 && (DateTime.Now - Convert.ToDateTime(time.Text)).TotalHours < 24)
                        {
                            timeAgo.InnerText = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(time.Text)).TotalHours).ToString() + " Hours Ago";
                        }
                        else
                        {
                            timeAgo.InnerText = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(time.Text)).TotalDays).ToString() + " Days Ago";
                        }
                    }
                }
                else
                {
                    commentNo.Visible = false;
                }

                if (Session["Account"].ToString() == Request.QueryString["id"])
                {
                    postSection.Visible = false;
                }

                if (favList.Rows.Count != 0)
                {
                    for (int i = 0; i < favList.Rows.Count; i++)
                    {
                        Label Blogid = (Label)favList.Rows[i].Cells[0].FindControl("BlogId");
                        HtmlGenericControl titleFav = (HtmlGenericControl)favList.Rows[i].Cells[0].FindControl("title");
                        titleFav.InnerText = blog.GetTitle(Convert.ToInt32(Blogid.Text));
                    }
                }
                else
                {

                }

            }
            else
            {
                Response.Redirect("./index.aspx");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
            bool validate = profile.ValidateImg(profile, path);
            if (validate == false)
            {
                Response.Write("<script>alert('Illegal File')</script>");
            }
            else
            {
                int ID = Session["Account"].ToString().Length;
                if (ID == 7)
                {
                    FileUpload1.SaveAs(Server.MapPath("") + "./assets/img/faces/" + FileUpload1.FileName);
                    profile.SaveStudentImg(profile, Session["Account"].ToString(), FileUpload1.FileName);
                }
                else if (ID == 9)
                {
                    FileUpload1.SaveAs(Server.MapPath("") + "./assets/img/faces/" + FileUpload1.FileName);
                    profile.SaveTeacherImg(profile, Session["Account"].ToString(), FileUpload1.FileName);
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("") + "./assets/img/faces/" + FileUpload1.FileName);
                    profile.SaveAdminImg(profile, Session["Account"].ToString(), FileUpload1.FileName);
                }

            }
            Response.Redirect("./profile.aspx?id=" + Request.QueryString["id"]);
        }

        protected void CommentPostButton_Click(object sender, EventArgs e)
        {
            if (CommentPostText.Text != "")
            {
                profile.PostComment(profile, Request.QueryString["id"].ToString(), Session["Account"].ToString(), CommentPostText.Text);
                Response.Redirect("./profile.aspx?id=" + Request.QueryString["id"]);
            }
            else
            {

            }

        }

        protected void post_Click(object sender, EventArgs e)
        {
            if (blogContent.Text != "" && blogTitle.Text != "")
            {
                if (FileUpload2.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(FileUpload2.FileName);
                    bool validate = profile.ValidateImg(profile, extension);
                    if (validate == true)
                    {
                        FileUpload2.SaveAs(Server.MapPath("") + "./assets/img/BlogBG/" + FileUpload2.FileName);
                        profile.PostBlog(profile, blogTitle.Text, blogContent.Text, Session["Account"].ToString(), false, FileUpload2.FileName);
                        Response.Redirect("./profile.aspx?id=" + Request.QueryString["id"]);
                    }
                    else
                    {
                        Response.Write("Only images are allowed");
                    }
                }
                else
                {
                    profile.PostBlog(profile, blogTitle.Text, blogContent.Text, Session["Account"].ToString(), true, null);
                    Response.Redirect("./profile.aspx?id=" + Request.QueryString["id"]);
                }
            }
        }
    }
}