using System;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RegistrationDAO”的 XML 注释
    public class RegistrationDAO
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RegistrationDAO”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.RegistrationDAO()”的 XML 注释
        public RegistrationDAO()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.RegistrationDAO()”的 XML 注释
        {

        }
        Database data = new Database();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.InsertStudent(string, string, string, string, int, string)”的 XML 注释
        public void InsertStudent(string AdminNo, string Password, string Mail, string Name, int Graduation, string Sex)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.InsertStudent(string, string, string, string, int, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@adminNo",  SqlDbType.VarChar, 50,AdminNo ),
                data.MakeInParam("@password",  SqlDbType.VarChar, 50, Password ),
                data.MakeInParam("@mail",  SqlDbType.VarChar, 50, Mail ),
                data.MakeInParam("@name",  SqlDbType.VarChar, 50, Name ),
                data.MakeInParam("@graduation",  SqlDbType.Int, 4, Graduation ),
                data.MakeInParam("@sex",  SqlDbType.VarChar, 30, Sex ),
                data.MakeInParam("@credit",  SqlDbType.Int, 10, 100 ),

            };
            data.RunProc("INSERT INTO tb_Student (adminNo,password,mail,name,graduation,sex,credit) "
                + "VALUES (@adminNo,@password,@mail,@name,@graduation,@sex,@credit)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.InsertTeacher(string, string, string, string, DateTime, string)”的 XML 注释
        public void InsertTeacher(string NRIC, string Password, string Mail, string Name, DateTime DOB, string Sex)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.InsertTeacher(string, string, string, string, DateTime, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,NRIC ),
                data.MakeInParam("@Password",  SqlDbType.VarChar, 50, Password ),
                data.MakeInParam("@Mail",  SqlDbType.VarChar, 50, Mail ),
                data.MakeInParam("@Name",  SqlDbType.VarChar, 50, Name ),
                data.MakeInParam("@DOB",  SqlDbType.Date, 50, DOB ),
                data.MakeInParam("@Sex",  SqlDbType.VarChar, 30, Sex ),
                data.MakeInParam("@credit",  SqlDbType.Int, 10, 500 ),

            };
            data.RunProc("INSERT INTO tb_Teacher (nric,password,mail,name,dob,sex,credit) "
                + "VALUES (@NRIC,@Password,@Mail,@Name,@DOB,@Sex,@credit)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.InsertStudentProfile(string, string, string)”的 XML 注释
        public void InsertStudentProfile(string AdminNo, string Name, string School)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.InsertStudentProfile(string, string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,AdminNo ),
                data.MakeInParam("@HeadIcon",  SqlDbType.VarChar, 50, "user-head-icon.jpg" ),
                data.MakeInParam("@Name",  SqlDbType.VarChar, 50, Name ),
                data.MakeInParam("@QuestionNo",  SqlDbType.Int, 4, 0 ),
                data.MakeInParam("@AnswersNo",  SqlDbType.Int, 4, 0 ),
                data.MakeInParam("@School",  SqlDbType.VarChar, 50, School ),

            };
            data.RunProc("INSERT INTO tb_StudentProfile (AdminNo,HeadIcon,Name,QuestionNo,AnswersNo,School) "
                + "VALUES (@AdminNo,@HeadIcon,@Name,@QuestionNo,@AnswersNo,@School)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.InsertTeacherProfile(string, string)”的 XML 注释
        public void InsertTeacherProfile(string NRIC, string Name)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.InsertTeacherProfile(string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,NRIC ),
                data.MakeInParam("@HeadIcon",  SqlDbType.VarChar, 50, "user-head-icon.jpg" ),
                data.MakeInParam("@Name",  SqlDbType.VarChar, 50, Name ),
                data.MakeInParam("@QuestionNo",  SqlDbType.Int, 4, 0 ),
                data.MakeInParam("@AnswersNo",  SqlDbType.Int, 4, 0 ),

            };
            data.RunProc("INSERT INTO tb_TeacherProfile (NRIC,HeadIcon,Name,QuestionNo,AnswersNo) "
                + "VALUES (@NRIC,@HeadIcon,@Name,@QuestionNo,@AnswersNo)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.InsertInvitation(string, string)”的 XML 注释
        public void InsertInvitation(string username, string EncryptUsername)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“RegistrationDAO.InsertInvitation(string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username ),
                data.MakeInParam("@Code",  SqlDbType.VarChar, 50, EncryptUsername)

            };
            data.RunProc("INSERT INTO tb_Invitation (Username,Code) "
                + "VALUES (@Username,@Code)", prams);
        }
    }
}