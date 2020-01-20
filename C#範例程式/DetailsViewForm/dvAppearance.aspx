<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dvAppearance.aspx.cs" Inherits="dvAppearance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>OverwriteChanges</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>DetailsView外觀的進階控制</h2>
        <asp:DetailsView ID="dvEmp" runat="server" Height="50px" Width="200px" 
            AllowPaging="True" AutoGenerateRows="False" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="EmployeeID" 
            DataSourceID="sqldsEmployees" Font-Size="10pt" ForeColor="Black" 
            OnModeChanging="dvEmps_ModeChanging" 
            OnDataBound="dvEmp_DataBound" FooterText="限人事單位使用" 
            HeaderText="員工基本資料維護" OnItemCommand="dvEmp_ItemCommand" 
            OnItemDeleting="dvEmp_ItemDeleting">
            <FooterStyle BackColor="Tan" HorizontalAlign="Center" />
            <EditRowStyle BackColor="DodgerBlue" ForeColor="GhostWhite" Width="50px" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False"
                    ReadOnly="True" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" ButtonType="Button" >
                    <ItemStyle Wrap="False" />
                </asp:CommandField>
            </Fields>
            <HeaderStyle BackColor="Tan" Font-Bold="True" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <InsertRowStyle Width="50px" />
            <CommandRowStyle HorizontalAlign="Left" Wrap="False" />
        </asp:DetailsView>
    
    </div>
        <asp:SqlDataSource ID="sqldsEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @original_EmployeeID AND [LastName] = @original_LastName AND [FirstName] = @original_FirstName AND [City] = @original_City AND [Country] = @original_Country" InsertCommand="INSERT INTO [Employees] ([LastName], [FirstName], [City], [Country]) VALUES (@LastName, @FirstName, @City, @Country)"
            SelectCommand="SELECT [LastName], [FirstName], [EmployeeID], [City], [Country] FROM [Employees]"
            UpdateCommand="UPDATE [Employees] SET [LastName] = @LastName, [FirstName] = @FirstName, [City] = @City, [Country] = @Country WHERE [EmployeeID] = @original_EmployeeID AND [LastName] = @original_LastName AND [FirstName] = @original_FirstName AND [City] = @original_City AND [Country] = @original_Country" ConflictDetection="CompareAllValues" OldValuesParameterFormatString="original_{0}">
            <DeleteParameters>
                <asp:Parameter Name="original_EmployeeID" Type="Int32" />
                <asp:Parameter Name="original_LastName" Type="String" />
                <asp:Parameter Name="original_FirstName" Type="String" />
                <asp:Parameter Name="original_City" Type="String" />
                <asp:Parameter Name="original_Country" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="original_EmployeeID" Type="Int32" />
                <asp:Parameter Name="original_LastName" Type="String" />
                <asp:Parameter Name="original_FirstName" Type="String" />
                <asp:Parameter Name="original_City" Type="String" />
                <asp:Parameter Name="original_Country" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:Literal ID="txtMsg" runat="server"></asp:Literal>
    </form>
</body>
</html>
