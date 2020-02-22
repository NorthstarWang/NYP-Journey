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
    public class Registration
    {
        public Registration()
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
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public int Graduation
        {
            get { return graduation; }
            set { graduation = value; }
        }
        public DateTime DOB
        {
            get { return dob; }
            set { dob = value; }
        }
        public string NRIC
        {
            get { return nric; }
            set { nric = value; }
        }
        public string School
        {
            get { return school; }
            set { school = value; }
        }
        public int Credit
        {
            get { return credit; }
            set { credit = value; }
        }
        public void RegisterStudent(Registration registration)
        {
            registrationDAO.InsertStudent(registration.AdminNo, registration.Password, registration.Mail, registration.Name, registration.Graduation, registration.Sex);
        }

        public void RegisterTeacher(Registration registration)
        {
            registrationDAO.InsertTeacher(registration.NRIC, registration.Password, registration.Mail, registration.Name, registration.DOB, registration.Sex);
        }

        public void GenerateStudentProfile(Registration registration)
        {
            registrationDAO.InsertStudentProfile(registration.AdminNo, registration.Name, registration.School);
        }
        public void GenerateTeacherProfile(Registration registration)
        {
            registrationDAO.InsertTeacherProfile(registration.NRIC, registration.Name);
        }

        public static string MD5Encrypt16(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(password)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }
        public void generateInvitationCode(string username)
        {
            registrationDAO.InsertInvitation(username, MD5Encrypt16(username));
        }

        }
    }