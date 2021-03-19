using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“BlogDAO”的 XML 注释
    public class BlogDAO
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“BlogDAO”的 XML 注释
    {
        Database data = new Database();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“BlogDAO.BlogDAO()”的 XML 注释
        public BlogDAO()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“BlogDAO.BlogDAO()”的 XML 注释
        {

        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“BlogDAO.SelectBlogById(int)”的 XML 注释
        public DataSet SelectBlogById(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“BlogDAO.SelectBlogById(int)”的 XML 注释
        {
            DataSet ds = null;
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,id)
                };
            ds = data.RunProcReturn("SELECT * FROM tb_Blog WHERE (Id = @Id)", prams, "tb_Blog");
            return ds;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“BlogDAO.UpdateBlogTip(int, int)”的 XML 注释
        public void UpdateBlogTip(int id, int amt)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“BlogDAO.UpdateBlogTip(int, int)”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,id),
                data.MakeInParam("@Tip",  SqlDbType.Int, 4,amt)
                };
            data.RunProc("UPDATE tb_Blog SET Tip = (@Tip) WHERE (Id = @Id)", prams);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“BlogDAO.UpdateBlogFavourite(int)”的 XML 注释
        public void UpdateBlogFavourite(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“BlogDAO.UpdateBlogFavourite(int)”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,id)
                };
            data.RunProc("UPDATE tb_Blog SET Favorite = Favorite + 1 WHERE (Id = @Id)", prams);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“BlogDAO.UpdateHighlight(int, int)”的 XML 注释
        public void UpdateHighlight(int id, int highlight)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“BlogDAO.UpdateHighlight(int, int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Id",  SqlDbType.Int, 4,id),
                data.MakeInParam("@Highlight",  SqlDbType.Int, 4,highlight)
                };
            data.RunProc("UPDATE tb_Blog SET HighLight = @Highlight WHERE (Id = @Id)", prams);
        }
    }
}