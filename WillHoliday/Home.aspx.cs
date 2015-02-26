using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using WillHolidayBusiness;

namespace WillHoliday
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        public void btnLogout_onclick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnCambioPassword_Click(object sender, EventArgs e)
        {
            string email;

            using (boLogin bo = new boLogin())
            {
                
            }

            Response.Redirect("~/CambioPassword.aspx?id="+this.Page.User.Identity.Name);
        }

       
    }
}
