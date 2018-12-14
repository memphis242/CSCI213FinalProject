using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ScheduleManagment
{
    public partial class Scheduler : System.Web.UI.Page
    {
        [Flags]
        private enum SqlParam
        {
            NONE = 0X00,
            ADVISORID = 0x01,
            STUDENTNAME = 0x02
        }

        private student_advisorEntities userDB = new student_advisorEntities();
        DataTable week = new DataTable();
        private const string defaultSqlCommand =
            "SELECT * FROM [AppointmentTable]" +
            "WHERE ([AdvisorID] = @AdvisorID)" +
            "ORDER BY [AppointmentDate], [AppointmentTime] ASC";

        /**Returns the connection string associated with the name
         * As I understand, every connection string is associated to some database object along with the database provider
         * This can be seen in the Web.config file under the <connectionStrings> tag
        */
        private string GetConnectionString()
        {
            //return AppointmentsGridView.DataSource.ToString();
            return ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        }




        protected void Page_Load(object sender, EventArgs e)
        {

            //Load relevant database tables
            userDB.AppointmentTables.Load();
            userDB.StudentTables.Load();

            //Clear any selections from the drop-down list of students so initial gridview shows all appointments
            LoadStudentDropDownList();
            StudentsDropDownList.ClearSelection();

            //DebugTextBox.Text = GetConnectionString();

            //Initialize appointments table
            string initialSqlCommand = defaultSqlCommand;
            BindAppointments(initialSqlCommand, SqlParam.ADVISORID, Session["advisorID"].ToString());

            //Load weekly calendar
            LoadWeeklyCalendar();
        }



        private void LoadStudentDropDownList()
        {
            DataTable students = new DataTable();

            using( SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    SqlDataAdapter dropDownListAdapter = new SqlDataAdapter("SELECT [StudentName], [StudentID] FROM [AppointmentTable] WHERE ([AdvisorID] = @AdvisorID)", sqlConnection);
                    dropDownListAdapter.Fill(students);

                    StudentsDropDownList.DataSource = students;
                    StudentsDropDownList.DataTextField = "StudentName";
                    StudentsDropDownList.DataValueField = "StudentID";

                    StudentsDropDownList.DataBind();

                } catch( SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }

            //Add first item in drop down list to be a "<Select Subject>" and an option to show all students again
            StudentsDropDownList.Items.Add(new ListItem("<Select Subject>", "-1"));
            StudentsDropDownList.Items.Add(new ListItem("All", "0"));
        }



        private void LoadWeeklyCalendar()
        {
            DataColumn column;
            DataRow row;

            column = new DataColumn("Hours", System.Type.GetType("System.String"));
            column.ReadOnly = true;
            column.Unique = true;
            week.Columns.Add(column);

            column = new DataColumn("Monday", System.Type.GetType("System.String"));
            column.ReadOnly = true;
            week.Columns.Add(column);

            column = new DataColumn("Tuesday", System.Type.GetType("System.String"));
            column.ReadOnly = true;
            week.Columns.Add(column);

            column = new DataColumn("Wednesday", System.Type.GetType("System.String"));
            column.ReadOnly = true;
            week.Columns.Add(column);

            column = new DataColumn("Thursday", System.Type.GetType("System.String"));
            column.ReadOnly = true;
            week.Columns.Add(column);

            column = new DataColumn("Friday", System.Type.GetType("System.String"));
            column.ReadOnly = true;
            week.Columns.Add(column);

            DataColumn[] PrimaryKeyColumn = new DataColumn[1];
            PrimaryKeyColumn[0] = week.Columns["Hours"];
            week.PrimaryKey = PrimaryKeyColumn;

            //Fill up first column for hours in the workday
            row = week.NewRow();
            DateTime date = DateTime.Today;
            string dayOfWeek = date.DayOfWeek.ToString();

            switch( dayOfWeek)
            {
                case "Monday":
                    row["Hours"] = "";
                    row["Monday"] = "Monday " + date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
                    row["Tuesday"] = "Tuesday " + date.AddDays(1).Month.ToString() + "/" + date.AddDays(1).Day.ToString() + "/" + date.AddDays(1).Year.ToString();
                    row["Wednesday"] = "Wednesday" + date.AddDays(2).Month.ToString() + "/" + date.AddDays(2).Day.ToString() + "/" + date.AddDays(2).Year.ToString();
                    row["Thursday"] = "Thursday" + date.AddDays(3).Month.ToString() + "/" + date.AddDays(3).Day.ToString() + "/" + date.AddDays(3).Year.ToString();
                    row["Friday"] = "Friday" + date.AddDays(4).Month.ToString() + "/" + date.AddDays(4).Day.ToString() + "/" + date.AddDays(4).Year.ToString();
                    break;

                case "Tuesday":
                    row["Hours"] = "";
                    row["Monday"] = "Monday " + date.AddDays(-1).Month.ToString() + "/" + date.AddDays(-1).Day.ToString() + "/" + date.AddDays(-1).Year.ToString();
                    row["Tuesday"] = "Tuesday " + date.AddDays(0).Month.ToString() + "/" + date.AddDays(0).Day.ToString() + "/" + date.AddDays(0).Year.ToString();
                    row["Wednesday"] = "Wednesday" + date.AddDays(1).Month.ToString() + "/" + date.AddDays(1).Day.ToString() + "/" + date.AddDays(1).Year.ToString();
                    row["Thursday"] = "Thursday" + date.AddDays(2).Month.ToString() + "/" + date.AddDays(2).Day.ToString() + "/" + date.AddDays(2).Year.ToString();
                    row["Friday"] = "Friday" + date.AddDays(3).Month.ToString() + "/" + date.AddDays(3).Day.ToString() + "/" + date.AddDays(3).Year.ToString();
                    break;

                case "Wednesday":
                    row["Hours"] = "";
                    row["Monday"] = "Monday " + date.AddDays(-2).Month.ToString() + "/" + date.AddDays(-2).Day.ToString() + "/" + date.AddDays(-2).Year.ToString();
                    row["Tuesday"] = "Tuesday " + date.AddDays(1).Month.ToString() + "/" + date.AddDays(1).Day.ToString() + "/" + date.AddDays(1).Year.ToString();
                    row["Wednesday"] = "Wednesday" + date.AddDays(0).Month.ToString() + "/" + date.AddDays(0).Day.ToString() + "/" + date.AddDays(0).Year.ToString();
                    row["Thursday"] = "Thursday" + date.AddDays(1).Month.ToString() + "/" + date.AddDays(1).Day.ToString() + "/" + date.AddDays(1).Year.ToString();
                    row["Friday"] = "Friday" + date.AddDays(2).Month.ToString() + "/" + date.AddDays(2).Day.ToString() + "/" + date.AddDays(2).Year.ToString();
                    break;

                case "Thursday":
                    row["Hours"] = "";
                    row["Monday"] = "Monday " + date.AddDays(-3).Month.ToString() + "/" + date.AddDays(-3).Day.ToString() + "/" + date.AddDays(-3).Year.ToString();
                    row["Tuesday"] = "Tuesday " + date.AddDays(-2).Month.ToString() + "/" + date.AddDays(-2).Day.ToString() + "/" + date.AddDays(-2).Year.ToString();
                    row["Wednesday"] = "Wednesday" + date.AddDays(-1).Month.ToString() + "/" + date.AddDays(-1).Day.ToString() + "/" + date.AddDays(-1).Year.ToString();
                    row["Thursday"] = "Thursday" + date.AddDays(0).Month.ToString() + "/" + date.AddDays(0).Day.ToString() + "/" + date.AddDays(0).Year.ToString();
                    row["Friday"] = "Friday" + date.AddDays(1).Month.ToString() + "/" + date.AddDays(1).Day.ToString() + "/" + date.AddDays(1).Year.ToString();
                    break;

                case "Friday":
                    row["Hours"] = "";
                    row["Monday"] = "Monday " + date.AddDays(-4).Month.ToString() + "/" + date.AddDays(-4).Day.ToString() + "/" + date.AddDays(-4).Year.ToString();
                    row["Tuesday"] = "Tuesday " + date.AddDays(-3).Month.ToString() + "/" + date.AddDays(-3).Day.ToString() + "/" + date.AddDays(-3).Year.ToString();
                    row["Wednesday"] = "Wednesday" + date.AddDays(-2).Month.ToString() + "/" + date.AddDays(-2).Day.ToString() + "/" + date.AddDays(-2).Year.ToString();
                    row["Thursday"] = "Thursday" + date.AddDays(-1).Month.ToString() + "/" + date.AddDays(-1).Day.ToString() + "/" + date.AddDays(-1).Year.ToString();
                    row["Friday"] = "Friday" + date.AddDays(0).Month.ToString() + "/" + date.AddDays(0).Day.ToString() + "/" + date.AddDays(0).Year.ToString();
                    break;
            }

            week.Rows.Add(row);

            //Fill up hours column
            for( int i=8; i<16; i++ )
            {
                row = week.NewRow();
                row["Hours"] = i + ":00";
                week.Rows.Add(row);
            }

            week.AcceptChanges();
            LoadAppointmentsToWeek();
        }



        private void LoadAppointmentsToWeek()
        {
            var currentAppointments = userDB.AppointmentTables.AsEnumerable();
            
            foreach( var app in currentAppointments)
            {
                string studentName =
                        (from student in userDB.StudentTables
                         where student.StudentID == app.StudentID
                         select student).First().ToString();

                switch ( app.AppointmentDate.DayOfWeek )
                {
                    case DayOfWeek.Monday:
                        switch( app.ApointmentTime.Hours )
                        {
                            case 8:
                                week.Rows[1][1] = studentName;
                                break;

                            case 9:
                                week.Rows[2][1] = studentName;
                                break;

                            case 10:
                                week.Rows[3][1] = studentName;
                                break;

                            case 11:
                                week.Rows[4][1] = studentName;
                                break;

                            case 12:
                                week.Rows[5][1] = studentName;
                                break;

                            case 13:
                                week.Rows[6][1] = studentName;
                                break;

                            case 14:
                                week.Rows[7][1] = studentName;
                                break;

                            case 15:
                                week.Rows[8][1] = studentName;
                                break;

                            case 16:
                                week.Rows[9][1] = studentName;
                                break;
                        }
                        break;

                    case DayOfWeek.Tuesday:
                        switch (app.ApointmentTime.Hours)
                        {
                            case 8:
                                week.Rows[1][2] = studentName;
                                break;

                            case 9:
                                week.Rows[2][2] = studentName;
                                break;

                            case 10:
                                week.Rows[3][2] = studentName;
                                break;

                            case 11:
                                week.Rows[4][2] = studentName;
                                break;

                            case 12:
                                week.Rows[5][2] = studentName;
                                break;

                            case 13:
                                week.Rows[6][2] = studentName;
                                break;

                            case 14:
                                week.Rows[7][2] = studentName;
                                break;

                            case 15:
                                week.Rows[8][2] = studentName;
                                break;

                            case 16:
                                week.Rows[9][2] = studentName;
                                break;
                        }
                        break;

                    case DayOfWeek.Wednesday:
                        switch (app.ApointmentTime.Hours)
                        {
                            case 8:
                                week.Rows[1][3] = studentName;
                                break;

                            case 9:
                                week.Rows[2][3] = studentName;
                                break;

                            case 10:
                                week.Rows[3][3] = studentName;
                                break;

                            case 11:
                                week.Rows[4][3] = studentName;
                                break;

                            case 12:
                                week.Rows[5][3] = studentName;
                                break;

                            case 13:
                                week.Rows[6][3] = studentName;
                                break;

                            case 14:
                                week.Rows[7][3] = studentName;
                                break;

                            case 15:
                                week.Rows[8][3] = studentName;
                                break;

                            case 16:
                                week.Rows[9][3] = studentName;
                                break;
                        }
                        break;

                    case DayOfWeek.Thursday:
                        switch (app.ApointmentTime.Hours)
                        {
                            case 8:
                                week.Rows[1][4] = studentName;
                                break;

                            case 9:
                                week.Rows[2][4] = studentName;
                                break;

                            case 10:
                                week.Rows[3][4] = studentName;
                                break;

                            case 11:
                                week.Rows[4][4] = studentName;
                                break;

                            case 12:
                                week.Rows[5][4] = studentName;
                                break;

                            case 13:
                                week.Rows[6][4] = studentName;
                                break;

                            case 14:
                                week.Rows[7][4] = studentName;
                                break;

                            case 15:
                                week.Rows[8][4] = studentName;
                                break;

                            case 16:
                                week.Rows[9][4] = studentName;
                                break;
                        }
                        break;

                    case DayOfWeek.Friday:
                        switch (app.ApointmentTime.Hours)
                        {
                            case 8:
                                week.Rows[1][5] = studentName;
                                break;

                            case 9:
                                week.Rows[2][5] = studentName;
                                break;

                            case 10:
                                week.Rows[3][5] = studentName;
                                break;

                            case 11:
                                week.Rows[4][5] = studentName;
                                break;

                            case 12:
                                week.Rows[5][5] = studentName;
                                break;

                            case 13:
                                week.Rows[6][5] = studentName;
                                break;

                            case 14:
                                week.Rows[7][5] = studentName;
                                break;

                            case 15:
                                week.Rows[8][5] = studentName;
                                break;

                            case 16:
                                week.Rows[9][5] = studentName;
                                break;
                        }
                        break;
                }
            }

            week.AcceptChanges();
            BindWeeklySchedule();
            CleanWeeklyTable();
        }


        //LoadAppointmentsToWeek() syncs the week table with the AppointmentsTable in the database. Now for the other way around concerning extras in week
        private void CleanWeeklyTable()
        {
            //for( int i = 1; i<=9; i++)
            //{
            //    for( int j = 1; j<=5; j++)
            //    {
            //        string entry = week.Rows[i][j].ToString();
            //        if ( entry != "" )
            //        {
            //            //TODO
            //            //Look at every entry that is nonempty and check to see if the appointment date and time associated with the student name in the entry matches the corresponding entry in the AppointmentTables table
            //            var apps =
            //                from app in userDB.AppointmentTables
            //                where week.Rows[i][0] == ""
            //                select app;

            //            //if(apps == null)
            //            //{
            //            //    week.Rows[i][j] = "";
            //            //}
            //        }
            //    }
            //}
        }



        /**When a student name is selected from the dropdown list, only the appointments with that student's name are shown in the grid view
         */
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string studentName = StudentsDropDownList.SelectedValue;

            if( studentName.Equals("All"))
            {
                BindAppointments();
            }
            else
            {
                string sqlCommand =
                "SELECT * FROM [AppointmentTable]" +
                "WHERE ([StudentName] = @StudentName) AND ([AdvisorID] = @AdvisorID);";
                BindAppointments(sqlCommand, SqlParam.STUDENTNAME, studentName);
            }            
        }



        /**
         * This method will now allow me to vary what the gridview will show depending on some SQL command
         * I put an optional parameter SqlParam parameters so that I can specify what type of parameter might be in the SQL command string
         * I also put an optional indefinite parameters params string[] parameterValues so that I can send in values for parameters
         * The order of those parameter values should match the switch-case statements below
         */
        private void BindAppointments(string sqlCommandString = defaultSqlCommand, SqlParam parameters = SqlParam.NONE, params string[] parameterValues)
        {
            DataTable appointmentTable = new DataTable("Appointments");
            using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    //sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConnection);
                    SqlDataAdapter gridViewAdapter = new SqlDataAdapter(sqlCommandString, sqlCommand.Connection);
                    DataSet dataSet = new DataSet();
                    if ( sqlCommand.Parameters.Count > 0)
                    {
                        switch( parameters)
                        {
                            case SqlParam.ADVISORID:
                                sqlCommand.Parameters.Add(new SqlParameter("@AdvisorID", parameterValues[0]));
                                break;

                            case SqlParam.STUDENTNAME:
                                sqlCommand.Parameters.Add(new SqlParameter("@StudentName", parameterValues[0]));
                                break;
                        }
                    }


                    gridViewAdapter.SelectCommand = sqlCommand;
                    sqlCommand.Connection.Open();
                    gridViewAdapter.Fill(dataSet);


                    if ( appointmentTable.Rows.Count > 0)
                    {
                        AppointmentsGridView.DataSource = appointmentTable;
                        AppointmentsGridView.DataBind();

                        DebugTextBox.Text = "Success! " + appointmentTable.Rows.Count.ToString();
                        //Console.WriteLine();
                        //Console.Write("Number of Rows in Table: {0}", appointmentTable.Rows.Count);
                    }
                    else
                    {
                        DebugTextBox.Text = "Failed: " + appointmentTable.Rows.Count.ToString();
                        //Console.WriteLine();
                        //Console.Write("Number of Rows in Table: {0}", appointmentTable.Rows.Count);
                    }


                } catch( SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            LoadAppointmentsToWeek();
        }


        private void BindWeeklySchedule()
        {
            WeeklyScheduleGridView.DataSource = week;
            WeeklyScheduleGridView.DataBind();
        }


        protected void CancelMeetingButton_Click(object sender, EventArgs e)
        {
            using (userDB)
            {
                if (AppointmentsGridView.SelectedDataKey.Value != null)
                {
                    int appointmentID = Convert.ToInt32(AppointmentsGridView.SelectedDataKey.Value.ToString());
                    AppointmentTable appointment =
                        (from app in userDB.AppointmentTables
                         where app.AppointmentID == appointmentID
                         select app).FirstOrDefault();
                    userDB.AppointmentTables.Remove(appointment);

                    userDB.SaveChanges();
                }
            }

            //Reload all relevant controls
            BindAppointments();
            LoadStudentDropDownList();
        }

        protected void WeeklyScheduleGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ScheduleNewButton_Click(object sender, EventArgs e)
        {
            using (userDB)
            {
                AppointmentTable appointment = new AppointmentTable();
                appointment.AdvisorID = Convert.ToInt32(Session["advisorID"]);
                appointment.ApointmentTime = TimeSpan.Parse(TextBox5.Text);
                appointment.AppointmentDate = DateTime.Parse(DateTime.Today.Month + "/" + TextBox4.Text);
                appointment.AppointmentReason = TextBox8.Text;
                appointment.StudentID = Convert.ToInt32(TextBox7.Text);

                if( (from app in userDB.AppointmentTables where (app.AppointmentDate.Equals(appointment.AppointmentDate)) && (app.ApointmentTime.Equals(appointment.ApointmentTime)) select app).First() != null )
                {

                    throw new Exception("There is already an appointment with that date and time!");

                }

                userDB.AppointmentTables.Add(appointment);
                userDB.SaveChanges();
            }

            // resets the fields to blank and binds the new data to the gridview, thus refreshing the page
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";

            newAppStatus.Text = "Success!";

            BindAppointments();
            LoadStudentDropDownList();
        }

        protected void ChangeAvailabilityButton_Click(object sender, EventArgs e)
        {
            using (userDB)
            {
                AppointmentTable appointment = new AppointmentTable();
                appointment.AdvisorID = Convert.ToInt32(Session["advisorID"]);
                appointment.ApointmentTime = TimeSpan.Parse(TextBox1.Text);
                appointment.AppointmentDate = DateTime.Parse(DateTime.Today.Month + "/" + TextBox2.Text);
                appointment.AppointmentReason = "UNAVAILABLE";
                appointment.StudentID = Convert.ToInt32("000000");

                if ((from app in userDB.AppointmentTables where (app.AppointmentDate.Equals(appointment.AppointmentDate)) && (app.ApointmentTime.Equals(appointment.ApointmentTime)) select app).First() != null)
                {

                    throw new Exception("There is already an appointment with that date and time!");

                }

                userDB.AppointmentTables.Add(appointment);
                userDB.SaveChanges();
            }

            // resets the fields to blank and binds the new data to the gridview, thus refreshing the page
            TextBox1.Text = "";
            TextBox2.Text = "";

            unavailableStatus.Text = "Success!";

            BindAppointments();
            LoadStudentDropDownList();
        }

        protected void RescheduleButton_Click(object sender, EventArgs e)
        {
            using (userDB)
            {
                AppointmentTable selectedAppointment =
                    (from app in userDB.AppointmentTables
                    where app.AppointmentID == Convert.ToInt32(AppointmentsGridView.SelectedDataKey.Value)
                    select app).First();

                selectedAppointment.ApointmentTime = TimeSpan.Parse(TextBox10.Text);
                selectedAppointment.AppointmentDate = DateTime.Parse(DateTime.Today.Month + "/" + TextBox9.Text);

                string sqlCommand =
                    "UPDATE [AppointmentTables]" +
                    "SET [ApointmentTime] = '" + selectedAppointment.ApointmentTime.ToString() + "', [AppointmentDate = '" + selectedAppointment.AppointmentDate.ToString() + "'" +
                    "WHERE [AppointmentID] = " + selectedAppointment.AppointmentID + ";";

                BindAppointments(sqlCommand);
            }
        }
    }
}