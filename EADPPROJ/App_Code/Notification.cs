using System.Data;

namespace EADPPROJ.App_Code
{
    public class Notification
    {
        Database data = new Database();
        NotificationDAO notificationDAO = new NotificationDAO();

        public Notification()
        {

        }

        public int GetNotificationNewTotalNo(Notification notification, string Username)
        {
            DataSet ds = notificationDAO.SelectNotificationByUsernameAndViewBool(Username);
            return ds.Tables[0].Rows.Count;
        }

        public void ChangeViewBool(Notification notification, string Username, int id)
        {
            notificationDAO.UpdateNotificationViewBoolByUsernameAndId(Username, id);
        }

        public void QuestionCreateNotification(Notification notification, string Username, string Url, string Type = "Your question has been created")
        {
            notificationDAO.InsertNotification(Username, Url, Type);
        }

        public void invitationCodeNotification(Notification notification, string Username, string Url = "index.aspx", string Type = "You have used an invitation code")
        {
            notificationDAO.InsertNotification(Username, Url, Type);
        }

        public void invitationCodeUseNotification(Notification notification, string Username, string Url = "index.aspx", string Type = "Your invitation code has been used.")
        {
            notificationDAO.InsertNotification(Username, Url, Type);
        }

        public void QuestionRejectNotification(Notification notification, string Username, string Url = "./questionList.aspx", string Type = "Your question has been rejected")
        {
            notificationDAO.InsertNotification(Username, Url, Type);
        }

        public void QuestionApproveNotification(Notification notification, string Username, string url, string Type = "Your question has been approved")
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

        public void AnswerPostNotificationToAnswer(Notification notification, string Username, string url, string Type = "You have posted a answer")
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

        public void AnswerPostNotificationToQuestion(Notification notification, string Username, string url, string Type = "Your question have received an answer")
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

        public void CommentPostNotificationToPoster(Notification notification, string Username, string url, string Type = "You have commented an answer")
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

        public void CommentPostNotificationToReceiver(Notification notification, string Username, string url, string Type = "Your answer have received a comment")
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

        public void ReplyPostNotificationToPoster(Notification notification, string Username, string url, string Type = "You have replied a comment")
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

        public void ReplyPostNotificationToReceiver(Notification notification, string Username, string url, string Type = "Your comment have a reply")
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

        public void SolutionSelectNotificationToQuestion(Notification notification, string Username, string url, string Type = "You have selected a best solution for your question")
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

        public void SolutionSelectNotificationToAnswer(Notification notification, string Username, string url, string Type = "Your answer has been selected as the best solution")
        {
            notificationDAO.InsertNotification(Username, url, Type);
        }

        public void RegistrationWelcome(Notification notification, string Username, string Url = "index.aspx", string Type = "Welcome to NYP Journey")
        {
            notificationDAO.InsertNotification(Username, Url, Type);
        }
    }
}