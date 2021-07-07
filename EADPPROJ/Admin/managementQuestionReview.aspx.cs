using EADPPROJ.App_Code;
using System;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
    public partial class managementQuestionReview : System.Web.UI.Page
    {
        Management management = new Management();
        Notification notification = new Notification();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                GridView1.Visible = false;
                NoRecord.Visible = true;
            }
        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            HiddenField hf = (HiddenField)row.Cells[0].FindControl("IdV");
            HiddenField un = (HiddenField)row.Cells[0].FindControl("User");
            HiddenField url = (HiddenField)row.Cells[0].FindControl("URL");
            int Id = Convert.ToInt32(hf.Value);
            string Url = "./questionDetail.aspx?id=" + url.Value.ToString();
            management.ApproveQuestion(Id);
            notification.QuestionApproveNotification(notification, un.Value.ToString(), Url);
            Session["QuestionApprove"] = "true";
            Response.Redirect("./managementQuestionReview.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
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