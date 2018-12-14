using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Entity;

namespace ScheduleManagment
{
    public partial class Logon : System.Web.UI.Page
    {

        student_advisorEntities dbcon = new student_advisorEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            dbcon.UserTables.Load();
            dbcon.StudentTables.Load();
            dbcon.AdvisorTables.Load();
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string user_name = Login1.UserName;
            string entered_password = Login1.Password;
            string actual_user_pass = "";  // had to instantiate the variable so i could put it in a try block

            // added this in to make sure it doesnt crash out if you enter a user that is not in the database
            try
            {
               actual_user_pass =
               (from val in dbcon.UserTables
                where val.UserName.Equals(user_name)
                select val.UserPassword).First();
            }
            catch(InvalidOperationException)
            {
                // nothing happens. just have to catch the exception
            }
            

            // Set login to User name and ID
            if (entered_password.Equals(actual_user_pass))
            {
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
                Session.Add("userName", user_name);

                var userRole =
                    (from val in dbcon.UserTables
                     where val.UserName.Equals(user_name)
                     select val.UserRole).First();

                if (userRole.Equals("Advisor"))
                {
                    var advisorID =
                        (from val in dbcon.AdvisorTables
                         where val.AdvisorUserName.Equals(user_name)
                         select val.AdvisorID).First();

                    Session.Add("advisorID", advisorID);
                }

                if (userRole.Equals("Student"))
                {
                    var studentID =
                        (from val in dbcon.StudentTables
                         where val.StudentUserName.Equals(user_name)
                         select val.StudentID).First();

                    Session.Add("studentID", studentID);
                }

            }

        }
    }
}