using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementCreditTransaction”的 XML 注释
    public partial class managementCreditTransaction : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementCreditTransaction”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementCreditTransaction.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementCreditTransaction.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (IsPostBack)
            {
                if (search.Text != "")
                {
                    try
                    {
                        creditTransaction.SelectCommand = "SELECT * FROM [tb_CreditRecord] WHERE [Username] LIKE '%" + search.Text + "%' OR [Id] LIKE '%" + search.Text + "%' ORDER BY[OccurTime] DESC, [Id] DESC";
                        creditTransaction.DataBind();
                        GridView1.DataBind();
                    }
                    catch (Exception)
                    {
                        NoData.Visible = true;
                        GridView1.Visible = false;
                    }

                }
                else
                {
                    creditTransaction.SelectCommand = "SELECT * FROM [tb_CreditRecord] ORDER BY [OccurTime] DESC, [Id] DESC";
                }
                
            }
        }
    }
}