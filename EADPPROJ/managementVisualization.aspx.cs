using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
    public partial class managementVisualization : System.Web.UI.Page
    {
        Management management = new Management();
        protected void Page_Load(object sender, EventArgs e)
        {
            WinNT.Value = management.GetOSCount("WinNT").ToString();
            Linux.Value = management.GetOSCount("Linux").ToString();
            MacOS.Value = management.GetOSCount("MacOS").ToString();

            List<string> weekDays = new List<string>();
            weekDays.Add(management.GetRecordMostRecentDate().ToString("MMM dd"));
            weekDays.Add(management.GetRecordMostRecentDate().AddDays(-1).ToString("MMM dd"));
            weekDays.Add(management.GetRecordMostRecentDate().AddDays(-2).ToString("MMM dd"));
            weekDays.Add(management.GetRecordMostRecentDate().AddDays(-3).ToString("MMM dd"));
            weekDays.Add(management.GetRecordMostRecentDate().AddDays(-4).ToString("MMM dd"));
            weekDays.Add(management.GetRecordMostRecentDate().AddDays(-5).ToString("MMM dd"));
            weekDays.Add(management.GetRecordMostRecentDate().AddDays(-6).ToString("MMM dd"));
            days.Value = String.Join(",", weekDays);

            List<string> viewPerDayStudent = new List<string>();
            viewPerDayStudent.Add(management.GetStudentViewOnDay(management.GetRecordMostRecentDate()).ToString());
            viewPerDayStudent.Add(management.GetStudentViewOnDay(management.GetRecordMostRecentDate().AddDays(-1)).ToString());
            viewPerDayStudent.Add(management.GetStudentViewOnDay(management.GetRecordMostRecentDate().AddDays(-2)).ToString());
            viewPerDayStudent.Add(management.GetStudentViewOnDay(management.GetRecordMostRecentDate().AddDays(-3)).ToString());
            viewPerDayStudent.Add(management.GetStudentViewOnDay(management.GetRecordMostRecentDate().AddDays(-4)).ToString());
            viewPerDayStudent.Add(management.GetStudentViewOnDay(management.GetRecordMostRecentDate().AddDays(-5)).ToString());
            viewPerDayStudent.Add(management.GetStudentViewOnDay(management.GetRecordMostRecentDate().AddDays(-6)).ToString());
            Student.Value = String.Join(",", viewPerDayStudent);

            List<string> viewPerDayTeacher = new List<string>();
            viewPerDayTeacher.Add(management.GetTeacherViewOnDay(management.GetRecordMostRecentDate()).ToString());
            viewPerDayTeacher.Add(management.GetTeacherViewOnDay(management.GetRecordMostRecentDate().AddDays(-1)).ToString());
            viewPerDayTeacher.Add(management.GetTeacherViewOnDay(management.GetRecordMostRecentDate().AddDays(-2)).ToString());
            viewPerDayTeacher.Add(management.GetTeacherViewOnDay(management.GetRecordMostRecentDate().AddDays(-3)).ToString());
            viewPerDayTeacher.Add(management.GetTeacherViewOnDay(management.GetRecordMostRecentDate().AddDays(-4)).ToString());
            viewPerDayTeacher.Add(management.GetTeacherViewOnDay(management.GetRecordMostRecentDate().AddDays(-5)).ToString());
            viewPerDayTeacher.Add(management.GetTeacherViewOnDay(management.GetRecordMostRecentDate().AddDays(-6)).ToString());
            Teacher.Value = String.Join(",", viewPerDayTeacher);

            List<string> viewPerDayAdmin = new List<string>();
            viewPerDayAdmin.Add(management.GetAdminViewOnDay(management.GetRecordMostRecentDate()).ToString());
            viewPerDayAdmin.Add(management.GetAdminViewOnDay(management.GetRecordMostRecentDate().AddDays(-1)).ToString());
            viewPerDayAdmin.Add(management.GetAdminViewOnDay(management.GetRecordMostRecentDate().AddDays(-2)).ToString());
            viewPerDayAdmin.Add(management.GetAdminViewOnDay(management.GetRecordMostRecentDate().AddDays(-3)).ToString());
            viewPerDayAdmin.Add(management.GetAdminViewOnDay(management.GetRecordMostRecentDate().AddDays(-4)).ToString());
            viewPerDayAdmin.Add(management.GetAdminViewOnDay(management.GetRecordMostRecentDate().AddDays(-5)).ToString());
            viewPerDayAdmin.Add(management.GetAdminViewOnDay(management.GetRecordMostRecentDate().AddDays(-6)).ToString());
            Admin.Value = String.Join(",", viewPerDayAdmin);

            List<string> viewPerDayGuest = new List<string>();
            viewPerDayGuest.Add(management.GetGuestViewOnDay(management.GetRecordMostRecentDate()).ToString());
            viewPerDayGuest.Add(management.GetGuestViewOnDay(management.GetRecordMostRecentDate().AddDays(-1)).ToString());
            viewPerDayGuest.Add(management.GetGuestViewOnDay(management.GetRecordMostRecentDate().AddDays(-2)).ToString());
            viewPerDayGuest.Add(management.GetGuestViewOnDay(management.GetRecordMostRecentDate().AddDays(-3)).ToString());
            viewPerDayGuest.Add(management.GetGuestViewOnDay(management.GetRecordMostRecentDate().AddDays(-4)).ToString());
            viewPerDayGuest.Add(management.GetGuestViewOnDay(management.GetRecordMostRecentDate().AddDays(-5)).ToString());
            viewPerDayGuest.Add(management.GetGuestViewOnDay(management.GetRecordMostRecentDate().AddDays(-6)).ToString());
            Guest.Value = String.Join(",", viewPerDayGuest);
        }
    }
}