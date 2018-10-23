using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace question_bank
{
    public partial class paper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //session check
            if (!IsPostBack)
            {


                if (Session["user_logged_in"] != null)
                {
                    //enabling logout button
                    Site1 m = (Site1)Master;
                    m.show_name_and_logout();
                    m.set_name(Request.QueryString["username"].ToString());
                }
                else
                {
                    Response.Redirect("login.aspx");
                }

                //populate all subjects
            }
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "faculty";
        }
    }
}