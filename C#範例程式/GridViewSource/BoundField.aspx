<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BoundField.aspx.cs" Inherits="BoundField" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>BoundField欄位</h2>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
            CellPadding="2" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" 
            EmptyDataText="沒有資料錄可顯示。" Font-Size="10pt" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="產品代號" ReadOnly="True" 
                    SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="產品名稱" 
                    SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryID" HeaderText="種類代號" 
                    SortExpression="CategoryID" />
                <asp:BoundField DataField="UnitPrice" HeaderText="單位價格" 
                    SortExpression="UnitPrice" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString1 %>" 
            DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID" 
            InsertCommand="INSERT INTO [Products] ([ProductName], [CategoryID], [UnitPrice]) VALUES (@ProductName, @CategoryID, @UnitPrice)" 
            ProviderName="<%$ ConnectionStrings:NorthwindConnectionString1.ProviderName %>" 
            SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice] FROM [Products]" 
            UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [CategoryID] = @CategoryID, [UnitPrice] = @UnitPrice WHERE [ProductID] = @ProductID">
            <DeleteParameters>
                <asp:Parameter Name="ProductID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="ProductID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
