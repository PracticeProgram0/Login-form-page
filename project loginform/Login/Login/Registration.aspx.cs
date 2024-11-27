using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Login
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static string CreateRandomPassword(int length = 4)
        {
            // Create a string of characters, numbers, and special characters that are allowed in the password
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string
            // and create an array of chars
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
                String p = CreateRandomPassword();
            String s = "insert into DETAIL( NAME,EMAIL,MOBILE,PASSWORD) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','"+ p +"')";
            SqlConnection con = new SqlConnection("Data Source=Hp;Initial Catalog=btps;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand(s, con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Label1.Text = "Succefully Ragistation";
                    con.Close();
                    Response.Redirect("submit.aspx?nm=" + TextBox1.Text + "&em=" + TextBox2.Text + "&pass=" + p);

                }
                else
                    Label1.Text = "Not  Ragistation";
           


        }
    }
}