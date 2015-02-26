using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using WillHolidayBusiness;

namespace WillHoliday
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        private string codigoActivacion = string.Empty;
        private bool olvidoAnterior = false;
        private string usuarioEmail = string.Empty;
        private string message;

        protected void Page_Load(object sender, EventArgs e)
        {
            codigoActivacion = !string.IsNullOrEmpty(Request.QueryString["codigoActivacion"]) ? Request.QueryString["codigoActivacion"] : Guid.Empty.ToString();
            olvidoAnterior = (codigoActivacion != Guid.Empty.ToString() ? true : false);
            usuarioEmail = !string.IsNullOrEmpty(Request.QueryString["id"]) ? Request.QueryString["id"] : string.Empty;

            if (!this.Page.User.Identity.IsAuthenticated && !olvidoAnterior)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            
        }


      
        private bool ValidaPassword()
        {
            if (!(txtPasswordNuevo.Text.Trim().Equals(txtConfirmacion.Text.Trim())))
            {
                message = "El password y su confirmacion deben ser iguales.";
                return false;
            }
                return true;

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int filasAfectadas = 0;

            using (boLogin bo = new boLogin())
            {

                if (ValidaPassword())
                {
                    if (olvidoAnterior)
                    {
                        filasAfectadas = bo.ResetPassword(usuarioEmail, Encriptacion.EncriptarMD5(txtPasswordNuevo.Text));
                        if (filasAfectadas > 0)
                        {
                            lblMessage.ForeColor = Color.Green;
                            message = "El password se guardó correctamente.";
                        }
                        else
                        {
                            lblMessage.ForeColor = Color.Red;
                            message = "EL password anterior no concuerda con tu usuario.";
                        }
                    }


                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

                    //if(filasAfectadas > 0)
                    //    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                }
            }

        }
    }



}
