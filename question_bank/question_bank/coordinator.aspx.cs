using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace question_bank
{
    public partial class coordinator : System.Web.UI.Page
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
               
            }
        }
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            Page.Theme = "faculty";
        }
        protected void add_questions(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                var checkbox = (CheckBox)gvrow.FindControl("CheckBox1");
                if (checkbox.Checked)
                {
                    
                    string question_name = gvrow.Cells[1].Text;
                    string marks = gvrow.Cells[2].Text;
                    string mcq = gvrow.Cells[3].Text;
                    //string faculty_id = gvrow.Cells[4].Text;
                    string faculty_name = gvrow.Cells[5].Text;
                    string subject = gvrow.Cells[6].Text;
                    string year = gvrow.Cells[9].Text;
                    string branch = gvrow.Cells[7].Text;
                    string semester = gvrow.Cells[8].Text;

                    //result.Text+="<br/>"+ question_name + " " + marks + " " + mcq + " " + faculty_id + " "+ faculty_name + " " + subject + " " + branch + " " + semester+" "+year;
                    //result.Visible = true;
                    //result.Enabled = true;


                    string q = "INSERT INTO questions_final(question_name,marks,mcq,faculty_name,added_by,subject,branch,semester,year) VALUES(";
                    q += "@question_name,@marks,@mcq,@faculty_name,@added_by,@subject,@branch,@semester,@year)";
                    user x = (user)Session["user_logged_in"];
                    string added_by = x.get_faculty_name();
                    //result.Text+=question_name+marks+mcq+faculty_id+faculty_name+subject+year;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source = (localdb)\\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True";
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(q, con);
                        cmd.Parameters.AddWithValue("@question_name", question_name);
                        cmd.Parameters.AddWithValue("@marks", marks);
                        cmd.Parameters.AddWithValue("@mcq", mcq);
                        cmd.Parameters.AddWithValue("@added_by", added_by);
                        cmd.Parameters.AddWithValue("@faculty_name", faculty_name);
                        cmd.Parameters.AddWithValue("@subject", subject);
                        cmd.Parameters.AddWithValue("@branch", branch);
                        cmd.Parameters.AddWithValue("@semester", semester);
                        cmd.Parameters.AddWithValue("@year", year);
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
                        result.Text = ex.ToString();
                        result.ForeColor = System.Drawing.Color.FromName("Red");
                        result.Visible = true;
                        result.Enabled = true;
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                checkbox.Checked = false;
            }

            GridView2.DataSourceID = SqlDataSource2.ID;
        }

        
    }
}