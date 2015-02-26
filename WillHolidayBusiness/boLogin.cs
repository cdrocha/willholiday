using WillHolidayDB;
using System;
namespace WillHolidayBusiness
{
    /// <summary>
    /// Metodos para loguarse y crear el usuario en la aplicación
    /// Principalmente actua contra la tabla Usuario, aunque en algunos casos agrega datos también en la tabla Perfil
    /// </summary>
    public class boLogin:IDisposable
    {


        #region IDisposable Members

        private bool disposed = false;

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //Liberar recursos manejados
                }
                //liberar recursos no manejados
            }
            disposed = true;
        }

        ~boLogin()
        {
            Dispose(false);
        }

        #endregion

        /// <summary>
        /// Loguarse o crear usuario utilizando una cuenta de Facebook.
        /// En caso de crear un usuario, guarda datos en las tablas Usuario y Perfil
        /// </summary>
        /// <param name="facebookUserId"></param>
        /// <param name="first_name"></param>
        /// <param name="last_name"></param>
        /// <param name="gender"></param>
        /// <param name="email"></param>
        /// <returns>UsuarioID</returns>
        public static int LoginWithFacebook(string facebookUserId, string first_name, string last_name, string gender, string email)
        {
            daLogin da = new daLogin();

            string fotoURL = Constantes.FacebookValues.GetFotoURL(facebookUserId);
            return da.RegistrarUsuarioFacebook(facebookUserId, first_name, last_name, Constantes.FacebookValues.GetGenero(gender), email, fotoURL);
        }


        /// <summary>
        /// Actualiza el password del usuario.
        /// </summary>
        /// <param name="usuarioEmail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int ResetPassword(string usuarioEmail, string password)
        {
            daLogin da = new daLogin();

            return da.ResetPassword(usuarioEmail, password);
        }

        /// <summary>
        /// Verifica la veracidad del usuario y en caso afirmativo, actualiza el password.
        /// </summary>
        /// <param name="usuarioEmail"></param>
        /// <param name="passwordActual"></param>
        /// <param name="passwordNuevo"></param>
        /// <returns></returns>
        public int CambioPassword(string usuarioEmail, string passwordActual, string passwordNuevo)
        {
            daLogin da = new daLogin();

            return da.CambioPassword(usuarioEmail, passwordActual,passwordNuevo);
        }

        public int ValidarUsuario(string usuarioEmail, string password)
        {
            daLogin da = new daLogin();

            return da.ValidarUsuario(usuarioEmail, password);
        }
    }
}