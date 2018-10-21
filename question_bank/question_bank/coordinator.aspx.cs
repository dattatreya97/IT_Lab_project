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
                    m.set_name(Request.QueryString["username"].ToString());
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
               
            }
        }

        protected void add_questions(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    string question_name = (string)DataBinder.Eval(gvrow.DataItem, "question_name");
                    string marks = (string)DataBinder.Eval(gvrow.DataItem, "marks");
                    string mcq = (string)DataBinder.Eval(gvrow.DataItem, "mcq");
                    string faculty_id = (string)DataBinder.Eval(gvrow.DataItem, "faculty_id");
                    string faculty_name = (string)DataBinder.Eval(gvrow.DataItem, "faculty_name");
                    string subject = (string)DataBinder.Eval(gvrow.DataItem, "subject");
                    string year = (string)DataBinder.Eval(gvrow.DataItem, "year");
                    string branch = (string)DataBinder.Eval(gvrow.DataItem, "branch");
                    string semester = (string)DataBinder.Eval(gvrow.DataItem, "semester");

                    string q = "INSERT INTO questions_final(question_name,marks,mcq,faculty_id,faculty_name,added_by,subject,branch,semester,year) VALUES(";
                    q+="@question_name,@marks,@mcq,@faculty_id,@faculty_name,@added_by,@subject,@branch,@semester,@year)";
                    user x = (user)Session["user_logged_in"];
                    string added_by=x.get_faculty_name();
                    result.Text+=question_name+marks+mcq+faculty_id+faculty_name+subject+year;
                    result.Visible = true;
                      result.Enabled = true;
                    //SqlConnection con = new SqlConnection();
                    //con.ConnectionString = "Data Source = (localdb)\\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True";
                    //try
                    //{
                    //    con.Open();                
                    //    SqlCommand cmd = new SqlCommand(q, con);
                    //    cmd.Parameters.AddWithValue("@question_name", question_name ?? (object)DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@marks", marks ?? (object)DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@mcq", mcq ?? (object)DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@faculty_id", faculty_id ?? (object)DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@added_by", added_by ?? (object)DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@faculty_name", faculty_name ?? (object)DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@subject", subject ?? (object)DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@branch", branch ?? (object)DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@semester", semester ?? (object)DBNull.Value);
                    //    cmd.Parameters.AddWithValue("@year", year ?? (object)DBNull.Value);
                    //    int rows_affected = cmd.ExecuteNonQuery();
                    //    if (rows_affected == 0)
                    //    {
                    //        result.Text = "Fail,Please contact developer";
                    //        result.ForeColor = System.Drawing.Color.FromName("Red");
                    //    }
                    //    else
                    //    {
                    //        result.Text = "Success";
                    //        result.ForeColor = System.Drawing.Color.FromName("Green");
                    //    }
                    //    result.Visible = true;
                    //    result.Enabled = true;
                    //}
                    //catch (Exception ex)
                    //{
                    //    result.Text = ex.ToString();
                    //    result.ForeColor = System.Drawing.Color.FromName("Red");
                    //    result.Visible = true;
                    //    result.Enabled = true;
                    //}
                    //finally
                    //{
                    //    con.Close();
                    //} 
                }

            }
        }
    }
}