<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs"
    Inherits="WillHoliday.ResetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server">Nueva contraseña</asp:Label>
        <asp:TextBox ID="txtPasswordNuevo" runat="server"></asp:TextBox><br />
        <asp:Label runat="server">Confirmar la nueva contraseña:</asp:Label>
        <asp:TextBox ID="txtConfirmacion" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnEnviar" Text="Enviar" runat="server" 
            onclick="btnEnviar_Click"/>
        <br />
        <asp:Label ID="lblMessage" runat="server" />
    </div>
    </form>
</body>
</html>
