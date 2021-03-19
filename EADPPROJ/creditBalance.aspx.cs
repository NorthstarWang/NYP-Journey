using EADPPROJ.App_Code;
using System;
using System.Data;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“creditBalance”的 XML 注释
    public partial class creditBalance : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“creditBalance”的 XML 注释
    {
        Credit credit = new Credit();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“creditBalance.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“creditBalance.Page_Load(object, EventArgs)”的 XML 注释
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