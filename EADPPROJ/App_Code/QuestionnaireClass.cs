using System.Data;
using System.Data.SqlClient;

namespace EADPPROJ.App_Code
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionnaireClass”的 XML 注释
    public class QuestionnaireClass
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionnaireClass”的 XML 注释
    {
        Database data = new Database();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“QuestionnaireClass.InsertQuestionnaire(string, string, string, string, string, string, string, string)”的 XML 注释
        public void InsertQuestionnaire(string adminno, string school, string year, string qlty, string rcmd, string nav, string reas, string email)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“QuestionnaireClass.InsertQuestionnaire(string, string, string, string, string, string, string, string)”的 XML 注释
        {
#pragma warning disable CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            DataSet ds = null;
#pragma warning restore CS0219 // 变量“ds”已被赋值，但从未使用过它的值
            SqlParameter[] prams = {
                data.MakeInParam("@adminno",  SqlDbType.VarChar,50,adminno),
                data.MakeInParam("@school",  SqlDbType.VarChar,50,school),
                data.MakeInParam("@year",  SqlDbType.VarChar,50,year),
                data.MakeInParam("@qlty",  SqlDbType.VarChar,50,qlty),
                data.MakeInParam("@rcmd",  SqlDbType.VarChar,50,rcmd),
                data.MakeInParam("@nav",  SqlDbType.VarChar,50,nav),
                data.MakeInParam("@reas",  SqlDbType.VarChar,50,reas),
                data.MakeInParam("@email",  SqlDbType.VarChar,50,email),
                };
            data.RunProc("INSERT INTO tb_Questionnaire (adminno,school,year,qlty,rcmd,nav,reas,email) VALUES(@adminno,@school,@year,@qlty,@rcmd,@nav,@reas,@email)", prams);

        }
    }
}