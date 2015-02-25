using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WillHoliday
{
    public partial class Login_Activacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                using (daLogin da = new daLogin())
                {
                    int filasAfectadas = 0;
                    string codigoActivacion = !string.IsNullOrEmpty(Request.QueryString["codigoActivacion"]) ? Request.QueryString["codigoActivacion"] : Guid.Empty.ToString();
                    filasAfectadas = da.EliminarActivacionPendiente(codigoActivacion);

                    if (filasAfectadas == 1)
                    {
                        ltMessage.Text = "Tu cuenta ya esta activada.";
                    }
                    else
                    {
                        ltMessage.Text = "Codigo de activacion invalido.";
                    }
                }
          
            }
        }
    }
}
