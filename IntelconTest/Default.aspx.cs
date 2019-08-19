using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntelconTest;

namespace IntelconTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            literal.Text = MessagesClass.GetMessages(); 
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(dropdownlist.SelectedValue);
            string messageText = textbox.Text;
            MessagesClass.AddMessage(userID, messageText);
            literal.Text = MessagesClass.GetMessages();
            textbox.Text = "";
        }
    }
}