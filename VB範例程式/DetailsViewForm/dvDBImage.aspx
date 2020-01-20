<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dvDBImage.aspx.vb" Inherits="dvDBImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>DetailsView顯示資料庫中Image圖片</h2>
        <asp:DetailsView ID="dvEmp" runat="server" AllowPaging="True" AutoGenerateRows="False"
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
            DataKeyNames="EmployeeID" DataSourceID="SqlDataSource1" ForeColor="Black" Height="50px"
            Width="268px" Font-Size="10pt">
            <Fields>
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False"
                    ReadOnly="True" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:TemplateField HeaderText="Photo">
                    <ItemTemplate>
                        <img alt="" src="ImageHandler.ashx?EmployeeID=<%# Eval("EmployeeID") %>" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        &nbsp;
                    </EditItemTemplate>
                </asp:TemplateField>
            </Fields>
            <FooterStyle BackColor="Tan" />
            <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @original_EmployeeID AND [LastName] = @original_LastName AND [FirstName] = @original_FirstName AND [City] = @original_City AND [Photo] = @original_Photo"
            EnableCaching="True" InsertCommand="INSERT INTO [Employees] ([LastName], [FirstName], [City], [Photo]) VALUES (@LastName, @FirstName, @City, @Photo)"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [City], [Photo] FROM [Employees]"
            UpdateCommand="UPDATE [Employees] SET [LastName] = @LastName, [FirstName] = @FirstName, [City] = @City, [Photo] = @Photo WHERE [EmployeeID] = @original_EmployeeID AND [LastName] = @original_LastName AND [FirstName] = @original_FirstName AND [City] = @original_City AND [Photo] = @original_Photo">
            <DeleteParameters>
                <asp:Parameter Name="original_EmployeeID" Type="Int32" />
                <asp:Parameter Name="original_LastName" Type="String" />
                <asp:Parameter Name="original_FirstName" Type="String" />
                <asp:Parameter Name="original_City" Type="String" />
                <asp:Parameter Name="original_Photo" Type="Object" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Photo" Type="Object" />
                <asp:Parameter Name="original_EmployeeID" Type="Int32" />
                <asp:Parameter Name="original_LastName" Type="String" />
                <asp:Parameter Name="original_FirstName" Type="String" />
                <asp:Parameter Name="original_City" Type="String" />
                <asp:Parameter Name="original_Photo" Type="Object" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Photo" Type="Object" />
            </InsertParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
