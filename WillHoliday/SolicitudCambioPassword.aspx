<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudCambioPassword.aspx.cs"
    Inherits="WillHoliday.SolicitudCambioPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Email:
        <asp:TextBox ID="txtEmail" runat="server" Width="250" />
        <br />
        <asp:Label ID="lblMessage" runat="server" />
        <br />
        <asp:Button ID="Button1" Text="Enviar" runat="server" OnClick="SendEmail" />
    </div>
    </form>
</body>
</html>
