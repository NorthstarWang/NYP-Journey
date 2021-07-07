using System;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    public class ManagementDAO
    {
        public ManagementDAO()
        {

        }

        Database data = new Database();

        public void DeleteStudentProfileByAdminNo(string adminNo)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,adminNo ),

            };
            data.RunProc("Delete FROM tb_StudentProfile WHERE  (AdminNo = @AdminNo)", prams);
        }

        public void DeleteStudentByAdminNo(string adminNo)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,adminNo ),

            };
            data.RunProc("Delete FROM tb_Student WHERE  (AdminNo = @AdminNo)", prams);
        }

        public DataSet SelectConnectionRecordByOS(string OS)
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
                data.MakeInParam("@OS",  SqlDbType.VarChar, 50,OS ),
            };
            return data.RunProcReturn("select * from tb_ConnectionRecord Where (OS = @OS)", prams, "tb_ConnectionRecord");
        }

        public DataSet SelectConnectionRecordByIdDESC()
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4, 1),
            };
            return data.RunProcReturn("select LeaveTime from tb_ConnectionRecord ORDER BY Id desc", prams, "tb_ConnectionRecord");

        }

        public DataSet SelectStudentConnectionRecordByDay(DateTime dateTime)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@LeaveTime",  SqlDbType.DateTime, 14, dateTime),
            };
            ds = data.RunProcReturn("select LeaveTime from tb_ConnectionRecord WHERE (DATEPART(yy, LeaveTime) = DATEPART(yy, @LeaveTime) AND DATEPART(mm, LeaveTime) = DATEPART(mm, @LeaveTime) AND DATEPART(dd, LeaveTime) = DATEPART(dd, @LeaveTime) AND LEN(Username) = 7)", prams, "tb_ConnectionRecord");
            return ds;
        }

        public DataSet SelectTeacherConnectionRecordByDay(DateTime dateTime)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@LeaveTime",  SqlDbType.DateTime, 14, dateTime),
            };
            ds = data.RunProcReturn("select LeaveTime from tb_ConnectionRecord WHERE (DATEPART(yy, LeaveTime) = DATEPART(yy, @LeaveTime) AND DATEPART(mm, LeaveTime) = DATEPART(mm, @LeaveTime) AND DATEPART(dd, LeaveTime) = DATEPART(dd, @LeaveTime) AND LEN(Username) = 9)", prams, "tb_ConnectionRecord");
            return ds;
        }

        public DataSet SelectAdminConnectionRecordByDay(DateTime dateTime)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@LeaveTime",  SqlDbType.DateTime, 14, dateTime),
            };
            ds = data.RunProcReturn("select LeaveTime from tb_ConnectionRecord WHERE (DATEPART(yy, LeaveTime) = DATEPART(yy, @LeaveTime) AND DATEPART(mm, LeaveTime) = DATEPART(mm, @LeaveTime) AND DATEPART(dd, LeaveTime) = DATEPART(dd, @LeaveTime) AND LEN(Username) <> 9 AND LEN(Username) <> 7 AND Username <> 'Guest')", prams, "tb_ConnectionRecord");
            return ds;
        }

        public DataSet SelectGuestConnectionRecordByDay(DateTime dateTime)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@LeaveTime",  SqlDbType.DateTime, 14, dateTime),
            };
            ds = data.RunProcReturn("select LeaveTime from tb_ConnectionRecord WHERE (DATEPART(yy, LeaveTime) = DATEPART(yy, @LeaveTime) AND DATEPART(mm, LeaveTime) = DATEPART(mm, @LeaveTime) AND DATEPART(dd, LeaveTime) = DATEPART(dd, @LeaveTime) AND Username = 'Guest')", prams, "tb_ConnectionRecord");
            return ds;
        }

        public void UpdateGraduationByAdminNo(int graduation, string AdminNo)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50, AdminNo),
                data.MakeInParam("@Graduation",  SqlDbType.Int, 4, graduation)
                };
            data.RunProc("UPDATE tb_Student SET Graduation = (@Graduation) WHERE (AdminNo = @AdminNo)", prams);
        }

        public void DeleteQuestionById(int Id)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id)
                };
            data.RunProcReturn("DELETE FROM tb_Question WHERE (Id = @Id)", prams, "tb_Question");
        }

        public void UpdateQuestionReviewById(int Id)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                data.MakeInParam("@Review",  SqlDbType.Int, 4,1)
                };
            data.RunProc("UPDATE tb_Question SET Review =@Review WHERE (Id = @Id)", prams);
        }

        public DataSet SelectAdminByUsername(string id)
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,id)
                };
            return data.RunProcReturn("Select * From tb_Admin Where (Username = @Username)", prams, "tb_Admin");
        }

        public void DeleteTeacherProfileByNRIC(string NRIC)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,NRIC),

            };
            data.RunProc("Delete FROM tb_TeacherProfile WHERE  (NRIC = @NRIC)", prams);
        }

        public void DeleteTeacherByNRIC(string NRIC)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,NRIC),

            };
            data.RunProc("Delete FROM tb_Teacher WHERE  (NRIC = @NRIC)", prams);
        }
    }
}