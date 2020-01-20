<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteProducts.aspx.cs" Inherits="DeleteProducts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Delete.jpg" />
    <br />
    <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
        Text="刪除產品記錄（M0001）" />
    <br />
    <asp:GridView ID="gvProducts" runat="server" BackColor="LightGoldenrodYellow" 
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" Font-Size="10pt" 
        ForeColor="Black">
        <FooterStyle BackColor="Tan" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <br />
    <asp:Label ID="txtMsg" runat="server"></asp:Label>
    </form>
</body>
</html>
