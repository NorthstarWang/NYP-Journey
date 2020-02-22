using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EADPPROJ
{
    public partial class managementCreditTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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