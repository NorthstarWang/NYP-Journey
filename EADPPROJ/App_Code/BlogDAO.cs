﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EADPPROJ.App_Code
{
    public class BlogDAO
    {
        Database data = new Database();

        public BlogDAO()
        {

        }
        public DataSet SelectBlogById(int id)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,id)
                };
            ds = data.RunProcReturn("SELECT * FROM tb_Blog WHERE (Id = @Id)", prams, "tb_Blog");
            return ds;
        }

        public void UpdateBlogTip(int id, int amt)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,id),
                data.MakeInParam("@Tip",  SqlDbType.Int, 4,amt)
                };
            data.RunProc("UPDATE tb_Blog SET Tip = (@Tip) WHERE (Id = @Id)", prams);
        }
        public void UpdateBlogFavourite(int id)
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,id)
                };
            data.RunProc("UPDATE tb_Blog SET Favorite = Favorite + 1 WHERE (Id = @Id)", prams);
        }

        public void UpdateHighlight(int id,int highlight)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,id),
                data.MakeInParam("@Highlight",  SqlDbType.Int, 4,highlight)
                };
            data.RunProc("UPDATE tb_Blog SET HighLight = @Highlight WHERE (Id = @Id)", prams);
        }
    }
}