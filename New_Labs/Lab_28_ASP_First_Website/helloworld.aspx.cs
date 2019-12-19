using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_28_ASP_First_Website
{
    public partial class helloworld : System.Web.UI.Page
    {
        public static int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            i++;
            Label1.Text = $"You clicked the button {i} times";
        }
    }
}