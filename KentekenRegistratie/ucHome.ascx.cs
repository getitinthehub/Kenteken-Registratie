using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHandler;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KentekenRegistratie
{
    public partial class ucHome : System.Web.UI.UserControl
    {
        private static Gebruiker gebruiker;
        protected void Page_Load(object sender, EventArgs e)
        {
            if((int)Session["loggedin"] != 1)
            {
                Response.Redirect("rdwlogin.aspx");
            }
            if (!IsPostBack)
            {
            }
            if(gebruiker == null)
            {
                SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["rdwDBConnectionString"].ConnectionString);
                SqlCommand sqlComm = new SqlCommand("spGetUser", sqlConn);

                sqlComm.Parameters.Add(new SqlParameter("@BSN", System.Data.SqlDbType.Int, 25, "BSN") { Value = (int)Session["gebruikersID"] });

                sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    sqlConn.Open();
                    SqlDataReader sqlReader = sqlComm.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        // Retrieve info from the sqsl reader and insert it into a class instance
                        // load logged in users name into page top right



                    }
                }
                catch (Exception ex)
                {
                    // REPORT ERROR

                }
                finally
                {
                    sqlConn.Close();
                }

            }
        }

        protected void btnRechtspersoonRegistreren_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}