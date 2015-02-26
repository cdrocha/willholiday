<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WillHoliday.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function signinCallback(authResult) {
            if (authResult['access_token']) {
                // Autorizado correctamente
                // Oculta el botón de inicio de sesión ahora que el usuario está autorizado, por ejemplo:
                document.getElementById('signinButton').setAttribute('style', 'display: none');
            } else if (authResult['error']) {
                // Se ha producido un error.
                // Posibles códigos de error:
                //   "access_denied": el usuario ha denegado el acceso a la aplicación.
                //   "immediate_failed": no se ha podido dar acceso al usuario de forma automática.
                // console.log('There was an error: ' + authResult['error']);
            }
        }
    </script>

</head>
<body>

    <script type="text/javascript">
        (function() {
            var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
            po.src = 'https://apis.google.com/js/client:plusone.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
        })();
    </script>

    <div>
        <div id="divFacebookLogin">
        </div>
        <div id="divGoogleLogin">
            <span id="signinButton"><span class="g-signin" data-callback="signinCallback" data-clientid="216735800749-cs9ln2u77tn8vshaitc1k84pcgi1p27r.apps.googleusercontent.com"
                data-cookiepolicy="single_host_origin" data-requestvisibleactions="http://schemas.google.com/AddActivity"
                data-scope="https://www.googleapis.com/auth/plus.login"></span></span>
        </div>
        <div id="divNuestroLogin">
            <form id="form2" runat="server">
            <asp:Login ID="Login1" runat="server" OnAuthenticate="ValidarUsuario">
            </asp:Login>
            <asp:Button ID="btnRegistracion" Text="Registracion" runat="server" 
            onclick="btnRegistracion_Click"/>
            <asp:Button ID="btnRecuperarPassword" runat="server" 
            onclick="btnRecuperarPassword_Click" Text="Recuperar password"/>
            </form>
            
        </div>
    </div>
</body>
</html>
