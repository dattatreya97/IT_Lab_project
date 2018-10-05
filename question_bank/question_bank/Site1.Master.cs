using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace question_bank
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void set_name(string name)
        {
            faculty_name.Text = name;
        }

        public void show_name_and_logout()
        {
            logout_button.Enabled = true;
            faculty_name.Enabled = true;
            logout_button.Visible = true;
            faculty_name.Visible = true;
        }
        public void hide_name_and_logout()
        {
            logout_button.Enabled = false;
            faculty_name.Enabled = false;
            logout_button.Visible = true;
            faculty_name.Visible = true;
        }

        protected void logout(object sender, EventArgs e)
        {
            Session["user_logged_in"] = null;
            Response.Redirect("login.aspx");
        }
    }

   
}