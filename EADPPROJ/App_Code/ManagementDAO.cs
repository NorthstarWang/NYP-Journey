using System;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO”的 XML 注释
    public class ManagementDAO
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.ManagementDAO()”的 XML 注释
        public ManagementDAO()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.ManagementDAO()”的 XML 注释
        {

        }

        Database data = new Database();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.DeleteStudentProfileByAdminNo(string)”的 XML 注释
        public void DeleteStudentProfileByAdminNo(string adminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.DeleteStudentProfileByAdminNo(string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,adminNo ),

            };
            data.RunProc("Delete FROM tb_StudentProfile WHERE  (AdminNo = @AdminNo)", prams);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.DeleteStudentByAdminNo(string)”的 XML 注释
        public void DeleteStudentByAdminNo(string adminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.DeleteStudentByAdminNo(string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,adminNo ),

            };
            data.RunProc("Delete FROM tb_Student WHERE  (AdminNo = @AdminNo)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectConnectionRecordByOS(string)”的 XML 注释
        public DataSet SelectConnectionRecordByOS(string OS)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectConnectionRecordByOS(string)”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
                data.MakeInParam("@OS",  SqlDbType.VarChar, 50,OS ),
            };
            return data.RunProcReturn("select * from tb_ConnectionRecord Where (OS = @OS)", prams, "tb_ConnectionRecord");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectConnectionRecordByIdDESC()”的 XML 注释
        public DataSet SelectConnectionRecordByIdDESC()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectConnectionRecordByIdDESC()”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4, 1),
            };
            return data.RunProcReturn("select LeaveTime from tb_ConnectionRecord ORDER BY Id desc", prams, "tb_ConnectionRecord");

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectStudentConnectionRecordByDay(DateTime)”的 XML 注释
        public DataSet SelectStudentConnectionRecordByDay(DateTime dateTime)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectStudentConnectionRecordByDay(DateTime)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@LeaveTime",  SqlDbType.DateTime, 14, dateTime),
            };
            ds = data.RunProcReturn("select LeaveTime from tb_ConnectionRecord WHERE (DATEPART(yy, LeaveTime) = DATEPART(yy, @LeaveTime) AND DATEPART(mm, LeaveTime) = DATEPART(mm, @LeaveTime) AND DATEPART(dd, LeaveTime) = DATEPART(dd, @LeaveTime) AND LEN(Username) = 7)", prams, "tb_ConnectionRecord");
            return ds;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectTeacherConnectionRecordByDay(DateTime)”的 XML 注释
        public DataSet SelectTeacherConnectionRecordByDay(DateTime dateTime)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectTeacherConnectionRecordByDay(DateTime)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@LeaveTime",  SqlDbType.DateTime, 14, dateTime),
            };
            ds = data.RunProcReturn("select LeaveTime from tb_ConnectionRecord WHERE (DATEPART(yy, LeaveTime) = DATEPART(yy, @LeaveTime) AND DATEPART(mm, LeaveTime) = DATEPART(mm, @LeaveTime) AND DATEPART(dd, LeaveTime) = DATEPART(dd, @LeaveTime) AND LEN(Username) = 9)", prams, "tb_ConnectionRecord");
            return ds;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectAdminConnectionRecordByDay(DateTime)”的 XML 注释
        public DataSet SelectAdminConnectionRecordByDay(DateTime dateTime)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectAdminConnectionRecordByDay(DateTime)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@LeaveTime",  SqlDbType.DateTime, 14, dateTime),
            };
            ds = data.RunProcReturn("select LeaveTime from tb_ConnectionRecord WHERE (DATEPART(yy, LeaveTime) = DATEPART(yy, @LeaveTime) AND DATEPART(mm, LeaveTime) = DATEPART(mm, @LeaveTime) AND DATEPART(dd, LeaveTime) = DATEPART(dd, @LeaveTime) AND LEN(Username) <> 9 AND LEN(Username) <> 7 AND Username <> 'Guest')", prams, "tb_ConnectionRecord");
            return ds;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectGuestConnectionRecordByDay(DateTime)”的 XML 注释
        public DataSet SelectGuestConnectionRecordByDay(DateTime dateTime)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectGuestConnectionRecordByDay(DateTime)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@LeaveTime",  SqlDbType.DateTime, 14, dateTime),
            };
            ds = data.RunProcReturn("select LeaveTime from tb_ConnectionRecord WHERE (DATEPART(yy, LeaveTime) = DATEPART(yy, @LeaveTime) AND DATEPART(mm, LeaveTime) = DATEPART(mm, @LeaveTime) AND DATEPART(dd, LeaveTime) = DATEPART(dd, @LeaveTime) AND Username = 'Guest')", prams, "tb_ConnectionRecord");
            return ds;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.UpdateGraduationByAdminNo(int, string)”的 XML 注释
        public void UpdateGraduationByAdminNo(int graduation, string AdminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.UpdateGraduationByAdminNo(int, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50, AdminNo),
                data.MakeInParam("@Graduation",  SqlDbType.Int, 4, graduation)
                };
            data.RunProc("UPDATE tb_Student SET Graduation = (@Graduation) WHERE (AdminNo = @AdminNo)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.DeleteQuestionById(int)”的 XML 注释
        public void DeleteQuestionById(int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.DeleteQuestionById(int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id)
                };
            data.RunProcReturn("DELETE FROM tb_Question WHERE (Id = @Id)", prams, "tb_Question");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.UpdateQuestionReviewById(int)”的 XML 注释
        public void UpdateQuestionReviewById(int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.UpdateQuestionReviewById(int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                data.MakeInParam("@Review",  SqlDbType.Int, 4,1)
                };
            data.RunProc("UPDATE tb_Question SET Review =@Review WHERE (Id = @Id)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectAdminByUsername(string)”的 XML 注释
        public DataSet SelectAdminByUsername(string id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.SelectAdminByUsername(string)”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,id)
                };
            return data.RunProcReturn("Select * From tb_Admin Where (Username = @Username)", prams, "tb_Admin");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.DeleteTeacherProfileByNRIC(string)”的 XML 注释
        public void DeleteTeacherProfileByNRIC(string NRIC)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.DeleteTeacherProfileByNRIC(string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,NRIC),

            };
            data.RunProc("Delete FROM tb_TeacherProfile WHERE  (NRIC = @NRIC)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ManagementDAO.DeleteTeacherByNRIC(string)”的 XML 注释
        public void DeleteTeacherByNRIC(string NRIC)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ManagementDAO.DeleteTeacherByNRIC(string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,NRIC),

            };
            data.RunProc("Delete FROM tb_Teacher WHERE  (NRIC = @NRIC)", prams);
        }
    }
}