using EADPPROJ.App_Code;
using System;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“WebForm2”的 XML 注释
    public partial class WebForm2 : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“WebForm2”的 XML 注释
    {
        Blog blog = new Blog();
        Profile profile = new Profile();
        Credit credit = new Credit();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“WebForm2.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“WebForm2.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Session["Account"] != null)
            {

                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    title.InnerText = blog.GetTitle(id);
                    content.InnerHtml = blog.GetContent(id);
                    if (blog.ValidateDefaultBG(id) == false)
                    {
                        BG.Style["background-image"] = "url(../assets/img/BlogBG/" + blog.GetBGPath(id) + ")";
                    }
                    string userId = blog.GetUsername(Convert.ToInt32(Request.QueryString["id"]));
                    username.InnerText = userId;
                    if (userId.Length == 7)
                    {
                        icon.ImageUrl = profile.GetStudentIcon(profile, userId);
                        author.InnerText = profile.GetStudentName(profile, userId);
                    }
                    else if (userId.Length == 9)
                    {
                        icon.ImageUrl = profile.GetTeacherIcon(profile, userId);
                        author.InnerText = profile.GetTeacherName(profile, userId);
                    }
                    else
                    {
                        icon.ImageUrl = profile.GetAdminIcon(profile, userId);
                        author.InnerText = "Admin";
                    }

                    if (Session["Success"] != null)
                    {
                        successTip.Visible = true;
                        Session["Success"] = null;
                    }
                    if (Session["Add"] != null)
                    {
                        addFav.Visible = true;
                        Session["Add"] = null;
                    }
                    if (Session["Warn"] != null)
                    {
                        insufficientCredit.Visible = true;
                        Session["Warn"] = null;
                    }
                    if (Session["Error"] != null)
                    {
                        wrongData.Visible = true;
                        Session["Error"] = null;
                    }
                    if (Session["Already"] != null)
                    {
                        cannotFavAgain.Visible = true;
                        Session["Already"] = null;
                    }

                    if (Session["successHighlight"] != null)
                    {
                        successSet.Visible = true;
                        Session["successHighlight"] = null;
                    }

                    if (Session["cancelHighlight"] != null)
                    {
                        cancelSet.Visible = true;
                        Session["cancelHighlight"] = null;
                    }

                    if (Session["Account"].ToString().Length != 7 && Session["Account"].ToString().Length != 9)
                    {
                        highlight.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("./index.aspx");
                }
            }
            else
            {
                Session["ErrorAccount"] = "true";
                Response.Redirect("./index.aspx");
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“WebForm2.visit_Click(object, EventArgs)”的 XML 注释
        protected void visit_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“WebForm2.visit_Click(object, EventArgs)”的 XML 注释
        {
            string userId = blog.GetUsername(Convert.ToInt32(Request.QueryString["id"]));
            Response.Redirect("./profile.aspx?id=" + userId);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“WebForm2.confirmTip_Click(object, EventArgs)”的 XML 注释
        protected void confirmTip_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“WebForm2.confirmTip_Click(object, EventArgs)”的 XML 注释
        {
            string tipAmt = tip.Text;
            try
            {
                int numeric = int.Parse(tipAmt);
            }
            catch (Exception)
            {
                Session["Error"] = true;
                Response.Redirect("./blogDetail.aspx?id=" + Request.QueryString["id"]);
            }

            if (credit.GetCreditAmount(Session["Account"].ToString()) > Convert.ToInt32(tipAmt))
            {
                credit.MinusCredit(Session["Account"].ToString(), Convert.ToInt32(tipAmt));
                credit.AddCredit(blog.GetUsername(Convert.ToInt32(Request.QueryString["id"])), Convert.ToInt32(tipAmt));
                blog.AddTip(Convert.ToInt32(Request.QueryString["id"]), Convert.ToInt32(tipAmt));
                Session["Success"] = true;
                Response.Redirect("./blogDetail.aspx?id=" + Request.QueryString["id"]);
            }
            else
            {
                Session["Warn"] = true;
                Response.Redirect("./blogDetail.aspx?id=" + Request.QueryString["id"]);
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“WebForm2.favorite_Click(object, EventArgs)”的 XML 注释
        protected void favorite_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“WebForm2.favorite_Click(object, EventArgs)”的 XML 注释
        {
            if (profile.ValidateFav(profile, Convert.ToInt32(Request.QueryString["id"]), Session["Account"].ToString()) == 0)
            {
                blog.AddFavourite(Convert.ToInt32(Request.QueryString["id"]));
                profile.AddFavorite(profile, Convert.ToInt32(Request.QueryString["id"]), Session["Account"].ToString());
                Session["Add"] = true;
                Response.Redirect("./blogDetail.aspx?id=" + Request.QueryString["id"]);
            }
            else
            {
                Session["Already"] = true;
                Response.Redirect("./blogDetail.aspx?id=" + Request.QueryString["id"]);
            }

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“WebForm2.highlight_Click(object, EventArgs)”的 XML 注释
        protected void highlight_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“WebForm2.highlight_Click(object, EventArgs)”的 XML 注释
        {
            bool highlight = blog.CheckHighlight(Convert.ToInt32(Request.QueryString["id"]));
            if (highlight == true)
            {
                Session["successHighlight"] = true;
                Response.Redirect("./blogDetail.aspx?id=" + Request.QueryString["id"]);
            }
            else
            {
                Session["cancelHighlight"] = true;
                Response.Redirect("./blogDetail.aspx?id=" + Request.QueryString["id"]);
            }
        }
    }
}