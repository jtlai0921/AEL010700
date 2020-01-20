<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forArray.aspx.cs" Inherits="forArray" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnAdd" runat="server" Text="加入陣列元素" onclick="btnAdd_Click" />
        &nbsp; 
        <br />
        <br />
        模特兒名字：<asp:DropDownList ID="dwnModels" runat="server" Width="200px">
        </asp:DropDownList>
    
    </div>
    </form>
</body>
</html>
