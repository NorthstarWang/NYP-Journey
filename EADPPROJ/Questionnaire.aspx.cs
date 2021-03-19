using EADPPROJ.App_Code;
using System;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Questionnaire”的 XML 注释
    public partial class Questionnaire : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Questionnaire”的 XML 注释
    {
        QuestionnaireClass questionnaireClass = new QuestionnaireClass();
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Questionnaire.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Questionnaire.Page_Load(object, EventArgs)”的 XML 注释
        {

        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“Questionnaire.Button1_Click(object, EventArgs)”的 XML 注释
        protected void Button1_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“Questionnaire.Button1_Click(object, EventArgs)”的 XML 注释
        {
            questionnaireClass.InsertQuestionnaire(adminno.Text, school.Text, year.Text, qlty.Text, rcmd.Text, nav.Text, reas.Text, email.Text);

        }
    }
}