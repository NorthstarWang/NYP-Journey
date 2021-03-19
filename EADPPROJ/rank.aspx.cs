using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Rank”的 XML 注释
    public partial class Rank : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Rank”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Rank.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Rank.Page_Load(object, EventArgs)”的 XML 注释
        {

            if(Session["Select"] != null)
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Rank.check_Click(object, EventArgs)”的 XML 注释
        protected void check_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Rank.check_Click(object, EventArgs)”的 XML 注释
        {
            if(type.SelectedValue=="0" || type.SelectedValue==null)
            {
                Session["Select"] = true;
                Response.Redirect("./rank.aspx");
            }
            else
            {
                Response.Redirect("./rankDetail.aspx?type="+type.SelectedValue);
            }
        }
    }
}