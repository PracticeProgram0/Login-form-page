using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace changepwd
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String s = "Select email,password,status from detail where email='" + TextBox1.Text + "' and password='" + TextBox2.Text + "' ";
            //string s = "select user_type from DETAIL where email='" + TextBox1.Text + "',password='" + TextBox2.Text + "'";
            SqlConnection con = new SqlConnection("Data Source=Hp;Initial Catalog=VIVEK;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (dr["EMAIL"].ToString() == TextBox1.Text && dr["PASSWORD"].ToString() == TextBox2.Text && dr["status"].ToString() == "1")
                {
                    Response.Redirect("user_dash.aspx" );
                }
                else if (dr["status"].ToString() == "0")
                {
                    Response.Redirect("changepsds.aspx?pass=" + TextBox2.Text+"&em="+TextBox1.Text);
                }
                else
                {
                    Response.Write("not a user .......");

                }
                               
            }
            else
            {
                Response.Write("invailid user .......");

            }

        }
    }
}