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
    public partial class Index : System.Web.UI.Page
    {
        Blog blog = new Blog();
        protected void Page_Load(object sender, EventArgs e)
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