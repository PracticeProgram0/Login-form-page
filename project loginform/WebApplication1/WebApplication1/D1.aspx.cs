using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class D1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text=Request["nm"];
            Label2.Text = Request["?pass"];

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String q = "Select*from TBL_EMP";
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1DUOJFP\\SQLEXPRESS;Initial Catalog=ADO;Integrated Security=True");
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            GridView1.DataSource= ds;
            GridView1.DataBind();



        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Button1_Click(sender, e);
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Button1_Click(sender, e);
        }

     

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            /*string  id =  GridView1.Rows[e.RowIndex].Cells[0].Text;
            TextBox nm=(TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox add = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            TextBox ct = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];

            String q = "update TBL_EMP set name'"+nm.Text+"',address'"+add.Text+"',city'"+ct.Text+"' where id'"+id+"' ";
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1DUOJFP\\SQLEXPRESS;Initial Catalog=ADO;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();

            GridView1.EditIndex = -1;
            Button1_Click(sender, e);*/


           
                // Retrieve the new values from the GridView
                string id = GridView1.Rows[e.RowIndex].Cells[0].Text;
                TextBox nm = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
                TextBox add = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
                TextBox ct = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];

                // Define the SQL query with parameters
                string q = "update TBL_EMP set name'" + nm.Text + "',address'" + add.Text + "',city'" + ct.Text + "' where id'" + id + "' ";

                // Establish the connection and execute the query
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-1DUOJFP\\SQLEXPRESS;Initial Catalog=ADO;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        // Define parameters and their values
                        cmd.Parameters.AddWithValue("@Name", nm.Text);
                        cmd.Parameters.AddWithValue("@Address", add.Text);
                        cmd.Parameters.AddWithValue("@City", ct.Text);
                        cmd.Parameters.AddWithValue("@Id", id);

                        // Open the connection, execute the command, and close the connection
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // Reset the GridView's EditIndex and rebind data
                GridView1.EditIndex = -1;
                Button1_Click(sender, e);
            


        }
    }
}