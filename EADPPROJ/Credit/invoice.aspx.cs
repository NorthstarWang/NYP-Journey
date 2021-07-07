using EADPPROJ.App_Code;
using Pechkin;
using System;
using System.Data;
using System.IO;
using System.Web.UI;

namespace EADPPROJ
{
    public partial class invoice : System.Web.UI.Page
    {
        Shop shop = new Shop();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                DataSet dsOrder = null;
                Label1.Text = Session["Account"].ToString();
                int orderId = Convert.ToInt32(Request.QueryString["id"]);
                dsOrder = shop.GetOrderInfo(shop, orderId);
                PostTime.InnerText = dsOrder.Tables[0].Rows[0]["PostTime"].ToString();
                invoiceId.InnerText = dsOrder.Tables[0].Rows[0]["Id"].ToString();
                totalPrice.InnerText = dsOrder.Tables[0].Rows[0]["Price"].ToString();
                Page.DataBind();
            }
        }

        protected string loadName(int id)
        {
            DataSet ds = null;
            ds = shop.ReturnBookInfo(shop, id);
            return ds.Tables[0].Rows[0]["Name"].ToString();
        }

        protected string loadPrice(int id)
        {
            DataSet ds = null;
            ds = shop.ReturnBookInfo(shop, id);
            return ds.Tables[0].Rows[0]["Price"].ToString();
        }

        protected string loadTotal(int quantity, int price)
        {
            int i = quantity * price;
            return i.ToString();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void download_Click(object sender, EventArgs e)
        {
            var config = new GlobalConfig();
            var pechkin = new SimplePechkin(config);
            ObjectConfig oc = new ObjectConfig();
            oc.SetPrintBackground(true)
                .SetLoadImages(true);
            System.Text.StringBuilder html = new System.Text.StringBuilder();
            System.IO.StringWriter htmlStr = new System.IO.StringWriter(html);
            System.Web.UI.HtmlTextWriter htw = new HtmlTextWriter(htmlStr);
            pdfHTML.RenderControl(htw);
            string htmlinner = html.ToString();
            byte[] pdf = pechkin.Convert(oc, htmlinner);
            File.WriteAllBytes("C:\\Users\\Wang Yang\\Desktop\\EADPPROJ\\EADPPROJ\\assets\\download\\invoice.pdf", pdf);
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=INVOICE_PDF.pdf");
            Response.TransmitFile(Server.MapPath("~/assets/download/invoice.pdf"));
            Response.End();
        }
    }
}