<%@ Page Language="C#" AutoEventWireup="true" CodeFile="whileStatement.aspx.cs" Inherits="whileStatement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" Height="60px" 
            ImageUrl="~/Images/while.jpg" Width="450px" />
        <br /><br />
        請選擇您的身高：&nbsp; 
        <asp:DropDownList ID="dwnHeight" runat="server" AutoPostBack="True" 
            onselectedindexchanged="dwnHeight_SelectedIndexChanged" Width="150px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
