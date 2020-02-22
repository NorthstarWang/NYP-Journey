using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
    public partial class MasterPageRegistration : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
            {
                Response.Redirect("./Index.aspx");
            }
            if (Session["NoChoice"] == "true")
            {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.onload = function Show(){$('#SelectModal').modal('show');}", true);
                    Session["NoChoice"] = null;
            }
        }
    }
}