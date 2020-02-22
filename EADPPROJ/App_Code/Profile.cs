using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    public class Profile
    {
        public Profile()
        {

        }
        Database data = new Database();
        ProfileDAO profileDAO = new ProfileDAO();
        QuestionDAO questionDAO = new QuestionDAO();

        public string GetStudentIcon(Profile profile,string adminNo)
        {
            DataSet ds = questionDAO.SelectStudentProfileByAdminNo(adminNo);
            string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
            string url = "../assets/img/faces/" + icon;
            return url;
        }
        public string GetStudentName(Profile profile, string adminNo)
        {
            DataSet ds = questionDAO.SelectStudentProfileByAdminNo(adminNo);
            string name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
            return name;
        }
        public string GetStudentSchool(Profile profile, string adminNo)
        {
            DataSet ds = questionDAO.SelectStudentProfileByAdminNo(adminNo);
            string school = Convert.ToString(ds.Tables[0].Rows[0]["School"]);
            return school;
        }
        public string GetStudentQuestionNo(Profile profile, string adminNo)
        {
            DataSet ds = questionDAO.SelectStudentProfileByAdminNo(adminNo);
            string questionNo = Convert.ToString(ds.Tables[0].Rows[0]["QuestionNo"]);
            return questionNo;
        }
        public string GetStudentAnswersNo(Profile profile, string adminNo)
        {
            DataSet ds = questionDAO.SelectStudentProfileByAdminNo(adminNo);
            string answersNo = Convert.ToString(ds.Tables[0].Rows[0]["AnswersNo"]);
            return answersNo;
        }

        public int GetStudentBestSolution(Profile profile, string adminNo)
        {
            DataSet ds = profileDAO.SelectAnswerByUsernameAndBestSelected(adminNo);
            return ds.Tables[0].Rows.Count;
        }
       
        public string GetTeacherIcon(Profile profile, string NRIC)
        {
            DataSet ds = questionDAO.SelectTeacherProfileByNRIC(NRIC);
            string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
            string url = "../assets/img/faces/" + icon;
            return url;
        }
        
        public string GetTeacherName(Profile profile, string NRIC)
        {
            DataSet ds = questionDAO.SelectTeacherProfileByNRIC(NRIC);
            string name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
            return name;
        }

        
        public string GetTeacherQuestionNo(Profile profile, string NRIC)
        {
            DataSet ds = questionDAO.SelectTeacherProfileByNRIC(NRIC);
            string questionNo = Convert.ToString(ds.Tables[0].Rows[0]["QuestionNo"]);
            return questionNo;
        }
        public string GetTeacherAnswersNo(Profile profile, string NRIC)
        {
            DataSet ds = questionDAO.SelectTeacherProfileByNRIC(NRIC);
            string answersNo = Convert.ToString(ds.Tables[0].Rows[0]["AnswersNo"]);
            return answersNo;
        }

        public int GetTeacherBestSolution(Profile profile, string NRIC)
        {
            DataSet ds = profileDAO.SelectAnswerByUsernameAndBestSelected(NRIC);
            return ds.Tables[0].Rows.Count;
        }

        public string GetAdminIcon(Profile profile, string Username)
        {
            DataSet ds = questionDAO.SelectAdminProfileByUsername(Username);
            string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
            string url = "../assets/img/faces/" + icon;
            return url;
        }

        public string GetIcon(Profile profile, string Username)
        {
            DataSet ds = null;
            if (Username.Length == 7)
            {
                ds = questionDAO.SelectStudentProfileByAdminNo(Username);
                string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
                string url = "../assets/img/faces/" + icon;
                return url;
            }
            else if(Username.Length == 9)
            {
                ds = questionDAO.SelectTeacherProfileByNRIC(Username);
                string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
                string url = "../assets/img/faces/" + icon;
                return url;
            }
            else
            {
                ds = questionDAO.SelectAdminProfileByUsername(Username);
                string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
            string url = "../assets/img/faces/" + icon;
            return url;
            }
            
        }
        public string GetAdminQuestionNo(Profile profile, string Username)
        {
            DataSet ds = questionDAO.SelectAdminProfileByUsername(Username);
            string questionNo = Convert.ToString(ds.Tables[0].Rows[0]["QuestionNo"]);
            return questionNo;
        }
        public string GetAdminAnswersNo(Profile profile, string Username)
        {
            DataSet ds = questionDAO.SelectAdminProfileByUsername(Username);
            string questionNo = Convert.ToString(ds.Tables[0].Rows[0]["AnswersNo"]);
            return questionNo;
        }
        public int GetAdminBestSolution(Profile profile, string Username)
        {
            DataSet ds = profileDAO.SelectAnswerByUsernameAndBestSelected(Username);
            return ds.Tables[0].Rows.Count;
        }

        public bool ValidateImg(Profile profile, string path)
        {
            bool fileIsValid=false;
            string[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (path == restrictExtension[i])
                {
                    fileIsValid = true;
                    break;
                }
                else
                {
                    fileIsValid = false;
                }
                
            }
            return fileIsValid;
            
        }

        public void SaveStudentImg(Profile profile,string adminNo,string path)
        {
            profileDAO.UpdateStudentProfileHeadIconByAdminNo(adminNo, path);
        }
        public void SaveTeacherImg(Profile profile, string NRIC, string path)
        {
            profileDAO.UpdateTeacherProfileHeadIconByNRIC(NRIC, path);
        }
        public void SaveAdminImg(Profile profile, string Username, string path)
        {
            profileDAO.UpdateAdminProfileHeadIconByUsername(Username, path);
        }
        public void UpdateProfileAnswerNo(Profile profile, string Username)
        {
            if (Username.Length == 7)
            {
                int NewNum = Convert.ToInt32(GetStudentAnswersNo(profile, Username))+1;
                profileDAO.UpdateStudentProfileAnswerNoByAdminNo(NewNum, Username);
            }
            else if (Username.Length == 9)
            {
                int NewNum = Convert.ToInt32(GetTeacherAnswersNo(profile, Username)) + 1;
                profileDAO.UpdateTeacherProfileAnswerNoByNRIC(NewNum, Username);
            }
            else
            {
                int NewNum = Convert.ToInt32(GetAdminAnswersNo(profile, Username)) + 1;
                profileDAO.UpdateAdminProfileAnswerNoByUsername(NewNum, Username);
            }
        }

        public void PostComment(Profile profile, string Username, string Poster, string comment)
        {
            profileDAO.InsertComment(Username, Poster, comment);
        }

        public void PostBlog(Profile profile, string title,string content, string poster,bool imgdefault,string imgpath)
        {
            if(imgdefault == true)
            {
                profileDAO.InsertBlog(title, content, poster);
            }
            else
            {
                profileDAO.InsertBlog(title, content, poster, imgpath);    
            }
            
        }

        public void AddFavorite(Profile profile,int id,string username)
        {
            profileDAO.InsertFavourite(id, username);
        }

        public int ValidateFav(Profile profile,int id,string username)
        {
            DataSet ds = profileDAO.SelectFavouriteByBlogIdAndUsername(id, username);
            if (ds.Tables[0].Rows.Count != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int GetBlogNo(Profile profile,string username)
        {
            DataSet ds = profileDAO.SelectBlogByPoster(username);
            return ds.Tables[0].Rows.Count;
        }
    }

}