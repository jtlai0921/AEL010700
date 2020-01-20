<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fvBasic.aspx.cs" Inherits="fvBasic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>FormView資料項目的讀取</h2>
        <table>
            <tr>
                <td style="width: 100px">
                    <asp:FormView ID="fvEmp" runat="server" AllowPaging="True" DataKeyNames="EmployeeID"
                        DataSourceID="sqldsEmployees" Width="183px" OnDataBound="fvEmp_DataBound" Font-Size="10pt"
                        OnItemCommand="fvEmp_ItemCommand" OnItemDeleting="fvEmp_ItemDeleting" BackColor="LightGoldenrodYellow"
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" FooterText="限人事單位使用" ForeColor="Black"
                        HeaderText="員工基本資料維護" OnPageIndexChanged="fvEmp_PageIndexChanged" DataMember="DefaultView">
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
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" Text="取消"></asp:LinkButton>
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
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" Text="取消"></asp:LinkButton>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            EmployeeID:
                            <asp:Label ID="txtEmployeeID" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label><br />
                            LastName:
                            <asp:Label ID="txtLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label><br />
                            FirstName:
                            <asp:Label ID="txtFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label><br />
                            City:
                            <asp:Label ID="txtCity" runat="server" Text='<%# Bind("City") %>'></asp:Label><br />
                            Country:
                            <asp:Label ID="txtCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label><br />
                            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="編輯"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="刪除"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                                Text="新增"></asp:LinkButton>
                        </ItemTemplate>
                        <PagerSettings FirstPageImageUrl="~/Images/First.gif" LastPageImageUrl="~/Images/Last.gif"
                            NextPageImageUrl="~/Images/Next.gif" PreviousPageImageUrl="~/Images/Previous.gif"
                            Mode="NextPreviousFirstLast" />
                        <FooterStyle BackColor="Tan" HorizontalAlign="Center" />
                        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" HorizontalAlign="Center" />
                    </asp:FormView>
                    <asp:SqlDataSource ID="sqldsEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                        DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @original_EmployeeID"
                        InsertCommand="INSERT INTO [Employees] ([LastName], [FirstName], [City], [Country]) VALUES (@LastName, @FirstName, @City, @Country)"
                        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [City], [Country] FROM [Employees]"
                        UpdateCommand="UPDATE [Employees] SET [LastName] = @LastName, [FirstName] = @FirstName, [City] = @City, [Country] = @Country WHERE [EmployeeID] = @original_EmployeeID">
                        <DeleteParameters>
                            <asp:Parameter Name="original_EmployeeID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="LastName" Type="String" />
                            <asp:Parameter Name="FirstName" Type="String" />
                            <asp:Parameter Name="City" Type="String" />
                            <asp:Parameter Name="Country" Type="String" />
                            <asp:Parameter Name="original_EmployeeID" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="LastName" Type="String" />
                            <asp:Parameter Name="FirstName" Type="String" />
                            <asp:Parameter Name="City" Type="String" />
                            <asp:Parameter Name="Country" Type="String" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                </td>
                <td bordercolor="#000000" style="border-right: black thin solid; border-top: black thin solid;
                    visibility: visible; border-left: black thin solid; width: 170px; border-bottom: black thin solid"
                    valign="top">
                    <asp:Literal ID="txtMsg1" runat="server"></asp:Literal>
                </td>
                <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                    width: 170px; border-bottom: black thin solid" valign="top">
                    <asp:Literal ID="txtMsg2" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
