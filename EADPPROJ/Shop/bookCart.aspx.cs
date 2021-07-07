using EADPPROJ.App_Code;
using System;
using System.Collections;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
    public partial class shoppingCart : System.Web.UI.Page
    {
        Shop shop = new Shop();
        Credit credit = new Credit();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                Hashtable ht = (Hashtable)Session["cart"];
                Repeater1.DataSource = ht;
                Repeater1.DataBind();
                int credits = 0;
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    Label bookId = (Label)item.FindControl("bookId");
                    int Id = Convert.ToInt32(bookId.Text);
                    DataSet ds = new DataSet();
                    ds = shop.ReturnBookInfo(shop, Id);
                    HtmlImage image = (HtmlImage)item.FindControl("Image");
                    image.Src = "../assets/img/books/" + ds.Tables[0].Rows[0]["Image"].ToString();
                    Label bookName = (Label)item.FindControl("bookName");
                    bookName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    Label bookSchool = (Label)item.FindControl("school");
                    bookSchool.Text = ds.Tables[0].Rows[0]["School"].ToString();
                    Label bookPrice = (Label)item.FindControl("price");
                    bookPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    Label totalPrice = (Label)item.FindControl("total");
                    Label bookNumber = (Label)item.FindControl("Number");
                    totalPrice.Text = (Convert.ToInt32(bookNumber.Text) * Convert.ToInt32(bookPrice.Text)).ToString();
                    credits += Convert.ToInt32(totalPrice.Text);

                }
                Label price = (Label)Repeater1.Controls[Repeater1.Controls.Count - 1].Controls[0].FindControl("OverallPrice");
                price.Text = credits.ToString();
                int creditNo = credit.GetCreditAmount(Session["Account"].ToString());
                HtmlGenericControl paymentBody = (HtmlGenericControl)Repeater1.Controls[Repeater1.Controls.Count - 1].Controls[0].FindControl("paymentBody");
                HtmlGenericControl paymentSection = (HtmlGenericControl)Repeater1.Controls[Repeater1.Controls.Count - 1].Controls[0].FindControl("paymentSection");
                if (credits <= creditNo)
                {
                    paymentBody.InnerText = "This payment will cost you " + credits.ToString() + " Credits. You currently have " + creditNo.ToString() + " Credits. Do you confirm to redeem these books?";
                    paymentSection.Visible = true;
                }
                else
                {
                    paymentBody.InnerText = "Insufficient credits! This payment will cost you " + credits.ToString() + " Credits. You currently have " + creditNo.ToString() + " Credits. Please earn more credits!";

                }

            }
            else
            {
                NoCart.Visible = true;
            }
        }

        protected void remove_Click(object sender, EventArgs e)
        {
            LinkButton remove = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)remove.NamingContainer;
            Label bookId = (Label)item.FindControl("bookId");
            Label Number = (Label)item.FindControl("Number");
            if (Convert.ToInt32(Number.Text) > 1)
            {
                int newNum = Convert.ToInt32(Number.Text) - 1;
                int Id = Convert.ToInt32(bookId.Text);
                Hashtable ht = (Hashtable)Session["cart"];
                ht[Id] = newNum;
                Response.Redirect("bookCart.aspx");
            }
            else
            {
                Session["MinimumNo"] = true;
                Response.Redirect("bookCart.aspx");
            }

        }

        protected void add_Click(object sender, EventArgs e)
        {
            LinkButton add = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)add.NamingContainer;
            Label bookId = (Label)item.FindControl("bookId");
            Label Number = (Label)item.FindControl("Number");
            int newNum = Convert.ToInt32(Number.Text) + 1;
            int Id = Convert.ToInt32(bookId.Text);
            Hashtable ht = (Hashtable)Session["cart"];
            ht[Id] = newNum;
            Response.Redirect("bookCart.aspx");
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            LinkButton delete = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)delete.NamingContainer;
            Hashtable ht = (Hashtable)Session["cart"];
            Label bookId = (Label)item.FindControl("bookId");
            int Id = Convert.ToInt32(bookId.Text);
            ht.Remove(Id);
            Response.Redirect("bookCart.aspx");
        }

        protected void Pay_Click(object sender, EventArgs e)
        {
            Label price = (Label)Repeater1.Controls[Repeater1.Controls.Count - 1].Controls[0].FindControl("OverallPrice");
            int cost = Convert.ToInt32(price.Text);
            credit.MinusCredit(Session["Account"].ToString(), cost);
            Hashtable ht = (Hashtable)Session["cart"];
            shop.CreateOrder(shop, Session["Account"].ToString(), cost);
            int OrderId = shop.ReturnOrderId(shop);
            ICollection items = ht.Keys;
            foreach (int id in items)
            {
                shop.CreateInvoice(shop, OrderId, id, Convert.ToInt32(ht[id]));
            }
            Session["cart"] = null;
            Session["successPayment"] = true;
            Response.Redirect("bookCart.aspx");
        }
    }
}