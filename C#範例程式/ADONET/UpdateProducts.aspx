<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateProducts.aspx.cs" Inherits="UpdateProducts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Update.gif" />
        <br />
        <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
            Text="更新產品記錄" />
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
    
    </div>
    </form>
</body>
</html>
