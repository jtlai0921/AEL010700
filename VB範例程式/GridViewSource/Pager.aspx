<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Pager.aspx.vb" Inherits="Pager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>GridView分頁外觀的設定</h2>
        <asp:GridView ID="gvEmployees" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" DataKeyNames="EmployeeID" DataSourceID="SqlDataSource1" EnableSortingAndPagingCallbacks="True"
            Font-Size="10pt" ForeColor="#333333" PageSize="5">
            <PagerSettings FirstPageImageUrl="~/Images/First.gif" LastPageImageUrl="~/Images/Last.gif"
                Mode="NextPreviousFirstLast" NextPageImageUrl="~/Images/Next.gif" PreviousPageImageUrl="~/Images/Previous.gif" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                <asp:CommandField ButtonType="Button" ShowEditButton="True">
                    <ControlStyle BackColor="#FFCCFF" />
                </asp:CommandField>
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False"
                    ReadOnly="True" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString1 %>"
            DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @EmployeeID" InsertCommand="INSERT INTO [Employees] ([LastName], [Title], [City]) VALUES (@LastName, @Title, @City)"
            SelectCommand="SELECT [EmployeeID], [LastName], [Title], [City] FROM [Employees]"
            UpdateCommand="UPDATE [Employees] SET [LastName] = @LastName, [Title] = @Title, [City] = @City WHERE [EmployeeID] = @EmployeeID">
            <DeleteParameters>
                <asp:Parameter Name="EmployeeID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="EmployeeID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter Name="City" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
