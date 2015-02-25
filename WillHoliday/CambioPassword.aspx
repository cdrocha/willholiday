<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioPassword.aspx.cs"
    Inherits="WillHoliday.CambioPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ChangePassword ID="ChangePassword1" runat="server" OnChangingPassword="OnChangingPassword"
            RenderOuterTable="false" NewPasswordRegularExpression="^[\s\S]{5,}$" NewPasswordRegularExpressionErrorMessage="Password must be of minimum 5 characters."
            CancelDestinationPageUrl="~/Home.aspx">
        </asp:ChangePassword>
        <br />
        <asp:Label ID="lblMessage" runat="server" />
    </div>
    </form>
</body>
</html>
