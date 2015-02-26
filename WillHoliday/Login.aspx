<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WillHoliday.Login"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script src="Js/jquery-1.11.2.min.js" type="text/javascript"></script>

<script src="Js/login.js" type="text/javascript"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    
</head>
<body>
    <div>
        <div id="divFacebookLogin">
            <!--
              Below we include the Login Button social plugin. This button uses
              the JavaScript SDK to present a graphical Login button that triggers
              the FB.login() function when clicked.
            -->
            <fb:login-button scope="public_profile,email" onlogin="checkLoginState();" data-auto-logout-link="true"></fb:login-button>
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
