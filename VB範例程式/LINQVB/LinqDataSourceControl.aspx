<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LinqDataSourceControl.aspx.vb" Inherits="LinqDataSourceControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="gvEmployees" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" Caption="員工基本資料" 
        CellPadding="4" DataKeyNames="EmployeeID" DataSourceID="LinqDataSource1" 
        Font-Size="10pt" ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="EmployeeID" HeaderText="員工編號" InsertVisible="False" 
                ReadOnly="True" SortExpression="EmployeeID" />
            <asp:BoundField DataField="LastName" HeaderText="名字" 
                SortExpression="LastName" />
            <asp:BoundField DataField="FirstName" HeaderText="姓" 
                SortExpression="FirstName" />
            <asp:BoundField DataField="City" HeaderText="城市" SortExpression="City" />
            <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
            <asp:BoundField DataField="ReportsTo" HeaderText="ReportsTo" 
                SortExpression="ReportsTo" />
        </Columns>
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="NorthwindDataContext" EnableDelete="True" EnableInsert="True" 
        EnableUpdate="True" TableName="Employees">
    </asp:LinqDataSource>
    </form>
</body>
</html>
