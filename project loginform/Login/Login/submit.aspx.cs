using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Login
{
    public partial class submit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            Label1.Text = "Thanku for Registration  " + Request["nm"];

            TextBox1.Text = Request["em"];
            TextBox2.Text = Request["pass"];

        }

    }
}