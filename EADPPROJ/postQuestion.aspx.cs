using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;
using System.Data;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“postQuestion”的 XML 注释
    public partial class postQuestion : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“postQuestion”的 XML 注释
    {
        Question question = new Question();
        Credit credit = new Credit();
        Notification notification = new Notification();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“postQuestion.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“postQuestion.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Session["Account"] != null)
            {
                
            }
            else
            {
                Response.Redirect("./login.aspx");
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“postQuestion.Post_Click(object, EventArgs)”的 XML 注释
        protected void Post_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“postQuestion.Post_Click(object, EventArgs)”的 XML 注释
        {   
            if(credit.MinusCredit(Session["Account"].ToString(), Convert.ToInt32(CreditReward.SelectedValue)) == true)
                {
                        question.Title = TitlePost.Text;
                        question.Type = Type.Text;
                        question.Content = QuestionPost.Text;
                        question.Username = Session["Account"].ToString();
                        question.CreditReward = Convert.ToInt32(CreditReward.SelectedValue);
                        question.AddQuestion(question);
                        Session["successPostSuccess"] = "true";
                        question.UpdateProfileQuestionNo(question, Session["Account"].ToString());
                        notification.QuestionCreateNotification(notification, Session["Account"].ToString(),"./questionDetail.aspx?id="+question.GetMaxAnswerId(question).ToString());
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