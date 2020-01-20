<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adoTransaction.aspx.cs" Inherits="sqldsTransaction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 300px; height: 221px">
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="txtFirstNameCap" runat="server" Text="姓氏："></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="txtLastNameCap" runat="server" Text="名字："></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="txtCityCap" runat="server" Text="縣市："></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="txtAddressCap" runat="server" Text="住址："></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="新增員工資料" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="txtMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
