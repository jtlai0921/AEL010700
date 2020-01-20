<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dlistImage.aspx.vb" Inherits="dlistImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>DataList控制項讀取顯示資料庫圖片</h2>
        <asp:DataList ID="dlEmployees" runat="server" DataKeyField="EmployeeID" DataSourceID="sqldsEmployeeID"
            RepeatColumns="3" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px"
            CellPadding="2" ForeColor="Black">
            <ItemTemplate>
                EmployeeID:
                <asp:Label ID="EmployeeIDLabel" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label><br />
                LastName:
                <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>'></asp:Label><br />
                FirstName:
                <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label><br />
                City:
                <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>'></asp:Label><br />
                Country:
                <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>'></asp:Label><br />
                Photo:
                <br />
                <br />
                <table width="250" height="250" align="center" style="border-top-style: outset; border-right-style: outset;
                    border-left-style: outset; border-bottom-style: outset;">
                    <tr align="center">
                        <td style="background-image: url(Images/Flower.jpg);" align="center">
                            <img src='ImageHandler.ashx?EmployeeID=<%# Eval("EmployeeID") %>' align="center" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterStyle BackColor="Tan" />
            <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <AlternatingItemStyle BackColor="PaleGoldenrod" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
        </asp:DataList>
        <asp:SqlDataSource ID="sqldsEmployeeID" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [City], [Country], [Photo] FROM [Employees] where EmployeeID<='10'"
            EnableCaching="True"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
