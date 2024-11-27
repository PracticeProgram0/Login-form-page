using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String s = "Select email,password,status,user_type from detail where email='"+TextBox1.Text+ "' and password='" + TextBox2.Text + "' ";
            //string s = "select user_type from DETAIL where email='" + TextBox1.Text + "',password='" + TextBox2.Text + "'";
            SqlConnection cn = new SqlConnection("Data Source=Hp;Initial Catalog=btps;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (dr["EMAIL"].ToString() == "admin@gmail.com" && dr["PASSWORD"].ToString() == "admin" && dr["user_type"].ToString() == "admin")
                {
                    Response.Redirect("admin_home.aspx");
                }
                else if (dr["status"].ToString() == "1") {

                    Response.Redirect("user_dash.aspx");
                }
                else {

                    Response.Write("you are not approved pleas try again after some time..");

                }
            }
            else
            {
                Response.Write("invailid user .......");

            }

        }
    }
}