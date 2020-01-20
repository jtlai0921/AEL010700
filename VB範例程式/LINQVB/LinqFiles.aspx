<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LinqFiles.aspx.vb" Inherits="LinqFiles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>LINQ在System.IO檔案讀取方面的應用</h2>
    <asp:Button ID="btnRead" runat="server" onclick="btnRead_Click" 
        Text="讀取專案目錄中的檔案名稱" /><BR />

    </form>
</body>
</html>
