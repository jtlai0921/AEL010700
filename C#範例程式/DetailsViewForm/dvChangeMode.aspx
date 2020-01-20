<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dvChangeMode.aspx.cs" Inherits="dvChangeMode" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>DetailsView模式的應用</h2>
        <asp:DetailsView ID="dvEmp" runat="server" AllowPaging="True" 
            AutoGenerateRows="False" BackColor="White" BorderColor="#E7E7FF" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="EmployeeID" 
            DataSourceID="SqlEmps" Font-Size="10pt" 
            HeaderText="&lt;div align='Center'&gt;員工基本資料&lt;/div&gt;" Height="50px" 
            Width="260px" onitemdeleting="dvEmp_ItemDeleting" 
            onpageindexchanging="dvEmp_PageIndexChanging">
            <PagerSettings FirstPageImageUrl="~/Images/First.gif" 
                LastPageImageUrl="~/Images/Last.gif" Mode="NextPreviousFirstLast" 
                NextPageImageUrl="~/Images/Next.gif" 
                PreviousPageImageUrl="~/Images/Previous.gif" />
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID">
                <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="LastName" 
                    SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Country" HeaderText="Country" 
                    SortExpression="Country" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    ShowEditButton="True" ShowInsertButton="True"></asp:CommandField>
            </Fields>
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlEmps" runat="server" 
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
            DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @EmployeeID" 
            InsertCommand="INSERT INTO [Employees] ([LastName], [FirstName], [City], [Country]) VALUES (@LastName, @FirstName, @City, @Country)" 
            SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [City], [Country] FROM [Employees]" 
            UpdateCommand="UPDATE [Employees] SET [LastName] = @LastName, [FirstName] = @FirstName, [City] = @City, [Country] = @Country WHERE [EmployeeID] = @EmployeeID">
            <DeleteParameters>
                <asp:Parameter Name="EmployeeID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="EmployeeID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    </div>
    </form>

 
</body>
</html>
