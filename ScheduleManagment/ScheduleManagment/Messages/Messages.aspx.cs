using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace ScheduleManagment
{
    public partial class Email : System.Web.UI.Page
    {
        // load both databases
        MessageDatabaseEntities messageDB = new MessageDatabaseEntities();
        student_advisorEntities userDB = new student_advisorEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            messageDB.MessageTables.Load();
            userDB.UserTables.Load();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // have to put in the using block so you can use the variables for the database tables
            // this block of code adds a new message to the database, meaning it "sends" it to the specified user
            using (messageDB)
            {
                MessageTable message = new MessageTable();
                message.To = TextBox1.Text;
                message.From = Session["userName"].ToString();
                message.Body = TextArea1.InnerText;

                messageDB.MessageTables.Add(message);
                messageDB.SaveChanges();
            }

            // resets the fields to blank and binds the new data to the gridview, thus refreshing the page
            TextArea1.InnerText = "";
            TextBox1.Text = "";
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // this deletes the selected message from the database and the grid
            using (messageDB)
            {
                if (GridView1.SelectedDataKey.Value != null)
                {
                    // need to use the message ID value to ensure the correct message is deleted from the database.
                    // if you dont use the using() block then you cant search for the value(the unique message id) of the selected data key
                    int item = Convert.ToInt32(GridView1.SelectedDataKey.Value.ToString());

                    MessageTable message = (from x in messageDB.MessageTables
                                            where x.Id == item
                                            select x).First();

                    messageDB.MessageTables.Remove(message);
                    messageDB.SaveChanges();
                }
            }
            GridView1.DataBind();
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // this grabs the From field of the sent message and puts it into the textbox for the To field of the outgoing message
            TextBox1.Text = GridView1.SelectedDataKey[1].ToString();
            // this focuses the cursor on the outgoing message body text area
            TextArea1.Focus();
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            // was going to use this to send the body of the message to a textarea but i couldnt figure out how to do it.
        }
    }
}