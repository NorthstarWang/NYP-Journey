using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration”的 XML 注释
    public class Registration
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.Registration()”的 XML 注释
        public Registration()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.Registration()”的 XML 注释
        {

        }
        RegistrationDAO registrationDAO = new RegistrationDAO();
        Database data = new Database();

        private string adminNo = "";
        private string password = "";
        private string mail = "";
        private string name = "";
        private string sex = "";
        private int graduation = 0;
        private DateTime dob = Convert.ToDateTime(DateTime.Now.Date);
        private string nric = "";
        private string school = "";
        private int credit = 0;
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.AdminNo”的 XML 注释
        public string AdminNo
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.AdminNo”的 XML 注释
        {
            get { return adminNo; }
            set { adminNo = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.Password”的 XML 注释
        public string Password
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.Password”的 XML 注释
        {
            get { return password; }
            set { password = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.Mail”的 XML 注释
        public string Mail
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.Mail”的 XML 注释
        {
            get { return mail; }
            set { mail = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.Name”的 XML 注释
        public string Name
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.Name”的 XML 注释
        {
            get { return name; }
            set { name = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.Sex”的 XML 注释
        public string Sex
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.Sex”的 XML 注释
        {
            get { return sex; }
            set { sex = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.Graduation”的 XML 注释
        public int Graduation
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.Graduation”的 XML 注释
        {
            get { return graduation; }
            set { graduation = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.DOB”的 XML 注释
        public DateTime DOB
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.DOB”的 XML 注释
        {
            get { return dob; }
            set { dob = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.NRIC”的 XML 注释
        public string NRIC
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.NRIC”的 XML 注释
        {
            get { return nric; }
            set { nric = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.School”的 XML 注释
        public string School
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.School”的 XML 注释
        {
            get { return school; }
            set { school = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.Credit”的 XML 注释
        public int Credit
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.Credit”的 XML 注释
        {
            get { return credit; }
            set { credit = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.RegisterStudent(Registration)”的 XML 注释
        public void RegisterStudent(Registration registration)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.RegisterStudent(Registration)”的 XML 注释
        {
            registrationDAO.InsertStudent(registration.AdminNo, registration.Password, registration.Mail, registration.Name, registration.Graduation, registration.Sex);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.RegisterTeacher(Registration)”的 XML 注释
        public void RegisterTeacher(Registration registration)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.RegisterTeacher(Registration)”的 XML 注释
        {
            registrationDAO.InsertTeacher(registration.NRIC, registration.Password, registration.Mail, registration.Name, registration.DOB, registration.Sex);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.GenerateStudentProfile(Registration)”的 XML 注释
        public void GenerateStudentProfile(Registration registration)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.GenerateStudentProfile(Registration)”的 XML 注释
        {
            registrationDAO.InsertStudentProfile(registration.AdminNo, registration.Name, registration.School);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.GenerateTeacherProfile(Registration)”的 XML 注释
        public void GenerateTeacherProfile(Registration registration)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.GenerateTeacherProfile(Registration)”的 XML 注释
        {
            registrationDAO.InsertTeacherProfile(registration.NRIC, registration.Name);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.MD5Encrypt16(string)”的 XML 注释
        public static string MD5Encrypt16(string password)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.MD5Encrypt16(string)”的 XML 注释
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(password)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Registration.generateInvitationCode(string)”的 XML 注释
        public void generateInvitationCode(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Registration.generateInvitationCode(string)”的 XML 注释
        {
            registrationDAO.InsertInvitation(username, MD5Encrypt16(username));
        }

        }
    }