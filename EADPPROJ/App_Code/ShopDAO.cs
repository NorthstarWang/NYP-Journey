using System;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ShopDAO”的 XML 注释
    public class ShopDAO
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ShopDAO”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ShopDAO.ShopDAO()”的 XML 注释
        public ShopDAO()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ShopDAO.ShopDAO()”的 XML 注释
        {

        }
        Database data = new Database();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ShopDAO.SelectShopById(int)”的 XML 注释
        public DataSet SelectShopById(int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ShopDAO.SelectShopById(int)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                };
            ds = data.RunProcReturn("SELECT * FROM tb_Shop WHERE (Id = @Id)", prams, "tb_Shop");
            return ds;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ShopDAO.InsertOrder(string, int)”的 XML 注释
        public void InsertOrder(string username, int price)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ShopDAO.InsertOrder(string, int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
                data.MakeInParam("@Price",  SqlDbType.Int, 4,price),
                data.MakeInParam("@PostTime",  SqlDbType.DateTime, 14,DateTime.Now)
                };
            data.RunProc("INSERT INTO tb_Order (Username,Price,PostTime) VALUES(@Username,@Price,@PostTime)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ShopDAO.SelectOrderByIdDESC()”的 XML 注释
        public DataSet SelectOrderByIdDESC()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ShopDAO.SelectOrderByIdDESC()”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,0),
                };
            return data.RunProcReturn("SELECT Id FROM tb_Order ORDER BY Id DESC", prams, "tb_Order");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ShopDAO.InsertInvoice(int, int, int)”的 XML 注释
        public void InsertInvoice(int OrderId, int BookId, int Quantity)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ShopDAO.InsertInvoice(int, int, int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@OrderId",  SqlDbType.Int, 4,OrderId),
                data.MakeInParam("@BookId",  SqlDbType.Int, 4,BookId),
                data.MakeInParam("@Quantity",  SqlDbType.Int, 4,Quantity)
                };
            data.RunProc("INSERT INTO tb_Invoice (OrderId,BookId,Quantity) VALUES(@OrderId,@BookId,@Quantity)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ShopDAO.SelectInvoiceByOrderId(int)”的 XML 注释
        public DataSet SelectInvoiceByOrderId(int OrderID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ShopDAO.SelectInvoiceByOrderId(int)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@OrderId",  SqlDbType.Int, 4,OrderID),
                };
            ds = data.RunProcReturn("SELECT * FROM tb_Invoice WHERE (OrderId = @OrderId)", prams, "tb_Invoice");
            return ds;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ShopDAO.SelectOrderById(int)”的 XML 注释
        public DataSet SelectOrderById(int ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ShopDAO.SelectOrderById(int)”的 XML 注释
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