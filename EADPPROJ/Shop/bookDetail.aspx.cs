using EADPPROJ.App_Code;
using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
    public partial class bookDetail : System.Web.UI.Page
    {
        Profile profile = new Profile();
        Shop shop = new Shop();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] != null)
            {
                profileimg.Style["display"] = "block";
                logout.Style["display"] = "block";
                appGroup.Style["display"] = "block";

                string ID = Session["Account"].ToString();
                if (ID.Length == 7)///If Student
                {
                    profileimg.Src = profile.GetStudentIcon(profile, ID);
                    profileUrl.HRef += "?id=" + Session["Account"].ToString();
                }
                else if (ID.Length == 9)///If Sensei
                {
                    profileimg.Src = profile.GetTeacherIcon(profile, ID);
                    profileUrl.HRef += "?id=" + Session["Account"].ToString();
                }
                else///If Admin
                {
                    profileimg.Src = profile.GetAdminIcon(profile, ID);
                    profileUrl.HRef += "?id=" + Session["Account"].ToString();
                }

                int id = Convert.ToInt32(Request.QueryString["id"]);
                DataSet ds = null;
                ds = shop.ReturnBookInfo(shop, id);
                price.InnerText = ds.Tables[0].Rows[0]["Price"].ToString() + " Credits";
                description.InnerText = ds.Tables[0].Rows[0]["Description"].ToString();
                name.InnerText = ds.Tables[0].Rows[0]["Name"].ToString();
                img.Src = "../assets/img/books/" + ds.Tables[0].Rows[0]["Image"].ToString();
            }
            else
            {
                Session["ErrorAccount"] = "true";
                Response.Redirect("~/index.aspx");
            }

            if (Session["successCart"] != null)
            {
                successCart.Visible = true;
                Session["successCart"] = null;
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["Account"] = null;
            Response.Redirect("~/index.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            var button = (LinkButton)sender;
            int Id = Convert.ToInt32(Request.QueryString["id"].ToString());
            if (Session["cart"] == null)
            {
                Hashtable ht = new Hashtable();
                ht.Add(Id, 1);
                Session["cart"] = ht;
                Session["successCart"] = true;
                Response.Redirect("./bookDetail.aspx?id=" + Request.QueryString["id"].ToString());
            }
            else
            {
                Hashtable ht = (Hashtable)Session["cart"];
                if (ht.Contains(Id))
                {
                    int count = Convert.ToInt32(ht[Id].ToString());
                    ht[Id] = count + 1;
                    Session["successCart"] = true;
                    Response.Redirect("./bookDetail.aspx?id=" + Request.QueryString["id"].ToString());
                }
                else
                {
                    ht.Add(Id, 1);
                    Session["successCart"] = true;
                    Response.Redirect("./bookDetail.aspx?id=" + Request.QueryString["id"].ToString());
                }
            }
        }
    }
}