using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace EADPPROJ.App_Code
{
    public class ForgetPassword
    {
        public ForgetPassword()
        {

        }

        Database data = new Database();

        private string username = "";
        private string nric = "";
        private string adminNo = "";
        private string password = "";

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string NRIC
        {
            get { return nric; }
            set { nric = value; }
        }

        public string AdminNo
        {
            get { return adminNo; }
            set { adminNo = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public DataSet GetAdminMail(ForgetPassword forgetPassword, string tbName)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50,forgetPassword.Username)
            };
            return (data.RunProcReturn("SELECT Mail FROM tb_Admin WHERE (username = @Username)", prams, tbName));
        }

        public DataSet GetStudentMail(ForgetPassword forgetPassword, string tbName)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,forgetPassword.AdminNo)
            };
            return (data.RunProcReturn("SELECT Mail FROM tb_Student WHERE (adminNo = @AdminNo)", prams, tbName));
        }

        public DataSet GetTeacherMail(ForgetPassword forgetPassword, string tbName)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,forgetPassword.NRIC)
            };
            return (data.RunProcReturn("SELECT Mail FROM tb_Teacher WHERE (nric = @NRIC)", prams, tbName));
        }

        public DataSet GetAdminPassword(ForgetPassword forgetPassword, string tbName)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50,forgetPassword.Username)
            };
            return (data.RunProcReturn("SELECT Password FROM tb_Admin WHERE (username = @Username)", prams, tbName));
        }

        public DataSet GetStudentPassword(ForgetPassword forgetPassword, string tbName)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,forgetPassword.AdminNo)
            };
            return (data.RunProcReturn("SELECT Password FROM tb_Student WHERE (adminNo = @AdminNo)", prams, tbName));
        }

        public DataSet GetTeacherPassword(ForgetPassword forgetPassword, string tbName)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,forgetPassword.NRIC)
            };
            return (data.RunProcReturn("SELECT Password FROM tb_Teacher WHERE (nric = @NRIC)", prams, tbName));
        }

        public void SendMail(ForgetPassword forgetPassword, string receiver, string password)
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