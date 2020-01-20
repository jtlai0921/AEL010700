<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DragAndDropDB.aspx.cs" Inherits="DragAndDropDB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            VS 2010對SQL Server資料庫直接拖曳</h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="EmployeeID" DataSourceID="SqlDataSource1" 
            EmptyDataText="沒有資料錄可顯示。">
            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" 
                    SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" 
                    SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="Address" HeaderText="Address" 
                    SortExpression="Address" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString1 %>" 
            DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @EmployeeID" 
            InsertCommand="INSERT INTO [Employees] ([LastName], [FirstName], [Address]) VALUES (@LastName, @FirstName, @Address)" 
            ProviderName="<%$ ConnectionStrings:NorthwindConnectionString1.ProviderName %>" 
            SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [Address] FROM [Employees]" 
            UpdateCommand="UPDATE [Employees] SET [LastName] = @LastName, [FirstName] = @FirstName, [Address] = @Address WHERE [EmployeeID] = @EmployeeID">
            <DeleteParameters>
                <asp:Parameter Name="EmployeeID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="EmployeeID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
