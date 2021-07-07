using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    public class CreditDAO
    {
        public CreditDAO()
        {

        }

        Database data = new Database();
        Record record = new Record();

        public DataSet SelectCreditFromUser(string username)
        {
            DataSet ds = null;
            if (username.Length == 7)
            {
                SqlParameter[] prams = {
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,username),
                };
                ds = data.RunProcReturn("SELECT Credit FROM tb_Student WHERE (AdminNo = @AdminNo)", prams, "tb_Student");
                return ds;
            }
            else if (username.Length == 9)
            {
                SqlParameter[] prams = {
                    data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,username),
                    };
                ds = data.RunProcReturn("SELECT Credit FROM tb_Teacher WHERE (NRIC = @NRIC)", prams, "tb_Teacher");
                return ds;
            }
            else
            {
                SqlParameter[] prams = {
                    data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
                    };
                ds = data.RunProcReturn("SELECT Credit FROM tb_Admin WHERE (Username = @Username)", prams, "tb_Admin");
                return ds;
            }
        }

        public DataSet SelectRewardFromQuestionById(int id)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                    data.MakeInParam("@Id",  SqlDbType.VarChar, 50,id),
                    };
            ds = data.RunProcReturn("SELECT CreditReward FROM tb_Question WHERE (Id = @Id)", prams, "tb_Question");
            return ds;
        }

        public void UpdateStudentCredit(string username, int credit)
        {
            SqlParameter[] prams = {
                    data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,username),
                    data.MakeInParam("@Credit",  SqlDbType.Int, 4,credit)
                    };
            data.RunProc("UPDATE tb_Student SET Credit = (@Credit) WHERE (AdminNo = @AdminNo)", prams);
        }

        public void UpdateTeacherCredit(string username, int credit)
        {
            SqlParameter[] prams = {
                    data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,username),
                    data.MakeInParam("@Credit",  SqlDbType.Int, 4,credit)
                    };
            data.RunProc("UPDATE tb_Teacher SET Credit = (@Credit) WHERE (NRIC = @NRIC)", prams);
        }

        public void UpdateAdminCredit(string username, int credit)
        {
            SqlParameter[] prams = {
                    data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
                    data.MakeInParam("@Credit",  SqlDbType.Int, 4,credit)
                    };
            data.RunProc("UPDATE tb_Admin SET Credit = (@Credit) WHERE (Username = @Username)", prams);
        }

        public DataSet SelectCreditRecordByUsername(string username)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                    data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
                    };
            ds = data.RunProcReturn("SELECT * FROM tb_CreditRecord WHERE (Username = @Username)", prams, "tb_CreditRecord");
            return ds;
        }

        public DataSet SelectCreditRecordByUsernameWhereActIsAdd(string username)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                    data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username)
                    };
            ds = data.RunProcReturn("SELECT * FROM tb_CreditRecord WHERE (Username = @Username) and (Act = 'Add')", prams, "tb_CreditRecord");
            return ds;
        }

        public DataSet SelectCreditRecordByUsernameWhereActIsMinus(string username)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                    data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username)
                    };
            ds = data.RunProcReturn("SELECT * FROM tb_CreditRecord WHERE (Username = @Username) and (Act = 'Minus')", prams, "tb_CreditRecord");
            return ds;
        }
    }
}