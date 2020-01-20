<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArraySortBasic.aspx.cs" Inherits="ArraySortBasic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .style1
        {
            height: 60px;
        }

        .Before
        {
            text-align: right;
            color: #0000FF
        }
        
        .After
        {
            text-align: right;
            color: #FF0000;
        }
    </style>
</head>
<body class="style1">
    <form id="form1" runat="server">
    <h2>基本的陣列排序</h2>
    <table class="style1">
        <tr>
            <td class="style1" width="250">
                <asp:label id="capBefore" Text="陣列排序前" runat="server"  />
                <br />
                <asp:TextBox ID="txtBefore" runat="server" Height="250px" TextMode="MultiLine" 
                    Width="200px" ReadOnly="True" CssClass="Before"></asp:TextBox>
            </td>
            <td class="style1" width="250">
                <asp:label id="capAfter" Text="陣列排序後" runat="server" />
                <br />
                <asp:TextBox ID="txtAfter" runat="server" Height="250px" TextMode="MultiLine" 
                    Width="200px" ReadOnly="True" CssClass="After"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
        <asp:Button ID="btnSort" Text="建立陣列並排序" runat="server" 
        onclick="btnSort_Click" />
    </form>
</body>
</html>
