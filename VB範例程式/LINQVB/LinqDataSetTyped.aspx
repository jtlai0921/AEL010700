<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LinqDataSetTyped.aspx.vb" Inherits="LinqDataSetTyped" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button ID="btnRead" runat="server" Text="讀取員工基本資料（強型別DataSet）" 
        onclick="btnRead_Click" />
    <asp:GridView ID="gvEmployees" runat="server" CellPadding="4" Font-Size="10pt" 
        ForeColor="#333333" 
        Caption="&lt;div style='background-color:red'&gt;員工基本資料&lt;/div&gt;" 
        EmptyDataText="###">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    </form>
</body>
</html>
