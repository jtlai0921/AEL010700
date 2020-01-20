<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dvStyle.aspx.vb" Inherits="dvStyle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            Style樣式調整變化之比較</h2>
        <table>
            <tr>
                <td style="width: 100px; height: 20px" valign="top">
                    <asp:DetailsView ID="dviewEmployee1" runat="server" AllowPaging="True" AutoGenerateRows="False"
                        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                        DataKeyNames="EmployeeID" DataSourceID="SqlDataSource1" ForeColor="Black" Height="50px"
                        Width="200px" Font-Size="10pt">
                        <FooterStyle BackColor="DeepSkyBlue" HorizontalAlign="Center" />
                        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <Fields>
                            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False"
                                ReadOnly="True" SortExpression="EmployeeID" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                        </Fields>
                        <FieldHeaderStyle ForeColor="Black" />
                        <HeaderStyle BackColor="Red" Font-Bold="True" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:DetailsView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues"
                        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @original_EmployeeID AND [LastName] = @original_LastName AND [FirstName] = @original_FirstName AND [City] = @original_City AND [Country] = @original_Country"
                        InsertCommand="INSERT INTO [Employees] ([LastName], [FirstName], [City], [Country]) VALUES (@LastName, @FirstName, @City, @Country)"
                        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [City], [Country] FROM [Employees]"
                        UpdateCommand="UPDATE [Employees] SET [LastName] = @LastName, [FirstName] = @FirstName, [City] = @City, [Country] = @Country WHERE [EmployeeID] = @original_EmployeeID AND [LastName] = @original_LastName AND [FirstName] = @original_FirstName AND [City] = @original_City AND [Country] = @original_Country">
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
                </td>
                <td style="width: 100px; height: 20px">
                    <div>
                        <asp:DetailsView ID="dviewEmployee2" runat="server" AllowPaging="True" AutoGenerateRows="False"
                            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                            DataKeyNames="EmployeeID" DataSourceID="SqlDataSource1" ForeColor="Black" Height="50px"
                            Width="200px" Font-Size="10pt" FooterText="限人事單位使用" HeaderText="員工基本資料維護">
                            <FooterStyle BackColor="DeepSkyBlue" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <Fields>
                                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False"
                                    ReadOnly="True" SortExpression="EmployeeID" />
                                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                            </Fields>
                            <HeaderStyle BackColor="Red" Font-Bold="True" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            <FieldHeaderStyle ForeColor="Blue" />
                        </asp:DetailsView>
                    </div>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
                        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @original_EmployeeID AND [LastName] = @original_LastName AND [FirstName] = @original_FirstName AND [City] = @original_City AND [Country] = @original_Country"
                        InsertCommand="INSERT INTO [Employees] ([LastName], [FirstName], [City], [Country]) VALUES (@LastName, @FirstName, @City, @Country)"
                        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [City], [Country] FROM [Employees]"
                        UpdateCommand="UPDATE [Employees] SET [LastName] = @LastName, [FirstName] = @FirstName, [City] = @City, [Country] = @Country WHERE [EmployeeID] = @original_EmployeeID AND [LastName] = @original_LastName AND [FirstName] = @original_FirstName AND [City] = @original_City AND [Country] = @original_Country">
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
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
