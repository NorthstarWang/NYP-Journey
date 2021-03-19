using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementQuestionReview”的 XML 注释
    public partial class managementQuestionReview : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementQuestionReview”的 XML 注释
    {
        Management management = new Management();
        Notification notification = new Notification();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementQuestionReview.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementQuestionReview.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (GridView1.Rows.Count == 0)
            {
                GridView1.Visible = false;
                NoRecord.Visible = true;
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementQuestionReview.Approve_Click(object, EventArgs)”的 XML 注释
        protected void Approve_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementQuestionReview.Approve_Click(object, EventArgs)”的 XML 注释
        {
            var btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hf = (HiddenField)row.Cells[0].FindControl("IdV");
            HiddenField un = (HiddenField)row.Cells[0].FindControl("User");
            HiddenField url = (HiddenField)row.Cells[0].FindControl("URL");
            int Id = Convert.ToInt32(hf.Value);
            string Url = "./questionDetail.aspx?id=" + url.Value.ToString();
            management.ApproveQuestion(Id);
            notification.QuestionApproveNotification(notification, un.Value.ToString(),Url);
            Session["QuestionApprove"] = "true";
            Response.Redirect("./managementQuestionReview.aspx");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementQuestionReview.Delete_Click(object, EventArgs)”的 XML 注释
        protected void Delete_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementQuestionReview.Delete_Click(object, EventArgs)”的 XML 注释
        {
            var btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hf = (HiddenField)row.Cells[0].FindControl("IdV");
            HiddenField un = (HiddenField)row.Cells[0].FindControl("User");
            HiddenField url = (HiddenField)row.Cells[0].FindControl("URL");
            int Id = Convert.ToInt32(hf.Value);
            string Url = "./questionDetail.aspx?id=" + url.Value.ToString();
            notification.QuestionRejectNotification(notification, un.Value.ToString());
            management.DeleteQuestion(Id);
            Session["QuestionDelete"] = "true";
            Response.Redirect("./managementQuestionReview.aspx");
        }
    }
}