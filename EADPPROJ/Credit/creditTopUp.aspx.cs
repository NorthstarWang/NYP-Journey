using EADPPROJ.App_Code;
using System;

namespace EADPPROJ
{
    public partial class creditTopUp : System.Web.UI.Page
    {
        Credit credit = new Credit();

        protected void Page_Load(object sender, EventArgs e)
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

        protected void RandomCredit_Click(object sender, EventArgs e)
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