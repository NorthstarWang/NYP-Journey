using System.Data;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification”的 XML 注释
    public class Notification
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification”的 XML 注释
    {
        Database data = new Database();
        NotificationDAO notificationDAO = new NotificationDAO();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.Notification()”的 XML 注释
        public Notification()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.Notification()”的 XML 注释
        {

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.GetNotificationNewTotalNo(Notification, string)”的 XML 注释
        public int GetNotificationNewTotalNo(Notification notification, string Username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.GetNotificationNewTotalNo(Notification, string)”的 XML 注释
        {
            DataSet ds = notificationDAO.SelectNotificationByUsernameAndViewBool(Username);
            return ds.Tables[0].Rows.Count;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.ChangeViewBool(Notification, string, int)”的 XML 注释
        public void ChangeViewBool(Notification notification, string Username, int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.ChangeViewBool(Notification, string, int)”的 XML 注释
        {
            notificationDAO.UpdateNotificationViewBoolByUsernameAndId(Username, id);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.QuestionCreateNotification(Notification, string, string, string)”的 XML 注释
        public void QuestionCreateNotification(Notification notification, string Username, string Url, string Type = "Your question has been created")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.QuestionCreateNotification(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, Url, Type);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.invitationCodeNotification(Notification, string, string, string)”的 XML 注释
        public void invitationCodeNotification(Notification notification, string Username, string Url = "index.aspx", string Type = "You have used an invitation code")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.invitationCodeNotification(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, Url, Type);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.invitationCodeUseNotification(Notification, string, string, string)”的 XML 注释
        public void invitationCodeUseNotification(Notification notification, string Username, string Url = "index.aspx", string Type = "Your invitation code has been used.")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.invitationCodeUseNotification(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, Url, Type);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.QuestionRejectNotification(Notification, string, string, string)”的 XML 注释
        public void QuestionRejectNotification(Notification notification, string Username, string Url = "./questionList.aspx", string Type = "Your question has been rejected")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.QuestionRejectNotification(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, Url, Type);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.QuestionApproveNotification(Notification, string, string, string)”的 XML 注释
        public void QuestionApproveNotification(Notification notification, string Username, string url, string Type = "Your question has been approved")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.QuestionApproveNotification(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.AnswerPostNotificationToAnswer(Notification, string, string, string)”的 XML 注释
        public void AnswerPostNotificationToAnswer(Notification notification, string Username, string url, string Type = "You have posted a answer")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.AnswerPostNotificationToAnswer(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.AnswerPostNotificationToQuestion(Notification, string, string, string)”的 XML 注释
        public void AnswerPostNotificationToQuestion(Notification notification, string Username, string url, string Type = "Your question have received an answer")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.AnswerPostNotificationToQuestion(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.CommentPostNotificationToPoster(Notification, string, string, string)”的 XML 注释
        public void CommentPostNotificationToPoster(Notification notification, string Username, string url, string Type = "You have commented an answer")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.CommentPostNotificationToPoster(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.CommentPostNotificationToReceiver(Notification, string, string, string)”的 XML 注释
        public void CommentPostNotificationToReceiver(Notification notification, string Username, string url, string Type = "Your answer have received a comment")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.CommentPostNotificationToReceiver(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.ReplyPostNotificationToPoster(Notification, string, string, string)”的 XML 注释
        public void ReplyPostNotificationToPoster(Notification notification, string Username, string url, string Type = "You have replied a comment")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.ReplyPostNotificationToPoster(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.ReplyPostNotificationToReceiver(Notification, string, string, string)”的 XML 注释
        public void ReplyPostNotificationToReceiver(Notification notification, string Username, string url, string Type = "Your comment have a reply")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.ReplyPostNotificationToReceiver(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.SolutionSelectNotificationToQuestion(Notification, string, string, string)”的 XML 注释
        public void SolutionSelectNotificationToQuestion(Notification notification, string Username, string url, string Type = "You have selected a best solution for your question")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.SolutionSelectNotificationToQuestion(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.SolutionSelectNotificationToAnswer(Notification, string, string, string)”的 XML 注释
        public void SolutionSelectNotificationToAnswer(Notification notification, string Username, string url, string Type = "Your answer has been selected as the best solution")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.SolutionSelectNotificationToAnswer(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Notification.RegistrationWelcome(Notification, string, string, string)”的 XML 注释
        public void RegistrationWelcome(Notification notification, string Username, string Url = "index.aspx", string Type = "Welcome to NYP Journey")
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Notification.RegistrationWelcome(Notification, string, string, string)”的 XML 注释
        {
            notificationDAO.InsertNotification(Username, Url, Type);
        }
    }
}