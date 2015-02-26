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

            using (daLogin da = new daLogin())
            {
                usuarioID = da.ValidarUsuario(Login1.UserName, Encriptacion.EncriptarMD5(Login1.Password));
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
            daLogin da = new daLogin();
            //Esto lo tendria que hacer en la capa de negocios, por ahora lo dejamos aca.
            char genderChar = 'F'; //Seteo mujer por defecto
            if(gender.ToUpper() == "MALE")
            {
                genderChar = 'M';
            }

            //Genero la url de la foto de FB, esto tmb va en la capa de negocios
            string altoFoto = "400";
            string anchoFoto = "400";

            string fotoURL = "https://graph.facebook.com/"+facebookUserId+"/picture?width="+anchoFoto+"&height="+altoFoto;


            da.RegistrarUsuarioFacebook(facebookUserId, first_name, last_name, genderChar, email, fotoURL);
            //FormsAuthentication.RedirectFromLoginPage(email, false);
            FormsAuthentication.SetAuthCookie(email, false);
            
        }

        protected void btnRecuperarPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SolicitudCambioPassword.aspx");
        }
    }
}
