using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO”的 XML 注释
    public class QuestionDAO
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.QuestionDAO()”的 XML 注释
        public QuestionDAO()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.QuestionDAO()”的 XML 注释
        {

        }
        Database data = new Database();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectQuestionOrderByIdDESC()”的 XML 注释
        public DataSet SelectQuestionOrderByIdDESC()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectQuestionOrderByIdDESC()”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
            data.MakeInParam("@Id",  SqlDbType.VarChar, 50, DBNull.Value),
            };
            return data.RunProcReturn("select * from tb_Question Order by Id DESC", prams, "tb_Question");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectQuestionBySchoolTypeOrderByIdDESC(string)”的 XML 注释
        public DataSet SelectQuestionBySchoolTypeOrderByIdDESC(string school)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectQuestionBySchoolTypeOrderByIdDESC(string)”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
            data.MakeInParam("@School",  SqlDbType.VarChar, 50, school),
            };
            return data.RunProcReturn("select * from tb_Question Where (SchoolType = @School) Order by Id DESC", prams, "tb_Question");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.InsertQuestion(string, string, string, DateTime, string, string, int)”的 XML 注释
        public void InsertQuestion(string Title,string Content,string Type, DateTime Posttime,string Username,string State,int CreditReward)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.InsertQuestion(string, string, string, DateTime, string, string, int)”的 XML 注释
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectQuestionById(int)”的 XML 注释
        public DataSet SelectQuestionById(int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectQuestionById(int)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
            data.MakeInParam("@Id",  SqlDbType.Int, 4, Id),
            };
            ds = data.RunProcReturn("select * from tb_Question Where (ID = @Id)", prams, "tb_Question");
            return ds;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectStudentProfileByAdminNo(string)”的 XML 注释
        public DataSet SelectStudentProfileByAdminNo(string ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectStudentProfileByAdminNo(string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50,ID)
                };
            return data.RunProcReturn("SELECT * FROM tb_StudentProfile WHERE (AdminNo = @AdminNo)", prams, "tb_StudentProfile");

        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectTeacherProfileByNRIC(string)”的 XML 注释
        public DataSet SelectTeacherProfileByNRIC(string ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectTeacherProfileByNRIC(string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50,ID)
                };
            return data.RunProcReturn("SELECT * FROM tb_TeacherProfile WHERE (NRIC = @NRIC)", prams, "tb_TeacherProfile");

        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAdminProfileByUsername(string)”的 XML 注释
        public DataSet SelectAdminProfileByUsername(string ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAdminProfileByUsername(string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,ID)
                };
            return data.RunProcReturn("SELECT * FROM tb_AdminProfile WHERE (Username = @Username)", prams, "tb_AdminProfile");

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateStudentProfileQuestionNoByAdminNo(int, string)”的 XML 注释
        public void UpdateStudentProfileQuestionNoByAdminNo(int Qno,string ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateStudentProfileQuestionNoByAdminNo(int, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@QuestionNo",  SqlDbType.VarChar, 50, Qno),
                data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50, ID),
                };
            data.RunProc("UPDATE tb_StudentProfile SET QuestionNo = (@QuestionNo) WHERE (AdminNo = @AdminNo)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateTeacherProfileQuestionNoByNRIC(int, string)”的 XML 注释
        public void UpdateTeacherProfileQuestionNoByNRIC(int Qno, string ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateTeacherProfileQuestionNoByNRIC(int, string)”的 XML 注释
        {
                SqlParameter[] prams = {
                data.MakeInParam("@QuestionNo",  SqlDbType.VarChar, 50, Qno),
                data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50, ID),
                };
                data.RunProc("UPDATE tb_TeacherProfile SET QuestionNo = (@QuestionNo) WHERE (NRIC = @NRIC)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateAdminProfileQuestionNoByUsername(int, string)”的 XML 注释
        public void UpdateAdminProfileQuestionNoByUsername(int Qno, string ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateAdminProfileQuestionNoByUsername(int, string)”的 XML 注释
        {
                SqlParameter[] prams = {
                data.MakeInParam("@QuestionNo",  SqlDbType.VarChar, 50, Qno),
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50, ID),
                };
                data.RunProc("UPDATE tb_AdminProfile SET QuestionNo = (@QuestionNo) WHERE (Username = @Username)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerOrderByIdDESC()”的 XML 注释
        public DataSet SelectAnswerOrderByIdDESC()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerOrderByIdDESC()”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
            data.MakeInParam("@Id",  SqlDbType.Int, 4, 0),
            };
            return data.RunProcReturn("select * from tb_Answer Order by Id DESC", prams, "tb_Answer");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.InsertAnswer(string, string, string)”的 XML 注释
        public void InsertAnswer(string QuestionCode, string QuestionContent, string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.InsertAnswer(string, string, string)”的 XML 注释
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateQuestionLastUpdateById(string)”的 XML 注释
        public void UpdateQuestionLastUpdateById(string Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateQuestionLastUpdateById(string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                data.MakeInParam("@LastUpdate",  SqlDbType.DateTime, 14,DateTime.Now),
                };
            data.RunProc("UPDATE tb_Question SET LastUpdate = (@LastUpdate) WHERE (Id = @Id)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerByQuestionCodeOrderByUpvoteDESC(string)”的 XML 注释
        public DataSet SelectAnswerByQuestionCodeOrderByUpvoteDESC(string QuestionCode)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerByQuestionCodeOrderByUpvoteDESC(string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@QuestionCode",  SqlDbType.Int, 4,QuestionCode),
            };
            return data.RunProcReturn("SELECT * FROM tb_Answer WHERE (QuestionCode = @QuestionCode) Order BY UpVote DESC", prams, "tb_Answer");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateAnswerBestSelectedById(int)”的 XML 注释
        public void UpdateAnswerBestSelectedById(int ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateAnswerBestSelectedById(int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,ID),
                };
            data.RunProc("UPDATE tb_Answer SET BestSelected = 1 WHERE (Id = @Id)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateQuestionStateById(int)”的 XML 注释
        public void UpdateQuestionStateById(int ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateQuestionStateById(int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,ID),
                };
            data.RunProc("UPDATE tb_Question SET State = 'Solved' WHERE (Id = @Id)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerByQuestionCodeAndBestSelected(int)”的 XML 注释
        public DataSet SelectAnswerByQuestionCodeAndBestSelected(int QuestionCode)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerByQuestionCodeAndBestSelected(int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@QuestionCode",  SqlDbType.Int, 4,QuestionCode),
                };
            return data.RunProcReturn("SELECT * FROM tb_Answer WHERE (QuestionCode = @QuestionCode) AND BestSelected = 1 ", prams, "tb_Answer");
          
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerById(int)”的 XML 注释
        public DataSet SelectAnswerById(int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerById(int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id)
                };
            return data.RunProcReturn("SELECT * FROM tb_Answer WHERE (Id = @Id) ", prams, "tb_Answer");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.InsertUpvoteRecord(string, int, int)”的 XML 注释
        public void InsertUpvoteRecord(string Username, int AnswerNo, int QuestionCode)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.InsertUpvoteRecord(string, int, int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@AnswerNo",  SqlDbType.Int, 4,AnswerNo),
                data.MakeInParam("@QuestionCode",  SqlDbType.Int, 4,QuestionCode)
                };
            data.RunProc("INSERT INTO tb_UpvoteRecord (Username,AnswerNo,QuestionCode) VALUES(@Username,@AnswerNo,@QuestionCode)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.DeleteUpvoteRecord(string, int)”的 XML 注释
        public void DeleteUpvoteRecord(string Username, int AnswerNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.DeleteUpvoteRecord(string, int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@AnswerNo",  SqlDbType.Int, 4,AnswerNo)
                };
            data.RunProcReturn("DELETE FROM tb_UpvoteRecord WHERE (AnswerNo = @AnswerNo) AND (Username = @Username)", prams, "tb_UpvoteRecord");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectUpvoteRecordByAnswerNoAndUsername(string, int)”的 XML 注释
        public DataSet SelectUpvoteRecordByAnswerNoAndUsername(string Username, int AnswerNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectUpvoteRecordByAnswerNoAndUsername(string, int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@AnswerNo",  SqlDbType.Int, 4,AnswerNo)
                };
            return data.RunProcReturn("SELECT * FROM tb_UpvoteRecord WHERE (AnswerNo = @AnswerNo) AND (Username = @Username) ", prams, "tb_UpvoteRecord");

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateAnswerUpvoteById(int, int)”的 XML 注释
        public void UpdateAnswerUpvoteById(int Id, int newVote)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.UpdateAnswerUpvoteById(int, int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                data.MakeInParam("@UpVote",  SqlDbType.Int, 4,newVote),
            };
            data.RunProc("UPDATE tb_Answer SET UpVote =@UpVote WHERE (Id = @Id)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerSectionByAnswerId(int)”的 XML 注释
        public DataSet SelectAnswerSectionByAnswerId(int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerSectionByAnswerId(int)”的 XML 注释
        {
            SqlParameter[] prams = {
                        data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                        };
            return data.RunProcReturn("SELECT * FROM tb_AnswerSection WHERE (AnswerId = @Id)", prams, "tb_AnswerSection");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.InsertAnswerSection(string, int, string)”的 XML 注释
        public void InsertAnswerSection(string Username, int AnswerId, string content)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.InsertAnswerSection(string, int, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                        data.MakeInParam("@AnswerId",  SqlDbType.Int, 4,AnswerId),
                        data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                        data.MakeInParam("@Content",  SqlDbType.NVarChar, 3000,content),
                        };
            data.RunProc("INSERT INTO tb_AnswerSection (AnswerId,Username,Content) VALUES(@AnswerId,@Username,@Content)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerSectionById(int)”的 XML 注释
        public DataSet SelectAnswerSectionById(int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.SelectAnswerSectionById(int)”的 XML 注释
        {
            SqlParameter[] prams = {
                        data.MakeInParam("@Id",  SqlDbType.Int, 4,Id),
                        };
            return data.RunProcReturn("SELECT * FROM tb_AnswerSection WHERE (Id = @Id)", prams, "tb_AnswerSection");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionDAO.InsertAnswerSectionWithReferenceId(string, int, string, int)”的 XML 注释
        public void InsertAnswerSectionWithReferenceId(string Username, int AnswerId, string content, int RID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionDAO.InsertAnswerSectionWithReferenceId(string, int, string, int)”的 XML 注释
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