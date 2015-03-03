using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using WillHolidayBusiness;



namespace WillHoliday
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ValidarUsuario(object sender, EventArgs e)
        {
            int usuarioID = 0;

            using (boLogin bo = new boLogin())
            {
                usuarioID = bo.ValidarUsuario(Login1.UserName, Encriptacion.EncriptarMD5(Login1.Password));
                switch (usuarioID)
                {
                    case -1:
                        Login1.FailureText = "usuario y/o password es incorrecto.";
                        break;
                    case -2:
                        Login1.FailureText = "La cuenta no ha sido activada todavia.";
                        break;
                    default:
                        FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                        break;
                }
            }
        }

        protected void btnRegistracion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registracion.aspx");
        }

        [WebMethod]
        public static void LoginWithFacebook(string facebookUserId, string first_name, string last_name, string gender, string email)
        {

            boLogin.LoginWithFacebook(facebookUserId, first_name, last_name, gender, email);
            //FormsAuthentication.RedirectFromLoginPage(email, false);
            FormsAuthentication.SetAuthCookie(email, false);
            
        }

        protected void btnRecuperarPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SolicitudCambioPassword.aspx");
        }

        [WebMethod]
        public static void LoginWithGoogle( string email)
        {
            string token = string.Empty;
            boLogin.LoginWithGoogle(token,email);
            FormsAuthentication.SetAuthCookie(email, false);
        }
    }
}
