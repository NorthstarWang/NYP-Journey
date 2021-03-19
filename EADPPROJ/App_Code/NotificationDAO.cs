using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NotificationDAO”的 XML 注释
    public class NotificationDAO
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NotificationDAO”的 XML 注释
    {

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NotificationDAO.NotificationDAO()”的 XML 注释
        public NotificationDAO()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NotificationDAO.NotificationDAO()”的 XML 注释
        {

        }
        Database data = new Database();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NotificationDAO.SelectNotificationByUsernameAndViewBool(string)”的 XML 注释
        public DataSet SelectNotificationByUsernameAndViewBool(string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NotificationDAO.SelectNotificationByUsernameAndViewBool(string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@ViewBool",  SqlDbType.Int, 50,0)
                };
            return data.RunProcReturn("SELECT * FROM tb_Notification WHERE (Username = @Username) AND ViewBool = @ViewBool", prams, "tb_Notification");
            
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NotificationDAO.UpdateNotificationViewBoolByUsernameAndId(string, int)”的 XML 注释
        public void UpdateNotificationViewBoolByUsernameAndId(string Username, int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NotificationDAO.UpdateNotificationViewBoolByUsernameAndId(string, int)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@ViewBool",  SqlDbType.Int, 50,1),
                data.MakeInParam("@Id",  SqlDbType.Int, 50,id)
                };
            data.RunProc("UPDATE tb_Notification SET ViewBool = (@ViewBool) WHERE (Username = @Username) AND (Id = @Id)", prams);
        
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“NotificationDAO.InsertNotification(string, string, string)”的 XML 注释
        public void InsertNotification(string Username, string Url,string Type)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“NotificationDAO.InsertNotification(string, string, string)”的 XML 注释
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@ViewBool",  SqlDbType.Int, 50,0),
                data.MakeInParam("@PostTime",  SqlDbType.DateTime,14,DateTime.Now),
                data.MakeInParam("@Type",  SqlDbType.VarChar,50,Type),
                data.MakeInParam("@Url",  SqlDbType.VarChar,50,Url),
                };
            data.RunProc("INSERT INTO tb_Notification (Username,ViewBool,PostTime,Type,Url) VALUES(@Username,@ViewBool,@PostTime,@Type,@Url)", prams);
        
        }
    }
}