using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EADPPROJ.App_Code;
using System.Data;
using Pechkin;
using System.IO;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“invoice”的 XML 注释
    public partial class invoice : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“invoice”的 XML 注释
    {
        Shop shop = new Shop();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“invoice.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“invoice.Page_Load(object, EventArgs)”的 XML 注释
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“invoice.loadName(int)”的 XML 注释
        protected string loadName(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“invoice.loadName(int)”的 XML 注释
        {
            DataSet ds = null;
            ds = shop.ReturnBookInfo(shop, id);
            return ds.Tables[0].Rows[0]["Name"].ToString();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“invoice.loadPrice(int)”的 XML 注释
        protected string loadPrice(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“invoice.loadPrice(int)”的 XML 注释
        {
            DataSet ds = null;
            ds = shop.ReturnBookInfo(shop, id);
            return ds.Tables[0].Rows[0]["Price"].ToString();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“invoice.loadTotal(int, int)”的 XML 注释
        protected string loadTotal(int quantity,int price)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“invoice.loadTotal(int, int)”的 XML 注释
        {
            int i = quantity* price;
            return i.ToString();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“invoice.VerifyRenderingInServerForm(Control)”的 XML 注释
        public override void VerifyRenderingInServerForm(Control control)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“invoice.VerifyRenderingInServerForm(Control)”的 XML 注释
        {
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“invoice.download_Click(object, EventArgs)”的 XML 注释
        protected void download_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“invoice.download_Click(object, EventArgs)”的 XML 注释
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
            string htmlinner= html.ToString();
            byte[] pdf = pechkin.Convert(oc, htmlinner);
            File.WriteAllBytes("C:\\Users\\Wang Yang\\Desktop\\EADPPROJ\\EADPPROJ\\assets\\download\\invoice.pdf", pdf);
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=INVOICE_PDF.pdf");
            Response.TransmitFile(Server.MapPath("~/assets/download/invoice.pdf"));
            Response.End();
        }
    }
}