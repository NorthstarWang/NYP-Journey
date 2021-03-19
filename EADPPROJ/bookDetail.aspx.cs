using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EADPPROJ.App_Code;
using System.Collections;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“bookDetail”的 XML 注释
    public partial class bookDetail : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“bookDetail”的 XML 注释
    {
        Profile profile = new Profile();
        Shop shop = new Shop();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“bookDetail.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“bookDetail.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Session["Account"] != null)
            {
                login_func.Style["display"] = "none";
                register_func.Style["display"] = "none";
                profileimg.Style["display"] = "block";
                logout.Style["display"] = "block";
                appGroup.Style["display"] = "block";

                string ID = Session["Account"].ToString();
#pragma warning disable CS1587 // XML 注释没有放在有效语言元素上
                if (ID.Length == 7)///If Student
                {
#pragma warning restore CS1587 // XML 注释没有放在有效语言元素上
                    profileimg.Src = profile.GetStudentIcon(profile, ID);
                    profileUrl.HRef += "?id=" + Session["Account"].ToString();
                }
#pragma warning disable CS1587 // XML 注释没有放在有效语言元素上
                else if (ID.Length == 9)///If Sensei
                {
#pragma warning restore CS1587 // XML 注释没有放在有效语言元素上
                    profileimg.Src = profile.GetTeacherIcon(profile, ID);
                    profileUrl.HRef += "?id=" + Session["Account"].ToString();
                }
#pragma warning disable CS1587 // XML 注释没有放在有效语言元素上
                else///If Admin
                {
#pragma warning restore CS1587 // XML 注释没有放在有效语言元素上
                    profileimg.Src = profile.GetAdminIcon(profile, ID);
                    profileUrl.HRef += "?id=" + Session["Account"].ToString();
                }

                int id = Convert.ToInt32(Request.QueryString["id"]);
                DataSet ds = null;
                ds = shop.ReturnBookInfo(shop, id);
                price.InnerText =ds.Tables[0].Rows[0]["Price"].ToString()+" Credits";
                description.InnerText = ds.Tables[0].Rows[0]["Description"].ToString();
                name.InnerText = ds.Tables[0].Rows[0]["Name"].ToString();
                img.Src = "../assets/img/books/"+ ds.Tables[0].Rows[0]["Image"].ToString();
            }
            else
            {
                Session["ErrorAccount"] = "true";
                Response.Redirect("./index.aspx");
            }

            if (Session["successCart"] != null)
            {
                successCart.Visible = true;
                Session["successCart"] = null;
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“bookDetail.btn_logout_Click(object, EventArgs)”的 XML 注释
        protected void btn_logout_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“bookDetail.btn_logout_Click(object, EventArgs)”的 XML 注释
        {
            Session["Account"] = null;
            Response.Redirect("./index.aspx");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“bookDetail.LinkButton1_Click(object, EventArgs)”的 XML 注释
        protected void LinkButton1_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“bookDetail.LinkButton1_Click(object, EventArgs)”的 XML 注释
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
                    Response.Redirect("./bookDetail.aspx?id="+Request.QueryString["id"].ToString());
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