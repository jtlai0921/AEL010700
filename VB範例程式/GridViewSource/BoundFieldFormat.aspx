<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BoundFieldFormat.aspx.vb"
    Inherits="BoundFieldFormat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>BoundField欄位的DataFormatString字串格式化的應用</h2>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="ProductID" DataSourceID="SqlDataSource1" Font-Size="10pt" ForeColor="#333333">
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="ProductID" DataFormatString="{0:000#}" HeaderText="ProductID"
                    HtmlEncode="False" InsertVisible="False" ReadOnly="True" SortExpression="ProductID">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="CategoryID" DataFormatString="{0:00#}" HeaderText="CategoryID"
                    HtmlEncode="False" SortExpression="CategoryID">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:C2}" HeaderText="UnitPrice"
                    HtmlEncode="False" SortExpression="UnitPrice">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="UnitsInStock" DataFormatString="{0:00##}" HeaderText="UnitsInStock"
                    HtmlEncode="False" SortExpression="UnitsInStock">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString1 %>"
            SelectCommand="SELECT Top 10 [ProductID], [ProductName], [CategoryID], [UnitPrice],[UnitsInStock] FROM [Products]">
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
