using EADPPROJ.App_Code;
using System;
using System.Data;

namespace EADPPROJ
{
    public partial class creditBalance : System.Web.UI.Page
    {
        Credit credit = new Credit();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet dsEarn = null;
            DataSet dsSpent = null;
            creditAmt.Text = credit.GetCreditAmount(Session["Account"].ToString()).ToString();
            dsEarn = credit.GetEarnNumber(Session["Account"].ToString());
            transactionNo.Text = credit.GetTransactionNumber(Session["Account"].ToString()).ToString();
            int earn = 0;
            if (dsEarn.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < dsEarn.Tables[0].Rows.Count; i++)
                {
                    earn += Convert.ToInt32(dsEarn.Tables[0].Rows[i]["CreditValue"]);
                }
            }
            earnNo.Text = earn.ToString();
            dsSpent = credit.GetMinusNumber(Session["Account"].ToString());
            int spent = 0;
            if (dsSpent.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < dsSpent.Tables[0].Rows.Count; i++)
                {
                    spent += Convert.ToInt32(dsSpent.Tables[0].Rows[i]["CreditValue"]);
                }
            }
            spentNo.Text = spent.ToString();
        }
    }
}