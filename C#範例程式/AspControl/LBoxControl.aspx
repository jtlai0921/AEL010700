<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LBoxControl.aspx.cs" Inherits="LBoxControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="Images/PcOrder.jpg" 
            Height="60px" Width="700px" />
            <table width="570px"  >
            <tr>
                <td align="left" valign="top" width="250">
                    商品：</td>
                <td  valign="middle" width="70">
                    &nbsp;</td>
                <td align="left" valign="top" width="250">
                    選購清單：</td>
            </tr>
            <tr>
                <td align="left"  valign="top">

                    <asp:ListBox ID="lbxSource" runat="server" Height="200px" 
                        SelectionMode="Multiple" Width="250px" Rows="20"></asp:ListBox>
                </td>
                <td  valign="middle" width="50" align="center">
                    <asp:ImageButton ID="btnAdd" runat="server" Height="22px" 
                        ImageUrl="~/Images/Add.gif" Width="28px" onclick="btnAdd_Click" 
                        ToolTip="加入" />
                    <br />
                    <br />
                    <asp:ImageButton ID="btnAddAll" runat="server" Height="22px" 
                        ImageUrl="~/Images/AddAll.gif" Width="28px" onclick="btnAddAll_Click" 
                        ToolTip="全部加入" />
                    <br />
                    <br />
                    <asp:ImageButton ID="btnRemove" runat="server" Height="22px" 
                        ImageUrl="~/Images/Remove.gif" Width="28px" onclick="btnRemove_Click" 
                        ToolTip="移除" />
                    <br />
                    <br />
                    <asp:ImageButton ID="btnRemoveAll" runat="server" Height="22px" Width="28px" 
                        ImageUrl="~/Images/RemoveAll.gif" onclick="btnRemoveAll_Click" 
                        ToolTip="全部移除" />
                </td>
                <td align="left" valign="top" width="250">
                    <asp:ListBox ID="lbxTarget" runat="server" Height="200px" Width="250px" 
                        SelectionMode="Multiple" Rows="20"></asp:ListBox>
                </td>
            </tr>
        </table>
    
    </div>
    <br />
    <asp:Button ID="btnBuy" runat="server" Text="結帳" Width="125px" 
        onclick="btnBuy_Click" />
    <br />
    <br />
    加入結帳的項目有：<br />
    <asp:Label ID="txtMsg" runat="server"></asp:Label>
    </form>
</body>
</html>
