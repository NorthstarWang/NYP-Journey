using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageRegistration”的 XML 注释
    public partial class MasterPageRegistration : System.Web.UI.MasterPage
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageRegistration”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MasterPageRegistration.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MasterPageRegistration.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Session["Account"] != null)
            {
                Response.Redirect("./Index.aspx");
            }
#pragma warning disable CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            if (Session["NoChoice"] == "true")
#pragma warning restore CS0252 // 可能非有意的引用比较；若要获取值比较，请将左边转换为类型“string”
            {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.onload = function Show(){$('#SelectModal').modal('show');}", true);
                    Session["NoChoice"] = null;
            }
        }
    }
}