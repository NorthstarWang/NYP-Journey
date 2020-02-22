using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
    public partial class MasterPageCredit : System.Web.UI.MasterPage
    {
        Notification notification = new Notification();
        Question question = new Question();
        Credit credit = new Credit();
        public string priceCustom = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
            {
                
                userID.Text = Session["Account"].ToString();
                creditBalance.Text = credit.GetCreditAmount(Session["Account"].ToString()).ToString() + " Credits";
                string iconPath = question.GetHeadIcon(question, Session["Account"].ToString());
                icon.Src = iconPath;
                profile.HRef = "./profile.aspx?id=" + Session["Account"].ToString();
                profileIcon.Src = question.GetHeadIcon(question, Session["Account"].ToString());
                if (Session["Account"].ToString().Length != 7 && Session["Account"].ToString().Length != 9)
                {
                    managementSide.Visible = true;
                }


                if (Session["Price"] != null)
                {
                    RandomPrice.Visible = true;
                    this.Price.InnerText = Session["Price"].ToString();
                    priceCustom = Session["Price"].ToString();
                    Session["Price"] = null;
                }

                if(Session["intWarn"] != null)
                {
                    warningInsufficientCredit.Visible = true;
                    Session["intWarn"] = null;
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
                        notificationDot.Visible = true;
                    }

                }
            }
            else
            {
                Session["ErrorAccount"] = "true";
                Response.Redirect("./index.aspx");
            }
        }
        protected void logout(object sender, EventArgs e)
        {
            Session["Account"] = null;
            Response.Redirect("index.aspx");
        }

        protected void Dismiss_Click(object sender, EventArgs e)
        {
            RandomPrice.Visible = false;
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