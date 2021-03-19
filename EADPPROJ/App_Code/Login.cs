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
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class”的 XML 注释
    public class Login_Class
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class”的 XML 注释
    {
        Credit credit = new Credit();
        LoginDAO loginDAO = new LoginDAO();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.Login_Class()”的 XML 注释
        public Login_Class()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.Login_Class()”的 XML 注释
        {

        }

        Database data = new Database();

        private string username = "";
        private string password = "";
        private string nric = "";
        private string adminNo = "";
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.Username”的 XML 注释
        public string Username
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.Username”的 XML 注释
        {
            get { return username; }
            set { username = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.Password”的 XML 注释
        public string Password
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.Password”的 XML 注释
        {
            get { return password; }
            set { password = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.AdminNo”的 XML 注释
        public string AdminNo
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.AdminNo”的 XML 注释
        {
            get { return adminNo; }
            set { adminNo = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.NRIC”的 XML 注释
        public string NRIC
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.NRIC”的 XML 注释
        {
            get { return nric; }
            set { nric = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.LoginAdmin(Login_Class)”的 XML 注释
        public DataSet LoginAdmin(Login_Class login)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.LoginAdmin(Login_Class)”的 XML 注释
        {
            return loginDAO.SelectAdminByIdentification(login.Username,login.Password);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.LoginTeacher(Login_Class)”的 XML 注释
        public DataSet LoginTeacher(Login_Class login)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.LoginTeacher(Login_Class)”的 XML 注释
        {
            return loginDAO.SelectTeacherByIdentification(login.NRIC, login.Password);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.LoginStudent(Login_Class)”的 XML 注释
        public DataSet LoginStudent(Login_Class login)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.LoginStudent(Login_Class)”的 XML 注释
        {
            return loginDAO.SelectStudentByIdentification(login.AdminNo, login.Password);
        }


#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.checkUserCodeAvailability(string)”的 XML 注释
        public int checkUserCodeAvailability(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.checkUserCodeAvailability(string)”的 XML 注释
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.getUserFromInviteBy(string)”的 XML 注释
        public string getUserFromInviteBy(string code)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.getUserFromInviteBy(string)”的 XML 注释
        {
            DataSet ds = loginDAO.SelectInvitationByCode(code);
            return ds.Tables[0].Rows[0]["Username"].ToString();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.getUserFromCode(string)”的 XML 注释
        public string getUserFromCode(string code)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.getUserFromCode(string)”的 XML 注释
        {
            DataSet ds = loginDAO.SelectInvitationByCode(code);
            return ds.Tables[0].Rows[0]["Username"].ToString();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.addCode(string, string)”的 XML 注释
        public void addCode(string username,string code)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.addCode(string, string)”的 XML 注释
        {
            string invite = getUserFromInviteBy(code);
            loginDAO.UpdateInvitationInviteByByUsername(username, invite);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.fillInInvitationCode(string, string)”的 XML 注释
        public string fillInInvitationCode(string code,string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.fillInInvitationCode(string, string)”的 XML 注释
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Login_Class.getInvitationCode(string)”的 XML 注释
        public string getInvitationCode(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Login_Class.getInvitationCode(string)”的 XML 注释
        {
            DataSet ds = loginDAO.SelectInvitationByUsername(username);
            return ds.Tables[0].Rows[0]["Code"].ToString();
        }
    }
}