using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“LoginDAO”的 XML 注释
    public class LoginDAO
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“LoginDAO”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“LoginDAO.LoginDAO()”的 XML 注释
        public LoginDAO()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“LoginDAO.LoginDAO()”的 XML 注释
        {

        }

        Database data = new Database();
        Record record = new Record();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“LoginDAO.SelectAdminByIdentification(string, string)”的 XML 注释
        public DataSet SelectAdminByIdentification(string username, string password)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“LoginDAO.SelectAdminByIdentification(string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
            data.MakeInParam("@Password",  SqlDbType.VarChar, 50, password),
            };
            return data.RunProcReturn("SELECT * FROM tb_Admin WHERE (username = @Username) AND (password = @Password)", prams, "tb_Admin");
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“LoginDAO.SelectTeacherByIdentification(string, string)”的 XML 注释
        public DataSet SelectTeacherByIdentification(string username, string password)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“LoginDAO.SelectTeacherByIdentification(string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,username),
            data.MakeInParam("@Password",  SqlDbType.VarChar, 50, password),
            };
            return data.RunProcReturn("SELECT * FROM tb_Teacher WHERE (nric = @NRIC) AND (password = @Password)", prams, "tb_Teacher");

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“LoginDAO.SelectStudentByIdentification(string, string)”的 XML 注释
        public DataSet SelectStudentByIdentification(string username, string password)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“LoginDAO.SelectStudentByIdentification(string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,username),
            data.MakeInParam("@Password",  SqlDbType.VarChar, 50, password),
            };
            return data.RunProcReturn("SELECT * FROM tb_Student WHERE (adminNo = @AdminNo) AND (password = @Password)", prams, "tb_Student");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“LoginDAO.SelectInvitationByUsername(string)”的 XML 注释
        public DataSet SelectInvitationByUsername(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“LoginDAO.SelectInvitationByUsername(string)”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
            };
            return data.RunProcReturn("SELECT * FROM tb_Invitation WHERE (Username = @username)", prams, "tb_Invitation");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“LoginDAO.SelectInvitationByCode(string)”的 XML 注释
        public DataSet SelectInvitationByCode(string code)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“LoginDAO.SelectInvitationByCode(string)”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
            data.MakeInParam("@Code",  SqlDbType.VarChar, 50,code),
            };
            return data.RunProcReturn("SELECT * FROM tb_Invitation WHERE (Code = @Code)", prams, "tb_Invitation");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“LoginDAO.UpdateInvitationInviteByByUsername(string, string)”的 XML 注释
        public void UpdateInvitationInviteByByUsername(string username, string invite)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“LoginDAO.UpdateInvitationInviteByByUsername(string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50, username),
                data.MakeInParam("@InviteBy",  SqlDbType.VarChar, 50, invite)
                };
            data.RunProc("UPDATE tb_Invitation SET InviteBy = (@InviteBy) WHERE (Username = @Username)", prams);
        }


    }
}