using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Shop”的 XML 注释
    public class Shop
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Shop”的 XML 注释
    {
        Database data = new Database();
        ShopDAO shopDAO = new ShopDAO();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Shop.ReturnBookInfo(Shop, int)”的 XML 注释
        public DataSet ReturnBookInfo(Shop shop,int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Shop.ReturnBookInfo(Shop, int)”的 XML 注释
        {
            return shopDAO.SelectShopById(id);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Shop.CreateOrder(Shop, string, int)”的 XML 注释
        public void CreateOrder(Shop shop,string username, int price)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Shop.CreateOrder(Shop, string, int)”的 XML 注释
        {
            shopDAO.InsertOrder(username, price);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Shop.ReturnOrderId(Shop)”的 XML 注释
        public int ReturnOrderId(Shop shop)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Shop.ReturnOrderId(Shop)”的 XML 注释
        {
            DataSet ds = shopDAO.SelectOrderByIdDESC();
            return Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Shop.CreateInvoice(Shop, int, int, int)”的 XML 注释
        public void CreateInvoice(Shop shop,int OrderId, int BookId, int Quantity)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Shop.CreateInvoice(Shop, int, int, int)”的 XML 注释
        {
            shopDAO.InsertInvoice(OrderId, BookId, Quantity);

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Shop.GetInvoiceBooks(Shop, int)”的 XML 注释
        public DataSet GetInvoiceBooks(Shop shop, int OrderID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Shop.GetInvoiceBooks(Shop, int)”的 XML 注释
        {
            return shopDAO.SelectInvoiceByOrderId(OrderID);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Shop.GetOrderInfo(Shop, int)”的 XML 注释
        public DataSet GetOrderInfo(Shop shop, int ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Shop.GetOrderInfo(Shop, int)”的 XML 注释
        {
            return shopDAO.SelectOrderById(ID);
        }
    }
}