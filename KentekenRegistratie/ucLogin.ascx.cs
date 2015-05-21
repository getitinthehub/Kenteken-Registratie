using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KentekenRegistratie
{
    public partial class ucLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtGebruikersnaam.Text == "" || txtWachtwoord.Text == "")
            {
                return;
            }

            // illustratie van check
            if(txtGebruikersnaam.Text.Contains('<') || txtGebruikersnaam.Text.Contains('>'))
            {
                return;
            }

            string gebruikersNaam = txtGebruikersnaam.Text;
            string pw = txtWachtwoord.Text;
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["rdwDBConnectionString"].ConnectionString);
            SqlCommand sqlComm = new SqlCommand("spLogin", sqlConn);

            sqlComm.Parameters.Add(new SqlParameter("@loginName", System.Data.SqlDbType.VarChar, 25, "EMAIL") { Value = txtGebruikersnaam.Text });
            sqlComm.Parameters.Add(new SqlParameter("@password", System.Data.SqlDbType.VarChar, 1000, "PASSWORD") { Value = txtWachtwoord.Text });

            sqlComm.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                sqlConn.Open();
                SqlDataReader sqlReader = sqlComm.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    Session.Add("loggedIn", 1);
                    Response.Redirect("home.aspx", true);
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
}