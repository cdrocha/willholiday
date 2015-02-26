using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WillHolidayBusiness
{
    public class Constantes
    {
        public static class FacebookValues
        {
            private static int FacebookFotoAlto = 400;
            private static int FacebookFotoAncho = 400;

            /// <summary>
            /// Dado el id de usuario de facebook, devuelve la url de la foto de su perfil.
            /// </summary>
            /// <param name="facebookID">ID de facebook para el usuario</param>
            /// <returns>URL con la imagen publica de perfil</returns>
            public static string GetFotoURL(string facebookID)
            {
                return "https://graph.facebook.com/" + facebookID + "/picture?width=" + FacebookFotoAncho + "&height=" + FacebookFotoAlto; ;
            }

            /// <summary>
            /// Este metodo toma la respuesta del genero de facebook y lo convierte en un char que nosotros usamos
            /// </summary>
            /// <param name="genero"></param>
            /// <returns>M=Masculino, F=Femenino, D=Desconocido</returns>
            public static char GetGenero(string genero)
            {
                if (genero == null)
                    return 'D';
                else if (genero == "male")
                    return 'M';
                else if (genero == "female")
                    return 'F';
                else return 'D';
            }
        }
    }
}
