using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
    public class Record
    {
        public Record()
        {

        }

        Database data = new Database();
        RecordDAO recordDAO = new RecordDAO();
        private int id = 0;
        private DateTime occurTime = Convert.ToDateTime(DateTime.Now.ToString());

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime OccurTime
        {
            get { return occurTime; }
            set { occurTime = value; }
        }
        public int GetCurrentMaxRecordId(Record record)
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
        public int GenerateNewRecordId(Record record)
        {
            int maxId = GetCurrentMaxRecordId(record);
            maxId += 1;
            return maxId;
        }

        public void CreateNewRecord(Record record,string username,string act,int creditValue)
        {
            recordDAO.InsertCreditRecord(GenerateNewRecordId(record),username,act,creditValue,OccurTime);
        }
    }
}