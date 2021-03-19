using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EADPPROJ.App_Code;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog”的 XML 注释
    public class Blog
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog”的 XML 注释
    {
        Database data = new Database();
        BlogDAO blogDAO = new BlogDAO();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.Blog()”的 XML 注释
        public Blog()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.Blog()”的 XML 注释
        {

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.GetTitle(int)”的 XML 注释
        public string GetTitle(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.GetTitle(int)”的 XML 注释
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return ds.Tables[0].Rows[0]["Title"].ToString();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.GetContent(int)”的 XML 注释
        public string GetContent(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.GetContent(int)”的 XML 注释
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return ds.Tables[0].Rows[0]["Content"].ToString();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.GetBGPath(int)”的 XML 注释
        public string GetBGPath(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.GetBGPath(int)”的 XML 注释
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return ds.Tables[0].Rows[0]["BGImage"].ToString();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.GetUsername(int)”的 XML 注释
        public string GetUsername(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.GetUsername(int)”的 XML 注释
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return ds.Tables[0].Rows[0]["Poster"].ToString();
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.GetTip(int)”的 XML 注释
        public int GetTip(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.GetTip(int)”的 XML 注释
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["Tip"]);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.GetFavorite(int)”的 XML 注释
        public int GetFavorite(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.GetFavorite(int)”的 XML 注释
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["Favorite"]);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.ValidateDefaultBG(int)”的 XML 注释
        public bool ValidateDefaultBG(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.ValidateDefaultBG(int)”的 XML 注释
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            int no = Convert.ToInt32(ds.Tables[0].Rows[0]["BGDefault"]);
            if(no == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.AddTip(int, int)”的 XML 注释
        public void AddTip(int id,int amt)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.AddTip(int, int)”的 XML 注释
        {
            amt += GetTip(id);
            blogDAO.UpdateBlogTip(id, amt);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.AddFavourite(int)”的 XML 注释
        public void AddFavourite(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.AddFavourite(int)”的 XML 注释
        {
            blogDAO.UpdateBlogFavourite(id);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.GetHighlight(int)”的 XML 注释
        public int GetHighlight(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.GetHighlight(int)”的 XML 注释
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["HighLight"]);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Blog.CheckHighlight(int)”的 XML 注释
        public bool CheckHighlight(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Blog.CheckHighlight(int)”的 XML 注释
        {
            
            
            if (GetHighlight(id) == 1) {
                blogDAO.UpdateHighlight(id, 0);
                return false;
            }
            else
            {
                blogDAO.UpdateHighlight(id, 1);
                return true;
            }
        }
    }
}