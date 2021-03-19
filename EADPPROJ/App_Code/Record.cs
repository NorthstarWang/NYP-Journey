using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Record”的 XML 注释
    public class Record
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Record”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Record.Record()”的 XML 注释
        public Record()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Record.Record()”的 XML 注释
        {

        }

        Database data = new Database();
        RecordDAO recordDAO = new RecordDAO();
        private int id = 0;
        private DateTime occurTime = Convert.ToDateTime(DateTime.Now.ToString());

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Record.Id”的 XML 注释
        public int Id
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Record.Id”的 XML 注释
        {
            get { return id; }
            set { id = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Record.OccurTime”的 XML 注释
        public DateTime OccurTime
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Record.OccurTime”的 XML 注释
        {
            get { return occurTime; }
            set { occurTime = value; }
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Record.GetCurrentMaxRecordId(Record)”的 XML 注释
        public int GetCurrentMaxRecordId(Record record)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Record.GetCurrentMaxRecordId(Record)”的 XML 注释
        {
            DataSet ds = recordDAO.SelectCreditRecordByIdDESC(Id);
            int currentMaxId;
            try {
                currentMaxId = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]); 
            }
            catch (Exception)
            {
                currentMaxId = 0;
            }
           
           return currentMaxId;
            
        }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Record.GenerateNewRecordId(Record)”的 XML 注释
        public int GenerateNewRecordId(Record record)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Record.GenerateNewRecordId(Record)”的 XML 注释
        {
            int maxId = GetCurrentMaxRecordId(record);
            maxId += 1;
            return maxId;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Record.CreateNewRecord(Record, string, string, int)”的 XML 注释
        public void CreateNewRecord(Record record,string username,string act,int creditValue)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Record.CreateNewRecord(Record, string, string, int)”的 XML 注释
        {
            recordDAO.InsertCreditRecord(GenerateNewRecordId(record),username,act,creditValue,OccurTime);
        }
    }
}