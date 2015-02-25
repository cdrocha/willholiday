using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using System;

namespace WillHoliday
{
    public partial class SolicitudCambioPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendEmail(object sender, EventArgs e)
        {
            int filasAfectadas = 0;

            using (daLogin da = new daLogin())
            {
                filasAfectadas = da.ExisteEmail(txtEmail.Text.Trim());
            }


            if (filasAfectadas > 0)
            {
                string codigoActivacion = Guid.NewGuid().ToString();
                string mailSender = WebConfigurationManager.AppSettings["mailSender"];
                string mailSenderTexto = WebConfigurationManager.AppSettings["mailSenderTexto"];
                string passSender = WebConfigurationManager.AppSettings["passSender"];
                string mailResetPasswordSubjectTexto = WebConfigurationManager.AppSettings["mailResetPasswordSubjectTexto"];
                string mailHost = WebConfigurationManager.AppSettings["mailHost"];
                int mailPort = Int32.Parse(WebConfigurationManager.AppSettings["mailPort"]);

                MailMessage mm = new MailMessage(mailSenderTexto, txtEmail.Text.Trim());
                mm.Subject = mailResetPasswordSubjectTexto;

                string body = "Hola " + txtEmail.Text.Trim() + ", ";
                body += "<br /><br />Hacé click en el siguiente link para resetear tu password.";
              //  body += "<br /><a href = '" + "CambioPassword.aspx?codigoActivacion=" + codigoActivacion + "'>Reset de password.</a>";
                body += "<br /><a href = '" + Request.Url.AbsoluteUri.ToLower().Replace("solicitudcambiopassword.aspx", "cambiopassword.aspx?codigoActivacion=" + codigoActivacion) + "&id="+txtEmail.Text.Trim()+"'>Reset de password.</a>";
                body += "<br /><br />Gracias";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = mailHost;
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = mailSender;
                NetworkCred.Password = passSender;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = mailPort;
                smtp.Send(mm);
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Te enviamos un mail para resetear tu password.";
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Este mail no pertenece a ningun usuario.";
            }
        }
    }
}
