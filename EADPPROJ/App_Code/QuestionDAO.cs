using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace EADPPROJ.App_Code
{
    public class QuestionDAO
    {
        public QuestionDAO()
        {

        }
        Database data = new Database();

        public DataSet SelectQuestionOrderByIdDESC()
        {
            DataSet ds = null;
            SqlParameter[] prams = {
            data.MakeInParam("@Id",  SqlDbType.VarChar, 50, DBNull.Value),
            };
            return data.RunProcReturn("select * from tb_Question Order by Id DESC", prams, "tb_Question");
        }

        public DataSet SelectQuestionBySchoolTypeOrderByIdDESC(string school)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
            data.MakeInParam("@School",  SqlDbType.VarChar, 50, school),
            };
            return data.RunProcReturn("select * from tb_Question Where (SchoolType = @School) Order by Id DESC", prams, "tb_Question");
        }

        public void InsertQuestion(string Title,string Content,string Type, DateTime Posttime,string Username,string State,int CreditReward)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@Title",  SqlDbType.VarChar, 500, Title),
            data.MakeInParam("@Content",  SqlDbType.NVarChar, 3000,Content),
            data.MakeInParam("@Type",  SqlDbType.VarChar, 50, Type),
            data.MakeInParam("@PostTime",  SqlDbType.DateTime, 14, Posttime ),
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50, Username ),
            data.MakeInParam("@Latest",  SqlDbType.DateTime, 14, Posttime ),
            data.MakeInParam("@State",  SqlDbType.VarChar, 30, State ),
            data.MakeInParam("@CreditReward",  SqlDbType.Int, 3, CreditReward),
            data.MakeInParam("@Review",  SqlDbType.Int, 4, 0),
            };
            data.RunProc("INSERT INTO tb_Question (Title,Content,SchoolType,PostTime,Username,LastUpdate,State,CreditReward,Review) VALUES(@Title,@Content,@Type,@Posttime,@Username,@Latest,@State,@CreditReward,@Review)", prams);
        
        }

        public DataSet SelectQuestionById(int Id)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
            data.MakeInParam("@Id",  SqlDbType.Int, 4, Id),
            };
            ds = data.RunProcReturn("select * from tb_Question Where (ID = @Id)", prams, "tb_Question");
            return ds;
        }

        public DataSet SelectStudentProfileByAdminNo(string ID)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,ID)
                };
            return data.RunProcReturn("SELECT * FROM tb_StudentProfile WHERE (AdminNo = @AdminNo)", prams, "tb_StudentProfile");

        }
        public DataSet SelectTeacherProfileByNRIC(string ID)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,ID)
                };
            return data.RunProcReturn("SELECT * FROM tb_TeacherProfile WHERE (NRIC = @NRIC)", prams, "tb_TeacherProfile");

        }
        public DataSet SelectAdminProfileByUsername(string ID)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,ID)
                };
            return data.RunProcReturn("SELECT * FROM tb_AdminProfile WHERE (Username = @Username)", prams, "tb_AdminProfile");

        }

        public void UpdateStudentProfileQuestionNoByAdminNo(int Qno,string ID)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@QuestionNo",  SqlDbType.VarChar, 50, Qno),
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50, ID),
                };
            data.RunProc("UPDATE tb_StudentProfile SET QuestionNo = (@QuestionNo) WHERE (AdminNo = @AdminNo)", prams);
        }

        public void UpdateTeacherProfileQuestionNoByNRIC(int Qno, string ID)
        {
                SqlParameter[] prams = {
                data.MakeInParam("@QuestionNo",  SqlDbType.VarChar, 50, Qno),
                data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50, ID),
                };
                data.RunProc("UPDATE tb_TeacherProfile SET QuestionNo = (@QuestionNo) WHERE (NRIC = @NRIC)", prams);
        }

        public void UpdateAdminProfileQuestionNoByUsername(int Qno, string ID)
        {
                SqlParameter[] prams = {
                data.MakeInParam("@QuestionNo",  SqlDbType.VarChar, 50, Qno),
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50, ID),
                };
                data.RunProc("UPDATE tb_AdminProfile SET QuestionNo = (@QuestionNo) WHERE (Username = @Username)", prams);
        }

        public DataSet SelectAnswerOrderByIdDESC()
        {
            DataSet ds = null;
            SqlParameter[] prams = {
            data.MakeInParam("@Id",  SqlDbType.Int, 4, 0),
            };
            return data.RunProcReturn("select * from tb_Answer Order by Id DESC", prams, "tb_Answer");
        }

        public void InsertAnswer(string QuestionCode, string QuestionContent, string Username)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Content",  SqlDbType.NVarChar, 3000,QuestionContent),
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@PostTime",  SqlDbType.DateTime, 14,DateTime.Now),
                data.MakeInParam("@BestSelected",  SqlDbType.Int, 1,0),
                data.MakeInParam("@QuestionCode",  SqlDbType.Int, 4,QuestionCode),
                data.MakeInParam("@LastUpdate",  SqlDbType.DateTime, 14,DateTime.Now),
                data.MakeInParam("@UpVote",  SqlDbType.Int, 4,0),
                };
            data.RunProc("INSERT INTO tb_Answer (Content,Username,PostTime,BestSelected,QuestionCode,UpVote) VALUES(@Content,@Username,@PostTime,@BestSelected,@QuestionCode,@UpVote)", prams);
        
        }

        public void UpdateQuestionLastUpdateById(string Id)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                data.MakeInParam("@LastUpdate",  SqlDbType.DateTime, 14,DateTime.Now),
                };
            data.RunProc("UPDATE tb_Question SET LastUpdate = (@LastUpdate) WHERE (Id = @Id)", prams);
        }

        public DataSet SelectAnswerByQuestionCodeOrderByUpvoteDESC(string QuestionCode)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@QuestionCode",  SqlDbType.Int, 4,QuestionCode),
            };
            return data.RunProcReturn("SELECT * FROM tb_Answer WHERE (QuestionCode = @QuestionCode) Order BY UpVote DESC", prams, "tb_Answer");
        }

        public void UpdateAnswerBestSelectedById(int ID)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,ID),
                };
            data.RunProc("UPDATE tb_Answer SET BestSelected = 1 WHERE (Id = @Id)", prams);
        }

        public void UpdateQuestionStateById(int ID)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,ID),
                };
            data.RunProc("UPDATE tb_Question SET State = 'Solved' WHERE (Id = @Id)", prams);
        }

        public DataSet SelectAnswerByQuestionCodeAndBestSelected(int QuestionCode)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@QuestionCode",  SqlDbType.Int, 4,QuestionCode),
                };
            return data.RunProcReturn("SELECT * FROM tb_Answer WHERE (QuestionCode = @QuestionCode) AND BestSelected = 1 ", prams, "tb_Answer");
          
        }

        public DataSet SelectAnswerById(int Id)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id)
                };
            return data.RunProcReturn("SELECT * FROM tb_Answer WHERE (Id = @Id) ", prams, "tb_Answer");
        }

        public void InsertUpvoteRecord(string Username, int AnswerNo, int QuestionCode)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@AnswerNo",  SqlDbType.Int, 4,AnswerNo),
                data.MakeInParam("@QuestionCode",  SqlDbType.Int, 4,QuestionCode)
                };
            data.RunProc("INSERT INTO tb_UpvoteRecord (Username,AnswerNo,QuestionCode) VALUES(@Username,@AnswerNo,@QuestionCode)", prams);
        }

        public void DeleteUpvoteRecord(string Username, int AnswerNo)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@AnswerNo",  SqlDbType.Int, 4,AnswerNo)
                };
            data.RunProcReturn("DELETE FROM tb_UpvoteRecord WHERE (AnswerNo = @AnswerNo) AND (Username = @Username)", prams, "tb_UpvoteRecord");
        }

        public DataSet SelectUpvoteRecordByAnswerNoAndUsername(string Username, int AnswerNo)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@AnswerNo",  SqlDbType.Int, 4,AnswerNo)
                };
            return data.RunProcReturn("SELECT * FROM tb_UpvoteRecord WHERE (AnswerNo = @AnswerNo) AND (Username = @Username) ", prams, "tb_UpvoteRecord");

        }

        public void UpdateAnswerUpvoteById(int Id, int newVote)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                data.MakeInParam("@UpVote",  SqlDbType.Int, 4,newVote),
            };
            data.RunProc("UPDATE tb_Answer SET UpVote =@UpVote WHERE (Id = @Id)", prams);
        }

        public DataSet SelectAnswerSectionByAnswerId(int Id)
        {
            SqlParameter[] prams = {
                        data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                        };
            return data.RunProcReturn("SELECT * FROM tb_AnswerSection WHERE (AnswerId = @Id)", prams, "tb_AnswerSection");
        }

        public void InsertAnswerSection(string Username, int AnswerId, string content)
        {
            SqlParameter[] prams = {
                        data.MakeInParam("@AnswerId",  SqlDbType.Int, 4,AnswerId),
                        data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                        data.MakeInParam("@Content",  SqlDbType.NVarChar, 3000,content),
                        };
            data.RunProc("INSERT INTO tb_AnswerSection (AnswerId,Username,Content) VALUES(@AnswerId,@Username,@Content)", prams);
        }

        public DataSet SelectAnswerSectionById(int Id)
        {
            SqlParameter[] prams = {
                        data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                        };
            return data.RunProcReturn("SELECT * FROM tb_AnswerSection WHERE (Id = @Id)", prams, "tb_AnswerSection");
        }

        public void InsertAnswerSectionWithReferenceId(string Username, int AnswerId, string content, int RID)
        {
            SqlParameter[] prams = {
                        data.MakeInParam("@AnswerId",  SqlDbType.Int, 4,AnswerId),
                        data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                        data.MakeInParam("@Content",  SqlDbType.NVarChar, 3000,content),
                        data.MakeInParam("@RId",  SqlDbType.Int, 4,RID),
                        };
            data.RunProc("INSERT INTO tb_AnswerSection (AnswerId,Username,Content,ReferenceId) VALUES(@AnswerId,@Username,@Content,@RId)", prams);
        }

       
    }
}