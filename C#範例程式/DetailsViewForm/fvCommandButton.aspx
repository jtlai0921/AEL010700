<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fvCommandButton.aspx.cs"
    Inherits="fvCommandButton" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FormView ID="fvEmp" runat="server" AllowPaging="True" DataKeyNames="EmployeeID"
            DataSourceID="sqldsEmployees" OnItemDeleting="fvEmp_ItemDeleting" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
            CellPadding="2" FooterText="限人事單位使用" ForeColor="Black" GridLines="Both" 
            HeaderText="員工基本資料表" Width="184px" Font-Size="10pt">
            <EditItemTemplate>
                EmployeeID:
                <asp:Label ID="EmployeeIDLabel1" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label><br />
                LastName:
                <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox><br />
                FirstName:
                <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox><br />
                City:
                <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>'></asp:TextBox><br />
                Country:
                <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>'></asp:TextBox><br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="更新"></asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="取消"></asp:LinkButton>
            </EditItemTemplate>
            <InsertItemTemplate>
                LastName:
                <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox><br />
                FirstName:
                <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox><br />
                City:
                <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>'></asp:TextBox><br />
                Country:
                <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>'></asp:TextBox><br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="插入"></asp:LinkButton>
                <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="取消"></asp:LinkButton>
            </InsertItemTemplate>
            <ItemTemplate>
                <br />
                <table style="width: 400px">
                    <tr>
                        <td style="width: 350px">
                EmployeeID:
                <asp:Label ID="EmployeeIDLabel" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label><br />
                LastName:
                <asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>'></asp:Label><br />
                FirstName:
                <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label><br />
                City:
                <asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>'></asp:Label><br />
                Country:
                <asp:Label ID="CountryLabel" runat="server" Text='<%# Bind("Country") %>'></asp:Label><br />
                &nbsp;<asp:ImageButton ID="btnInsert" runat="server" AlternateText="新增" CommandName="New"
                    ImageUrl="~/Images/New.png" OnClick="btnInsert_Click" />
                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClick="btnDelete_Click">刪除</asp:LinkButton>&nbsp;
                <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="編輯" OnClick="btnEdit_Click" /></td>
                        <td style="width: 100px">
                <img src='ImageHandler.ashx?EmployeeID=<%# Eval("EmployeeID") %>' /></td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterStyle BackColor="LightSkyBlue" HorizontalAlign="Center" />
            <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <HeaderStyle BackColor="HotPink" Font-Bold="True" HorizontalAlign="Center" />
        </asp:FormView>
    
    </div>
        <asp:SqlDataSource ID="sqldsEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [City], [Country] FROM [Employees]">
        </asp:SqlDataSource>
    </form>
</body>
</html>
