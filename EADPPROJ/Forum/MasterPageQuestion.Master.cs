using EADPPROJ.App_Code;
using System;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
    public partial class Header : System.Web.UI.MasterPage
    {
        Question question = new Question();
        Credit credit = new Credit();
        Notification notification = new Notification();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
            {
                if (Session["Account"].ToString().Length != 7 && Session["Account"].ToString().Length != 9)
                {
                    managementSide.Visible = true;
                }
                userID.InnerText = Session["Account"].ToString();
                creditBalance.Text = credit.GetCreditAmount(Session["Account"].ToString()).ToString() + " Credits";
                profile.HRef = "../Profile/profile.aspx?id=" + Session["Account"].ToString();
                profileIcon.Style.Remove("background-image");
                profileIcon.Style.Add("background-image", string.Format("url('{0}')", question.GetHeadIcon(question, Session["Account"].ToString())));
            }
            else
            {
                Response.Redirect("~/index.aspx");
            }

            ///Alert Message Show
 
            if (Session["warningInsufficientCredit"] == "true")
 
            {
                warningInsufficientCredit.Visible = true;
                Session["warningInsufficientCredit"] = "false";
            }

            ///Success Message Show
 
            if (Session["successPostSuccess"] == "true")
 
            {
                successPostSuccess.Visible = true;
                Session["successPostSuccess"] = "false";
            }
 
            if (Session["successUpvote"] == "true")
 
            {
                successUpvote.Visible = true;
                Session["successUpvote"] = "false";
            }
 
            if (Session["illegal"] == "true")
 
            {
                illegalAccess.Visible = true;
                Session["illegal"] = "false";
            }
 
            if (Session["answerPost"] == "true")
 
            {
                successAnswerPost.Visible = true;
                Session["answerPost"] = "false";
            }
 
            if (Session["commentPost"] == "true")
 
            {
                successCommentPost.Visible = true;
                Session["commentPost"] = "false";
            }
 
            if (Session["replyPost"] == "true")
 
            {
                successReplyPost.Visible = true;
                Session["replyPost"] = "false";
            }
 
            if (Session["SolutionSelect"] == "true")
 
            {
                successSolutionSelect.Visible = true;
                Session["SolutionSelect"] = "false";
            }

            foreach (GridViewRow row in GridViewNotification.Rows)
            {
                HiddenField RT = (HiddenField)row.Cells[0].FindControl("RT");
                Label timeAgo = (Label)row.Cells[0].FindControl("timeAgo");
                if ((DateTime.Now - Convert.ToDateTime(RT.Value)).TotalHours < 1)
                {
                    timeAgo.Text = "Just Now";
                }
                else if ((DateTime.Now - Convert.ToDateTime(RT.Value)).TotalHours > 1 && (DateTime.Now - Convert.ToDateTime(RT.Value)).TotalHours < 24)
                {
                    timeAgo.Text = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(RT.Value)).TotalHours).ToString() + " Hours Ago";
                }
                else
                {
                    timeAgo.Text = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(RT.Value)).TotalDays).ToString() + " Days Ago";
                }

                if (notification.GetNotificationNewTotalNo(notification, Session["Account"].ToString()) == 0)
                {
                    msgNo.Text = "Currently no new notification";
                }
                else
                {
                    msgNo.Text = notification.GetNotificationNewTotalNo(notification, Session["Account"].ToString()).ToString() + " New Notifications";
                }

            }

        }

        protected void logout(object sender, EventArgs e)
        {
            Session["Account"] = null;
            Response.Redirect("~/index.aspx");
        }

        protected void Try_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Label url = (Label)row.FindControl("Url");
            Label Id = (Label)row.FindControl("notificationId");
            int notificationId = Convert.ToInt32(Id.Text);
            string link = url.Text;
            notification.ChangeViewBool(notification, Session["Account"].ToString(), notificationId);
            Response.Redirect(link);
        }
    }
}