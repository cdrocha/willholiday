﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WillHoliday.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
    Bienvenido
    <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" />
    <br />
    <br />
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
</div>  
<asp:Button ID="btnCambioPassword" runat="server" 
    onclick="btnCambioPassword_Click" Text="Cambiar password"/>
</form>
</body>
</html>
