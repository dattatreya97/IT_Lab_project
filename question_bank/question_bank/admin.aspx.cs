using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace question_bank
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                faculty_type.Items.Add(new ListItem("Administrator", "Administrator"));
                faculty_type.Items.Add(new ListItem("Coordinator", "Coordinator"));
                faculty_type.Items.Add(new ListItem("Faculty", "Faculty"));

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
            }
        }

        protected void create_user(object sender, EventArgs e)
        {
            if(faculty_validator.IsValid && name_validator.IsValid && password_validator.IsValid && subject_validator.IsValid && branch_validator.IsValid && semester_validator.IsValid && year_validator.IsValid)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (localdb)\\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True";
                try
                {
                    con.Open();

                    int isAdmin = 0, isCordinator = 0 ;
                    if (string.Compare(faculty_type.Items[faculty_type.SelectedIndex].Value, "Administrator") == 0)
                    {
                        isAdmin = 1;
                    }else if (string.Compare(faculty_type.Items[faculty_type.SelectedIndex].Value, "Coordinator") == 0)
                    {
                        isCordinator = 1;
                    }


                    String query = "INSERT INTO users(faculty_id,name,password,isAdmin,isCoordinator,subject,branch,semester,year) VALUES(";
                    query += "@faculty_id,@name,@password,@isAdmin,@isCoordinator,@subject,@branch,@semester,@year)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@faculty_id", faculty_id.Text);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@password", password.Text);
                    cmd.Parameters.AddWithValue("@isAdmin", isAdmin);
                    cmd.Parameters.AddWithValue("@isCoordinator", isCordinator);
                    cmd.Parameters.AddWithValue("@subject", subject.Text);
                    cmd.Parameters.AddWithValue("@branch", branch.Text);
                    cmd.Parameters.AddWithValue("@semester", semester.Text);
                    cmd.Parameters.AddWithValue("@year", year.Text);
                    int rows_affected = cmd.ExecuteNonQuery();
                    if (rows_affected == 0)
                    {
                        result.Text = "Fail,Please contact developer";
                        result.ForeColor = System.Drawing.Color.FromName("Red");
                    }
                    else
                    {
                        result.Text = "Success";
                        result.ForeColor = System.Drawing.Color.FromName("Green"); 
                    }
                    result.Visible = true;
                    result.Enabled = true;
                }
                catch (Exception ex)
                {
                    result.Text = "Fail,Please contact developer";
                    result.ForeColor = System.Drawing.Color.FromName("Red");
                    result.Visible = true;
                    result.Enabled = true;
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
               //give summary
            }
        }
    }
}