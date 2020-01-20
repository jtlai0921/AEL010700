<%@ Page Language="C#" AutoEventWireup="true" CodeFile="A.aspx.cs" Inherits="A" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>來源網頁</h2>
        <asp:Button ID="btnOK" runat="server" OnClick="Button1_Click" Text="請點選我！" />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem>C</asp:ListItem>
        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
