using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace GridView
{
    public partial class gridviewcolums : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String q = "insert into gridview values('"+TextBox1.Text+"','"+TextBox2.Text+ "','"+TextBox3.Text+"','"+TextBox4.Text+"','"+TextBox5.Text+"')";
            SqlConnection con = new SqlConnection("Data Source=Hp;Initial Catalog=btps;Integrated Security=True");
            con.Open();
            SqlCommand cmd=new SqlCommand(q, con);
            int i=cmd.ExecuteNonQuery();
            if (i > 0)
             Response.Write("Inserted Data");
            else
                Response.Write("Not Inserted Data");



            String s = "Select*from gridview ";
            SqlConnection co = new SqlConnection("Data Source=Hp;Initial Catalog=btps;Integrated Security=True");
            SqlDataAdapter da=new SqlDataAdapter(s, co);
            DataSet ds=new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

           




        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}