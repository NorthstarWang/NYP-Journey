using EADPPROJ.App_Code;
using System;

namespace EADPPROJ
{
    public partial class postQuestion : System.Web.UI.Page
    {
        Question question = new Question();
        Credit credit = new Credit();
        Notification notification = new Notification();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
            {

            }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }

        protected void Post_Click(object sender, EventArgs e)
        {
            if (credit.MinusCredit(Session["Account"].ToString(), Convert.ToInt32(CreditReward.SelectedValue)) == true)
            {
                question.Title = TitlePost.Text;
                question.Type = Type.Text;
                question.Content = QuestionPost.Text;
                question.Username = Session["Account"].ToString();
                question.CreditReward = Convert.ToInt32(CreditReward.SelectedValue);
                question.AddQuestion(question);
                Session["successPostSuccess"] = "true";
                question.UpdateProfileQuestionNo(question, Session["Account"].ToString());
                notification.QuestionCreateNotification(notification, Session["Account"].ToString(), "./questionDetail.aspx?id=" + question.GetMaxAnswerId(question).ToString());
                Response.Redirect("./questionList.aspx");
            }
            else
            {
                Session["warningInsufficientCredit"] = "true";
                Response.Redirect("./postQuestion.aspx");

            }

        }
    }
}