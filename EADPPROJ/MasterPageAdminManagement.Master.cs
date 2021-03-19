using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageAdminManagement”的 XML 注释
    public partial class MasterPageAdminManagement : System.Web.UI.MasterPage
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageAdminManagement”的 XML 注释
    {
        Question question = new Question();
        Credit credit = new Credit();
        Notification notification = new Notification();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageAdminManagement.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageAdminManagement.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Session["Account"] != null)
            {
                if ((Session["Account"].ToString().Length != 7) && (Session["Account"].ToString().Length != 9))//if admin
                {
                    userID.Text = Session["Account"].ToString();
                    creditBalance.Text = credit.GetCreditAmount(Session["Account"].ToString()).ToString() + " Credits";
                    string iconPath = question.GetHeadIcon(question, Session["Account"].ToString());
                    icon.Src = iconPath;
                    profile.HRef = "./profile.aspx?id=" + Session["Account"].ToString();
                    profileIcon.Src = question.GetHeadIcon(question, Session["Account"].ToString());
                }


                else
                {
                    Session["ErrorAccount"] = "true";
                    Response.Redirect("./index.aspx");
                }
            }
            else
            {
                Session["ErrorAccount"] = "true";
                Response.Redirect("./index.aspx");
            }
#pragma warning disable CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            if (Session["successDelete"] == "true")
#pragma warning restore CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            {
                successDelete.Visible = true;
                Session["successDelete"] = null;
            }
#pragma warning disable CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            if (Session["successEdit"] == "true")
#pragma warning restore CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            {
                Session["successEdit"] = null;
                successEdit.Visible = true;
            }
#pragma warning disable CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            if (Session["QuestionDelete"] == "true")
#pragma warning restore CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            {
                Session["QuestionDelete"] = null;
                QuestionDelete.Visible = true;
            }
#pragma warning disable CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            if (Session["QuestionApprove"] == "true")
#pragma warning restore CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            {
                Session["QuestionApprove"] = null;
                QuestionApprove.Visible = true;
            }

            foreach (GridViewRow row in GridViewNotification.Rows)
            {
                HiddenField RT = (HiddenField)row.Cells[0].FindControl("RT");
                Label timeAgo = (Label)row.Cells[0].FindControl("timeAgo");
                if((DateTime.Now - Convert.ToDateTime(RT.Value)).TotalHours < 1)
                {
                    timeAgo.Text = "Just Now";
                }else if((DateTime.Now - Convert.ToDateTime(RT.Value)).TotalHours > 1 && (DateTime.Now - Convert.ToDateTime(RT.Value)).TotalHours < 24)
                {
                    timeAgo.Text = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(RT.Value)).TotalHours).ToString() + " Hours Ago";
                }
                else
                {
                    timeAgo.Text=Convert.ToInt32((DateTime.Now - Convert.ToDateTime(RT.Value)).TotalDays).ToString()+" Days Ago";
                }

                if(notification.GetNotificationNewTotalNo(notification, Session["Account"].ToString()) == 0)
                {
                    msgNo.Text = "Currently no new notification";
                }
                else
                {
                    msgNo.Text = notification.GetNotificationNewTotalNo(notification, Session["Account"].ToString()).ToString()+" New Notifications";
                    notificationDot.Visible = true;
                }
                
            }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageAdminManagement.logout(object, EventArgs)”的 XML 注释
        protected void logout(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageAdminManagement.logout(object, EventArgs)”的 XML 注释
        {
            Session["Account"] = null;
            Response.Redirect("index.aspx");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageAdminManagement.Try_Click(object, EventArgs)”的 XML 注释
        protected void Try_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageAdminManagement.Try_Click(object, EventArgs)”的 XML 注释
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