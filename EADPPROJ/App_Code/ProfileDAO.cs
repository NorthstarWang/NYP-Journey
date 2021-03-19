using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO”的 XML 注释
    public class ProfileDAO
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.ProfileDAO()”的 XML 注释
        public ProfileDAO()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.ProfileDAO()”的 XML 注释
        {

        }
        Database data = new Database();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.SelectAnswerByUsernameAndBestSelected(string)”的 XML 注释
        public DataSet SelectAnswerByUsernameAndBestSelected(string adminNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.SelectAnswerByUsernameAndBestSelected(string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50,adminNo)
            };
            return data.RunProcReturn("Select * FROM tb_Answer WHERE (Username = @Username) AND BestSelected = 1", prams, "tb_Answer");
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateStudentProfileHeadIconByAdminNo(string, string)”的 XML 注释
        public void UpdateStudentProfileHeadIconByAdminNo(string adminNo, string path)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateStudentProfileHeadIconByAdminNo(string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@AdminNo",  SqlDbType.VarChar, 50, adminNo),
            data.MakeInParam("@HeadIcon",  SqlDbType.VarChar, 50, path),
            };
            data.RunProc("UPDATE tb_StudentProfile SET HeadIcon = (@HeadIcon) WHERE (AdminNo = @AdminNo)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateTeacherProfileHeadIconByNRIC(string, string)”的 XML 注释
        public void UpdateTeacherProfileHeadIconByNRIC(string NRIC, string path)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateTeacherProfileHeadIconByNRIC(string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@NRIC",  SqlDbType.VarChar, 50, NRIC),
            data.MakeInParam("@HeadIcon",  SqlDbType.VarChar, 50, path),
            };
            data.RunProc("UPDATE tb_TeacherProfile SET HeadIcon = (@HeadIcon) WHERE (NRIC = @NRIC)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateAdminProfileHeadIconByUsername(string, string)”的 XML 注释
        public void UpdateAdminProfileHeadIconByUsername(string Username, string path)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateAdminProfileHeadIconByUsername(string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
            data.MakeInParam("@Username",  SqlDbType.VarChar, 50, Username),
            data.MakeInParam("@HeadIcon",  SqlDbType.VarChar, 50, path),
            };
            data.RunProc("UPDATE tb_AdminProfile SET HeadIcon = (@HeadIcon) WHERE (Username = @Username)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateStudentProfileAnswerNoByAdminNo(int, string)”的 XML 注释
        public void UpdateStudentProfileAnswerNoByAdminNo(int NewNum,string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateStudentProfileAnswerNoByAdminNo(int, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@AnswersNo",  SqlDbType.Int, 4,NewNum)
                };
                data.RunProc("UPDATE tb_StudentProfile SET AnswersNo = (@AnswersNo) WHERE (AdminNo = @Username)", prams);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateTeacherProfileAnswerNoByNRIC(int, string)”的 XML 注释
        public void UpdateTeacherProfileAnswerNoByNRIC(int NewNum, string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateTeacherProfileAnswerNoByNRIC(int, string)”的 XML 注释
        {
        SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@AnswersNo",  SqlDbType.Int, 4,NewNum)
                };
                data.RunProc("UPDATE tb_TeacherProfile SET AnswersNo = (@AnswersNo) WHERE (NRIC = @Username)", prams);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateAdminProfileAnswerNoByUsername(int, string)”的 XML 注释
        public void UpdateAdminProfileAnswerNoByUsername(int NewNum, string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.UpdateAdminProfileAnswerNoByUsername(int, string)”的 XML 注释
        { 
        SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@AnswersNo",  SqlDbType.Int, 4,NewNum)
                };
                data.RunProc("UPDATE tb_AdminProfile SET AnswersNo = (@AnswersNo) WHERE (Username = @Username)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.InsertComment(string, string, string)”的 XML 注释
        public void InsertComment(string Username, string Poster, string comment)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.InsertComment(string, string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@Poster",  SqlDbType.VarChar, 50,Poster),
                data.MakeInParam("@Content",  SqlDbType.NVarChar, 500,comment),
                data.MakeInParam("@PostTime",  SqlDbType.DateTime, 14,DateTime.Now),
                };
            data.RunProc("INSERT INTO tb_Comment (Username,Poster,PostTime,Content) VALUES(@Username,@Poster,@PostTime,@Content)", prams);

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.InsertBlog(string, string, string)”的 XML 注释
        public void InsertBlog(string title, string content, string poster)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.InsertBlog(string, string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                            data.MakeInParam("@Title",  SqlDbType.VarChar, 100,title),
                            data.MakeInParam("@Poster",  SqlDbType.VarChar, 50,poster),
                            data.MakeInParam("@Content",  SqlDbType.NVarChar, 5000,content),
                            data.MakeInParam("@PostTime",  SqlDbType.DateTime, 14,DateTime.Now),
                            data.MakeInParam("@HighLight",  SqlDbType.Int, 4,0),
                            data.MakeInParam("@BGDefault",  SqlDbType.Int, 4,1),
                            data.MakeInParam("@Tip",  SqlDbType.Int, 4,0),
                            data.MakeInParam("@Favorite",  SqlDbType.Int, 4,0),
                            };
            data.RunProc("INSERT INTO tb_Blog (Title,Poster,PostTime,Content,HighLight,BGDefault,Tip,Favorite) VALUES(@Title,@Poster,@PostTime,@Content,@HighLight,@BGDefault,@Tip,@Favorite)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.InsertBlog(string, string, string, string)”的 XML 注释
        public void InsertBlog(string title, string content, string poster, string imgpath)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.InsertBlog(string, string, string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                            data.MakeInParam("@Title",  SqlDbType.VarChar, 100,title),
                            data.MakeInParam("@Poster",  SqlDbType.VarChar, 50,poster),
                            data.MakeInParam("@Content",  SqlDbType.NVarChar, 5000,content),
                            data.MakeInParam("@PostTime",  SqlDbType.DateTime, 14,DateTime.Now),
                            data.MakeInParam("@HighLight",  SqlDbType.Int, 4,0),
                            data.MakeInParam("@BGImage",  SqlDbType.VarChar, 100,imgpath),
                            data.MakeInParam("@BGDefault",  SqlDbType.Int, 4,0),
                            data.MakeInParam("@Tip",  SqlDbType.Int, 4,0),
                            data.MakeInParam("@Favorite",  SqlDbType.Int, 4,0),
                            };
            data.RunProc("INSERT INTO tb_Blog (Title,Poster,PostTime,Content,HighLight,BGImage,BGDefault,Tip,Favorite) VALUES(@Title,@Poster,@PostTime,@Content,@HighLight,@BGImage,@BGDefault,@Tip,@Favorite)", prams);

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.InsertFavourite(int, string)”的 XML 注释
        public void InsertFavourite(int id, string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.InsertFavourite(int, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username),
                data.MakeInParam("@BlogId",  SqlDbType.Int, 4,id)
                };
            data.RunProc("INSERT INTO tb_Favourite (Username,BlogId) VALUES(@Username,@BlogId)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.SelectFavouriteByBlogIdAndUsername(int, string)”的 XML 注释
        public DataSet SelectFavouriteByBlogIdAndUsername(int id, string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.SelectFavouriteByBlogIdAndUsername(int, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,id),
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,username)
                };
            return data.RunProcReturn("Select * FROM tb_Favourite WHERE (BlogId = @Id) AND (Username=@Username)", prams, "tb_Favourite");
            
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ProfileDAO.SelectBlogByPoster(string)”的 XML 注释
        public DataSet SelectBlogByPoster(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ProfileDAO.SelectBlogByPoster(string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Poster", SqlDbType.VarChar, 50,username)
                };
            return data.RunProcReturn("Select * FROM tb_Blog WHERE (Poster = @Poster)", prams, "tb_Blog");
        }
    }
}