using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RecordDAO”的 XML 注释
    public class RecordDAO
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RecordDAO”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RecordDAO.RecordDAO()”的 XML 注释
        public RecordDAO()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RecordDAO.RecordDAO()”的 XML 注释
        {

        }
        Database data = new Database();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RecordDAO.SelectCreditRecordByIdDESC(int)”的 XML 注释
        public DataSet SelectCreditRecordByIdDESC(int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RecordDAO.SelectCreditRecordByIdDESC(int)”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
            data.MakeInParam("@Id",  SqlDbType.Int, 4,Id)
            };
            return data.RunProcReturn("SELECT * FROM tb_CreditRecord Order By Id Desc", prams, "tb_CreditRecord");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RecordDAO.InsertCreditRecord(int, string, string, int, DateTime)”的 XML 注释
        public void InsertCreditRecord(int RecordId,string username, string act, int creditValue,DateTime OccurTime)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RecordDAO.InsertCreditRecord(int, string, string, int, DateTime)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@Id",  SqlDbType.Int, 4, RecordId),
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50, username),
            data.MakeInParam("@Act",  SqlDbType.VarChar, 50, act),
            data.MakeInParam("@CreditValue",  SqlDbType.Int, 4, creditValue),
            data.MakeInParam("@OccurTime",  SqlDbType.DateTime, 14, OccurTime),
            };
            data.RunProc("INSERT INTO tb_CreditRecord (Id,Username,Act,CreditValue,OccurTime) VALUES(@Id,@Username,@Act,@CreditValue,@OccurTime)", prams);
        
        }
    }
}