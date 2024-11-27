using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace changepwd
{
    public partial class changepsds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String p= Request["pass"];
            String mail = Request["em"];
            TextBox3.Text = Request["pass"];
            TextBox4.Text = Request["em"];
            if (TextBox1.Text==p)
            {
                if (TextBox2.Text==TextBox3.Text)
                {
                    String c = "Update DETAIL set password='" + TextBox2.Text+ "',status = 1 where email ="+mail;
                    SqlConnection con = new SqlConnection("Data Source=Hp;Initial Catalog=VIVEK;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(c, con);
                   int i= cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Write(" Your Password Changed ");

                    }
                    else
                    {
                        Response.Write(" Your Password  Not Changed ");
                    }
                }
                else
                {
                    Response.Write(" password not Same");
                }

            }
            else
            {
                Response.Write("Old password not match");
            }

        }
    }
}