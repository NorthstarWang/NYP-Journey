using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question”的 XML 注释
    public class Question
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.Question()”的 XML 注释
        public Question()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.Question()”的 XML 注释
        {

        }
        Database data = new Database();
        QuestionDAO questionDAO = new QuestionDAO();

        private int id = 0;
        private string title = "";
        private string type = "";
        private string content ="";
        private DateTime posttime = Convert.ToDateTime(DateTime.Now.ToString());
        private string username = "";
        private DateTime latest = Convert.ToDateTime(DateTime.Now.ToString());
        private string state = "Not Solved";
        private string questionContent = "";
        private int bestSelected = 0;
        private int creditReward = 0;

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.Id”的 XML 注释
        public int Id
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.Id”的 XML 注释
        {
            get { return id; }
            set { id = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.Title”的 XML 注释
        public string Title
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.Title”的 XML 注释
        {
            get { return title; }
            set { title = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.Type”的 XML 注释
        public string Type
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.Type”的 XML 注释
        {
            get { return type; }
            set { type = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.Content”的 XML 注释
        public string Content
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.Content”的 XML 注释
        {
            get { return content; }
            set { content = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.Username”的 XML 注释
        public string Username
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.Username”的 XML 注释
        {
            get { return username; }
            set { username = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.Posttime”的 XML 注释
        public DateTime Posttime
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.Posttime”的 XML 注释
        {
            get { return posttime; }
            set { posttime = value; }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.Latest”的 XML 注释
        public DateTime Latest
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.Latest”的 XML 注释
        {
            get { return latest; }
            set { latest = value; }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.State”的 XML 注释
        public string State
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.State”的 XML 注释
        {
            get { return state; }
            set { state = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.QuestionContent”的 XML 注释
        public string QuestionContent
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.QuestionContent”的 XML 注释
        {
            get { return questionContent; }
            set { questionContent = value; }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.BestSelected”的 XML 注释
        public int BestSelected
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.BestSelected”的 XML 注释
        {
            get { return bestSelected; }
            set { bestSelected = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.CreditReward”的 XML 注释
        public int CreditReward
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.CreditReward”的 XML 注释
        {
            get { return creditReward; }
            set { creditReward = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetMaxId(Question)”的 XML 注释
        public string GetMaxId(Question question)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetMaxId(Question)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectQuestionOrderByIdDESC();
            string maxId = Convert.ToString(ds.Tables[0].Rows[0]["Id"]);
            return maxId;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetSpecificSchoolMaxId(Question, string)”的 XML 注释
        public int GetSpecificSchoolMaxId(Question question,string school)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetSpecificSchoolMaxId(Question, string)”的 XML 注释
        {
            DataSet ds = null;
            if(school == "All")
            {
                ds = questionDAO.SelectQuestionOrderByIdDESC();
            }
            else
            {
                ds = questionDAO.SelectQuestionBySchoolTypeOrderByIdDESC(school);
            }
            string maxId = Convert.ToString(ds.Tables[0].Rows.Count);
            return Convert.ToInt32(maxId);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.AddQuestion(Question)”的 XML 注释
        public void AddQuestion(Question question)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.AddQuestion(Question)”的 XML 注释
        {
            questionDAO.InsertQuestion(question.Title, question.Content, question.Type, question.Posttime, question.Username, question.State, question.CreditReward);
         }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetQuestionDetail(Question, int)”的 XML 注释
        public DataSet GetQuestionDetail(Question question, int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetQuestionDetail(Question, int)”的 XML 注释
        {
            return questionDAO.SelectQuestionById(Id);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetHeadIcon(Question, string)”的 XML 注释
        public string GetHeadIcon(Question question,string ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetHeadIcon(Question, string)”的 XML 注释
        {   
            DataSet ds = null;
            if(ID.Length == 7)
            {
                ds = questionDAO.SelectStudentProfileByAdminNo(ID);
                string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
                string url = "../assets/img/faces/" + icon;
                return url;
            }
            else if(ID.Length == 9)
            {
                ds = questionDAO.SelectTeacherProfileByNRIC(ID);
                string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
                string url = "../assets/img/faces/" + icon;
                return url;
            }
            else
            {
                ds = questionDAO.SelectAdminProfileByUsername(ID);
                string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
                string url = "../assets/img/faces/" + icon;
                return url;
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetCurrentProfileQuestionNo(Question, string)”的 XML 注释
        public int GetCurrentProfileQuestionNo(Question question,string ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetCurrentProfileQuestionNo(Question, string)”的 XML 注释
        {
            DataSet ds = null;
            if (ID.Length == 7)
            {
                ds = questionDAO.SelectStudentProfileByAdminNo(ID);
                int questions = Convert.ToInt32(ds.Tables[0].Rows[0]["QuestionNo"]);
                return questions;
            }else if (ID.Length == 9)
            {
                ds = questionDAO.SelectTeacherProfileByNRIC(ID);
                int questions = Convert.ToInt32(ds.Tables[0].Rows[0]["QuestionNo"]);
                return questions;
            }
            else
            {
                ds = questionDAO.SelectAdminProfileByUsername(ID);
                int questions = Convert.ToInt32(ds.Tables[0].Rows[0]["QuestionNo"]);
                return questions;
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.UpdateProfileQuestionNo(Question, string)”的 XML 注释
        public void UpdateProfileQuestionNo(Question question,string ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.UpdateProfileQuestionNo(Question, string)”的 XML 注释
        {
            int newQuestionNo = GetCurrentProfileQuestionNo(question, ID)+1;
            if (ID.Length == 7)
            {
                questionDAO.UpdateStudentProfileQuestionNoByAdminNo(newQuestionNo, ID);
            }else if(ID.Length == 9)
            {
                questionDAO.UpdateTeacherProfileQuestionNoByNRIC(newQuestionNo, ID);
            }
            else
            {
                questionDAO.UpdateAdminProfileQuestionNoByUsername(newQuestionNo, ID);
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.LoadQuestionDetail(Question, int)”的 XML 注释
        public DataSet LoadQuestionDetail(Question question, int ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.LoadQuestionDetail(Question, int)”的 XML 注释
        {
            return questionDAO.SelectQuestionById(ID);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetMaxAnswerId(Question)”的 XML 注释
        public int GetMaxAnswerId(Question question)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetMaxAnswerId(Question)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectAnswerOrderByIdDESC();
            try
            {
                int maxId = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                return maxId; 
            }
            catch (Exception)
            {
                return 1;
            }
            
                   
        }
        
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.SaveRichTextAnswer(Question, string, string, string)”的 XML 注释
        public void SaveRichTextAnswer(Question question,string QuestionCode,string QuestionContent,string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.SaveRichTextAnswer(Question, string, string, string)”的 XML 注释
        {
            questionDAO.InsertAnswer(QuestionCode, QuestionContent, Username);
            }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.UpdateQuestionLastUpdate(Question, string)”的 XML 注释
        public void UpdateQuestionLastUpdate(Question question,string QuestionCode)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.UpdateQuestionLastUpdate(Question, string)”的 XML 注释
        {
            questionDAO.UpdateQuestionLastUpdateById(QuestionCode);
        }


#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.CalculateTotalAnswerForQuestionDetail(Question, string)”的 XML 注释
        public int CalculateTotalAnswerForQuestionDetail(Question question,string QuestionCode)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.CalculateTotalAnswerForQuestionDetail(Question, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectAnswerByQuestionCodeOrderByUpvoteDESC(QuestionCode);
            int total = ds.Tables[0].Rows.Count;
            return total;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.SetAnswerBestAnswer(Question, int)”的 XML 注释
        public void SetAnswerBestAnswer(Question question, int ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.SetAnswerBestAnswer(Question, int)”的 XML 注释
        {
            questionDAO.UpdateAnswerBestSelectedById(ID);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.SetProblemSolved(Question, int)”的 XML 注释
        public void SetProblemSolved(Question question, int ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.SetProblemSolved(Question, int)”的 XML 注释
        {
            questionDAO.UpdateQuestionStateById(ID);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetQuestionStatus(Question, int)”的 XML 注释
        public string GetQuestionStatus(Question question, int ID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetQuestionStatus(Question, int)”的 XML 注释
        {

            DataSet ds = questionDAO.SelectQuestionById(ID);
            string status = ds.Tables[0].Rows[0]["State"].ToString();
            return status;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetBestAnswer(Question, int)”的 XML 注释
        public DataSet GetBestAnswer(Question question, int QuestionCode)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetBestAnswer(Question, int)”的 XML 注释
        {
            return questionDAO.SelectAnswerByQuestionCodeAndBestSelected(QuestionCode);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetUpvoteNumber(Question, int)”的 XML 注释
        public int GetUpvoteNumber(Question question, int AnswerNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetUpvoteNumber(Question, int)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectAnswerById(AnswerNo);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["UpVote"]);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.UpdateUpvoteRecord(Question, string, int, int)”的 XML 注释
        public void UpdateUpvoteRecord(Question question,string Username, int AnswerNo, int QuestionCode)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.UpdateUpvoteRecord(Question, string, int, int)”的 XML 注释
        {
            questionDAO.InsertUpvoteRecord(Username, AnswerNo, QuestionCode);
             }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.DeleteUpvoteRecord(Question, string, int)”的 XML 注释
        public void DeleteUpvoteRecord(Question question, string Username, int AnswerNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.DeleteUpvoteRecord(Question, string, int)”的 XML 注释
        {
            questionDAO.DeleteUpvoteRecord(Username, AnswerNo);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.CheckUpvoteAvailability(Question, string, int)”的 XML 注释
        public bool CheckUpvoteAvailability(Question question,string Username, int AnswerNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.CheckUpvoteAvailability(Question, string, int)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectUpvoteRecordByAnswerNoAndUsername(Username, AnswerNo);
            int i = Convert.ToInt32(ds.Tables[0].Rows.Count);
            if(i == 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.UpdateUpvote(Question, int, string, int)”的 XML 注释
        public void UpdateUpvote(Question question, int Id, string Username,int QuestionCode)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.UpdateUpvote(Question, int, string, int)”的 XML 注释
        {
            int newVote = GetUpvoteNumber(question, Id) + 1;
            questionDAO.UpdateAnswerUpvoteById(Id, newVote);
            UpdateUpvoteRecord(question, Username, Id, QuestionCode);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.MinusUpvote(Question, int, string, int)”的 XML 注释
        public void MinusUpvote(Question question, int Id, string Username, int QuestionCode)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.MinusUpvote(Question, int, string, int)”的 XML 注释
        {
            int newVote = GetUpvoteNumber(question, Id) - 1;
            questionDAO.UpdateAnswerUpvoteById(Id, newVote);
            UpdateUpvoteRecord(question, Username, Id, QuestionCode);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.CheckAnswerSection(Question, int)”的 XML 注释
        public bool CheckAnswerSection(Question question,int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.CheckAnswerSection(Question, int)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectAnswerSectionByAnswerId(Id);
            if(ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else{
                return false;
            }
                
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.PostReply(Question, string, int, string)”的 XML 注释
        public void PostReply(Question question,string Username,int AnswerId,string content)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.PostReply(Question, string, int, string)”的 XML 注释
        {
            questionDAO.InsertAnswerSection(Username, AnswerId, content);    
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetReplierUsername(Question, int)”的 XML 注释
        public string GetReplierUsername(Question question,int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetReplierUsername(Question, int)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectAnswerSectionById(Id);
            return ds.Tables[0].Rows[0]["Username"].ToString();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.PostReplyInReply(Question, string, int, string, int)”的 XML 注释
        public void PostReplyInReply(Question question, string Username, int AnswerId, string content,int RID)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.PostReplyInReply(Question, string, int, string, int)”的 XML 注释
        {
            questionDAO.InsertAnswerSectionWithReferenceId(Username, AnswerId, content, RID); 
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.CheckQuestionReview(Question, int)”的 XML 注释
        public int CheckQuestionReview(Question question,int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.CheckQuestionReview(Question, int)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectQuestionById(Id);
            int i = Convert.ToInt32(ds.Tables[0].Rows[0]["Review"]);
            return i;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetQuestionTitle(Question, int)”的 XML 注释
        public string GetQuestionTitle(Question question, int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetQuestionTitle(Question, int)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectQuestionById(Id);
            return ds.Tables[0].Rows[0]["Title"].ToString();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Question.GetQuestionPoster(Question, int)”的 XML 注释
        public string GetQuestionPoster(Question question, int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Question.GetQuestionPoster(Question, int)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectQuestionById(Id);
            return ds.Tables[0].Rows[0]["Username"].ToString();
        }

    }
}