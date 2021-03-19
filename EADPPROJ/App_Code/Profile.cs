using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile”的 XML 注释
    public class Profile
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.Profile()”的 XML 注释
        public Profile()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.Profile()”的 XML 注释
        {

        }
        Database data = new Database();
        ProfileDAO profileDAO = new ProfileDAO();
        QuestionDAO questionDAO = new QuestionDAO();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentIcon(Profile, string)”的 XML 注释
        public string GetStudentIcon(Profile profile,string adminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentIcon(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectStudentProfileByAdminNo(adminNo);
            string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
            string url = "../assets/img/faces/" + icon;
            return url;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentName(Profile, string)”的 XML 注释
        public string GetStudentName(Profile profile, string adminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentName(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectStudentProfileByAdminNo(adminNo);
            string name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
            return name;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentSchool(Profile, string)”的 XML 注释
        public string GetStudentSchool(Profile profile, string adminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentSchool(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectStudentProfileByAdminNo(adminNo);
            string school = Convert.ToString(ds.Tables[0].Rows[0]["School"]);
            return school;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentQuestionNo(Profile, string)”的 XML 注释
        public string GetStudentQuestionNo(Profile profile, string adminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentQuestionNo(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectStudentProfileByAdminNo(adminNo);
            string questionNo = Convert.ToString(ds.Tables[0].Rows[0]["QuestionNo"]);
            return questionNo;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentAnswersNo(Profile, string)”的 XML 注释
        public string GetStudentAnswersNo(Profile profile, string adminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentAnswersNo(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectStudentProfileByAdminNo(adminNo);
            string answersNo = Convert.ToString(ds.Tables[0].Rows[0]["AnswersNo"]);
            return answersNo;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentBestSolution(Profile, string)”的 XML 注释
        public int GetStudentBestSolution(Profile profile, string adminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetStudentBestSolution(Profile, string)”的 XML 注释
        {
            DataSet ds = profileDAO.SelectAnswerByUsernameAndBestSelected(adminNo);
            return ds.Tables[0].Rows.Count;
        }
       
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetTeacherIcon(Profile, string)”的 XML 注释
        public string GetTeacherIcon(Profile profile, string NRIC)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetTeacherIcon(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectTeacherProfileByNRIC(NRIC);
            string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
            string url = "../assets/img/faces/" + icon;
            return url;
        }
        
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetTeacherName(Profile, string)”的 XML 注释
        public string GetTeacherName(Profile profile, string NRIC)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetTeacherName(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectTeacherProfileByNRIC(NRIC);
            string name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
            return name;
        }

        
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetTeacherQuestionNo(Profile, string)”的 XML 注释
        public string GetTeacherQuestionNo(Profile profile, string NRIC)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetTeacherQuestionNo(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectTeacherProfileByNRIC(NRIC);
            string questionNo = Convert.ToString(ds.Tables[0].Rows[0]["QuestionNo"]);
            return questionNo;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetTeacherAnswersNo(Profile, string)”的 XML 注释
        public string GetTeacherAnswersNo(Profile profile, string NRIC)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetTeacherAnswersNo(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectTeacherProfileByNRIC(NRIC);
            string answersNo = Convert.ToString(ds.Tables[0].Rows[0]["AnswersNo"]);
            return answersNo;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetTeacherBestSolution(Profile, string)”的 XML 注释
        public int GetTeacherBestSolution(Profile profile, string NRIC)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetTeacherBestSolution(Profile, string)”的 XML 注释
        {
            DataSet ds = profileDAO.SelectAnswerByUsernameAndBestSelected(NRIC);
            return ds.Tables[0].Rows.Count;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetAdminIcon(Profile, string)”的 XML 注释
        public string GetAdminIcon(Profile profile, string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetAdminIcon(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectAdminProfileByUsername(Username);
            string icon = Convert.ToString(ds.Tables[0].Rows[0]["HeadIcon"]);
            string url = "../assets/img/faces/" + icon;
            return url;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetIcon(Profile, string)”的 XML 注释
        public string GetIcon(Profile profile, string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetIcon(Profile, string)”的 XML 注释
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
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetAdminQuestionNo(Profile, string)”的 XML 注释
        public string GetAdminQuestionNo(Profile profile, string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetAdminQuestionNo(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectAdminProfileByUsername(Username);
            string questionNo = Convert.ToString(ds.Tables[0].Rows[0]["QuestionNo"]);
            return questionNo;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetAdminAnswersNo(Profile, string)”的 XML 注释
        public string GetAdminAnswersNo(Profile profile, string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetAdminAnswersNo(Profile, string)”的 XML 注释
        {
            DataSet ds = questionDAO.SelectAdminProfileByUsername(Username);
            string questionNo = Convert.ToString(ds.Tables[0].Rows[0]["AnswersNo"]);
            return questionNo;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetAdminBestSolution(Profile, string)”的 XML 注释
        public int GetAdminBestSolution(Profile profile, string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetAdminBestSolution(Profile, string)”的 XML 注释
        {
            DataSet ds = profileDAO.SelectAnswerByUsernameAndBestSelected(Username);
            return ds.Tables[0].Rows.Count;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.ValidateImg(Profile, string)”的 XML 注释
        public bool ValidateImg(Profile profile, string path)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.ValidateImg(Profile, string)”的 XML 注释
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.SaveStudentImg(Profile, string, string)”的 XML 注释
        public void SaveStudentImg(Profile profile,string adminNo,string path)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.SaveStudentImg(Profile, string, string)”的 XML 注释
        {
            profileDAO.UpdateStudentProfileHeadIconByAdminNo(adminNo, path);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.SaveTeacherImg(Profile, string, string)”的 XML 注释
        public void SaveTeacherImg(Profile profile, string NRIC, string path)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.SaveTeacherImg(Profile, string, string)”的 XML 注释
        {
            profileDAO.UpdateTeacherProfileHeadIconByNRIC(NRIC, path);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.SaveAdminImg(Profile, string, string)”的 XML 注释
        public void SaveAdminImg(Profile profile, string Username, string path)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.SaveAdminImg(Profile, string, string)”的 XML 注释
        {
            profileDAO.UpdateAdminProfileHeadIconByUsername(Username, path);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.UpdateProfileAnswerNo(Profile, string)”的 XML 注释
        public void UpdateProfileAnswerNo(Profile profile, string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.UpdateProfileAnswerNo(Profile, string)”的 XML 注释
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.PostComment(Profile, string, string, string)”的 XML 注释
        public void PostComment(Profile profile, string Username, string Poster, string comment)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.PostComment(Profile, string, string, string)”的 XML 注释
        {
            profileDAO.InsertComment(Username, Poster, comment);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.PostBlog(Profile, string, string, string, bool, string)”的 XML 注释
        public void PostBlog(Profile profile, string title,string content, string poster,bool imgdefault,string imgpath)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.PostBlog(Profile, string, string, string, bool, string)”的 XML 注释
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.AddFavorite(Profile, int, string)”的 XML 注释
        public void AddFavorite(Profile profile,int id,string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.AddFavorite(Profile, int, string)”的 XML 注释
        {
            profileDAO.InsertFavourite(id, username);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.ValidateFav(Profile, int, string)”的 XML 注释
        public int ValidateFav(Profile profile,int id,string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.ValidateFav(Profile, int, string)”的 XML 注释
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Profile.GetBlogNo(Profile, string)”的 XML 注释
        public int GetBlogNo(Profile profile,string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Profile.GetBlogNo(Profile, string)”的 XML 注释
        {
            DataSet ds = profileDAO.SelectBlogByPoster(username);
            return ds.Tables[0].Rows.Count;
        }
    }

}