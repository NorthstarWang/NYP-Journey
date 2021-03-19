using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CreditDAO”的 XML 注释
    public class CreditDAO
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CreditDAO”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CreditDAO.CreditDAO()”的 XML 注释
        public CreditDAO()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CreditDAO.CreditDAO()”的 XML 注释
        {

        }

        Database data = new Database();
        Record record = new Record();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CreditDAO.SelectCreditFromUser(string)”的 XML 注释
        public DataSet SelectCreditFromUser(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CreditDAO.SelectCreditFromUser(string)”的 XML 注释
        {
            DataSet ds = null;
            if (username.Length == 7)
            {
                SqlParameter[] prams = {
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,username),
                };
                ds = data.RunProcReturn("SELECT Credit FROM tb_Student WHERE (AdminNo = @AdminNo)", prams, "tb_Student");
                return ds;
            }
            else if (username.Length == 9)
            {
                SqlParameter[] prams = {
                    data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,username),
                    };
                ds = data.RunProcReturn("SELECT Credit FROM tb_Teacher WHERE (NRIC = @NRIC)", prams, "tb_Teacher");
                return ds;
            }
            else
            {
                SqlParameter[] prams = {
                    data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
                    };
                ds = data.RunProcReturn("SELECT Credit FROM tb_Admin WHERE (Username = @Username)", prams, "tb_Admin");
                return ds;
            }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CreditDAO.SelectRewardFromQuestionById(int)”的 XML 注释
        public DataSet SelectRewardFromQuestionById(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CreditDAO.SelectRewardFromQuestionById(int)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                    data.MakeInParam("@Id",  SqlDbType.VarChar, 50,id),
                    };
            ds = data.RunProcReturn("SELECT CreditReward FROM tb_Question WHERE (Id = @Id)", prams, "tb_Question");
            return ds;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CreditDAO.UpdateStudentCredit(string, int)”的 XML 注释
        public void UpdateStudentCredit(string username,int credit)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CreditDAO.UpdateStudentCredit(string, int)”的 XML 注释
        {
            SqlParameter[] prams = {
                    data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,username),
                    data.MakeInParam("@Credit",  SqlDbType.Int, 4,credit)
                    };
            data.RunProc("UPDATE tb_Student SET Credit = (@Credit) WHERE (AdminNo = @AdminNo)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CreditDAO.UpdateTeacherCredit(string, int)”的 XML 注释
        public void UpdateTeacherCredit(string username, int credit)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CreditDAO.UpdateTeacherCredit(string, int)”的 XML 注释
        {
            SqlParameter[] prams = {
                    data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,username),
                    data.MakeInParam("@Credit",  SqlDbType.Int, 4,credit)
                    };
            data.RunProc("UPDATE tb_Teacher SET Credit = (@Credit) WHERE (NRIC = @NRIC)", prams);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CreditDAO.UpdateAdminCredit(string, int)”的 XML 注释
        public void UpdateAdminCredit(string username, int credit)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CreditDAO.UpdateAdminCredit(string, int)”的 XML 注释
        {
            SqlParameter[] prams = {
                    data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
                    data.MakeInParam("@Credit",  SqlDbType.Int, 4,credit)
                    };
            data.RunProc("UPDATE tb_Admin SET Credit = (@Credit) WHERE (Username = @Username)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CreditDAO.SelectCreditRecordByUsername(string)”的 XML 注释
        public DataSet SelectCreditRecordByUsername(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CreditDAO.SelectCreditRecordByUsername(string)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                    data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
                    };
            ds = data.RunProcReturn("SELECT * FROM tb_CreditRecord WHERE (Username = @Username)", prams, "tb_CreditRecord");
            return ds;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CreditDAO.SelectCreditRecordByUsernameWhereActIsAdd(string)”的 XML 注释
        public DataSet SelectCreditRecordByUsernameWhereActIsAdd(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CreditDAO.SelectCreditRecordByUsernameWhereActIsAdd(string)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                    data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username)
                    };
            ds = data.RunProcReturn("SELECT * FROM tb_CreditRecord WHERE (Username = @Username) and (Act = 'Add')", prams, "tb_CreditRecord");
            return ds;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“CreditDAO.SelectCreditRecordByUsernameWhereActIsMinus(string)”的 XML 注释
        public DataSet SelectCreditRecordByUsernameWhereActIsMinus(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“CreditDAO.SelectCreditRecordByUsernameWhereActIsMinus(string)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                    data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username)
                    };
            ds = data.RunProcReturn("SELECT * FROM tb_CreditRecord WHERE (Username = @Username) and (Act = 'Minus')", prams, "tb_CreditRecord");
            return ds;
        }
    }
}