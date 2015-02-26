using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Web.Configuration;


namespace WillHoliday
{

    public partial class Registracion : System.Web.UI.Page
    {
        private string codigoActivacion =  Guid.NewGuid().ToString();

        protected void RegistrarUsuario(object sender, EventArgs e)
        {
            int usuarioID;
            string message = string.Empty;

            using(daLogin da = new daLogin())
            {
                usuarioID = da.RegistrarUsuario(txtEmail.Text.Trim(), Encriptacion.EncriptarMD5(txtPassword.Text.Trim()));
                switch (usuarioID)
                {
                    case -2:
                        message = "El mail que ingresaste ya está en uso.";
                        break;
                    default:
                        da.GuardarActivacionPendiente(codigoActivacion, usuarioID);
                        EnviarEmailValidacion(usuarioID);
                        message = "Registración exitosa.";
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }


        }


        

        private void EnviarEmailValidacion(int usuarioID)
        {
            string mailSender = WebConfigurationManager.AppSettings["mailSender"];
            string mailSenderTexto = WebConfigurationManager.AppSettings["mailSenderTexto"];
            string passSender = WebConfigurationManager.AppSettings["passSender"];
            string mailSubjectTexto = WebConfigurationManager.AppSettings["mailSubjectTexto"];
            string mailHost = WebConfigurationManager.AppSettings["mailHost"];
            int mailPort = Int32.Parse(WebConfigurationManager.AppSettings["mailPort"]);

            
            using (MailMessage mail = new MailMessage(mailSenderTexto, txtEmail.Text.Trim()))
            {
                mail.Subject = mailSubjectTexto;
                string body = "Hola" + ",";
                body += "<br /><br />Hacé click en el siguiente link para activar tu cuenta.";
                body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Registracion.aspx", "Login_Activacion.aspx?codigoActivacion=" + codigoActivacion) + "'>Hacé click acá para activar tu cuenta.</a>";
                body += "<br /><br />Gracias";
                mail.Body = body;
                mail.IsBodyHtml = true;
                // SmtpClient cliente = new SmtpClient("s04.minplan.gob.ar", 8090); Configuracion Proxy
                SmtpClient cliente = new SmtpClient();
                cliente.Port = mailPort;
                cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                cliente.UseDefaultCredentials = true;
                NetworkCredential NetworkCred = new NetworkCredential(mailSender, passSender);
                cliente.Credentials = NetworkCred;
                cliente.Host = mailHost;
                cliente.Send(mail);

            }
        }
    }
}