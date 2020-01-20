<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SqlAdapterDataTable.aspx.cs" Inherits="SqlAdapterDataTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/DataTable.jpg" />
        <br />
    
        <asp:Button ID="btnFill" runat="server" onclick="btnFill_Click" 
            Text="將資料Fill到DataTable" />
    
        <br /><br />
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
