using WillHolidayDB;
namespace WillHolidayBusiness
{
    /// <summary>
    /// Metodos para loguarse y crear el usuario en la aplicación
    /// Principalmente actua contra la tabla Usuario, aunque en algunos casos agrega datos también en la tabla Perfil
    /// </summary>
    public class boLogin
    {
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
    }
}