using System;
using System.Data;

namespace EADPPROJ.App_Code
{
    public class Credit
    {
        public Credit()
        {

        }

        Database data = new Database();
        Record record = new Record();
        CreditDAO creditDAO = new CreditDAO();

        public int GetCreditAmount(string username)
        {
            DataSet ds = creditDAO.SelectCreditFromUser(username);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["Credit"]);

        }

        public int GetRewardAmount(int Id)
        {
            DataSet ds = creditDAO.SelectRewardFromQuestionById(Id);
            int creditValue = Convert.ToInt32(ds.Tables[0].Rows[0]["CreditReward"]);
            return creditValue;
        }

        public bool MinusCredit(string username, int creditNo)
        {
            if (username.Length == 7)///If Student
            {
                int current = GetCreditAmount(username);
                current -= creditNo;
                if (current >= 0)
                {
                    creditDAO.UpdateStudentCredit(username, current);
                    record.CreateNewRecord(record, username, "Minus", creditNo);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (username.Length == 9)
            {
                int current = GetCreditAmount(username);
                current -= creditNo;
                if (current >= 0)
                {
                    creditDAO.UpdateTeacherCredit(username, current);
                    record.CreateNewRecord(record, username, "Minus", creditNo);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int current = GetCreditAmount(username);
                current -= creditNo;
                if (current >= 0)
                {
                    creditDAO.UpdateAdminCredit(username, current);
                    record.CreateNewRecord(record, username, "Minus", creditNo);
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public void AddCredit(string username, int creditNo)
        {
            if (username.Length == 7)
            {
                int current = GetCreditAmount(username);
                int newcurrent = creditNo + current;
                creditDAO.UpdateStudentCredit(username, newcurrent);
                record.CreateNewRecord(record, username, "Add", creditNo);
            }
            else if (username.Length == 9)
            {
                int current = GetCreditAmount(username);
                int newcurrent = creditNo + current;
                creditDAO.UpdateTeacherCredit(username, newcurrent);
                record.CreateNewRecord(record, username, "Add", creditNo);
            }
            else
            {
                int current = GetCreditAmount(username);
                int newcurrent = creditNo + current;
                creditDAO.UpdateAdminCredit(username, newcurrent);
                record.CreateNewRecord(record, username, "Add", creditNo);
            }
        }

        public double CalculateTopUpPrice(int creditAmt)
        {
            double price;
            if (creditAmt < 1000)
            {
                price = creditAmt * 0.01;
                return price;
            }
            else if (creditAmt < 2000)
            {
                price = creditAmt * 0.01 - 1;
                return price;
            }
            else if (creditAmt < 5000)
            {
                price = creditAmt * 0.01 - 3;
                return price;
            }
            else
            {
                price = creditAmt * 0.01 - 5;
                return price;
            }
        }

        public int GetTransactionNumber(string username)
        {
            DataSet ds = creditDAO.SelectCreditRecordByUsername(username);
            int No = Convert.ToInt32(ds.Tables[0].Rows.Count);
            return No;
        }

        public DataSet GetEarnNumber(string username)
        {
            return creditDAO.SelectCreditRecordByUsernameWhereActIsAdd(username);
        }

        public DataSet GetMinusNumber(string username)
        {
            return creditDAO.SelectCreditRecordByUsernameWhereActIsMinus(username);
        }
    }
}