using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Database”的 XML 注释
    public class Database:IDisposable
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Database”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Database.Database()”的 XML 注释
        public Database()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Database.Database()”的 XML 注释
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
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Database.Close()”的 XML 注释
        public void Close()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Database.Close()”的 XML 注释
        {
            if (con != null)
                con.Close();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Database.Dispose()”的 XML 注释
        public void Dispose()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Database.Dispose()”的 XML 注释
        {
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Database.MakeInParam(string, SqlDbType, int, object)”的 XML 注释
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Database.MakeInParam(string, SqlDbType, int, object)”的 XML 注释
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Database.MakeParam(string, SqlDbType, int, ParameterDirection, object)”的 XML 注释
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Database.MakeParam(string, SqlDbType, int, ParameterDirection, object)”的 XML 注释
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
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Database.RunProc(string, SqlParameter[])”的 XML 注释
        public int RunProc(string procName, SqlParameter[] prams)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Database.RunProc(string, SqlParameter[])”的 XML 注释
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Database.RunProc(string)”的 XML 注释
        public int RunProc(string procName)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Database.RunProc(string)”的 XML 注释
        {
            this.Open();
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.ExecuteNonQuery();
            this.Close();
            return 1;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Database.RunProcReturn(string, SqlParameter[], string)”的 XML 注释
        public DataSet RunProcReturn(string procName, SqlParameter[] prams, string tbName)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Database.RunProcReturn(string, SqlParameter[], string)”的 XML 注释
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, prams);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            return ds;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Database.RunProcReturn(string, string)”的 XML 注释
        public DataSet RunProcReturn(string procName, string tbName)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Database.RunProcReturn(string, string)”的 XML 注释
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