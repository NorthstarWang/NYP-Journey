using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    public class ShopDAO
    {
        public ShopDAO()
        {

        }
        Database data = new Database();

        public DataSet SelectShopById(int Id)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                };
            ds = data.RunProcReturn("SELECT * FROM tb_Shop WHERE (Id = @Id)", prams, "tb_Shop");
            return ds;
        }

        public void InsertOrder(string username,int price)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
                data.MakeInParam("@Price",  SqlDbType.Int, 4,price),
                data.MakeInParam("@PostTime",  SqlDbType.DateTime, 14,DateTime.Now)
                };
            data.RunProc("INSERT INTO tb_Order (Username,Price,PostTime) VALUES(@Username,@Price,@PostTime)", prams);
        }

        public DataSet SelectOrderByIdDESC()
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,0),
                };
            return data.RunProcReturn("SELECT Id FROM tb_Order ORDER BY Id DESC", prams, "tb_Order");
        }

        public void InsertInvoice(int OrderId, int BookId, int Quantity)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@OrderId",  SqlDbType.Int, 4,OrderId),
                data.MakeInParam("@BookId",  SqlDbType.Int, 4,BookId),
                data.MakeInParam("@Quantity",  SqlDbType.Int, 4,Quantity)
                };
            data.RunProc("INSERT INTO tb_Invoice (OrderId,BookId,Quantity) VALUES(@OrderId,@BookId,@Quantity)", prams);
        }

        public DataSet SelectInvoiceByOrderId(int OrderID)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@OrderId",  SqlDbType.Int, 4,OrderID),
                };
            ds = data.RunProcReturn("SELECT * FROM tb_Invoice WHERE (OrderId = @OrderId)", prams, "tb_Invoice");
            return ds;
        }

        public DataSet SelectOrderById(int ID)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,ID),
                };
            ds = data.RunProcReturn("SELECT * FROM tb_Order WHERE (Id = @Id)", prams, "tb_Order");
            return ds;
        }
    }
}