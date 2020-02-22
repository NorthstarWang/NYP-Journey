using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    public class RecordDAO
    {
        public RecordDAO()
        {

        }
        Database data = new Database();

        public DataSet SelectCreditRecordByIdDESC(int Id)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
            data.MakeInParam("@Id",  SqlDbType.Int, 4,Id)
            };
            return data.RunProcReturn("SELECT * FROM tb_CreditRecord Order By Id Desc", prams, "tb_CreditRecord");
        }

        public void InsertCreditRecord(int RecordId,string username, string act, int creditValue,DateTime OccurTime)
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