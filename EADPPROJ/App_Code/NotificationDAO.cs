using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    public class NotificationDAO
    {

        public NotificationDAO()
        {

        }
        Database data = new Database();

        public DataSet SelectNotificationByUsernameAndViewBool(string Username)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@ViewBool",  SqlDbType.Int, 50,0)
                };
            return data.RunProcReturn("SELECT * FROM tb_Notification WHERE (Username = @Username) AND ViewBool = @ViewBool", prams, "tb_Notification");
            
        }

        public void UpdateNotificationViewBoolByUsernameAndId(string Username, int id)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@Username",  SqlDbType.VarChar, 50,Username),
                data.MakeInParam("@ViewBool",  SqlDbType.Int, 50,1),
                data.MakeInParam("@Id",  SqlDbType.Int, 50,id)
                };
            data.RunProc("UPDATE tb_Notification SET ViewBool = (@ViewBool) WHERE (Username = @Username) AND (Id = @Id)", prams);
        
        }

        public void InsertNotification(string Username, string Url,string Type)
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