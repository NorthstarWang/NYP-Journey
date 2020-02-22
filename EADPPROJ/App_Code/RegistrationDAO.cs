using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    public class RegistrationDAO
    {
        public RegistrationDAO()
        {

        }
        Database data = new Database();

        public void InsertStudent(string AdminNo,string Password,string Mail,string Name,int Graduation,string Sex)
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

        public void InsertTeacher(string NRIC, string Password, string Mail, string Name, DateTime DOB,string Sex)
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

        public void InsertStudentProfile(string AdminNo,string Name,string School)
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

        public void InsertTeacherProfile(string NRIC,string Name)
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

        public void InsertInvitation(string username,string EncryptUsername)
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