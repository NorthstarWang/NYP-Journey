using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
    public partial class questionDetail : System.Web.UI.Page
    {
        Question question = new Question();
        Profile profile = new Profile();
        Credit credit = new Credit();
        Management management = new Management();
        Notification notification = new Notification();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((question.CheckQuestionReview(question, Convert.ToInt32(Request.QueryString["id"])) == 0) && (management.VerifyAdminIdentity(Session["Account"].ToString()) == 0))
                {
                    Session["illegal"] = "true";
                    Response.Redirect("./questionList.aspx");

                }
                else
                {
                    if (Request.QueryString["id"] != null)
                    {

                        DataSet ds = null;
                        ds = question.LoadQuestionDetail(question, Convert.ToInt32(Request.QueryString["id"]));
                        Content.Text = Convert.ToString(ds.Tables[0].Rows[0]["Content"]);
                        title.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["Title"]);
                        PostTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["PostTime"]);
                        Username.Text = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                        Username.NavigateUrl = "./profile.aspx?id=" + Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                        answerCount.Text = question.CalculateTotalAnswerForQuestionDetail(question, Request.QueryString["id"]).ToString();
                        if ((Session["Account"].ToString() == Convert.ToString(ds.Tables[0].Rows[0]["Username"])) && (question.GetQuestionStatus(question, Convert.ToInt32(Request.QueryString["id"])) == "Not Solved"))//check whether the current user is the poster
                        {
                            for (int i = 0; i < AnswerList.Rows.Count; i++)
                            {
                                Button solution = (Button)AnswerList.Rows[i].Cells[0].FindControl("Solution");
                                solution.Visible = true;
                            }
                        }
                        else
                        {

                        }
                        if (Convert.ToString(ds.Tables[0].Rows[0]["Username"]).Length == 7)
                        {
                            Name.Text = profile.GetStudentName(profile, Convert.ToString(ds.Tables[0].Rows[0]["Username"]));
                            icon.Src = profile.GetStudentIcon(profile, Convert.ToString(ds.Tables[0].Rows[0]["Username"]));
                            for (int i = 0; i < AnswerList.Rows.Count; i++)
                            {
                                HyperLink usernameControl = (HyperLink)AnswerList.Rows[i].Cells[0].FindControl("answerUsername");
                                string username = usernameControl.Text;
                                usernameControl.NavigateUrl = "./profile.aspx?id=" + username;
                                if (username.Length == 7)
                                {
                                    Image iconControl = (Image)AnswerList.Rows[i].Cells[0].FindControl("answerIcon");
                                    iconControl.ImageUrl = profile.GetStudentIcon(profile, username);
                                }
                                else if (username.Length == 9)
                                {
                                    Image iconControl = (Image)AnswerList.Rows[i].Cells[0].FindControl("answerIcon");
                                    iconControl.ImageUrl = profile.GetTeacherIcon(profile, username);
                                }
                                else
                                {
                                    Image iconControl = (Image)AnswerList.Rows[i].Cells[0].FindControl("answerIcon");
                                    iconControl.ImageUrl = profile.GetAdminIcon(profile, username);
                                }
                            }
                        }
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["Username"]).Length == 9)
                        {
                            Name.Text = profile.GetTeacherName(profile, Convert.ToString(ds.Tables[0].Rows[0]["Username"]));
                            icon.Src = profile.GetTeacherIcon(profile, Convert.ToString(ds.Tables[0].Rows[0]["Username"]));
                            for (int i = 0; i < AnswerList.Rows.Count; i++)
                            {
                                HyperLink usernameControl = (HyperLink)AnswerList.Rows[i].Cells[0].FindControl("answerUsername");
                                string username = usernameControl.Text;
                                usernameControl.NavigateUrl = "./profile.aspx?id=" + username;
                                if (username.Length == 7)
                                {
                                    Image iconControl = (Image)AnswerList.Rows[i].Cells[0].FindControl("answerIcon");
                                    iconControl.ImageUrl = profile.GetStudentIcon(profile, username);
                                }
                                else if (username.Length == 9)
                                {
                                    Image iconControl = (Image)AnswerList.Rows[i].Cells[0].FindControl("answerIcon");
                                    iconControl.ImageUrl = profile.GetTeacherIcon(profile, username);
                                }
                                else
                                {
                                    Image iconControl = (Image)AnswerList.Rows[i].Cells[0].FindControl("answerIcon");
                                    iconControl.ImageUrl = profile.GetAdminIcon(profile, username);
                                }
                            }

                        }
                        else
                        {
                            Name.Text = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                            icon.Src = profile.GetAdminIcon(profile, Convert.ToString(ds.Tables[0].Rows[0]["Username"]));
                            for (int i = 0; i < AnswerList.Rows.Count; i++)
                            {
                                HyperLink usernameControl = (HyperLink)AnswerList.Rows[i].Cells[0].FindControl("answerUsername");
                                string username = usernameControl.Text;
                                usernameControl.NavigateUrl = "./profile.aspx?id=" + username;
                                if (username.Length == 7)
                                {
                                    Image iconControl = (Image)AnswerList.Rows[i].Cells[0].FindControl("answerIcon");
                                    iconControl.ImageUrl = profile.GetStudentIcon(profile, username);
                                }
                                else if (username.Length == 9)
                                {
                                    Image iconControl = (Image)AnswerList.Rows[i].Cells[0].FindControl("answerIcon");
                                    iconControl.ImageUrl = profile.GetTeacherIcon(profile, username);
                                }
                                else
                                {
                                    Image iconControl = (Image)AnswerList.Rows[i].Cells[0].FindControl("answerIcon");
                                    iconControl.ImageUrl = profile.GetAdminIcon(profile, username);
                                }
                            }
                        }
                        if (question.GetQuestionStatus(question, Convert.ToInt32(Request.QueryString["id"])) == "Solved")
                        {
                            BestAnswerBlock.Style["display"] = "inline";
                            DataSet bestAnswer = question.GetBestAnswer(question, Convert.ToInt32(Request.QueryString["id"]));
                            bestAnswerPostTime.Text = Convert.ToString(bestAnswer.Tables[0].Rows[0]["PostTime"]);
                            bestAnswerUsername.Text = Convert.ToString(bestAnswer.Tables[0].Rows[0]["Username"]);
                            bestAnswerUsername.NavigateUrl = "./profile.aspx?id=" + Convert.ToString(bestAnswer.Tables[0].Rows[0]["Username"]);
                            bestAnswerDetailContent.Text = Convert.ToString(bestAnswer.Tables[0].Rows[0]["Content"]);
                            if (Convert.ToString(bestAnswer.Tables[0].Rows[0]["Username"]).Length == 7)
                            {
                                bestAnswerIcon.ImageUrl = profile.GetStudentIcon(profile, Convert.ToString(bestAnswer.Tables[0].Rows[0]["Username"]));
                            }
                            else if (Convert.ToString(bestAnswer.Tables[0].Rows[0]["Username"]).Length == 9)
                            {
                                bestAnswerIcon.ImageUrl = profile.GetTeacherIcon(profile, Convert.ToString(bestAnswer.Tables[0].Rows[0]["Username"]));
                            }
                            else
                            {
                                bestAnswerIcon.ImageUrl = profile.GetAdminIcon(profile, Convert.ToString(bestAnswer.Tables[0].Rows[0]["Username"]));
                            }
                        }


                    }
                }
                if ((question.CheckQuestionReview(question, Convert.ToInt32(Request.QueryString["id"])) == 0) && (management.VerifyAdminIdentity(Session["Account"].ToString()) == 1))
                {
                    collapseAnswerButton.Visible = false;

                }
            }
            catch (Exception)
            {
                Session["ErrorAccount"] = "true";
                Response.Redirect("./index.aspx");
            }
            
        }
            

        protected void postAnswer_Click(object sender, EventArgs e)
        {
            string answerText = answerContent.Text;
            question.SaveRichTextAnswer(question, Request.QueryString["id"],answerText,Session["Account"].ToString());
            question.UpdateQuestionLastUpdate(question, Request.QueryString["id"]);
            profile.UpdateProfileAnswerNo(profile, Session["Account"].ToString());
            Session["answerPost"] = "true";
            notification.AnswerPostNotificationToAnswer(notification, Session["Account"].ToString(), "./questionDetail.aspx?id=" + Request.QueryString["id"]);
            DataSet ds = question.GetQuestionDetail(question, Convert.ToInt32(Request.QueryString["id"]));
            string username = ds.Tables[0].Rows[0]["Username"].ToString();
            notification.AnswerPostNotificationToQuestion(notification, username, "./questionDetail.aspx?id=" + Request.QueryString["id"]);
            Response.Redirect("./questionDetail.aspx?id=" + Request.QueryString["id"]);
        }

        protected void postReply_Click(object sender, EventArgs e)
        {
            var post = (Button)sender;
            GridViewRow row = (GridViewRow)post.NamingContainer;
            TextBox replyContent = (TextBox)row.Cells[0].FindControl("replyContent");
            Label Id = (Label)row.Cells[0].FindControl("Id");
            string replyText = replyContent.Text;
            question.PostReply(question, Session["Account"].ToString(),Convert.ToInt32(Id.Text), replyText);
            Session["commentPost"]="true";
            notification.CommentPostNotificationToPoster(notification, Session["Account"].ToString(), "./questionDetail.aspx?id=" + Request.QueryString["id"]);
            HiddenField username = (HiddenField)row.Cells[0].FindControl("answerPostUsername");
            notification.CommentPostNotificationToReceiver(notification,username.Value, "./questionDetail.aspx?id=" + Request.QueryString["id"]);
            Response.Redirect("./questionDetail.aspx?id=" + Request.QueryString["id"]);
        }

        protected void SolutionSelect(object sender, EventArgs e)
        {
            var solutionSelect = (Button)sender;
            GridViewRow row = (GridViewRow)solutionSelect.NamingContainer;
            Label Id = (Label)row.Cells[0].FindControl("Id");
            int username = Convert.ToInt32(Id.Text);
            HyperLink Poster = (HyperLink)row.Cells[0].FindControl("answerUsername");
            int award = credit.GetRewardAmount(Convert.ToInt32(Request.QueryString["id"]));
            credit.AddCredit(Poster.Text, award);
            question.SetAnswerBestAnswer(question, username);
            question.SetProblemSolved(question, Convert.ToInt32(Request.QueryString["id"]));
            Session["SolutionSelect"] = "true";
            notification.SolutionSelectNotificationToQuestion(notification, Session["Account"].ToString(), "./questionDetail.aspx?id=" + Request.QueryString["id"]);
            notification.SolutionSelectNotificationToAnswer(notification, Poster.Text, "./questionDetail.aspx?id=" + Request.QueryString["id"]);
            Response.Redirect("./questionDetail.aspx?id=" + Request.QueryString["id"]);
            
        }

        protected void upVote_Click(object sender, EventArgs e)
        {
            var upVote = (Button)sender;
            GridViewRow row = (GridViewRow)upVote.NamingContainer;
            Label Id = (Label)row.Cells[0].FindControl("Id");
            if(question.CheckUpvoteAvailability(question, Session["Account"].ToString(), Convert.ToInt32(Id.Text)) == true)
            {
                question.UpdateUpvote(question, Convert.ToInt32(Id.Text), Session["Account"].ToString(),Convert.ToInt32(Request.QueryString["id"]));
                Response.Redirect("./questionDetail.aspx?id=" + Request.QueryString["id"]);
            }
            else
            {
                Session["successUpvote"] = "true"; ;
            }
            
        }


        protected void Show_Click(object sender, EventArgs e)
        {
            
            var show = (LinkButton)sender;
            GridViewRow row = (GridViewRow)show.NamingContainer;
            GridView AnswerSection = (GridView)row.Cells[0].FindControl("GridView1");
            SqlDataSource AnswerSectionSrc = (SqlDataSource)row.Cells[0].FindControl("AnswerSection");
            Label No = (Label)row.Cells[0].FindControl("NoYet");
            Label Id = (Label)row.Cells[0].FindControl("Id");
            int answerId = Convert.ToInt32(Id.Text);
            if (question.CheckAnswerSection(question, answerId) == true)
            {
                AnswerSection.Visible = true;
                foreach(GridViewRow replies in AnswerSection.Rows)
                {
                    Image icon = (Image)replies.Cells[0].FindControl("ReplyUserIcon");
                    HyperLink UserId = (HyperLink)replies.Cells[0].FindControl("ReplyUsername");
                    HyperLink Name = (HyperLink)replies.Cells[0].FindControl("ReplyName");
                    Name.NavigateUrl = "./profile.aspx?id=" + UserId.Text;
                    Label Content = (Label)replies.Cells[0].FindControl("Content");
                    Label ReplyTo = (Label)replies.Cells[0].FindControl("ReplyTo");
                    Label ReferenceId = (Label)replies.Cells[0].FindControl("ReferenceId");
                    if (UserId.Text.Length == 7)
                    {
                        icon.ImageUrl = profile.GetStudentIcon(profile, UserId.Text);
                        Name.Text = profile.GetStudentName(profile, UserId.Text);
                    }else if(UserId.Text.Length == 9)
                    {
                        icon.ImageUrl = profile.GetTeacherIcon(profile, UserId.Text);
                        Name.Text = profile.GetTeacherName(profile, UserId.Text);
                    }
                    else
                    {
                        icon.ImageUrl = profile.GetAdminIcon(profile, UserId.Text);
                        Name.Text = "Admin";
                    }
                    if(ReferenceId.Text !="")
                    {
                        ReplyTo.Text = " Says to " + question.GetReplierUsername(question, Convert.ToInt32(ReferenceId.Text))+" :";
                    }
                    show.Visible = false;
                }
                
            }
            else
            {
                No.Visible = true;
                show.Visible = false;
            }
        }

        protected void Reply_Click(object sender, EventArgs e)
        {
            var reply = (Button)sender;
            GridViewRow row = (GridViewRow)reply.NamingContainer;
            Label UserId = (Label)row.Cells[0].FindControl("Id");
            TextBox editor = (TextBox)row.Cells[0].FindControl("Editor1");
            Label Id = (Label)row.Cells[0].FindControl("AnswerId");
            question.PostReplyInReply(question, Session["Account"].ToString(), Convert.ToInt32(Id.Text),editor.Text, Convert.ToInt32(UserId.Text));
            Session["replyPost"] = "true";
            notification.ReplyPostNotificationToPoster(notification, Session["Account"].ToString(), "./questionDetail.aspx?id=" + Request.QueryString["id"]);
            notification.ReplyPostNotificationToReceiver(notification, question.GetReplierUsername(question, Convert.ToInt32(UserId.Text)), "./questionDetail.aspx?id=" + Request.QueryString["id"]);
            Response.Redirect("./questionDetail.aspx?id=" + Request.QueryString["id"]);
        }

    }
}