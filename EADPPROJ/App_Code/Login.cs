using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace EADPPROJ.App_Code
{
    public class Login_Class
    {
        Credit credit = new Credit();
        LoginDAO loginDAO = new LoginDAO();
        public Login_Class()
        {

        }

        Database data = new Database();

        private string username = "";
        private string password = "";
        private string nric = "";
        private string adminNo = "";
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string AdminNo
        {
            get { return adminNo; }
            set { adminNo = value; }
        }
        public string NRIC
        {
            get { return nric; }
            set { nric = value; }
        }
        public DataSet LoginAdmin(Login_Class login)
        {
            return loginDAO.SelectAdminByIdentification(login.Username,login.Password);
        }
        public DataSet LoginTeacher(Login_Class login)
        {
            return loginDAO.SelectTeacherByIdentification(login.NRIC, login.Password);
        }
        public DataSet LoginStudent(Login_Class login)
        {
            return loginDAO.SelectStudentByIdentification(login.AdminNo, login.Password);
        }


        public int checkUserCodeAvailability(string username)
        {
            DataSet ds = loginDAO.SelectInvitationByUsername(username);
            if (ds.Tables[0].Rows[0]["InviteBy"] != DBNull.Value)
            {
                return 0;//available
            }
            else
            {
                return 1;
            }
        }

        public string getUserFromInviteBy(string code)
        {
            DataSet ds = loginDAO.SelectInvitationByCode(code);
            return ds.Tables[0].Rows[0]["Username"].ToString();
        }

        public string getUserFromCode(string code)
        {
            DataSet ds = loginDAO.SelectInvitationByCode(code);
            return ds.Tables[0].Rows[0]["Username"].ToString();
        }
        public void addCode(string username,string code)
        {
            string invite = getUserFromInviteBy(code);
            loginDAO.UpdateInvitationInviteByByUsername(username, invite);
        }

        public string fillInInvitationCode(string code,string username)
        {
            DataSet ds = loginDAO.SelectInvitationByCode(code);
            if (ds.Tables[0].Rows.Count == 0)//no such code
            {
                return "Insufficient code";
            }
            else if(checkUserCodeAvailability(username)==1)
            {
                addCode(username, code);
                credit.AddCredit(username, 300);
                credit.AddCredit(ds.Tables[0].Rows[0]["Username"].ToString(), 100);
                return "You have used the invitation code.";
            }
            else
            {
                return "You have already used an invitation code.";
            }
        }

        public string getInvitationCode(string username)
        {
            DataSet ds = loginDAO.SelectInvitationByUsername(username);
            return ds.Tables[0].Rows[0]["Code"].ToString();
        }
    }
}