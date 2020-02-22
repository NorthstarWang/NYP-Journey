using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace EADPPROJ.App_Code
{
    public class Database:IDisposable
    {
        public Database()
        {

        }
        private SqlConnection con;
        private void Open()
        {
            if (con == null)
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            }
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }
        public void Close()
        {
            if (con != null)
                con.Close();
        }
        public void Dispose()
        {
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;
            return param;
        }
        public int RunProc(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        public int RunProc(string procName)
        {
            this.Open();
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.ExecuteNonQuery();
            this.Close();
            return 1;
        }
        public DataSet RunProcReturn(string procName, SqlParameter[] prams, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, prams);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            return ds;
        }
        public DataSet RunProcReturn(string procName, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, null);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            return ds;
        }
        private SqlDataAdapter CreateDataAdaper(string procName, SqlParameter[] prams)
        {
            this.Open();
            SqlDataAdapter dap = new SqlDataAdapter(procName, con);
            dap.SelectCommand.CommandType = CommandType.Text;
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    dap.SelectCommand.Parameters.Add(parameter);
            }
            dap.SelectCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return dap;
        }
        private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            this.Open();
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.Text;

            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }
            cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return cmd;
        }
    }
    
}