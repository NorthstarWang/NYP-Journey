using System;
using System.Collections;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“bookShop”的 XML 注释
    public partial class bookShop : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“bookShop”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“bookShop.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“bookShop.Page_Load(object, EventArgs)”的 XML 注释
        {

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“bookShop.LinkButton1_Click(object, EventArgs)”的 XML 注释
        protected void LinkButton1_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“bookShop.LinkButton1_Click(object, EventArgs)”的 XML 注释
        {
            var button = (LinkButton)sender;
            ListViewItem item = (ListViewItem)button.NamingContainer;
            Label id = (Label)item.FindControl("Id");
            int Id = Convert.ToInt32(id.Text);
            if (Session["cart"] == null)
            {
                Hashtable ht = new Hashtable();
                ht.Add(Id, 1);
                Session["cart"] = ht;
                Session["successCart"] = true;
                Response.Redirect("./bookShop.aspx");
            }
            else
            {
                Hashtable ht = (Hashtable)Session["cart"];
                if (ht.Contains(Id))
                {
                    int count = Convert.ToInt32(ht[Id].ToString());
                    ht[Id] = count + 1;
                    Session["successCart"] = true;
                    Response.Redirect("./bookShop.aspx");
                }
                else
                {
                    ht.Add(Id, 1);
                    Session["successCart"] = true;
                    Response.Redirect("./bookShop.aspx");
                }
            }
        }
    }
}