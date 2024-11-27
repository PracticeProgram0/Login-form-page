using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Login
{
    public partial class admin_home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {    
            admin_home admin_Home = new admin_home();
            admin_Home.binddata();

            String s = "select name,status from DETAIL where status=0";
            SqlConnection con = new SqlConnection("Data Source=Hp;Initial Catalog=btps;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Response.Write(dr["NAME"].ToString() + "<br/>");
            }


        }
        public void binddata()
        {

          /*  String s = "select name,status from DETAIL where status=0";
            SqlConnection con = new SqlConnection("Data Source=Hp;Initial Catalog=btps;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Response.Write(dr["NAME"].ToString()+"<br/>");
            }*/
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String s = "update DETAIL set status=1 where status=0";
            SqlConnection con = new SqlConnection("Data Source=Hp;Initial Catalog=btps;Integrated Security=True");
            con.Open();
            SqlCommand cmd=new SqlCommand(s, con);
           int i= cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("All Data approved");
                String ss = "select name,status from DETAIL where status=0";
                SqlConnection conn = new SqlConnection("Data Source=Hp;Initial Catalog=btps;Integrated Security=True");
                conn.Open();
                SqlCommand cmdd = new SqlCommand(ss, conn);
                SqlDataReader drr = cmdd.ExecuteReader();
                while (drr.Read())
                {
                    Response.Write(drr["NAME"].ToString() + "<br/>");
                }
            }
        }
    }
}