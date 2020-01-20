<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HyperLinkField.aspx.cs" Inherits="HyperLinkField" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>HyperLinkField超連結欄位的應用</h2>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" Font-Size="10pt" 
            ForeColor="#333333">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                    SortExpression="ProductName" />
                <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" 
                    SortExpression="SupplierID" />
                <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" 
                    SortExpression="CategoryID" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
                    SortExpression="UnitPrice" />
                <asp:HyperLinkField DataNavigateUrlFields="ProductName,CategoryID,SupplierID" 
                    DataNavigateUrlFormatString="ProductDetails.aspx?ProductName={0}&amp;CategoryID={1}&amp;SupplierID={2}" 
                    DataTextField="ProductName" DataTextFormatString="察看{0}的明細" HeaderText="產品明細" 
                    Text="詳細資料" />
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
            SelectCommand="SELECT [ProductName], [SupplierID], [CategoryID], [UnitPrice] FROM [Products]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
