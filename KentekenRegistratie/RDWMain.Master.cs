using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KentekenRegistratie
{
    public partial class RDWMain : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnUitloggen.Visible = false;
            }
        }

        protected void btnUitloggen_Click(object sender, EventArgs e)
        {
            Response.Redirect("uitloggen.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}