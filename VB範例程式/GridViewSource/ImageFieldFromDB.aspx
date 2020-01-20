<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ImageFieldFromDB.aspx.vb"
    Inherits="ImageFieldFromDB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>GridView動態顯示資料庫圖片</h2>
        <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataSourceID="SqlDataSource1" Font-Size="10pt" ForeColor="#333333">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False"
                    ReadOnly="True" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:TemplateField HeaderText="員工照片">
                    <ItemTemplate>
                        		<img alt="" src='ImageHandler.ashx?EmployeeID=<%# Eval("EmployeeID") %>' style='width:50px;height:50px;border:1px solid Gray' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString1 %>"
            SelectCommand="SELECT [EmployeeID], [LastName], [Photo] FROM [Employees]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
