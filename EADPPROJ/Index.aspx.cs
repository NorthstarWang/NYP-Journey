using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Index”的 XML 注释
    public partial class Index : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Index”的 XML 注释
    {
        Blog blog = new Blog();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Index.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Index.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (GridView1.Rows.Count != 0)
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    Label Default = (Label)GridView1.Rows[i].Cells[0].FindControl("Default");
                    HtmlImage BG = (HtmlImage)GridView1.Rows[i].Cells[0].FindControl("BlogImg");
                    Label id = (Label)GridView1.Rows[i].Cells[0].FindControl("BlogId");
                    if (Convert.ToInt32(Default.Text) == 0)
                    {
                        BG.Src = "../assets/img/BlogBG/" + blog.GetBGPath(Convert.ToInt32(id.Text));
                    }
                    else
                    {
                        BG.Src = "../assets/img/examples/office2.jpg";
                    }
                }
            }
        }
    }
}