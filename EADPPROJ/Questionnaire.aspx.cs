using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADPPROJ.App_Code;

namespace EADPPROJ
{
    public partial class Questionnaire : System.Web.UI.Page
    {
        QuestionnaireClass questionnaireClass = new QuestionnaireClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            questionnaireClass.InsertQuestionnaire(adminno.Text, school.Text, year.Text, qlty.Text, rcmd.Text, nav.Text, reas.Text, email.Text);

        }
    }
}