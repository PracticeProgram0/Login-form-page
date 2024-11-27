using System;

namespace WebApplication1
{
    public partial class Course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                if (CheckBox1.Checked == CheckBox2.Checked)
                {
                    Label1.Text = TextBox1.Text + " Is intrested in C# .net with ASP .net";
                }
                else
                {
                    Label1.Text = TextBox1.Text + " Is intrested in C# .net  Only";
                }
            }
            else
            {
                Label1.Text = TextBox1.Text + " Is intrested in ASP.net Only";

            }
        }
    }
}