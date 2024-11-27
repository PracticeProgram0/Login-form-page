using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class CRUP : System.Web.UI.Page
    {
             String con = ConfigurationManager.ConnectionStrings["sqlcn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String i = "insert into crud values('"+TextBox1.Text+"','"+TextBox2.Text+"','"+TextBox3.Text+"','"+TextBox4.Text+"')";
            //SqlConnection conn = new SqlConnection(con);
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1DUOJFP\\SQLEXPRESS;Initial Catalog=ADO;Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand(i, conn);
           int j= cmd.ExecuteNonQuery();
            if(j>0)
            {
                Response.Write("Insert Data");
            }
            else
                Response.Write(" Not Insert Data");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String s = "select*from crud where id="+TextBox5.Text;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1DUOJFP\\SQLEXPRESS;Initial Catalog=ADO;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(s, conn);
           SqlDataReader dr= cmd.ExecuteReader();
            if(dr.Read())
            {
                TextBox1.Text = dr[1].ToString();
                TextBox2.Text = dr[2].ToString();
                TextBox3.Text = dr[3].ToString();
                TextBox4.Text = dr[4].ToString();
              // TextBox5.Text = dr[5].ToString();
            }
            else
            {
                Response.Write("record not found");

                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String u = "update crud set";
            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1DUOJFP\\SQLEXPRESS;Initial Catalog=ADO;Integrated Security=True");


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String d = "delect from crud where id=" + TextBox5.Text;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1DUOJFP\\SQLEXPRESS;Initial Catalog=ADO;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(d, conn);
            int j = cmd.ExecuteNonQuery();
            if (j>0)
            {
                Response.Write("Delect Data");
            }

            else
                Response.Write("Not Delect Data");
        }
    }
}