using System;

namespace EADPPROJ
{
    public partial class Rank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Select"] != null)
            {
                requireSelection.Visible = true;
                Session["Select"] = null;
            }
            if (Session["illegal"] != null)
            {
                illegalAccess.Visible = true;
                Session["illegal"] = null;
            }
        }

        protected void check_Click(object sender, EventArgs e)
        {
            if (type.SelectedValue == "0" || type.SelectedValue == null)
            {
                Session["Select"] = true;
                Response.Redirect("./rank.aspx");
            }
            else
            {
                Response.Redirect("./rankDetail.aspx?type=" + type.SelectedValue);
            }
        }
    }
}