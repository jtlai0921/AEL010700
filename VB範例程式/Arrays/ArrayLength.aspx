<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ArrayLength.aspx.vb" Inherits="ArrayLength" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .TextStyle
        {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>計算陣列元素的總數目</h2>
        <asp:Button ID="btnArray" runat="server" OnClick="btnArray_Click" Text="以亂數建立陣列元素"
            Width="200px" />
        <br />
        <br />
        <asp:TextBox ID="txtArray" runat="server" Height="217px" TextMode="MultiLine" Width="200px"
            CssClass="TextStyle"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="txtLength" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
