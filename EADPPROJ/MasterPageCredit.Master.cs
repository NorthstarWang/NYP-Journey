using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageCredit”的 XML 注释
    public partial class MasterPageCredit : System.Web.UI.MasterPage
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageCredit”的 XML 注释
    {
        Notification notification = new Notification();
        Question question = new Question();
        Credit credit = new Credit();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageCredit.priceCustom”的 XML 注释
        public string priceCustom = "0";
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageCredit.priceCustom”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageCredit.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageCredit.Page_Load(object, EventArgs)”的 XML 注释
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
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageCredit.logout(object, EventArgs)”的 XML 注释
        protected void logout(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageCredit.logout(object, EventArgs)”的 XML 注释
        {
            Session["Account"] = null;
            Response.Redirect("index.aspx");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageCredit.Dismiss_Click(object, EventArgs)”的 XML 注释
        protected void Dismiss_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageCredit.Dismiss_Click(object, EventArgs)”的 XML 注释
        {
            RandomPrice.Visible = false;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageCredit.Try_Click(object, EventArgs)”的 XML 注释
        protected void Try_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageCredit.Try_Click(object, EventArgs)”的 XML 注释
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