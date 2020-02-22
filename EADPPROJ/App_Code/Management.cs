using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace EADPPROJ.App_Code
{
    public class Management
    {
        public Management()
        {

        }

        Database data = new Database();
        ManagementDAO managementDAO = new ManagementDAO();


        public void DeleteSelectedStudentProfile(string adminNo)
        {
            managementDAO.DeleteStudentProfileByAdminNo(adminNo);
        }
        public void DeleteSelectedStudentInfo(string adminNo)
        {
            DeleteSelectedStudentProfile(adminNo);
            managementDAO.DeleteStudentByAdminNo(adminNo);
        }

        public int GetOSCount(string OS)
        {
            DataSet ds = managementDAO.SelectConnectionRecordByOS(OS);
            return ds.Tables[0].Rows.Count;
        }

        public DateTime GetRecordMostRecentDate()
        {
            DataSet ds = managementDAO.SelectConnectionRecordByIdDESC();
            DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["LeaveTime"]);
            return dt;
        }

        public int GetStudentViewOnDay(DateTime dateTime)
        {
            DataSet ds = managementDAO.SelectStudentConnectionRecordByDay(dateTime);
            return ds.Tables[0].Rows.Count;
        }

        public int GetTeacherViewOnDay(DateTime dateTime)
        {
            DataSet ds = managementDAO.SelectTeacherConnectionRecordByDay(dateTime);
            return ds.Tables[0].Rows.Count;
        }

        public int GetAdminViewOnDay(DateTime dateTime)
        {
            DataSet ds = managementDAO.SelectAdminConnectionRecordByDay(dateTime); 
            return ds.Tables[0].Rows.Count;
        }

        public int GetGuestViewOnDay(DateTime dateTime)
        {
            DataSet ds = managementDAO.SelectGuestConnectionRecordByDay(dateTime);
            return ds.Tables[0].Rows.Count;
        }

        public void EditGraduationYear(int graduation,string AdminNo)
        {
            managementDAO.UpdateGraduationByAdminNo(graduation, AdminNo);
        }

        public void DeleteQuestion(int Id)
        {
            managementDAO.DeleteQuestionById(Id);
        }

        public void ApproveQuestion(int Id)
        {
            managementDAO.UpdateQuestionReviewById(Id);
        }

        public int VerifyAdminIdentity(string id)
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
        public void DeleteSelectedTeacherProfile(string NRIC)
        {
            managementDAO.DeleteTeacherProfileByNRIC(NRIC);
        }
        public void DeleteSelectedTeacherInfo(string NRIC)
        {
            DeleteSelectedTeacherProfile(NRIC);
            managementDAO.DeleteTeacherByNRIC(NRIC);
        }

        public bool CheckSearchTextSubstringIsNumeric(string str)
        {
           int result;
            bool b = int.TryParse(str, out result);
           return b;
        }
    }
}