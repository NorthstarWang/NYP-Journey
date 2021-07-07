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
    }
}