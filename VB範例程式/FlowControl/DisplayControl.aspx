<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DisplayControl.aspx.vb" Inherits="DisplayControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>以VB常值控制顯示</h2>
        <asp:Button ID="btnDisplay" runat="server" Text="顯示文字" />
        <br />
        <br />
        <asp:TextBox ID="txtMsg" runat="server" Height="132px" TextMode="MultiLine" 
            Width="618px"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
