using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    public class Question
    {
        public Question()
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

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public DateTime Posttime
        {
            get { return posttime; }
            set { posttime = value; }
        }

        public DateTime Latest
        {
            get { return latest; }
            set { latest = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public string QuestionContent
        {
            get { return questionContent; }
            set { questionContent = value; }
        }

        public int BestSelected
        {
            get { return bestSelected; }
            set { bestSelected = value; }
        }
        public int CreditReward
        {
            get { return creditReward; }
            set { creditReward = value; }
        }
        public string GetMaxId(Question question)
        {
            DataSet ds = questionDAO.SelectQuestionOrderByIdDESC();
            string maxId = Convert.ToString(ds.Tables[0].Rows[0]["Id"]);
            return maxId;
        }
        public int GetSpecificSchoolMaxId(Question question,string school)
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
        public void AddQuestion(Question question)
        {
            questionDAO.InsertQuestion(question.Title, question.Content, question.Type, question.Posttime, question.Username, question.State, question.CreditReward);
         }

        public DataSet GetQuestionDetail(Question question, int Id)
        {
            return questionDAO.SelectQuestionById(Id);
        }

        public string GetHeadIcon(Question question,string ID)
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

        public int GetCurrentProfileQuestionNo(Question question,string ID)
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

        public void UpdateProfileQuestionNo(Question question,string ID)
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

        public DataSet LoadQuestionDetail(Question question, int ID)
        {
            return questionDAO.SelectQuestionById(ID);
        }

        public int GetMaxAnswerId(Question question)
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
        
        public void SaveRichTextAnswer(Question question,string QuestionCode,string QuestionContent,string Username)
        {
            questionDAO.InsertAnswer(QuestionCode, QuestionContent, Username);
            }

        public void UpdateQuestionLastUpdate(Question question,string QuestionCode)
        {
            questionDAO.UpdateQuestionLastUpdateById(QuestionCode);
        }


        public int CalculateTotalAnswerForQuestionDetail(Question question,string QuestionCode)
        {
            DataSet ds = questionDAO.SelectAnswerByQuestionCodeOrderByUpvoteDESC(QuestionCode);
            int total = ds.Tables[0].Rows.Count;
            return total;
        }

        public void SetAnswerBestAnswer(Question question, int ID)
        {
            questionDAO.UpdateAnswerBestSelectedById(ID);
        }

        public void SetProblemSolved(Question question, int ID)
        {
            questionDAO.UpdateQuestionStateById(ID);
        }

        public string GetQuestionStatus(Question question, int ID)
        {

            DataSet ds = questionDAO.SelectQuestionById(ID);
            string status = ds.Tables[0].Rows[0]["State"].ToString();
            return status;
        }

        public DataSet GetBestAnswer(Question question, int QuestionCode)
        {
            return questionDAO.SelectAnswerByQuestionCodeAndBestSelected(QuestionCode);
        }

        public int GetUpvoteNumber(Question question, int AnswerNo)
        {
            DataSet ds = questionDAO.SelectAnswerById(AnswerNo);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["UpVote"]);
        }

        public void UpdateUpvoteRecord(Question question,string Username, int AnswerNo, int QuestionCode)
        {
            questionDAO.InsertUpvoteRecord(Username, AnswerNo, QuestionCode);
             }
        public void DeleteUpvoteRecord(Question question, string Username, int AnswerNo)
        {
            questionDAO.DeleteUpvoteRecord(Username, AnswerNo);
        }
        public bool CheckUpvoteAvailability(Question question,string Username, int AnswerNo)
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

        public void UpdateUpvote(Question question, int Id, string Username,int QuestionCode)
        {
            int newVote = GetUpvoteNumber(question, Id) + 1;
            questionDAO.UpdateAnswerUpvoteById(Id, newVote);
            UpdateUpvoteRecord(question, Username, Id, QuestionCode);
        }

        public void MinusUpvote(Question question, int Id, string Username, int QuestionCode)
        {
            int newVote = GetUpvoteNumber(question, Id) - 1;
            questionDAO.UpdateAnswerUpvoteById(Id, newVote);
            UpdateUpvoteRecord(question, Username, Id, QuestionCode);
        }

        public bool CheckAnswerSection(Question question,int Id)
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

        public void PostReply(Question question,string Username,int AnswerId,string content)
        {
            questionDAO.InsertAnswerSection(Username, AnswerId, content);    
        }

        public string GetReplierUsername(Question question,int Id)
        {
            DataSet ds = questionDAO.SelectAnswerSectionById(Id);
            return ds.Tables[0].Rows[0]["Username"].ToString();
        }

        public void PostReplyInReply(Question question, string Username, int AnswerId, string content,int RID)
        {
            questionDAO.InsertAnswerSectionWithReferenceId(Username, AnswerId, content, RID); 
        }

        public int CheckQuestionReview(Question question,int Id)
        {
            DataSet ds = questionDAO.SelectQuestionById(Id);
            int i = Convert.ToInt32(ds.Tables[0].Rows[0]["Review"]);
            return i;
        }

        public string GetQuestionTitle(Question question, int Id)
        {
            DataSet ds = questionDAO.SelectQuestionById(Id);
            return ds.Tables[0].Rows[0]["Title"].ToString();
        }
        public string GetQuestionPoster(Question question, int Id)
        {
            DataSet ds = questionDAO.SelectQuestionById(Id);
            return ds.Tables[0].Rows[0]["Username"].ToString();
        }

    }
}