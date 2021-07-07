using System;
using System.Collections;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
    public partial class bookShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
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