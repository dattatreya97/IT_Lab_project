using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace question_bank
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_login(object sender, EventArgs e)
        {
            //login check
            if(username_validator.IsValid && password_validator.IsValid)
            {

                //check all validators

                //get data from database
                //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["project"].ConnectionString);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (localdb)\\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True";
                try
                {
                    con.Open();

                    String query = "SELECT * FROM users WHERE faculty_id='"+username.Text+"' AND password = '"+password.Text+"'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        

                        //valid user,identify if admin or coordinator or normal faculty
                        int isAdmin = Int32.Parse(reader["isAdmin"].ToString());
                        int isCoordinator = Int32.Parse(reader["isCoordinator"].ToString());
                        user faculty = new user(reader["faculty_id"].ToString(), reader["name"].ToString(), reader["subject"].ToString(), isAdmin, isCoordinator, reader["branch"].ToString(), reader["semester"].ToString(), reader["year"].ToString());
                        Session["user_logged_in"] = faculty;
                        if (isAdmin == 1)
                        {
                            //go to admin.aspx;
                            Response.Redirect("admin.aspx?username="+reader["name"].ToString());
                        }
                        else if (isCoordinator == 1)
                        {
                            //go to coordinator.aspx;
                            Session["subject"] = faculty.get_subject();
                            Session["year"] = faculty.get_year();
                            Session["branch"] = faculty.get_branch();
                            Response.Redirect("coordinator.aspx?username=" + reader["name"].ToString());
                        }
                        else
                        {
                            //go to faculty.aspx;
                            Response.Redirect("faculty.aspx?username=" + reader["name"].ToString());
                        }
                    }
                    else
                    {
                        //invalid user
                        Response.Redirect("login.aspx");
                    }
                }catch(Exception ex)
                {
                    Label1.Text = ex.ToString();
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "faculty";
        }
    }
}