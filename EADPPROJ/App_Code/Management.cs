using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management”的 XML 注释
    public class Management
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.Management()”的 XML 注释
        public Management()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.Management()”的 XML 注释
        {

        }

        Database data = new Database();
        ManagementDAO managementDAO = new ManagementDAO();


#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.DeleteSelectedStudentProfile(string)”的 XML 注释
        public void DeleteSelectedStudentProfile(string adminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.DeleteSelectedStudentProfile(string)”的 XML 注释
        {
            managementDAO.DeleteStudentProfileByAdminNo(adminNo);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.DeleteSelectedStudentInfo(string)”的 XML 注释
        public void DeleteSelectedStudentInfo(string adminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.DeleteSelectedStudentInfo(string)”的 XML 注释
        {
            DeleteSelectedStudentProfile(adminNo);
            managementDAO.DeleteStudentByAdminNo(adminNo);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.GetOSCount(string)”的 XML 注释
        public int GetOSCount(string OS)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.GetOSCount(string)”的 XML 注释
        {
            DataSet ds = managementDAO.SelectConnectionRecordByOS(OS);
            return ds.Tables[0].Rows.Count;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.GetRecordMostRecentDate()”的 XML 注释
        public DateTime GetRecordMostRecentDate()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.GetRecordMostRecentDate()”的 XML 注释
        {
            DataSet ds = managementDAO.SelectConnectionRecordByIdDESC();
            DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["LeaveTime"]);
            return dt;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.GetStudentViewOnDay(DateTime)”的 XML 注释
        public int GetStudentViewOnDay(DateTime dateTime)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.GetStudentViewOnDay(DateTime)”的 XML 注释
        {
            DataSet ds = managementDAO.SelectStudentConnectionRecordByDay(dateTime);
            return ds.Tables[0].Rows.Count;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.GetTeacherViewOnDay(DateTime)”的 XML 注释
        public int GetTeacherViewOnDay(DateTime dateTime)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.GetTeacherViewOnDay(DateTime)”的 XML 注释
        {
            DataSet ds = managementDAO.SelectTeacherConnectionRecordByDay(dateTime);
            return ds.Tables[0].Rows.Count;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.GetAdminViewOnDay(DateTime)”的 XML 注释
        public int GetAdminViewOnDay(DateTime dateTime)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.GetAdminViewOnDay(DateTime)”的 XML 注释
        {
            DataSet ds = managementDAO.SelectAdminConnectionRecordByDay(dateTime); 
            return ds.Tables[0].Rows.Count;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.GetGuestViewOnDay(DateTime)”的 XML 注释
        public int GetGuestViewOnDay(DateTime dateTime)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.GetGuestViewOnDay(DateTime)”的 XML 注释
        {
            DataSet ds = managementDAO.SelectGuestConnectionRecordByDay(dateTime);
            return ds.Tables[0].Rows.Count;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.EditGraduationYear(int, string)”的 XML 注释
        public void EditGraduationYear(int graduation,string AdminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.EditGraduationYear(int, string)”的 XML 注释
        {
            managementDAO.UpdateGraduationByAdminNo(graduation, AdminNo);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.DeleteQuestion(int)”的 XML 注释
        public void DeleteQuestion(int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.DeleteQuestion(int)”的 XML 注释
        {
            managementDAO.DeleteQuestionById(Id);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.ApproveQuestion(int)”的 XML 注释
        public void ApproveQuestion(int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.ApproveQuestion(int)”的 XML 注释
        {
            managementDAO.UpdateQuestionReviewById(Id);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.VerifyAdminIdentity(string)”的 XML 注释
        public int VerifyAdminIdentity(string id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.VerifyAdminIdentity(string)”的 XML 注释
        {
            DataSet ds = managementDAO.SelectAdminByUsername(id);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.DeleteSelectedTeacherProfile(string)”的 XML 注释
        public void DeleteSelectedTeacherProfile(string NRIC)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.DeleteSelectedTeacherProfile(string)”的 XML 注释
        {
            managementDAO.DeleteTeacherProfileByNRIC(NRIC);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.DeleteSelectedTeacherInfo(string)”的 XML 注释
        public void DeleteSelectedTeacherInfo(string NRIC)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.DeleteSelectedTeacherInfo(string)”的 XML 注释
        {
            DeleteSelectedTeacherProfile(NRIC);
            managementDAO.DeleteTeacherByNRIC(NRIC);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Management.CheckSearchTextSubstringIsNumeric(string)”的 XML 注释
        public bool CheckSearchTextSubstringIsNumeric(string str)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Management.CheckSearchTextSubstringIsNumeric(string)”的 XML 注释
        {
           int result;
            bool b = int.TryParse(str, out result);
           return b;
        }
    }
}