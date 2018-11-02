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
    
    public partial class faculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user_logged_in"] != null)
                {
                    //enabling logout button
                    Site1 m = (Site1)Master;
                    m.show_name_and_logout();
                    HttpCookie user_new = Request.Cookies["user_new"];
                    m.set_name(Request.QueryString["username"].ToString() + " | " + user_new["user_type"]);
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
                marks.Items.Add(new ListItem("0.5", "0.5"));
                marks.Items.Add(new ListItem("1", "1"));
                marks.Items.Add(new ListItem("1.5", "1.5"));
                marks.Items.Add(new ListItem("2", "2"));
                marks.Items.Add(new ListItem("2.5", "2.5"));
                marks.Items.Add(new ListItem("3", "3"));
                marks.Items.Add(new ListItem("3.5", "3.5"));
                marks.Items.Add(new ListItem("4", "4"));
                marks.Items.Add(new ListItem("4.5", "4.5"));
                marks.Items.Add(new ListItem("5", "5"));
            }
        }
        protected void Page_PreInit(object sender,EventArgs e)
        {
            Page.Theme = "faculty";
        }
        protected void add_question(object sender, EventArgs e)
        {
            user faculty = (user)Session["user_logged_in"];
            if (question_validator.IsValid && marks_validator.IsValid)
            {
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (localdb)\\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True";
                try
                {
                    con.Open();

                    string isMcQ = "No";
                    if (mcq.Checked)
                    {
                        isMcQ = "Yes";
                    }
                    String query = "INSERT INTO questions(question_name,marks,mcq,faculty_id,faculty_name,subject,branch,semester,year) VALUES(";
                    query += "@question_name,@marks,@isMcq,@faculty_id,@faculty_name,@subject,@branch,@semester,@year)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@question_name", question.Text);
                    cmd.Parameters.AddWithValue("@marks", marks.Items[marks.SelectedIndex].Value.ToString());
                    cmd.Parameters.AddWithValue("@isMcq", isMcQ);
                    cmd.Parameters.AddWithValue("@faculty_id", faculty.get_faculty_id());
                    cmd.Parameters.AddWithValue("@faculty_name", faculty.get_faculty_name());                    
                    cmd.Parameters.AddWithValue("@subject", faculty.get_subject());
                    cmd.Parameters.AddWithValue("@branch", faculty.get_branch());
                    cmd.Parameters.AddWithValue("@semester", faculty.get_semester());
                    cmd.Parameters.AddWithValue("@year", faculty.get_year());
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

                    question.Text = "";
                    
                }
                catch (Exception ex)
                {
                    result.Text = ex.ToString();
                    result.ForeColor = System.Drawing.Color.FromName("Red");
                    result.Visible = true;
                    result.Enabled = true;
                }
                finally
                {
                    con.Close();
                }

                //to bind gridview after update
                //try
                //{
                //    con.Open();
                //    string q = "Select id,question_name,marks,mcq FROM questions WHERE faculty_name = '"+faculty.get_faculty_id()+"'";
                //    SqlDataAdapter ad = new SqlDataAdapter(q, con);
                //    DataTable dt = new DataTable();
                //    ad.Fill(dt);
                //    if (dt.Rows.Count > 0)
                //    {
                //        GridView1.DataSource = dt;
                //        GridView1.DataBind();
                //    }

                //}
                //catch (Exception ex)
                //{

                //}
                //finally
                //{
                //    con.Close();
                //}
                GridView1.DataSourceID = SqlDataSource1.ID;

            }                   
        }

        

        
    }
}