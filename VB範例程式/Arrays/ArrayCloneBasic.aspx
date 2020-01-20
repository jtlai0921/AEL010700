<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ArrayCloneBasic.aspx.vb"
    Inherits="ArrayCloneBasic" %>

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
            color: #0000FF;
        }
        .After
        {
            text-align: right;
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>陣列複製</h2>
        <table class="style1">
            <tr>
                <td class="style1" width="250">
                    <asp:Label ID="capSource" Text="來源陣列" runat="server" />
                    <br />
                    <asp:TextBox ID="txtSource" runat="server" Height="250px" TextMode="MultiLine" Width="200px"
                        ReadOnly="True" CssClass="Before"></asp:TextBox>
                </td>
                <td class="style1" width="250">
                    <asp:Label ID="capTarget" Text="目標陣列" runat="server" />
                    <br />
                    <asp:TextBox ID="txtTarget" runat="server" Height="250px" TextMode="MultiLine" Width="200px"
                        ReadOnly="True" CssClass="After"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnClone" Text="Clone複製來源陣列" runat="server" OnClick="btnClone_Click"
            Width="200px" />
        <br />
        <br />
        <asp:Button ID="btnCopy" runat="server" OnClick="btnCopy_Click" Style="margin-bottom: 0px"
            Text="Copy複製來源陣列" Width="200px" />
        <br />
        <br />
        <asp:Button ID="btnCopyTo" runat="server" OnClick="btnCopyTo_Click" Style="margin-bottom: 0px"
            Text="CopyTo複製來源陣列" Width="200px" />
    </div>
    </form>
</body>
</html>
