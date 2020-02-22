using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    
    public class Shop
    {
        Database data = new Database();
        ShopDAO shopDAO = new ShopDAO();
        public DataSet ReturnBookInfo(Shop shop,int id)
        {
            return shopDAO.SelectShopById(id);
        }

        public void CreateOrder(Shop shop,string username, int price)
        {
            shopDAO.InsertOrder(username, price);
        }

        public int ReturnOrderId(Shop shop)
        {
            DataSet ds = shopDAO.SelectOrderByIdDESC();
            return Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
        }

        public void CreateInvoice(Shop shop,int OrderId, int BookId, int Quantity)
        {
            shopDAO.InsertInvoice(OrderId, BookId, Quantity);

        }

        public DataSet GetInvoiceBooks(Shop shop, int OrderID)
        {
            return shopDAO.SelectInvoiceByOrderId(OrderID);
        }
        public DataSet GetOrderInfo(Shop shop, int ID)
        {
            return shopDAO.SelectOrderById(ID);
        }
    }
}