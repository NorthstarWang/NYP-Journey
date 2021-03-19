using EADPPROJ.App_Code;
using System;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“creditTopUp”的 XML 注释
    public partial class creditTopUp : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“creditTopUp”的 XML 注释
    {
        Credit credit = new Credit();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“creditTopUp.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“creditTopUp.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (Request.QueryString["paymentId"] != null)
            {
                if (Request.QueryString["item"] == "first")
                {
                    credit.AddCredit(Session["Account"].ToString(), 98);
                    Response.Redirect("./creditTopUp.aspx");
                }
                else if (Request.QueryString["item"] == "second")
                {
                    credit.AddCredit(Session["Account"].ToString(), 999);
                    Response.Redirect("./creditTopUp.aspx");
                }
                else if (Request.QueryString["item"] == "third")
                {
                    credit.AddCredit(Session["Account"].ToString(), 10088);
                    Response.Redirect("./creditTopUp.aspx");
                }
                else if (Request.QueryString["item"] == "custom")
                {
                    credit.AddCredit(Session["Account"].ToString(), Convert.ToInt32(Session["CreditAmt"]));
                    Response.Redirect("./creditTopUp.aspx");
                }
            }
        }


#pragma warning disable CS1591 // 缺少对公共可见类型或成员“creditTopUp.RandomCredit_Click(object, EventArgs)”的 XML 注释
        protected void RandomCredit_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“creditTopUp.RandomCredit_Click(object, EventArgs)”的 XML 注释
        {
            try
            {
                int cNo = Convert.ToInt32(creditNo.Text);
            }
            catch (Exception)
            {
                Session["intWarn"] = "true";
                Response.Redirect("./creditTopUp.aspx");
            }
            Session["CreditAmt"] = creditNo.Text;
            Session["Price"] = credit.CalculateTopUpPrice(Convert.ToInt32(creditNo.Text));
            Response.Redirect("./creditTopUp.aspx");

        }
    }
}