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
    public partial class add_branch : System.Web.UI.Page
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

                branch_new.Items.Add(new ListItem("Aeronautical Engineering", "AU"));
                branch_new.Items.Add(new ListItem("Automobile Engineering", "AM"));
                branch_new.Items.Add(new ListItem("Biotechnology Engineering", "BT"));
                branch_new.Items.Add(new ListItem("Biomedical Engineering", "BM"));
                branch_new.Items.Add(new ListItem("Chemical Engineering", "CH"));
                branch_new.Items.Add(new ListItem("Civil Engineering", "CV"));
                branch_new.Items.Add(new ListItem("Computer Science Engineering", "CSE"));
                branch_new.Items.Add(new ListItem("Computer and Communication Engineering", "CCE"));
                branch_new.Items.Add(new ListItem("Electrical Engineering", "EEE"));
                branch_new.Items.Add(new ListItem("Electronics Engineering", "EC"));
                branch_new.Items.Add(new ListItem("Mechatronics", "MT"));
                branch_new.Items.Add(new ListItem("Mechanical Engineering", "ME"));
                branch_new.Items.Add(new ListItem("Information Technology", "IT"));
                branch_new.Items.Add(new ListItem("Instrumentation and Control", "ICE"));
                branch_new.Items.Add(new ListItem("Industrial Production", "IP"));
                branch_new.Items.Add(new ListItem("Print and Media Engineering", "PM"));
               
            }
        }

        protected void add_subject(object sender, EventArgs e)
        {
            //check in database, if not present add, else ignore
            if (subject_vld.IsValid)
            {
                string branch_selected = branch.Items[branch.SelectedIndex].Value;
                string subject_selected = subject.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (localdb)\\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True";
                try
                {
                    con.Open();

                    string query = "SELECT * FROM subjects WHERE branch = '" + branch_selected + "' AND subjects='"+subject_selected+"'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader x = cmd.ExecuteReader();
                    x.Read();
                    bool c = x.HasRows;
                    x.Close();
                    if (c)
                    {
                        //say success
                        result.Text = "Already Exists!";
                        result.ForeColor = System.Drawing.Color.FromName("Green");
                    }
                    else
                    {
                        string query2 = "INSERT into subjects(branch,subjects) VALUES (@branch,@subject)";
                        SqlCommand cmd2 = new SqlCommand(query2, con);
                        cmd2.Parameters.AddWithValue("@branch", branch_selected);
                        cmd2.Parameters.AddWithValue("@subject", subject_selected);
                        int rows_affected = cmd2.ExecuteNonQuery();
                        if (rows_affected!=0)
                        {
                            //success
                            result.Text = "Success";
                            result.ForeColor = System.Drawing.Color.FromName("Green");
                        }
                        else
                        {
                            //failure
                            result.Text = "Fail 1,Please contact developer";
                            result.ForeColor = System.Drawing.Color.FromName("Red");
                        }
                    }

                    
                    result.Visible = true;
                    result.Enabled = true;
                }
                catch (Exception ex)
                {
                    result.Text = ex.Message;
                    result.ForeColor = System.Drawing.Color.FromName("Red");
                    result.Visible = true;
                    result.Enabled = true;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        
        protected void add_branch_name(object sender, EventArgs e)
        {
            string branch_name = branch_new.Items[branch_new.SelectedIndex].Value;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = (localdb)\\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True";
            try
            {
                con.Open();

                string query = "SELECT * FROM subjects WHERE branch = '" + branch_name +"'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader x = cmd.ExecuteReader();
                x.Read();
                bool c = x.HasRows;
                x.Close();
                if (c)
                {
                    //say success
                    result.Text = "Already Exists!";
                    result.ForeColor = System.Drawing.Color.FromName("Green");
                }
                else
                {
                    string query2 = "INSERT into subjects(branch,subjects) VALUES (@branch,@subject)";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.AddWithValue("@branch", branch_name);
                    cmd2.Parameters.AddWithValue("@subject", subject_new.Text);
                    int rows_affected = cmd2.ExecuteNonQuery();
                    if (rows_affected != 0)
                    {
                        //success
                        result.Text = "Success";
                        result.ForeColor = System.Drawing.Color.FromName("Green");
                    }
                    else
                    {
                        //failure
                        result.Text = "Fail 1,Please contact developer";
                        result.ForeColor = System.Drawing.Color.FromName("Red");
                    }
                }


                result.Visible = true;
                result.Enabled = true;
            }
            catch (Exception ex)
            {
                result.Text = ex.Message;
                result.ForeColor = System.Drawing.Color.FromName("Red");
                result.Visible = true;
                result.Enabled = true;
            }
            finally
            {
                con.Close();
                branch.DataSourceID = SqlDataSource1.ID;
            }
        }

        protected void add_user(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?username=" + Request.QueryString["username"]);
        }
    }
}