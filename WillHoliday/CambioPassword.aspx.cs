using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using WillHolidayDB;

namespace WillHoliday
{
    public partial class CambioPassword : System.Web.UI.Page
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


        protected void OnChangingPassword(object sender, LoginCancelEventArgs e)
        {
            int filasAfectadas = 0;

            using (daLogin da = new daLogin())
            {
                if (olvidoAnterior)
                {
                    //Falta obtener el email
                    filasAfectadas = da.ResetPassword(usuarioEmail, ChangePassword1.NewPassword);
                    if (filasAfectadas > 0)
                    {
                        lblMessage.ForeColor = Color.Green;
                        message = "El password se guardó correctamente.";
                    }
                }
                else
                {
                    if (!ChangePassword1.CurrentPassword.Equals(ChangePassword1.NewPassword, StringComparison.CurrentCultureIgnoreCase))
                    {
                        filasAfectadas = da.CambioPassword(usuarioEmail, ChangePassword1.CurrentPassword, ChangePassword1.NewPassword);
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
                    else
                    {
                        lblMessage.ForeColor = Color.Red;
                        message = "El password anterior y el nuevo no deben ser iguales.";
                    }
                }

                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

                //if(filasAfectadas > 0)
                //    Response.Redirect("~/Login.aspx");
            }

            e.Cancel = true;
        }
    }



}
