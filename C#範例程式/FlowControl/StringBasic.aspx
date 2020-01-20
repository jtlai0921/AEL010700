<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StringBasic.aspx.cs" Inherits="StringBasic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        請輸入字串：<asp:TextBox ID="txtInput" runat="server" Width="510px"></asp:TextBox>
        <br />
        <br />
     <asp:Button ID="btnGo" runat="server" onclick="btnGo_Click" Text="進行字串處理作業" />
        <br />
        <br />
        字串長度：<asp:Label ID="txtLength" runat="server" ForeColor="Blue"></asp:Label>
        <br />
        <br />
        部分字串：<asp:Label ID="txtSubString" runat="server" ForeColor="Blue"></asp:Label>
        <br />
        <br />
        轉換大寫：<asp:Label ID="txtToUpper" runat="server" ForeColor="Blue"></asp:Label>
        <br />
        <br />
        轉換小寫：<asp:Label ID="txtToLower" runat="server" ForeColor="Blue"></asp:Label>
        <br />
        <br />
        尋找字串：<asp:Label ID="txtIndexOf" runat="server" ForeColor="Blue"></asp:Label>
        <br />
        <br />
        清除空白：<asp:Label ID="txtTrim" runat="server" ForeColor="Blue"></asp:Label>
    
    </div>
    </form>
</body>
</html>
