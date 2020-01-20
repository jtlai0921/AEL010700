<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExtractTemplateRow.aspx.cs"
    Inherits="ExtractTemplateRow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            DataList控制項的ExtractTemplateRows屬性應用</h2>
        <asp:DataList ID="dlProducts" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource1"
            CellPadding="4" ForeColor="#333333" Width="350px" Height="110px">
            <ItemTemplate>
                <asp:Table ID="Table1" runat="server" Width="100%">
                    <asp:TableRow>
                        <asp:TableHeaderCell Text='<%# String.Format("<<< {0} >>>",Eval("ProductID")) %>'
                            BackColor="#FFCCCC"></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Text='<%# "產品名稱　：" + Eval("ProductName") %>'></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Text='<%# "供應商代碼：" + Eval("SupplierID") %>'></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Text='<%# "類別代碼　：" + Eval("CategoryID") %>'></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Text='<%# "商品庫存　：" + Eval("UnitsInStock") %>'></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ItemTemplate>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <AlternatingItemStyle BackColor="White" />
            <ItemStyle BackColor="#EFF3FB" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        </asp:DataList>&nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="Data Source=.;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=test"
            DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @original_ProductID AND [ProductName] = @original_ProductName AND [SupplierID] = @original_SupplierID AND [CategoryID] = @original_CategoryID AND [UnitPrice] = @original_UnitPrice AND [UnitsInStock] = @original_UnitsInStock"
            InsertCommand="INSERT INTO [Products] ([ProductName], [SupplierID], [CategoryID], [UnitPrice], [UnitsInStock]) VALUES (@ProductName, @SupplierID, @CategoryID, @UnitPrice, @UnitsInStock)"
            OldValuesParameterFormatString="original_{0}" ProviderName="System.Data.SqlClient"
            SelectCommand="SELECT [ProductID], [ProductName], [SupplierID], [CategoryID], [UnitPrice], [UnitsInStock] FROM [Products]"
            UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [SupplierID] = @SupplierID, [CategoryID] = @CategoryID, [UnitPrice] = @UnitPrice, [UnitsInStock] = @UnitsInStock WHERE [ProductID] = @original_ProductID AND [ProductName] = @original_ProductName AND [SupplierID] = @original_SupplierID AND [CategoryID] = @original_CategoryID AND [UnitPrice] = @original_UnitPrice AND [UnitsInStock] = @original_UnitsInStock">
            <DeleteParameters>
                <asp:Parameter Name="original_ProductID" Type="Int32" />
                <asp:Parameter Name="original_ProductName" Type="String" />
                <asp:Parameter Name="original_SupplierID" Type="Int32" />
                <asp:Parameter Name="original_CategoryID" Type="Int32" />
                <asp:Parameter Name="original_UnitPrice" Type="Decimal" />
                <asp:Parameter Name="original_UnitsInStock" Type="Int16" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="SupplierID" Type="Int32" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="UnitsInStock" Type="Int16" />
                <asp:Parameter Name="original_ProductID" Type="Int32" />
                <asp:Parameter Name="original_ProductName" Type="String" />
                <asp:Parameter Name="original_SupplierID" Type="Int32" />
                <asp:Parameter Name="original_CategoryID" Type="Int32" />
                <asp:Parameter Name="original_UnitPrice" Type="Decimal" />
                <asp:Parameter Name="original_UnitsInStock" Type="Int16" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="SupplierID" Type="Int32" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="UnitsInStock" Type="Int16" />
            </InsertParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
