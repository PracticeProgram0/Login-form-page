using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class D2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Server.Transfer("D1.aspx ?nm="+TextBox1.Text+"&pass="+TextBox2.Text);


            // Response.Redirect("D1.aspx");
        }
    }
}