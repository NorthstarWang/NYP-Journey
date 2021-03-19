using System;
using System.Data;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Credit”的 XML 注释
    public class Credit
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Credit”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Credit.Credit()”的 XML 注释
        public Credit()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Credit.Credit()”的 XML 注释
        {

        }

        Database data = new Database();
        Record record = new Record();
        CreditDAO creditDAO = new CreditDAO();

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Credit.GetCreditAmount(string)”的 XML 注释
        public int GetCreditAmount(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Credit.GetCreditAmount(string)”的 XML 注释
        {
            DataSet ds = creditDAO.SelectCreditFromUser(username);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["Credit"]);

        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Credit.GetRewardAmount(int)”的 XML 注释
        public int GetRewardAmount(int Id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Credit.GetRewardAmount(int)”的 XML 注释
        {
            DataSet ds = creditDAO.SelectRewardFromQuestionById(Id);
            int creditValue = Convert.ToInt32(ds.Tables[0].Rows[0]["CreditReward"]);
            return creditValue;
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Credit.MinusCredit(string, int)”的 XML 注释
        public bool MinusCredit(string username, int creditNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Credit.MinusCredit(string, int)”的 XML 注释
        {
#pragma warning disable CS1587 // XML 注释没有放在有效语言元素上
            if (username.Length == 7)///If Student
            {
#pragma warning restore CS1587 // XML 注释没有放在有效语言元素上
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
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Credit.AddCredit(string, int)”的 XML 注释
        public void AddCredit(string username, int creditNo)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Credit.AddCredit(string, int)”的 XML 注释
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

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Credit.CalculateTopUpPrice(int)”的 XML 注释
        public double CalculateTopUpPrice(int creditAmt)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Credit.CalculateTopUpPrice(int)”的 XML 注释
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


#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Credit.GetTransactionNumber(string)”的 XML 注释
        public int GetTransactionNumber(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Credit.GetTransactionNumber(string)”的 XML 注释
        {
            DataSet ds = creditDAO.SelectCreditRecordByUsername(username);
            int No = Convert.ToInt32(ds.Tables[0].Rows.Count);
            return No;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Credit.GetEarnNumber(string)”的 XML 注释
        public DataSet GetEarnNumber(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Credit.GetEarnNumber(string)”的 XML 注释
        {
            return creditDAO.SelectCreditRecordByUsernameWhereActIsAdd(username);
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Credit.GetMinusNumber(string)”的 XML 注释
        public DataSet GetMinusNumber(string username)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Credit.GetMinusNumber(string)”的 XML 注释
        {
            return creditDAO.SelectCreditRecordByUsernameWhereActIsMinus(username);
        }
    }
}