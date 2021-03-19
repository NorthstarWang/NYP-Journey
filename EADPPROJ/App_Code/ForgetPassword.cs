using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword”的 XML 注释
    public class ForgetPassword
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.ForgetPassword()”的 XML 注释
        public ForgetPassword()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.ForgetPassword()”的 XML 注释
        {

        }

        Database data = new Database();

        private string username = "";
        private string nric = "";
        private string adminNo = "";
        private string password = "";
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.Username”的 XML 注释
        public string Username
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.Username”的 XML 注释
        {
            get { return username; }
            set { username = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.NRIC”的 XML 注释
        public string NRIC
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.NRIC”的 XML 注释
        {
            get { return nric; }
            set { nric = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.AdminNo”的 XML 注释
        public string AdminNo
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.AdminNo”的 XML 注释
        {
            get { return adminNo; }
            set { adminNo = value; }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.Password”的 XML 注释
        public string Password
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.Password”的 XML 注释
        {
            get { return password; }
            set { password = value; }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetAdminMail(ForgetPassword, string)”的 XML 注释
        public DataSet GetAdminMail(ForgetPassword forgetPassword, string tbName)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetAdminMail(ForgetPassword, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50,forgetPassword.Username)
            };
            return (data.RunProcReturn("SELECT Mail FROM tb_Admin WHERE (username = @Username)", prams, tbName));
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetStudentMail(ForgetPassword, string)”的 XML 注释
        public DataSet GetStudentMail(ForgetPassword forgetPassword, string tbName)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetStudentMail(ForgetPassword, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,forgetPassword.AdminNo)
            };
            return (data.RunProcReturn("SELECT Mail FROM tb_Student WHERE (adminNo = @AdminNo)", prams, tbName));
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetTeacherMail(ForgetPassword, string)”的 XML 注释
        public DataSet GetTeacherMail(ForgetPassword forgetPassword, string tbName)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetTeacherMail(ForgetPassword, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,forgetPassword.NRIC)
            };
            return (data.RunProcReturn("SELECT Mail FROM tb_Teacher WHERE (nric = @NRIC)", prams, tbName));
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetAdminPassword(ForgetPassword, string)”的 XML 注释
        public DataSet GetAdminPassword(ForgetPassword forgetPassword, string tbName)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetAdminPassword(ForgetPassword, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50,forgetPassword.Username)
            };
            return (data.RunProcReturn("SELECT Password FROM tb_Admin WHERE (username = @Username)", prams, tbName));
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetStudentPassword(ForgetPassword, string)”的 XML 注释
        public DataSet GetStudentPassword(ForgetPassword forgetPassword, string tbName)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetStudentPassword(ForgetPassword, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,forgetPassword.AdminNo)
            };
            return (data.RunProcReturn("SELECT Password FROM tb_Student WHERE (adminNo = @AdminNo)", prams, tbName));
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetTeacherPassword(ForgetPassword, string)”的 XML 注释
        public DataSet GetTeacherPassword(ForgetPassword forgetPassword, string tbName)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.GetTeacherPassword(ForgetPassword, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,forgetPassword.NRIC)
            };
            return (data.RunProcReturn("SELECT Password FROM tb_Teacher WHERE (nric = @NRIC)", prams, tbName));
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ForgetPassword.SendMail(ForgetPassword, string, string)”的 XML 注释
        public void SendMail(ForgetPassword forgetPassword, string receiver, string password)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ForgetPassword.SendMail(ForgetPassword, string, string)”的 XML 注释
        {
            SmtpClient mailClient = new SmtpClient("smtp.office365.com", 587);
            mailClient.EnableSsl = true;
            NetworkCredential crendetial = new NetworkCredential("181192P@mymail.nyp.edu.sg", "Wangyang197201");

            mailClient.Credentials = crendetial;
            MailMessage message = new MailMessage("181192P@mymail.nyp.edu.sg", receiver, "Your Education System Password ", "Your Password is " + password);

            mailClient.Send(message);
        }
    }
}