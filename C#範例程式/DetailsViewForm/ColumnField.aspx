<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ColumnField.aspx.cs" Inherits="ColumnField" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table>
            <tr>
                <td valign="top">
                    <asp:GridView ID="gvEmps" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataKeyNames="EmployeeID" DataSourceID="SqlEmp1" 
                        Font-Size="10pt" ForeColor="#333333" AllowPaging="True" PageSize="5">
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" 
                                InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" 
                                SortExpression="LastName" />
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                                SortExpression="FirstName" />
                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                            <asp:BoundField DataField="Country" HeaderText="Country" 
                                SortExpression="Country" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlEmp1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
                        SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [City], [Country] FROM [Employees]">
                    </asp:SqlDataSource>
                </td>
                <td valign="top">
                    <asp:DetailsView ID="dvEmps" runat="server" AutoGenerateRows="False" 
                        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                        CellPadding="2" DataKeyNames="EmployeeID" DataSourceID="SqlEmp2" 
                        ForeColor="Black" Height="50px" Width="125px" AllowPaging="True">
                        <FooterStyle BackColor="Tan" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                            HorizontalAlign="Center" />
                        <Fields>
                            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" 
                                InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" 
                                SortExpression="LastName" />
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                                SortExpression="FirstName" />
                            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                            <asp:BoundField DataField="Country" HeaderText="Country" 
                                SortExpression="Country" />
                        </Fields>
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:DetailsView>
                    <asp:SqlDataSource ID="SqlEmp2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
                        SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [City], [Country] FROM [Employees]">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
