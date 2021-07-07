using System;
using System.Data;

namespace EADPPROJ.App_Code
{
    public class Blog
    {
        Database data = new Database();
        BlogDAO blogDAO = new BlogDAO();

        public Blog()
        {

        }

        public string GetTitle(int id)
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return ds.Tables[0].Rows[0]["Title"].ToString();
        }

        public string GetContent(int id)
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return ds.Tables[0].Rows[0]["Content"].ToString();
        }

        public string GetBGPath(int id)
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return ds.Tables[0].Rows[0]["BGImage"].ToString();
        }

        public string GetUsername(int id)
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return ds.Tables[0].Rows[0]["Poster"].ToString();
        }

        public int GetTip(int id)
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["Tip"]);
        }

        public int GetFavorite(int id)
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["Favorite"]);
        }

        public bool ValidateDefaultBG(int id)
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            int no = Convert.ToInt32(ds.Tables[0].Rows[0]["BGDefault"]);
            if (no == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AddTip(int id, int amt)
        {
            amt += GetTip(id);
            blogDAO.UpdateBlogTip(id, amt);
        }

        public void AddFavourite(int id)
        {
            blogDAO.UpdateBlogFavourite(id);
        }

        public int GetHighlight(int id)
        {
            DataSet ds = blogDAO.SelectBlogById(id);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["HighLight"]);
        }

        public bool CheckHighlight(int id)
        {


            if (GetHighlight(id) == 1)
            {
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